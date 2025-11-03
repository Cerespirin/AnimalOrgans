using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using Verse;

namespace Cerespirin.AnimalOrgans
{
	[HarmonyPatch(typeof(MedicalRecipesUtility), nameof(MedicalRecipesUtility.IsCleanAndDroppable))]
	public static class HarmonyPatch_MedicalRecipesUtility_IsCleanAndDroppable
	{
		// Transpile to remove the check "!pawn.RaceProps.Animal"
		public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
		{
			List<CodeInstruction> blockInstructions = new List<CodeInstruction>();
			bool discard = false;
			bool didTheThing = false;

			MethodInfo targetMethod = typeof(RaceProperties).GetProperty(nameof(RaceProperties.Animal)).GetGetMethod();

			foreach (CodeInstruction instruction in instructions)
			{
				blockInstructions.Add(instruction);

				if (instruction.opcode == OpCodes.Callvirt && (MethodInfo)instruction.operand == targetMethod)
				{
					discard = true;
				}
				else if (instruction.opcode == OpCodes.Ret)
				{
					foreach (CodeInstruction blockInstruction in blockInstructions)
					{
						if (discard)
						{
							blockInstruction.opcode = OpCodes.Nop;
							blockInstruction.operand = null;
						}
						yield return blockInstruction;
					}
					if (discard)
					{
						didTheThing = true;
						discard = false;
					}
					blockInstructions.Clear();
				}
			}
			if (!didTheThing)
			{
				Log.Error("[AnimalOrgans] HarmonyPatch_MedicalRecipesUtility_IsCleanAndDroppable: unable to find injection point. This was likely due to a mod incompatibility; please report this to the mod author.");
			}
			yield break;
		}
	}
}

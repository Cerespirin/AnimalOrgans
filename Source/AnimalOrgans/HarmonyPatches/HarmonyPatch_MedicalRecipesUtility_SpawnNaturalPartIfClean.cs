using HarmonyLib;
using RimWorld;
using Verse;

namespace Cerespirin.AnimalOrgans
{
	[HarmonyPatch(typeof(MedicalRecipesUtility), nameof(MedicalRecipesUtility.SpawnNaturalPartIfClean))]
	public static class HarmonyPatch_MedicalRecipesUtility_SpawnNaturalPartIfClean
	{
		public static void Postfix(Thing __result, Pawn pawn)
		{
			if (__result.TryGetComp(out CompOrganOrigin organOrigin))
			{
				organOrigin.originDef = pawn.def;
			}
		}
	}
}

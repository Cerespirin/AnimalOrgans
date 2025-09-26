using HarmonyLib;
using RimWorld;
using Verse;

namespace Cerespirin.AnimalOrgans
{
	[HarmonyPatch(typeof(Bill), nameof(Bill.IsFixedOrAllowedIngredient), typeof(Thing))]
	public static class HarmonyPatch_Bill_IsFixedOrAllowedIngredient_Thing
	{
		public static bool Postfix(bool __result, Bill __instance, Thing thing)
		{
			if (!__result) return false;

			if (thing.TryGetComp(out CompOrganOrigin organOrgin) && (__instance.billStack.billGiver is Pawn patient) && (__instance.recipe.Worker is Recipe_InstallNaturalBodyPart))
			{
				return organOrgin.originDef == patient.def;
			}
			return __result;
		}
	}
}

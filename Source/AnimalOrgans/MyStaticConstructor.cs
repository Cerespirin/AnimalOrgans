using HarmonyLib;
using RimWorld;
using Verse;

namespace Cerespirin.AnimalOrgans
{
	[StaticConstructorOnStartup]
	public static class MyStaticConstructor
	{
		static MyStaticConstructor()
		{
			Harmony harmony = new Harmony("rimworld.cerespirin.animalorgans");
			harmony.PatchAll();

			foreach (ThingDef thingDef in DefDatabase<ThingDef>.AllDefsListForReading)
			{
				if ((thingDef.description?.Contains(ThingDefOf.Human.label) ?? false) && (thingDef.thingCategories?.Contains(MyDefOf.BodyPartsNatural) ?? false))
				{
					// Remove all instances of "human" in the def's label, then replace unwanted double spaces this might have caused.
					thingDef.description = thingDef.description.Replace(ThingDefOf.Human.label, null).Replace("  ", " ");
				}
			}
		}
	}
}

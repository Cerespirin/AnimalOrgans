using HarmonyLib;
using RimWorld;
using System.Text;
using Verse;

namespace Cerespirin.AnimalOrgans
{
	[StaticConstructorOnStartup]
	public static class MyStaticConstructor
	{
		static MyStaticConstructor()
		{
			// Execute our Harmony patches.
			Harmony harmony = new Harmony("rimworld.cerespirin.animalorgans");
			harmony.PatchAll();

			StringBuilder stringBuilder = new StringBuilder("[AnimalOrgans] Dynamic patched the following defs: ");
			bool first = true;

			// Search all ThingDefs in the DefDatabase.
			foreach (ThingDef thingDef in DefDatabase<ThingDef>.AllDefsListForReading)
			{
				if ((thingDef.description?.Contains(ThingDefOf.Human.label) ?? false) && (thingDef.thingCategories?.Contains(MyDefOf.BodyPartsNatural) ?? false))
				{
					// Remove all instances of "human" in the def's label, then replace unwanted double spaces this might have caused.
					thingDef.description = thingDef.description.Replace(ThingDefOf.Human.label, null).Replace("  ", " ");

					if (first)
					{
						stringBuilder.Append(thingDef.defName);
						first = false;
					}
					else
					{
						stringBuilder.AppendWithComma(thingDef.defName);
					}
				}
			}
			// Report on patched defs.
			Log.Message(stringBuilder.ToString());
		}
	}
}

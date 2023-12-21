using RimWorld;
using Verse;

namespace Cerespirin.AnimalOrgans
{
	[DefOf]
	public static class MyDefOf
	{
		static MyDefOf() => DefOfHelper.EnsureInitializedInCtor(typeof(MyDefOf));

		public static ThingCategoryDef BodyPartsNatural;
	}
}
using RimWorld;
using Verse;

#pragma warning disable IDE1006 // Naming Styles

namespace Cerespirin.AnimalOrgans
{
	[DefOf]
	public static class MyDefOf
	{
		static MyDefOf() => DefOfHelper.EnsureInitializedInCtor(typeof(MyDefOf));

		public static ThingCategoryDef BodyPartsNatural;
	}
}
using Verse;

namespace Cerespirin.AnimalOrgans
{
	public class SpecialThingFilterWorker_OrgansAnimal : SpecialThingFilterWorker
	{
		public override bool Matches(Thing t)
		{
			return t.TryGetComp<CompOrganOrigin>()?.originDef.race.Animal ?? false;
		}
	}
}

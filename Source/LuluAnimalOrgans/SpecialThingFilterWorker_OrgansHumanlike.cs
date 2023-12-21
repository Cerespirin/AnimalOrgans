using Verse;

namespace Cerespirin.AnimalOrgans
{
	public class SpecialThingFilterWorker_OrgansHumanlike : SpecialThingFilterWorker
	{
		public override bool Matches(Thing t)
		{
			return t.TryGetComp<CompOrganOrigin>()?.originDef.race.Humanlike ?? false;
		}
	}
}

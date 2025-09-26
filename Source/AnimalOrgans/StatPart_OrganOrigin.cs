using RimWorld;
using Verse;

namespace Cerespirin.AnimalOrgans
{
	public class StatPart_OrganOrigin : StatPart
	{
		private const string StatsReport_OrganOrigin = "AnimalOrgans_StatsReport_OrganOrigin";

		public override void TransformValue(StatRequest req, ref float val)
		{
			// Only apply our factor if it makes sense to do so.
			if (MyTryGetFactor(req, out float factor))
			{
				val *= factor;
			}
		}

		public override string ExplanationPart(StatRequest req)
		{
			if (MyTryGetFactor(req, out float factor))
			{
				// "Multiplier for {0} organ"
				return StatsReport_OrganOrigin.Translate(req.Thing.TryGetComp<CompOrganOrigin>().originDef.label) + ": x" + factor.ToStringPercent();
			}
			return null;
		}

		private bool MyTryGetFactor(StatRequest req, out float factor)
		{
			CompOrganOrigin organOrgin = req.Thing?.TryGetComp<CompOrganOrigin>();

			if (organOrgin != null)
			{
				// Normalize against human market value (most animals are worth less than humans).
				factor = organOrgin.originDef.BaseMarketValue / ThingDefOf.Human.BaseMarketValue;
				return true;
			}

			factor = 1f;
			return false;
		}
	}
}

using Domain.Attractions;

namespace Domain.Plans;

public sealed class PlanItem
{
    public PlanItemId Id { get; private set; }
    public PlanId PlanId { get; private set; }

    public AttractionId AttractionId { get; private set; }
    public Attraction Attraction { get; set; }

    public PlanItem(PlanItemId id, PlanId planId, AttractionId attractionId)
    {
        Id = id;
        PlanId = planId;
        AttractionId = attractionId;
    }
}

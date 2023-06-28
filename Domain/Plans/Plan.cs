using Domain.Primitives;

namespace Domain.Plans;

public sealed class Plan : AggregateRoot
{
    public PlanId Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime Departure { get; private set; }
    public DateTime Return { get; private set; }
    public decimal Price { get; private set; }

    private readonly List<PlanItem> _planItems = new();

    public IReadOnlyList<PlanItem> PlanItems => _planItems;

    public Plan(PlanId id, string name, string description, DateTime departure, DateTime @return, decimal price)
    {
        Id = id;
        Name = name;
        Description = description;
        Departure = departure;
        Return = @return;
        Price = price;
    }

    public void Update(string name, string description, DateTime departure, DateTime @return, decimal price)
    {
        Name = name;
        Description = description;
        Departure = departure;
        Return = @return;
        Price = price;
    }

    public void AddPlanItem(PlanItem planItem)
    {
        _planItems.Add(planItem);
    }
}

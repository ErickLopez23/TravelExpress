using Domain.Primitives;

namespace Domain.Attractions;

public sealed class Attraction : AggregateRoot
{
    public AttractionId Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Country { get; private set; }

    private Attraction()
    {
        
    }

    public Attraction(AttractionId id, string name, string description, string country)
    {
        Id = id;
        Name = name;
        Description = description;
        Country = country;
    }

    public void Update(string name, string description, string country)
    {
        Name = name;
        Description = description;
        Country = country;
    }
}

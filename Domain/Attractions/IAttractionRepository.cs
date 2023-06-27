namespace Domain.Attractions;

public interface IAttractionRepository
{
    Task<IReadOnlyList<Attraction>> GetAllAsync();
    Task<Attraction?> GetByIdAsync(AttractionId id);
    void Add(Attraction attraction);
    void Update(Attraction attraction);
    void Remove(Attraction attraction);
}

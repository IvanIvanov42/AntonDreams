using AntonDream.Models;

namespace AntonDream.Services.IServices
{
    public interface IDreamService
    {
        Task<IEnumerable<Dream>> GetDreamsAsync();
        Task<Dream> GetDreamAsync(int id);
        Task<Dream> GetLatestDreamAsync();
        Task<Dream> PostDreamAsync(Dream newDream);
    }
}

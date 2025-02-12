using WebApi4Boooks.Models;
namespace WebApi4Boooks.Services.Interfaces
{
    public interface IFakeRestAPIHttpClient
    {
        Task<List<Boook>> GetBoooks();
        Task<Boook> GetBoookById(int id);
    }
}

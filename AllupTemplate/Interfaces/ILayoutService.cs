using AllupTemplate.Models;

namespace AllupTemplate.Interfaces
{
    public interface ILayoutService
    {
        Task<IDictionary<string,string>> GetSettings();
    }
}

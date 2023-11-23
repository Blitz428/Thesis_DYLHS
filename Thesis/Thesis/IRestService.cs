using System.Collections.Generic;
using System.Threading.Tasks;
using Thesis.Models;

namespace Thesis
{
    public interface IRestService
    {
        Task<List<T>> RefreshDataAsync<T>(string url);

        Task SaveItemAsync<T>(string url, T item, bool isNewItem);

        Task DeleteItemAsync(string url, string id);

        Task<User> FindUserAsync(string url, string username, string password);
    }
}
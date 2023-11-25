using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Thesis.Models;

namespace Thesis
{
    public interface IRestService
    {

        User User { get; set; }
        Task<List<T>> RefreshDataAsync<T>(string url);

        Task SaveItemAsync<T>(string url, T item, bool isNewItem);

        Task DeleteItemAsync(string url, string id);

        Task<User> FindUserAsync(string url, string username, string password);

        Task<bool[]> CheckUserExistsAsync(string url, string username, string password, string email, double mobile);

        Task CreateUserAsync(string url, string username, string password, string email, double mobile, double points, bool gender, double weight, double height, DateTime birthday);
    }
}
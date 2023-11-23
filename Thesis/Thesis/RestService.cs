using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using Thesis.Models;
using ThesisApi.Models;
using Xamarin.Forms;
using static Android.Content.ClipData;

namespace Thesis
{
    public class RestService : IRestService
    {
        HttpClient client;
        JsonSerializerOptions serializerOptions;

        User user;

        public User User { get { return user; } set { User = value; } }

        public RestService()
        {
            client = new HttpClient();
            serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
                IncludeFields = true  
            };
        }

        public async Task<List<T>> RefreshDataAsync<T>(string url)
        {
            List<T> Items = new List<T>();

            Uri uri = new Uri(string.Format(url, string.Empty));
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Items = JsonSerializer.Deserialize<List<T>>(content, serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Items;
        }

        public async Task SaveItemAsync<T>(string url, T item, bool isNewItem = false)
        {
            Uri uri = new Uri(string.Format(url, string.Empty));

            try
            {
                string json = JsonSerializer.Serialize<T>(item, serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    response = await client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tItem successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task DeleteItemAsync(string url, string id)
        {
            Uri uri = new Uri(string.Format(url, id));

            try
            {
                HttpResponseMessage response = await client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tItem successfully deleted.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task<User> FindUserAsync(string url, string username, string password)
        {
            List<User> Items = new List<User>();
            user = new User();
            CredentialChecker = new bool[3] { false, false, false };

            Uri uri = new Uri(string.Format(url, "Users"));
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Items = JsonSerializer.Deserialize<List<User>>(content, serializerOptions);

                    foreach (User item in Items)
                    {
                        if (item.Username.Equals(username))
                        {
                            if (item.Password.Equals(password))
                            {
                                user._Id = item._Id;
                                user.Password = item.Password;
                                user.Points = item.Points;
                                user.Email = item.Email;
                                user.Mobile = item.Mobile;
                                user.Role = item.Role;
                                user.Body_data = item.Body_data;
                                user.Birthday = item.Birthday;
                            }
                            else
                            {
                                CredentialChecker[0] = true;
                            }
                          
                        }

                    }
                    if (!user.Password.Equals(password)) { CredentialChecker[1] = true; }
                }
               
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return user;
        }

        public async Task CreateUserAsync(string url, string username, string password, string email, double mobile, double points, bool gender, double weight, double height, DateTime birthday)
        {
            List<User> Items = new List<User>();
            user = new User();
            BodyData bodyData;
            
            

            if (UserExists.Equals(false))
            {
                user.Username = username;
                user.Password = password;
                user.Email = email;
                user.Mobile = mobile;
                user.Body_data= new BodyData(gender,weight,height);
                user.Birthday = birthday;
                user.Role = "user";

            }

            Uri uri = new Uri(string.Format(url, "Users"));
            try
            {
                string json = JsonSerializer.Serialize<User>(user, serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = await client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tItem successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }


        }


        bool userExists;
        public bool UserExists { get { return userExists; } set { userExists = value; } }

 

        bool[] credentialChecker;
        public bool[] CredentialChecker { get {  return credentialChecker; } set { credentialChecker = value; } }

        public async Task<bool[]> CheckUserExistsAsync(string url, string username, string password, string email, double mobile)
        {
            List<User> Items = new List<User>();
            
            CredentialChecker = new bool[3] {false,false,false };


            Uri uri = new Uri(string.Format(url, "Users"));
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Items = JsonSerializer.Deserialize<List<User>>(content, serializerOptions);

                    foreach (User item in Items)
                    {
                        if (item.Username.Equals(username))
                        {
                            CredentialChecker[0] = true;
                            
                        }
                        if (item.Email.Equals(email))
                        {
                            CredentialChecker[1] = true;
                        }
                        if (item.Mobile.Equals(mobile))
                        {
                            CredentialChecker[2] = true;
                        }
                    }
                }
                
                

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            
            return CredentialChecker;

        }

    }
}


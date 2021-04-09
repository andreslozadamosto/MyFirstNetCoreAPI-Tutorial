using System;
using System.Net.Http;
using System.Threading.Tasks;
using MyFirstNetCoreWebAPI.WebAPI.Client;
using System.Linq;

namespace MyFirstNetCoreWebAPI.ConsoleClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:44380/");

            var usersClient = new UsersClient(httpClient);

            try
            {
                var users = await usersClient.UsersGetAsync();

                if (users != null && users.Any())
                {
                    users
                        .ToList()
                        .ForEach(x => Console.WriteLine($"User: {x.Name}"));
                }
                else
                {
                    Console.WriteLine("There is no users");
                }
            } 
            catch (ApiException ex)
            {
                //do something
                Console.WriteLine($"HTTP Status Error Code: {ex.StatusCode}");
                Console.WriteLine($"Exception Message: {ex.Message}");
            }
            catch (Exception ex)
            {
                //do something
                Console.WriteLine(ex.Message);
            }
        }
    }
}

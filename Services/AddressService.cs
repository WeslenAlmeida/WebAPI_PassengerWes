using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using WebAPI_Passenger.Models;

namespace WebApi_Passenger.Service
{
    public class AddressService
    {
        private Address _address;
        public AddressService()
        {
         
        }
        // A classe Task representa uma operação assíncrona.
        public async Task<Address> MainAsync(string cep)
        {
          
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://viacep.com.br/ws/" + cep + "/json/");

                var adressJson = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode) 
                    return _address = JsonConvert.DeserializeObject<Address>(adressJson);

                else 
                    return null;
            }

        }
    }
}

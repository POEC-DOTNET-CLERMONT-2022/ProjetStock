using ApiApplication.Profil;
using ProjectStockLibrary;
using AutoMapper;
using ProjectStockDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using ProjectStockPatternsLibrary;

namespace WPF_Application.JsonReader
{
    internal class JsonUserReader : UserProfile
    {

        private HttpClient _httpClient { get; }
        private readonly IMapper _mapper;

        public JsonUserReader(IMapper mapper)
        {
            _mapper = mapper;
            _httpClient = new HttpClient();

            // Update port # in the following line.
            _httpClient.BaseAddress = new Uri("http://localhost:7136/api/User/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async  Task<Client> GetUser(UserDto user)
        {
     
            var request = new HttpRequestMessage(HttpMethod.Get, _httpClient.BaseAddress + user._id.ToString());
            request.Headers.Add("Accept", "application/json");

            var response = await _httpClient.SendAsync(request);


            if (response.IsSuccessStatusCode) {

                using var responseStream = await response.Content.ReadAsStreamAsync();
                var res = await JsonSerializer.DeserializeAsync<Client>(responseStream);

                return user.ToModel();
            }
            return null;

          
        }

        public async Task<Client> UpdateClient(UserDto user)
        {
      
            var request = new HttpRequestMessage(HttpMethod.Put, _httpClient.BaseAddress + user._id.ToString());
            request.Headers.Add("Accept", "application/json");

            var response = await _httpClient.SendAsync(request);


            if (response.IsSuccessStatusCode) {

                using var responseStream = await response.Content.ReadAsStreamAsync();
                var res = await JsonSerializer.DeserializeAsync<Client>(responseStream);

                
            }

            return user.ToModel();
        }




        public async void deleteClient(UserDto user)
        {

            var request = new HttpRequestMessage(HttpMethod.Delete,  _httpClient.BaseAddress + user._id.ToString());
            request.Headers.Add("Accept", "application/json");

            var response = await _httpClient.SendAsync(request);


            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException("Error");
               
            }

           
        }


        public async void addClient(UserDto user)
        {

            var request = new HttpRequestMessage(HttpMethod.Post, _httpClient.BaseAddress + user._id.ToString());

            var response = await _httpClient.SendAsync(request);


            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException("Error");

            }

        }






    }
}

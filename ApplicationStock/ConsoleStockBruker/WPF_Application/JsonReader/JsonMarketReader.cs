using ApiApplication.Profil;
using AutoMapper;
using ProjectStockDTOS;
using ProjectStockLibrary;
using ProjectStockPatternsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WPF_Application.JsonReader
{
    internal class JsonMarketReader : MarketProfile
    {
        private IMapper _mapper;

        private HttpClient _httpClient;

        public JsonMarketReader(IMapper mapper)
        {
            _mapper = mapper;
            _httpClient = new HttpClient();

            // Update port # in the following line.
            _httpClient.BaseAddress = new Uri("http://localhost:7136/api/Market/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public string getUsers(List<UserDto> users)
        {
            List<Client> _clients = new List<Client>();
            foreach (UserDto user in users)
                _clients.Add(_mapper.Map<Client>(user));

            string maString = "";

            foreach (Client client in _clients)
            {
                maString += $"{client.ToString()}";
            }
            return maString;

        }


        public async Task<Market> GetMarket(MarketDto marketDto)
        {

            var request = new HttpRequestMessage(HttpMethod.Get, _httpClient.BaseAddress + marketDto._id.ToString());
            request.Headers.Add("Accept", "application/json");

            var response = await _httpClient.SendAsync(request);



            if (response.IsSuccessStatusCode)
            {

                using var responseStream = await response.Content.ReadAsStreamAsync();
                var res = await JsonSerializer.DeserializeAsync<Client>(responseStream);

                return marketDto.ToModelStock();
            }
            return null;


        }

        public async Task<MarketDto> PutMarket(MarketDto marketDto)
        {

            var request = new HttpRequestMessage(HttpMethod.Put, _httpClient.BaseAddress + marketDto._id.ToString());
            request.Headers.Add("Accept", "application/json");

            var response = await _httpClient.SendAsync(request);


            if (response.IsSuccessStatusCode)
            {

                using var responseStream = await response.Content.ReadAsStreamAsync();
                var res = await JsonSerializer.DeserializeAsync<Market>(responseStream);

            }

            return marketDto;
        }




        public async void deleteMarket(MarketDto marketDto)
        {

            var request = new HttpRequestMessage(HttpMethod.Delete, _httpClient.BaseAddress + marketDto._id.ToString());
            request.Headers.Add("Accept", "application/json");

            var response = await _httpClient.SendAsync(request);


            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException("Error");

            }


        }


        public async void addMarket(MarketDto marketDto)
        {

            var request = new HttpRequestMessage(HttpMethod.Post, _httpClient.BaseAddress + marketDto._id.ToString());
            request.Headers.Add("Accept", "application/json");

            var response = await _httpClient.SendAsync(request);


            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException("Error");

            }

        }

    }
}

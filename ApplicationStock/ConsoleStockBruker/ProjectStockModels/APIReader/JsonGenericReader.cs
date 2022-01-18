using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WPF_Application.JsonReader;

namespace ProjectStockModels.JsonReader
{
   public class JsonGenericReader<T> : IGenericReader<T> where T : class, new()
    {

        private HttpClient _httpClient { get; }
        private readonly IMapper _mapper;

        public JsonGenericReader(IMapper mapper)
        {
            _mapper = mapper;
            _httpClient = new HttpClient();
            // Update port # in the following line.
            _httpClient.BaseAddress = new Uri("http://localhost:7136/api/"+typeof(T).ToString());
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjIzNDY3Yjk5LTBmM2UtNDJkZi1hN2FjLTQzODY5YTFlMDdjMCIsIm5iZiI6MTY0MjQwNDY3MSwiZXhwIjoxNjQzMDA5NDcxLCJpYXQiOjE2NDI0MDQ2NzF9.3XvBwc9RVmZyVUGvaZqkAQX6Hh4Yn69uEhVdzFo-nAw");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        }



    

        public async Task<T> Get(T item)
        {

            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = _httpClient.BaseAddress,
                Content = new StringContent(JsonConvert.SerializeObject(item))
            };
            httpRequestMessage.Headers.Add("Accept", "application/json");
           

            var response = await _httpClient.SendAsync(httpRequestMessage);


            if (response.IsSuccessStatusCode)
            {

                using var responseStream = await response.Content.ReadAsStreamAsync();
                var res = await System.Text.Json.JsonSerializer.DeserializeAsync<T>(responseStream);

                return item;
            }
            return null;


        }

        public async Task<T> Update(T item)
        {

            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri = _httpClient.BaseAddress,
                Content = new StringContent(JsonConvert.SerializeObject(item))
            };
            httpRequestMessage.Headers.Add("Accept", "application/json");

            var response = await _httpClient.SendAsync(httpRequestMessage);


            if (response.IsSuccessStatusCode)
            {

                using var responseStream = await response.Content.ReadAsStreamAsync();
                var res = await System.Text.Json.JsonSerializer.DeserializeAsync<T>(responseStream);


            }

            return item;
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<int> Delete(T item)
        {
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = _httpClient.BaseAddress,
                Content = new StringContent(JsonConvert.SerializeObject(item))
            };

            httpRequestMessage.Headers.Add("Accept", "application/json");

            var response = await _httpClient.SendAsync(httpRequestMessage);



            if (!response.IsSuccessStatusCode)
            {
                return StatusCodes.Status200OK;


            }
            return StatusCodes.Status400BadRequest;


        }

     
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<int> Add(T item)
        {
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = _httpClient.BaseAddress,
                Content = new StringContent(JsonConvert.SerializeObject(item))
            };
            httpRequestMessage.Headers.Add("Accept", "application/json");

            var response = await _httpClient.SendAsync(httpRequestMessage);



            if (!response.IsSuccessStatusCode)
            {
                return StatusCodes.Status200OK;


            }
            return StatusCodes.Status400BadRequest;

        }
    }
}

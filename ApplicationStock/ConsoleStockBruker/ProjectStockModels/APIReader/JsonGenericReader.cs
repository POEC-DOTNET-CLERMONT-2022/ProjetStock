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
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WPF_Application.JsonReader;

namespace ProjectStockModels.JsonReader
{
   public class JsonGenericReader<TModel,TDto> where TModel : class
                                               where TDto : class
    {

        private HttpClient _httpClient { get; }
        private readonly IMapper _mapper;
        private readonly JsonSerializerOptions _options;
        private readonly string uri;

        public JsonGenericReader(HttpClient httpClient, string baseuri)
        {
          
            _httpClient = httpClient;
            // Update port # in the following line.
            _httpClient.BaseAddress = new Uri("https://localhost:");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjIzNDY3Yjk5LTBmM2UtNDJkZi1hN2FjLTQzODY5YTFlMDdjMCIsIm5iZiI6MTY0MjQwNDY3MSwiZXhwIjoxNjQzMDA5NDcxLCJpYXQiOjE2NDI0MDQ2NzF9.3XvBwc9RVmZyVUGvaZqkAQX6Hh4Yn69uEhVdzFo-nAw");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Converters =
                {
                    new JsonStringEnumConverter(JsonNamingPolicy.CamelCase),
                }
            };
            uri = baseuri;
        }



        public virtual async Task<IEnumerable<TModel>> GetAll()
        {

         
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = _httpClient.BaseAddress
               
            };
            httpRequestMessage.Headers.Add("Accept", "application/json");


            var response = await _httpClient.GetFromJsonAsync<IEnumerable<TDto>>((httpRequestMessage.RequestUri).ToString(),_options);
            return _mapper.Map<IList<TModel>>(response);


        }



        public async Task<TModel> Get(TModel item)
        {
            var dto = _mapper.Map<TDto>(item);
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = _httpClient.BaseAddress,
            };
            httpRequestMessage.Headers.Add("Accept", "application/json");

            
            var response = await _httpClient.PostAsJsonAsync((httpRequestMessage.RequestUri).ToString(), dto, _options);


            if (response.IsSuccessStatusCode)
            {

                using var responseStream = await response.Content.ReadAsStreamAsync();
                var res = await System.Text.Json.JsonSerializer.DeserializeAsync<TDto>(responseStream);

                return item;
            }
            return null;


        }

        public async Task<TModel> Update(TModel item)
        {
            var dto = _mapper.Map<TDto>(item);
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri = _httpClient.BaseAddress,
            };
            httpRequestMessage.Headers.Add("Accept", "application/json");
           
            var response = await _httpClient.PutAsJsonAsync((httpRequestMessage.RequestUri).ToString(), dto, _options);




            if (response.IsSuccessStatusCode)
            {

                using var responseStream = await response.Content.ReadAsStreamAsync();
                var res = await System.Text.Json.JsonSerializer.DeserializeAsync<TDto>(responseStream);


            }

            return item;
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<int> Delete(TModel item)
        {
            var dto = _mapper.Map<TDto>(item);
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = _httpClient.BaseAddress
            };

            httpRequestMessage.Headers.Add("Accept", "application/json");


            var response = await _httpClient.DeleteAsync((httpRequestMessage.RequestUri).ToString());



            if (!response.IsSuccessStatusCode)
            {
                return StatusCodes.Status200OK;


            }
            return StatusCodes.Status400BadRequest;


        }

     
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<int> Add(TModel item)
        {
            var dto = _mapper.Map<TDto>(item);
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = _httpClient.BaseAddress,
                Content = new StringContent(JsonConvert.SerializeObject(dto))
            };
            httpRequestMessage.Headers.Add("Accept", "application/json");

            var response = await _httpClient.DeleteAsync((httpRequestMessage.RequestUri).ToString());



            if (!response.IsSuccessStatusCode)
            {
                return StatusCodes.Status200OK;


            }
            return StatusCodes.Status400BadRequest;

        }
    }
}

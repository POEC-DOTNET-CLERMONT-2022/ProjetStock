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
using ProjectStockModels.Mapper;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Net;
using ProjectStockDTOS;
using ProjectStockModels.Model;

namespace ProjectStockModels.JsonReader
{
   public class JsonGenericReader<TModel,TDto> where TModel : class
                                               where TDto : class
    {

        private HttpClient _httpClient { get; }
        private  IMapper _mapper { get; }
        private readonly JsonSerializerOptions _options;
        private  string uri { get; set; }

        private const string AuthorizationHeader = "Authorization";
        public JsonGenericReader(HttpClient httpClient, string baseuri, IMapper mapper)
        {
            _mapper = mapper;

            _httpClient = httpClient;
            // Update port # in the following line.

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
            _httpClient.DefaultRequestHeaders.Add(AuthorizationHeader, $"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjIzNDY3Yjk5LTBmM2UtNDJkZi1hN2FjLTQzODY5YTFlMDdjMCIsIm5iZiI6MTY0MjQwNDY3MSwiZXhwIjoxNjQzMDA5NDcxLCJpYXQiOjE2NDI0MDQ2NzF9.3XvBwc9RVmZyVUGvaZqkAQX6Hh4Yn69uEhVdzFo-nAw");
            uri = "https://localhost:7136/" + baseuri; 
            _httpClient.BaseAddress = new Uri(uri);
        }



        public virtual async Task<IEnumerable<TModel>> GetAll()
        {


            var response = await _httpClient.GetFromJsonAsync<IEnumerable<TDto>>(_httpClient.BaseAddress.ToString(), _options);
            return _mapper.Map<IList<TModel>>(_mapper.Map<TModel> (response));


        }



        //public async Task<TModel> Get(TModel item)
        //{
        //    var dto = _mapper.Map<TDto>(item);


        //    await _httpClient.GetFromJsonAsync<IEnumerable<TDto>>(_httpClient.BaseAddress.ToString(), _options) ;
            
        //    var response = await _httpClient.PostAsJsonAsync(_httpClient.BaseAddress.ToString(), dto, _options);


        //    if (response.IsSuccessStatusCode)
        //    {

        //        using var responseStream = await response.Content.ReadAsStreamAsync();
        //        var res = await System.Text.Json.JsonSerializer.DeserializeAsync<TDto>(responseStream);

        //        return item;
        //    }
        //    return null;


        //}

        public async Task<int> Update(TModel item)
        {

            var item_ = item;
            try
            {
                var map = _mapper.Map<TDto>(item);

                var response = await _httpClient.PutAsJsonAsync(uri, map);
                return StatusCodes.Status200OK;



            }
            catch (Exception e)
            {
                return StatusCodes.Status400BadRequest;
            }
           

           
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<int> Delete(TModel item)
        {
           

            var response = await _httpClient.DeleteAsync(uri);


            if (!response.IsSuccessStatusCode)
            {
                return StatusCodes.Status200OK;


            }
            return StatusCodes.Status400BadRequest;


        }

     
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<int> Add(TModel item)
        {


            var item_ = item;
            try
            {
                var map = _mapper.Map<TDto>(item);
              
                var response =  await _httpClient.PostAsJsonAsync(uri,map);
                return StatusCodes.Status200OK;



            }
            catch (Exception e)
            {
                return StatusCodes.Status400BadRequest;
            }
           

        }
    }
}

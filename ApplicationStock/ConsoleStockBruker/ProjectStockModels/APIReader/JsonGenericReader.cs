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
using System.Threading.Tasks;
using System.Net;
using ProjectStockDTOS;
using ProjectStockModels.Model;
using ApiApplication.Models;


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
            _httpClient.DefaultRequestHeaders.Add(AuthorizationHeader, "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjIzNDY3Yjk5LTBmM2UtNDJkZi1hN2FjLTQzODY5YTFlMDdjMCIsIm5iZiI6MTY0MjQwNDY3MSwiZXhwIjoxNjQzMDA5NDcxLCJpYXQiOjE2NDI0MDQ2NzF9.3XvBwc9RVmZyVUGvaZqkAQX6Hh4Yn69uEhVdzFo-nAw");
            uri = "https://localhost:7136/" + baseuri; 
            _httpClient.BaseAddress = new Uri(uri);


        }


        //La fonction Get all marche
        public virtual async Task<IEnumerable<TModel>> GetAll()
        {
            var uri_ = new Uri(uri + "/all");
            IEnumerable<TDto> response = await _httpClient.GetFromJsonAsync<IEnumerable<TDto>>(uri_, _options);
            IEnumerable<TModel> _models = _mapper.Map<IEnumerable<TModel>>(response);
            return _models;
        }

        //La fonction Get by id  marche
        public virtual async Task<TModel> Get(Guid id)
        {
  
            TDto response = await _httpClient.GetFromJsonAsync<TDto>(new Uri($"{uri}?id={id.ToString()}"), _options);
            TModel _model = _mapper.Map<TModel>(response);
            return _model;
        }

        //La fonction get update ?
        public async Task<int> Update(TModel item)
        {
            var item_ = item;
            try
            {
                var map = _mapper.Map<TDto>(item);

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Put,
                    RequestUri = new Uri(uri),
                    Content = new StringContent(JsonConvert.SerializeObject(map), Encoding.UTF8, "application/json")
                };
                var response = await _httpClient.SendAsync(request);
                return StatusCodes.Status200OK;


                 
            }
            catch (Exception e)
            {
                return StatusCodes.Status400BadRequest;
            }
           
        }


        //La fonction delete marche
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<int> Delete(Guid id)
        {

            DeleteClass _class = new DeleteClass();
            _class._id = id;

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(uri),
                Content = new StringContent(JsonConvert.SerializeObject(_class), Encoding.UTF8, "application/json")
            };
            var response = await _httpClient.SendAsync(request);

          


            if (response.IsSuccessStatusCode)
            {
                return StatusCodes.Status200OK;


            }
            return StatusCodes.Status400BadRequest;


        }


        //La fonction add : ?
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<int> Add(TModel item)
        {


            var item_ = item;
            try
            {
                var map = _mapper.Map<TDto>(item);

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Put,
                    RequestUri = new Uri(uri),
                    Content = new StringContent(JsonConvert.SerializeObject(map), Encoding.UTF8, "application/json")
                };
                var response = await _httpClient.SendAsync(request);
                return StatusCodes.Status200OK;



            }
            catch (Exception e)
            {
                return StatusCodes.Status400BadRequest;
            }
           

        }
    }
}

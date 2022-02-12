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
using System.Threading.Tasks;
using System.Net;
using System.Net.Mime;
using ProjectStockDTOS;
using ProjectStockModels.Model;
using ApiApplication.Models;
using ApiApplication.Service.Interfaces;
using ProjectStockModels.APIReader.ServiceSpe;
using Newtonsoft.Json.Linq;
using ProjectStockLibrary;
using MediaTypeHeaderValue = Microsoft.Net.Http.Headers.MediaTypeHeaderValue;

namespace ProjectStockModels.JsonReader
{
   public class JsonGenericReader<TModel,TDto> where TModel : class
                                               where TDto : class
    {

        private HttpClient _httpClient { get; }
        private  IMapper _mapper { get; }
        private readonly JsonSerializerOptions _options;
        private  string uri { get; set; }

        private IPasswordHasherService _userPasswordHasher { get; }


        private const string AuthorizationHeader = "Authorization";
        public JsonGenericReader(HttpClient httpClient, string baseuri, IMapper mapper)
        {
            _mapper = mapper;

            _httpClient = httpClient;
            // Update port # in the following line.

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            //TODO : use => MediaTypeNames.Application.Json
            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Converters =
                {
                    new JsonStringEnumConverter(JsonNamingPolicy.CamelCase),
                }
            };
            _httpClient.DefaultRequestHeaders.Add(AuthorizationHeader, "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6ImE3OTRhYjUxLWYzMzEtNDdiOS1hMGQ2LTMzMWUxOGMxZDEyNyIsIm5iZiI6MTY0MzkwNjEyNSwiZXhwIjoxNjQ0NTEwOTI1LCJpYXQiOjE2NDM5MDYxMjV9.a7HYeLtSAEabLU-zHnniCsh_PBgvA7FoEZ2hC-Pld4U");
            //TODO : supprimer le token ici 
            uri = "https://localhost:7136/" + baseuri; 
            //TODO : rendre configurable l'url => regarder app.config wpf 
            _httpClient.BaseAddress = new Uri(uri);

            _userPasswordHasher = new PassworsHasherService();


        }



        public async Task<HttpResponseMessage> Connect(AuthenticateRequest create)
        {
                HttpClient httpClient_ = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(uri + "/authenticate"),
                    Content = new StringContent(JsonConvert.SerializeObject(create), Encoding.UTF8, "application/json")
                };
                            
                //TODO : utiliser plutôt _httpClient.PostAsJsonAsync()
                return _httpClient.SendAsync(request).Result;

    
           
        }

        public async Task<int> CreateAccount(CreateResult create)
        {
            try
            {

          
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(uri + "/register"),
                    Content = new StringContent(JsonConvert.SerializeObject(create), Encoding.UTF8, "application/json")
                };
                //TODO : retourner un HttpStatusCode
                return (int)_httpClient.SendAsync(request).Result.StatusCode;

            }
            catch (Exception ex)
            {
                //TODO : Logger l'exception ici 
                return StatusCodes.Status400BadRequest;
            }

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


        public virtual async Task<HttpResponseMessage> GetById(Guid id)
        {

            ProjectStockModels.APIReader.Models.GetClass _user = new ProjectStockModels.APIReader.Models.GetClass();

            _user.Id = id;
            HttpClient httpClient_ = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(uri),
                Content = new StringContent(JsonConvert.SerializeObject(_user), Encoding.UTF8, "application/json")
            };

            return _httpClient.SendAsync(request).Result;


        }



        public virtual async Task<HttpResponseMessage> GetByEmail(AuthenticateRequest create)
        {
            HttpClient httpClient_ = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(uri + "/email?email="+create._email),
                Content = new StringContent(JsonConvert.SerializeObject(create), Encoding.UTF8, "application/json")
            };

            return _httpClient.SendAsync(request).Result;


        }



        public virtual async Task<TModel> GetByToken(string token)
        {

            //TODO : à supprimer 
            var uri_ = new Uri(uri + "/token?token="+token);
            TDto response = await _httpClient.GetFromJsonAsync<TDto>(uri_, _options);
            TModel _model = _mapper.Map<TModel>(response);
            return _model;
        }

        public async Task<int> Update(TModel item)
        {
            try
            {
                var map = _mapper.Map<TDto>(item);


                return (int)_httpClient.PutAsJsonAsync(new Uri(uri),map).Result.StatusCode;

            }
            catch (Exception e)
            {
                return StatusCodes.Status400BadRequest;
            }


        }


       
        public async Task<int> UpdateStocks(TModel item, string url)
        {
            try
            {
                var map = _mapper.Map<TDto>(item);


                return (int)_httpClient.PutAsJsonAsync(new Uri(uri + url), map).Result.StatusCode;

            }
            catch (Exception e)
            {
                return StatusCodes.Status400BadRequest;
            }


        }




        //La fonction delete marche
        public async Task<int> Delete(Guid id)
        {

            DeleteClass _class = new DeleteClass();
            _class.Id = id;

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



        public async Task<int> Add(TModel item)
        {


           
            try
            {
                var map = _mapper.Map<TDto>(item);

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(uri),
                    Content = new StringContent(JsonConvert.SerializeObject(map), Encoding.UTF8, "application/json")
                };
               
                return (int)_httpClient.SendAsync(request).Result.StatusCode;



            }
            catch (Exception e)
            {
                return StatusCodes.Status400BadRequest;
            }
           
           

        }
    }
}

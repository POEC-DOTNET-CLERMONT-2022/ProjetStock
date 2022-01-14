using ApiApplication.Profil;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Application.JsonReader
{
    internal class JsonOrderReader : OrderProfile
    {
        private IMapper _mapper;
        private HttpClient _httpClient;
        public JsonOrderReader(IMapper mapper)
        {
            _mapper = mapper;
            _httpClient = new HttpClient();

            // Update port # in the following line.
            _httpClient.BaseAddress = new Uri("http://localhost:7136/api/Order");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        }



    }
}

﻿using ApiApplication.Profil;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectStockDTOS;
using ProjectStockLibrary;
using ProjectStockPatternsLibrary.Factory;
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
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<Order> GetOrder(OrderDto orderDto)
        {

            var request = new HttpRequestMessage(HttpMethod.Get, _httpClient.BaseAddress + orderDto._id.ToString());
            request.Headers.Add("Accept", "application/json");

            var response = await _httpClient.SendAsync(request);



            if (response.IsSuccessStatusCode)
            {

                using var responseStream = await response.Content.ReadAsStreamAsync();
                var res = await JsonSerializer.DeserializeAsync<OrderDto>(responseStream);

                return orderDto.ToModel();
            }
            return null;


        }

        public async Task<OrderDto> PutOrder(OrderDto orderDto)
        {

            var request = new HttpRequestMessage(HttpMethod.Put, _httpClient.BaseAddress + orderDto._id.ToString());
            request.Headers.Add("Accept", "application/json");

            var response = await _httpClient.SendAsync(request);


            if (response.IsSuccessStatusCode)
            {

                using var responseStream = await response.Content.ReadAsStreamAsync();
                var res = await JsonSerializer.DeserializeAsync<Order>(responseStream);

            }

            return orderDto;
        }



        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MarketDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<int> deleteOrder(OrderDto orderDto)
        {

            var request = new HttpRequestMessage(HttpMethod.Delete, _httpClient.BaseAddress + orderDto._id.ToString());
            request.Headers.Add("Accept", "application/json");

            var response = await _httpClient.SendAsync(request);


            if (!response.IsSuccessStatusCode)
            {
                return StatusCodes.Status200OK;


            }
            return StatusCodes.Status400BadRequest;


        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MarketDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<int> addOrder(OrderDto orderDto)
        {

            var request = new HttpRequestMessage(HttpMethod.Post, _httpClient.BaseAddress + orderDto._id.ToString());
            request.Headers.Add("Accept", "application/json");

            var response = await _httpClient.SendAsync(request);


            if (!response.IsSuccessStatusCode)
            {
                return StatusCodes.Status200OK;


            }
            return StatusCodes.Status400BadRequest;

        }

    }
}

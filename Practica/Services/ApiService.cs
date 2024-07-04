using Newtonsoft.Json;
using Practica.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Practica.Services
{
    internal class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("https://rickandmortyapi.com/api/") };
        }

        public async Task<List<Personaje>> GetCharactersAsync()
        {
            var response = await _httpClient.GetStringAsync("character");
            var data = JsonConvert.DeserializeObject<ApiResponse>(response);
            return data.Results;
        }

        private class ApiResponse
        {
            public List<Personaje> Results { get; set; }
        }
    }
}
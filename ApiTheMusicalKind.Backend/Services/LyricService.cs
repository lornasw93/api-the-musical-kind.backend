﻿using System;
using System.Net.Http;
using ApiTheMusicalKind.Backend.Models;
using Newtonsoft.Json;

namespace ApiTheMusicalKind.Backend.Services
{
    public class LyricService : ILyricService
    {
        public string Get(string resourceUrl)
        {
            var baseAddress = new Uri("https://api.lyrics.ovh/v1/");

            using var httpClient = new HttpClient { BaseAddress = baseAddress };
            using var response = httpClient.GetAsync(resourceUrl);

            var responseData = response.Result.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<Lyric>(responseData.Result);

            return result.Lyrics;
        }
    }
}
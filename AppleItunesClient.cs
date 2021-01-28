using Newtonsoft.Json;
using OpendorseWebMvc.Interfaces;
using OpendorseWebMvc.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace OpendorseWebMvc
{
    public class AppleItunesClient : IAppleItunesClient
    {
        private readonly HttpClient _httpClient;

        public AppleItunesClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://itunes.apple.com/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<AlbumModel> LoadAlbums(string url)
        {            
            using HttpResponseMessage response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode == false)
                return null;

            string json = await response.Content.ReadAsStringAsync();            
            AlbumModel albums = JsonConvert.DeserializeObject<AlbumModel>(json);

            return albums;
        }
    }
}
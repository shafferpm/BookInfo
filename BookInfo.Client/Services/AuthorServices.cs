using BookInfo.Client.Helpers;
using BookInfo.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookInfo.Client.Services
{
    public class AuthorServices : IIntegrationService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptionsWrapper _jsonSerializerOptionsWrapper;

        public AuthorServices(IHttpClientFactory httpClientFactory,
            JsonSerializerOptionsWrapper jsonSerializerOptionsWrapper)
        {            
            _httpClientFactory = httpClientFactory ?? 
                throw new ArgumentNullException(nameof(httpClientFactory));
            _jsonSerializerOptionsWrapper = jsonSerializerOptionsWrapper ??
                throw new ArgumentNullException(nameof(jsonSerializerOptionsWrapper));
        }

        public async Task RunAsync()
        {
            //await GetAuthorsAsync();            
            //await CreateAuthorAsync();
            await DeleteAuthorAsync();
        }
        public async Task GetAuthorsAsync()
        {
            var httpClient = _httpClientFactory.CreateClient("AuthorsAPIClient");

            var response = await httpClient.GetAsync("api/authors");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var authors = JsonSerializer.Deserialize<IEnumerable<AuthorDto>>(
                content,
                _jsonSerializerOptionsWrapper.Options);
        }

        public async Task CreateAuthorAsync()
        {
            var httpClient = _httpClientFactory.CreateClient("AuthorsAPIClient");

            var authorToCreate = new AuthorForCreationDto
            {
                AuId = "172-32-1177",
                AuLname = "Grisham",
                AuFname = "John",
                Phone = "408 496-7223",
                Address = "1745 Broadway",
                City = "New York",
                State = "NY",
                Zip = "10019",
                Contract = "true"
            };

            var authorJson = JsonSerializer.Serialize(
                authorToCreate, 
                _jsonSerializerOptionsWrapper.Options);

            // Send a POST request
            // to the API endpoint
            var request = new HttpRequestMessage(
                HttpMethod.Post, 
                "api/authors");

            // Add an Accept header to the request
            // to specify that the client wants a JSON response.
            request.Headers.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            request.Content = new StringContent(authorJson);

            request.Content.Headers.ContentType = 
                new MediaTypeHeaderValue("application/json");

            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAuthorAsync()
        {
            var httpClient = _httpClientFactory.CreateClient("AuthorsAPIClient");

            var request = new HttpRequestMessage(
                HttpMethod.Delete, 
                "api/authors/172-32-1177");

            request.Headers.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }
    }    
}

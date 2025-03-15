using _MultiShop.WebUI.Services.Interfaces;
using _MultiShop.WebUI.Settings;
using IdentityModel.Client;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using MultiShop.WebUI.Settings;

namespace _MultiShop.WebUI.Services.Concrete
{
    public class ClientCredentialTokenService : IClientCredentialTokenService
    {
        private readonly ServiceApiSettings _serviceApiSettingsettings;
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _memoryCache;
        private readonly ClientSettings _clientSettings;

        public ClientCredentialTokenService(IOptions<ServiceApiSettings> serviceApiSettingsettings, HttpClient httpClient, IMemoryCache clientAccesTokenCache, IOptions<ClientSettings> clientSettings)
        {
            _serviceApiSettingsettings = serviceApiSettingsettings.Value;
            _httpClient = httpClient;
            _memoryCache = clientAccesTokenCache;
            _clientSettings = clientSettings.Value;
        }

        public async Task<string> GetToken()
        {
            if (_memoryCache.TryGetValue("multishoptoken", out string cachedToken))
            {
                return cachedToken;
            }

            var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest

            {
                Address = _serviceApiSettingsettings.IdentityServerUrl,

                Policy = new DiscoveryPolicy
                {
                    RequireHttps = false
                }
            });

            var clientCredentialTokenRequest = new ClientCredentialsTokenRequest
            {
                ClientId = _clientSettings.MultiShopVisitorClient.ClientId,
                ClientSecret = _clientSettings.MultiShopVisitorClient.ClientSecret,
                Address = discoveryEndPoint.TokenEndpoint
            };

            var tokenResponse = await _httpClient.RequestClientCredentialsTokenAsync(clientCredentialTokenRequest);
            if (tokenResponse.IsError)
            {
                throw new Exception("Token alınamadı: " + tokenResponse.ErrorDescription);
            }
            _memoryCache.Set("multishoptoken", tokenResponse.AccessToken, TimeSpan.FromSeconds(tokenResponse.ExpiresIn));
            return tokenResponse.AccessToken;
        }
    }
}


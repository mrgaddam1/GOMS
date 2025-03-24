using GOMS.Web.Infrastructure.Common.Http;
using GOMS.Web.Services.Interface;
using GOMS.Web.Shared;

namespace GOMS.Web.Services.Implementation
{
   

    public class AuthService : IAuthService
    {
        public HttpClient httpClient { get; set; }
        public AuthService(HttpClient _httpClient)
        {
            httpClient = _httpClient;
        }

        public async Task<T?> UserLogin<T>(LoginRequest loginRequest)
        {
            var response = await httpClient.PostAsJsonAsync("api/Auth/Login", loginRequest);
            return await ApiStatusCodeHandler.HandleResponse<T>(response);
        }
    }
}
 
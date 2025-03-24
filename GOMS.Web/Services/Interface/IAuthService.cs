using GOMS.Web.Shared;

namespace GOMS.Web.Services.Interface
{
    public interface IAuthService
    {
        Task<T?> UserLogin<T>(LoginRequest loginRequest);
    }
}

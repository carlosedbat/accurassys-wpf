namespace AccurassysWpf.Services.Api.Authentication
{
    using AccurassysWpf.Models.DTOs.Login;
    using Refit;

    public interface IAuthenticationApi
    {
        [Post("/api/Authentication/login")]
        public Task<LoginResponse> LoginAsync([Body] LoginRequest loginRequest);
    }
}

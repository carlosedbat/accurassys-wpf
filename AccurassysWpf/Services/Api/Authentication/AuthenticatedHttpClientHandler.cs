namespace AccurassysWpf.Services.Api.Authentication
{
    using System.Net.Http.Headers;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class AuthenticatedHttpClientHandler : DelegatingHandler
    {
        private readonly TokenProvider _tokenProvider;

        public AuthenticatedHttpClientHandler(TokenProvider tokenProvider)
        {
            _tokenProvider = tokenProvider;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Adiciona o token Bearer no header Authorization
            if (!string.IsNullOrEmpty(_tokenProvider.AccessToken))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _tokenProvider.AccessToken);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}

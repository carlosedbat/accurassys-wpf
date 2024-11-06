using AccurassysWpf.Models.Entities.Environment;
using DotNetEnv;

namespace AccurassysWpf.Helpers.Environment
{
    public static class EnvironmentMethods
    {

            public static EnvironmentVariablesDTO variables = new EnvironmentVariablesDTO();

            public static void GetVariablesFromDotEnv()
            {
                SetBackendApi();
            }

            private static void SetBackendApi()
            {
                string? backendApi = System.Environment.GetEnvironmentVariable("BACKEND_API");

                variables.BackendApi = !string.IsNullOrEmpty(backendApi) ? backendApi : "https://127.0.0.1:7238/";
            }
    }
}


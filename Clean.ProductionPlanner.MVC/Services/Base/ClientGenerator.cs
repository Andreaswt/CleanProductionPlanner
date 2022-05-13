using System;
using System.Threading.Tasks;
using NSwag;
using NSwag.CodeGeneration.CSharp;

namespace Clean.ProductionPlanner.MVC.Services.Base
{
    public static class ClientGenerator
    {
        public static async Task<string> GenerateClient()
        {
            System.Net.WebClient wclient = new System.Net.WebClient();

            var document =
                await OpenApiDocument.FromJsonAsync(
                    wclient.DownloadString("https://localhost:7010/swagger/v1/swagger.json"));

            wclient.Dispose();

            var settings = new CSharpClientGeneratorSettings
            {
                ClassName = "{controller}Client",
                CSharpGeneratorSettings =
                {
                    Namespace = "Clean.ProductionPlanner.MVC.Services.Base",
                },
                GenerateClientInterfaces = true
            };

            var generator = new CSharpClientGenerator(document, settings);
            var code = generator.GenerateFile();
            return code;
        }
    }
}
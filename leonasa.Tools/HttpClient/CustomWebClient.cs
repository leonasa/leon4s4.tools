using System.Net;
using Newtonsoft.Json;

namespace leonasa.Tools.HttpClient
{
    public class CustomWebClient<TResult,TSend>
    {
        private readonly string _contentType;
        private readonly string _url;

        public CustomWebClient(string remoteMachineName, string remoteMachinePort)
        {
            _contentType = "application/x-www-form-urlencoded";
            _url = $"http://{remoteMachineName}:{remoteMachinePort}/api/inject";

        }

        public TResult PostMessage(TSend sendObject)
        {
            using (var client = new WebClient())
            {
                var data = GenerateData(sendObject);

                client.Headers[HttpRequestHeader.ContentType] = _contentType;
                var resultEvent = client.UploadString(_url, "POST", data);
                return JsonConvert.DeserializeObject<TResult>(resultEvent);
            }
        }

        private string GenerateData(TSend sendObject)
        {
            var serializeObject = JsonConvert.SerializeObject(sendObject);
            return $"={serializeObject}";
        }
    }
}
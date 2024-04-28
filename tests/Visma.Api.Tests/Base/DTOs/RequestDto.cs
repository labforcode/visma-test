using Visma.Api.Tests.Base.Enums;

namespace Visma.Api.Tests.Base.DTOs
{
    public class RequestDto
    {
        public RequestType Type { get; set; }

        public string Uri { get; set; }

        public dynamic Payload { get; set; }

        public static RequestDto GenerateRequestDto(RequestType type, string uri, dynamic payload) => new RequestDto
        {
            Type = type,
            Uri = uri,
            Payload = payload
        };
    }
}

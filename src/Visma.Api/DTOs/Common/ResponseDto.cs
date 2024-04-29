using Newtonsoft.Json;

namespace Visma.HR.Api.DTOs.Common
{
    /// <inheritdoc/>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ResponseDto
    {
        /// <inheritdoc/>
        public int Code { get; private set; }

        /// <inheritdoc/>
        public bool Success { get; private set; }

        /// <inheritdoc/>
        public object Data { get; private set; }

        /// <inheritdoc/>
        public List<string> Notifications { get; private set; }

        /// <inheritdoc/>
        public List<string> Errors { get; private set; }

        /// <inheritdoc/>
        public int TotalRecords { get; private set; }

        /// <inheritdoc/>
        public static ResponseDto CreateResponseToData(int code, object data, int totalRecords) => new ResponseDto { Code = code, Success = true, Data = data, TotalRecords = totalRecords };

        /// <inheritdoc/>
        public static string CreateResponseToNotification(int code, string notification) => SerializeObject(new ResponseDto { Code = code, Success = true, Notifications = new List<string> { notification } });

        /// <inheritdoc/>
        public static string CreateResponseToFailure(int code, string error) => SerializeObject(new ResponseDto { Code = code, Success = false, Errors = new List<string> { error } });

        /// <inheritdoc/>
        public static ResponseDto CreateResponseToError(int code, string error) => new ResponseDto { Code = code, Success = false, Errors = new List<string> { error } };

        /// <inheritdoc/>
        private static string SerializeObject(ResponseDto response) => JsonConvert.SerializeObject(response, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
    }
}

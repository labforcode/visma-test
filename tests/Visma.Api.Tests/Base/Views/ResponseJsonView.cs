namespace Visma.Api.Tests.Base.Views
{
    public class ResponseJsonView
    {
        public int Code { get; set; }

        public bool Success { get; set; }

        public object Data { get; set; }

        public int TotalRecords { get; set; }

        public List<string> Notifications { get; set; }

        public List<string> Errors { get; set; }
    }
}

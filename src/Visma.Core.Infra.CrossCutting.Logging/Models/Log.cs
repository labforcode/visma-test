namespace Visma.Core.Infra.CrossCutting.Logging.Models
{
    public class Log
    {
        public Guid Id { get; private set; }

        public string Message { get; private set; }

        public string StackTrace { get; private set; }

        public DateTime InputDate { get; private set; }

        private Log(string message,
                    string stackTrace)
        {
            Id = Guid.NewGuid();
            Message = message;
            StackTrace = stackTrace;
            InputDate = DateTime.Now;
        }

        protected Log() { }

        public static Log Create(string message, string stackTrace) => new Log(message, stackTrace);
    }
}

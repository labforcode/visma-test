using Visma.Core.Infra.CrossCutting.Logging.Contexts;
using Visma.Core.Infra.CrossCutting.Logging.Models;

namespace Visma.Core.Infra.CrossCutting.Logging.Services
{
    public class LogService
    {
        public static void RegisterLog(string message, string stackTrace)
        {
            var log = Log.Create(message, stackTrace);
            using var context = new LogContext();
            context.Add(log);
            context.SaveChanges();
        }
    }
}

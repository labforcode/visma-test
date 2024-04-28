using Visma.Core.Infra.CrossCutting.Security.Models;

namespace Visma.Core.Infra.CrossCutting.Security.Interfaces
{
    public interface ITokenService
    {
        public TokenModel GenerateToken();
    }
}

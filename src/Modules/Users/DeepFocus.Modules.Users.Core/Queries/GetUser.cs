using Modular.Abstractions.Queries;
using Modular.Modules.Users.Core.DTO;

namespace Modular.Modules.Users.Core.Queries
{
    internal class GetUser : IQuery<UserDetailsDto>
    {
        public Guid UserId { get; set; }
    }
}
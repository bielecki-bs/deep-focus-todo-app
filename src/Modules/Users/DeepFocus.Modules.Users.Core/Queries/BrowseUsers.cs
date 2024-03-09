using Modular.Abstractions.Queries;
using Modular.Modules.Users.Core.DTO;

namespace Modular.Modules.Users.Core.Queries
{
    internal class BrowseUsers : PagedQuery<UserDto>
    {
        public string Email { get; set; }
        public string Role { get; set; }
        public string State { get; set; }
    }
}
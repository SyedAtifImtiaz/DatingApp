using Microsoft.AspNetCore.Identity;

namespace API.Entities;

public class AppRole : IdentityRole<int> // to define id as int
{
    public ICollection<AppUserRole> UserRoles { get; set; }
}

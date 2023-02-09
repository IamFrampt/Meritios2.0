using Meritios2._0.Data;
using Meritios2._0.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Meritios2._0.Pages.Users;

public class ListUserModel : PageModel
{
    private readonly UserDbContext _context;
    public List<User> _usersList { get; set; }

    public ListUserModel(UserDbContext context)
    {
        _context = context;
    }

    public void OnGet()
    {
        _usersList = _context._users.ToList();
    }
}

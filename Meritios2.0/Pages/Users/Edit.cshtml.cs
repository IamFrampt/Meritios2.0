using Meritios2._0.Data;
using Meritios2._0.Models.Domain;
using Meritios2._0.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Meritios2._0.Pages.Users;
public class EditModel : PageModel
{

    private readonly UserDbContext dbContext;
    [BindProperty]
    public EditUserViewModel _editUser { get; set; }

    public EditModel(UserDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public void OnGet(Guid id)
    {
        var existingUser = dbContext._users.Find(id);

        if (existingUser != null)
        {
            _editUser = new EditUserViewModel()
            {
                Id= existingUser.id,
                Name= existingUser.Name, 
                Email= existingUser.Email,
                Phone= existingUser.Phone,
                School= existingUser.School,
                Education= existingUser.Education, 
                Location= existingUser.Location
            };
        }
    }

    public IActionResult OnPostUpdate()
    {
        var user = dbContext._users.Find(_editUser.Id);

        if (user != null) 
        {
            user.Name = _editUser.Name;
            user.Email = _editUser.Email;
            user.Phone = _editUser.Phone;
            user.School= _editUser.School;
            user.Education= _editUser.Education;
            user.Location= _editUser.Location;

            dbContext.SaveChanges();
            return RedirectToPage("/Users/ListUser");
        }
            return Page();
    }

    public IActionResult OnPostDelete()
    {
        var user = dbContext._users.Find(_editUser.Id);
        if (user != null)
        {
            dbContext._users.Remove(user);
            dbContext.SaveChanges();
            return RedirectToPage("/Users/ListUser");
        }
        return Page();
    }
}

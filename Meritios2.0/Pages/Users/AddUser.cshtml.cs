using Meritios2._0.Data;
using Meritios2._0.Models.Domain;
using Meritios2._0.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Meritios2._0.Pages.Users;

public class AddUserModel : PageModel
{
    private readonly UserDbContext dbContext;

    [BindProperty]
    public AddUserViewModel AddUserRequest { get; set; }


    public AddUserModel(UserDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public void OnGet()
    {
    }

    public void OnPost()
    {
        var userDomainModel = new User()
        {
            Name = AddUserRequest.Name,
            Email = AddUserRequest.Email,
            Phone = AddUserRequest.Phone,
            School = AddUserRequest.School,
            Education = AddUserRequest.Education,
            Location = AddUserRequest.Location
        };
        dbContext._users.Add(userDomainModel);
        dbContext.SaveChanges();
    }
}

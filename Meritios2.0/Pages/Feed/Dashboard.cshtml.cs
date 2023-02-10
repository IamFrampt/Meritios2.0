using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Meritios2._0.Pages.Feed;

public class DashboardModel : PageModel
{
    private FirestoreDb _db;

    public List<Dictionary<string,object>> Posts { get; set; }

    public DashboardModel()
    {
        string filePath = "./merit2-48df7-firebase-adminsdk-2lg14-54393f3200.json";
        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filePath);
        _db = FirestoreDb.Create("merit2-48df7");
    }

    public async Task<IActionResult> OnPostAsync()
    {
        string content = Request.Form["postContent"];

        var post = new Dictionary<string, object>
        {
            {"content", content},
            {"createdAt",DateTime.UtcNow }
        };

        await _db.Collection("posts").AddAsync(post);

        return RedirectToPage(); 
        
    }
    public async Task OnGetAsync()
    {
        var postRef = _db.Collection("posts");

        var query = await postRef.OrderByDescending("createdAt").GetSnapshotAsync();

        Posts = query.Documents.Select(d=>d.ToDictionary()).ToList();
    }
}

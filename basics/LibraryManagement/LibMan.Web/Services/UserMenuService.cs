namespace LibMan.Web;

public class MenuItem
{
    public string Text { get; set; }
    public string Url { get; set; }
}

public static class UserMenuService
{

    public static List<MenuItem> GetMenuItems(HttpContext context)
    {
        if(context.User.IsInRole("Admin"))
        {
            return new List<MenuItem>(){
                new MenuItem(){Text = "Home", Url = "/"},
                new MenuItem(){Text = "Books", Url = "/books"},
                new MenuItem(){Text = "Categories", Url = "/categories"}
            };
        }
        else
        {
            return new List<MenuItem>(){
                new MenuItem(){Text = "Home", Url = "/"},
            };
        }
    }
}

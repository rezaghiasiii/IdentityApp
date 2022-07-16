namespace IdentityApp.Views.ManageUser;

public class AddUserToRoleViewModel
{
    public string UserId { get; set; }
    public List<UserRolesViewModel> UserRoles { get; set; }

    public AddUserToRoleViewModel()
    {
        UserRoles = new List<UserRolesViewModel>();
    }
}

public class UserRolesViewModel
{
    public string RoleName { get; set; }
    public bool IsSelected { get; set; }
}
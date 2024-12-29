using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace PeopleManager.Ui.BlazorApp.Security
{
    [Authorize]
    public class AdminPageComponent: ComponentBase
    {
    }
}

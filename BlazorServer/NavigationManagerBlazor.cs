using Microsoft.AspNetCore.Components;

namespace BlazorServer
{
    public class NavigationManagerBlazor
    {
        NavigationManager _navigationManager;
        public NavigationManagerBlazor(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }

        public void GoHome()
        {
            _navigationManager.NavigateTo("/");
        }
    }
}

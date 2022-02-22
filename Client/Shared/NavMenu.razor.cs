using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace HandsOnWithBlazor.Client.Shared
{
    public partial class NavMenu : ComponentBase
    {
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        private NavLinkMatch _matchMode = NavLinkMatch.All;

        protected override void OnInitialized() => NavigationManager.LocationChanged += (s, e) => StateHasChanged();


        private bool IsActive(string href, NavLinkMatch navLinkMatch = NavLinkMatch.Prefix)
        {
            var relativePath = NavigationManager.ToBaseRelativePath(NavigationManager.Uri).ToLower();
            return navLinkMatch == NavLinkMatch.All ? relativePath == href.ToLower() : relativePath.StartsWith(href.ToLower());
        }

        private string GetActive(string href, NavLinkMatch navLinkMatch = NavLinkMatch.Prefix) => IsActive(href, navLinkMatch) ? "active" : "";
    }
}

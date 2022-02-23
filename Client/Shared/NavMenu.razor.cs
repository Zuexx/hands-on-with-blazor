using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using HandsOnWithBlazor.Client.Services;
using HandsOnWithBlazor.Client.Models;

namespace HandsOnWithBlazor.Client.Shared
{
    public partial class NavMenu : ComponentBase, IDisposable
    {
        [Inject]
        private NavigationManager _navigationManager { get; set; } = default!;

        [Inject]
        private SimpleStateContainerService<SimpleStateModel> _stateService { get; set; } = default!;

        private NavLinkMatch _matchMode = NavLinkMatch.All;

        protected override void OnInitialized()
        {
            _navigationManager.LocationChanged += (s, e) => StateHasChanged();
            _stateService.OnStateChange += StateHasChanged;
        }

        private bool IsActive(string href, NavLinkMatch navLinkMatch = NavLinkMatch.Prefix)
        {
            var relativePath = _navigationManager.ToBaseRelativePath(_navigationManager.Uri).ToLower();
            return navLinkMatch == NavLinkMatch.All ? relativePath == href.ToLower() : relativePath.StartsWith(href.ToLower());
        }

        private string GetActive(string href, NavLinkMatch navLinkMatch = NavLinkMatch.Prefix) => IsActive(href, navLinkMatch) ? "active" : string.Empty;

        private string IsToggle() => _stateService.Value.IsToggle ? "toggled" : string.Empty;

        public void Dispose()
        {
            _navigationManager.LocationChanged -= (s, e) => StateHasChanged();

            _stateService.OnStateChange -= StateHasChanged;
        }
    }
}

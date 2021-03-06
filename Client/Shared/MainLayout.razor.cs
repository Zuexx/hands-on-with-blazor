using Microsoft.AspNetCore.Components;
using HandsOnWithBlazor.Client.Models;
using HandsOnWithBlazor.Client.Services;
namespace HandsOnWithBlazor.Client.Shared
{
    public partial class MainLayout : LayoutComponentBase, IDisposable
    {
        [Inject] private SimpleStateContainerService<SimpleStateModel> _stateService { get; set; } = default!;

        protected override void OnInitialized()
        {
            _stateService.OnStateChange += StateHasChanged;
        }

        private string IsToggle() => _stateService.Value.IsToggle ? "toggled" : string.Empty;

        public void Dispose()
        {
            _stateService.OnStateChange -= StateHasChanged;
        }
    }
}

using Microsoft.AspNetCore.Components;
using HandsOnWithBlazor.Client.Services;
using HandsOnWithBlazor.Client.Models;

namespace HandsOnWithBlazor.Client.Shared
{
    public partial class Header : ComponentBase, IDisposable
    {
        [Inject] private SimpleStateContainerService<SimpleStateModel> _stateService { get; set; } = default!;

        protected override void OnInitialized()
        {
            _stateService.OnStateChange += StateHasChanged;
        }

        private void OnToggle()
        {
            var stateModel = _stateService.Value;
            stateModel.IsToggle = !stateModel.IsToggle;
            _stateService.SetValue(stateModel);
        }

        public void Dispose()
        {
            _stateService.OnStateChange -= StateHasChanged;
        }
    }
}

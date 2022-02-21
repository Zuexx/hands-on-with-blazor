using Microsoft.AspNetCore.Components;

namespace HandsOnWithBlazor.Client.Pages
{
    public partial class Counter : ComponentBase
    {
        private int _currentCount = 0;

        private void IncrementCount()
        {
            _currentCount++;
        }
    }
}

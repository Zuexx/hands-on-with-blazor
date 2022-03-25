using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace HandsOnWithBlazor.Client.Pages
{
    public partial class Authenticate : ComponentBase
    {
        private bool isSignUpActivated = false;

        private void HandleSignUpActivated(MouseEventArgs e, bool isActivated)
        {
            isSignUpActivated = isActivated;
        }
    }
}

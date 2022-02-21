using Microsoft.AspNetCore.Components;
using System.Collections;

namespace HandsOnWithBlazor.Client.Shared
{
    public partial class MainLayout : LayoutComponentBase
    {
        private Type _pageType { get; set; }

        private string _activeRoute = string.Empty;

        private Hashtable _routesTable = new Hashtable()
        {
            { "INDEX", "Overview"},
            { "COUNTER", "Counter"},
            { "FETCHDATA", "Fetch Data"}
        };

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected override void OnParametersSet()
        {
            _pageType = (Body.Target as RouteView)?.RouteData.PageType;

            _activeRoute = _routesTable[_pageType.Name.ToUpper()].ToString();

            base.OnParametersSet();
        }
    }
}

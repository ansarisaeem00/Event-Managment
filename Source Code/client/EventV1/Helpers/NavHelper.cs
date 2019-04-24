using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EventV1.Helpers
{
    public static class NavHelper
    {
        public static Page CurrentPage => Application.Current.MainPage;

        private static INavigation Navigation => CurrentPage.Navigation;

        public static async Task PopAsync()
        {
            var masterDetailPage = CurrentPage as MasterDetailPage;

            if (masterDetailPage != null)
                await masterDetailPage.Detail.Navigation.PopAsync();
            else
                await Navigation.PopAsync();
        }

        public static async Task PopModalAsync()
        {
            var masterDetailPage = CurrentPage as MasterDetailPage;

            if (masterDetailPage != null)
                await masterDetailPage.Detail.Navigation.PopModalAsync();
            else
                await Navigation.PopModalAsync();
        }

        public static async Task PushModalAsync(Page page)
        {
            var masterDetailPage = CurrentPage as MasterDetailPage;

            if (masterDetailPage != null)
                await masterDetailPage.Detail.Navigation.PushModalAsync(page);
            else
                await Navigation.PushModalAsync(page);
        }

        public static async Task PushAsync(Page page)
        {
            var masterDetailPage = CurrentPage as MasterDetailPage;

            if (masterDetailPage != null)
                await masterDetailPage.Detail.Navigation.PushAsync(page);
            else
                await Navigation.PushAsync(page);
        }
    }
}

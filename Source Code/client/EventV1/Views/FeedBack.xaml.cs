using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventV1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FeedBack : ContentPage
    {
        public FeedBack()
        {
            InitializeComponent();
            Rating.Maximum = 5;
            Rating.Minimum = 0;
            var Value = Rating.Value;
            //Debug.Write(Value);
        }

        private void Submit_Clicked(object sender, EventArgs e)
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakePicture.Views
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void OnCaptureButtonClicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new CapturePage());
        }
    }
}

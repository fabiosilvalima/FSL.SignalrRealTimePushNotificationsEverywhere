using System;
using Xamarin.Forms;

namespace FSL.XamarinForms
{
    public partial class SignalrPage : ContentPage
    {
        SignalrPageViewModel vm;

        public SignalrPage()
        {
            vm = new SignalrPageViewModel()
            {
                Messages = "Stand by"
            };

            BindingContext = vm;

            InitializeComponent();
        }

        async void Enviar(object sender, EventArgs e)
        {
            await vm.PlaygroundHub.Invoke("sendMessage", Message.Text);

            Message.Text = "";
        }
    }
}

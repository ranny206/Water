using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Water
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Choosing : ContentPage 
    {
        Label header1;
        Label header2;
        public static int amount = 0;
        public static object Selected;
        public Choosing()
        {
            InitializeComponent();
        }
        public void Choose(object sender, EventArgs e)
        {
            amount = 0;
            header1 = new Label
            {
                Text = "Choose drink",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };

            Picker picker = sender as Picker;

            //picker.SelectedIndexChanged += Picker_SelectedIndexChanged;

            Selected = picker.SelectedItem;

            switch (Selected)
            {
                case "Water":
                    image.Source = "water.jpg";
                    break;
                case "Juice":
                    image.Source = "Juice.jpg";
                    break;
                case "Wine":
                    image.Source = "wine.jpg";
                    break;
                case "Something stronger":
                    image.Source = "Stronger.jpg";
                    break;
            }

            Stepper stepper = new Stepper
            {
                Minimum = 0,
                Maximum = 100,
                Increment = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            stepper.ValueChanged += OnStepperValueChanged;



            header2 = new Label
            {
                Text = String.Format("{0}", stepper.Value),
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            Button button_add = new Button
            {
                Text = "Add to order",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Pink
            };

            button_add.Clicked += Button_Clicked_1;


            this.Content = new StackLayout { Children = { header1, picker, image, header2, stepper, button_add } };
        }

        private void OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            header2.Text = String.Format("You chose: {0}", e.NewValue);
            amount = Convert.ToInt32(e.NewValue);
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            if(amount > 0)
            {
                Chosen chosen = new Chosen();
                Navigation.PushAsync(chosen);
            }
         }
    }
}
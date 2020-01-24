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
    public partial class Chosen : ContentPage
    {
        public struct Product
        {
            public object item;
            public int count;
            public Image image;
        }
        public ObservableCollection<Product> Basket = new ObservableCollection<Product>();
        public Chosen()
        {
            InitializeComponent();
            listView.ItemsSource = Basket;
        }

        public void AddToList()
        {
            Product product = new Product();
            Label header = new Label
            {
                Text = "Your order",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };
            product.item = Choosing.Selected;
            product.count = Choosing.amount;
            Image img = new Image();

            switch (product.item)
            {
                case "Water":
                    img.Source = "water.jpg";
                    product.image = img;
                    break;
                case "Juice":
                    img.Source = "Juice.jpg";
                    product.image = img;
                    break;
                case "Wine":
                    img.Source = "wine.jpg";
                    product.image = img;
                    break;
                case "Something stronger":
                    img.Source = "Stronger.jpg";
                    product.image = img;
                    break;
            }
            Basket.Add(product);
        }
        private void Button_Clicked_Back(object sender, EventArgs e)
        {
            if (Basket.Count == 0)
            {
                DisplayAlert("Ooooops", "You chose nothing, dear", "Choose");
            }
            else
            {
                DisplayAlert("Thank you!", "We`ve got your order, dear.", "Bye-Bye");
            }
            Basket.Clear();
            Choosing.amount = 0;
            MainPage mainPage = new MainPage();
            Navigation.PushAsync(mainPage);
        }
        private void Button_Clicked_Add(object sender, EventArgs e)
        {
            Choosing choosing = new Choosing();
            Navigation.PushAsync(choosing);
        }
    }
}
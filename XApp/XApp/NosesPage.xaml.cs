using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XApp.Data;

namespace XApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NosesPage : ContentPage
	{
        List<Nose> Items = new List<Nose>();

		public NosesPage ()
		{
            Items.Add(new Nose() { Name = "Nose 1", Image = "http://www.stickpng.com/assets/images/580b57fbd9996e24bc43bed5.png" });
            Items.Add(new Nose() { Name = "Nose 2", Image = "http://www.stickpng.com/assets/images/580b57fbd9996e24bc43bed5.png" });
            Items.Add(new Nose() { Name = "Nose 3", Image = "http://www.stickpng.com/assets/images/580b57fbd9996e24bc43bed5.png" });
            Items.Add(new Nose() { Name = "Nose 4", Image = "http://www.stickpng.com/assets/images/580b57fbd9996e24bc43bed5.png" });
            Items.Add(new Nose() { Name = "Nose 5", Image = "http://www.stickpng.com/assets/images/580b57fbd9996e24bc43bed5.png" });
            Items.Add(new Nose() { Name = "Nose 6", Image = "http://www.stickpng.com/assets/images/580b57fbd9996e24bc43bed5.png" });
            Items.Add(new Nose() { Name = "Nose 7", Image = "http://www.stickpng.com/assets/images/580b57fbd9996e24bc43bed5.png" });

			InitializeComponent ();
            NoseList.ItemsSource = Items;
        }

        private void NoseList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new MainPage(e.Item as Nose));
        }
    }
}

using Xamarin.Forms;
using System;
using System.Threading.Tasks;

namespace GeoffForms
{
	public partial class GeoffFormsPage : ContentPage
	{

		Image image;

		public GeoffFormsPage()
		{
			InitializeComponent();

			image = this.FindByName<Image>("geoffImage");

		}

		public void OnAskButtonClick(object sender, EventArgs e)
		{
			//Console.WriteLine("You clicked this button");
			OnMagic();

		}

		async void OnMagic() {

			image.BackgroundColor = Color.Blue;

			if (await DisplayAlert(
				"Welcome",
				"Would you like to experience the magical powers of Geoff?",
				"Yes",
				"No"
			))
			{
				//Console.WriteLine("Magic happens here");

			}
			else {
				await DisplayAlert("Bye!","Bye!","Bye!");
			}
		}
	}
}


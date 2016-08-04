using Xamarin.Forms;
using System;
using System.Threading.Tasks;

namespace GeoffForms
{
	public partial class GeoffFormsPage : ContentPage
	{

		Image image;

		ContentView noLabel;
		ContentView yesLabel;

		Color neutralBackground = Color.FromRgb(100,100,100);
		Color highlightedBackground = Color.FromRgb(255,255,200);

		Random random;

		public GeoffFormsPage()
		{
			InitializeComponent();

			image = this.FindByName<Image>("geoffImage");
			noLabel = this.FindByName<ContentView>("no");
			yesLabel = this.FindByName<ContentView>("yes");

			random = new Random();

			Reset();
		}

		void Reset()
		{
			yesLabel.BackgroundColor = neutralBackground;
			noLabel.BackgroundColor = neutralBackground;

			image.BackgroundColor = Color.Black;
			image.Source = "resting.png";
		}

		public void OnAskButtonClick(object sender, EventArgs e)
		{
			DoMagic();
		}

		async void DoMagic() {

			Reset();
			for (int i = 0; i < 10; i++)
			{
				await Task.Delay(100);
				image.BackgroundColor = Color.FromRgb(random.Next(256), random.Next(256), random.Next(256));
			}

			image.BackgroundColor = Color.Black;

			int result = random.Next(0, 2);
			switch (result) {
				case 0:
					SelectYes();
					break;
				case 1:
					SelectNo();
					break;
			}

			await Task.Delay(10 * 1000);
			Reset();
		}

		void SelectYes() {
			Highlight(yesLabel, "left_point.png");
		}

		void SelectNo()
		{
			Highlight(noLabel,"right_point.png");
		}

		void Highlight(ContentView view, String imageSource) {
			
			view.BackgroundColor = highlightedBackground;
			image.Source = imageSource;		
		}

		void Unhighlight(ContentView view, String imageSource)
		{

			view.BackgroundColor = neutralBackground;

		}
	}
}


using Xamarin.Forms;
using System;
using System.Threading.Tasks;

namespace GeoffForms
{
	public partial class GeoffFormsPage : ContentPage
	{
		Image left;
		Image resting;
		Image right;
        
		ContentView noLabel;
		ContentView yesLabel;

        Label noText;
        Label yesText;

		Color neutralBackground = Color.FromRgb(100,100,100);
		Color highlightedBackground = Color.FromRgb(255,255,200);

        Button askButton;

		Grid geoffContainer;

		Random random;

		public GeoffFormsPage()
		{
			InitializeComponent();

			noLabel = this.FindByName<ContentView>("no");
			yesLabel = this.FindByName<ContentView>("yes");
            yesText = this.FindByName<Label>("yesLettering");
            noText = this.FindByName<Label>("noLettering");
            askButton = this.FindByName<Button>("askGeoff");
            geoffContainer = this.FindByName<Grid>("geoffBox");

			random = new Random();

			//geoffContainer = this.FindByName<Grid>("geoffContainer");

			left = new Image();
			left.Source = ImageSource.FromFile("left_point.png");
			right = new Image();
			right.Source = ImageSource.FromFile("right_point.png");
			resting = new Image();
			resting.Source = ImageSource.FromFile("resting.png");

            //Lay the images on top of each other

			geoffContainer.Children.Add(left);
			geoffContainer.Children.Add(right);
			geoffContainer.Children.Add(resting);

			left.IsVisible = false;
			right.IsVisible = false;

			Reset();
		}

		void Reset()
		{
			yesLabel.BackgroundColor = neutralBackground;
			noLabel.BackgroundColor = neutralBackground;

			Unhighlight(yesLabel, yesText, left);
			Unhighlight(noLabel, noText, right);

			resting.IsVisible = true;

			resting.BackgroundColor = Color.Black;

            askButton.IsEnabled = true;   
		}

		public void OnAskButtonClick(object sender, EventArgs e)
		{
            askButton.IsEnabled = false;
			DoMagic();
		}

		async void DoMagic() {

			for (int i = 0; i < 10; i++)
			{
				await Task.Delay(100);
				resting.BackgroundColor = Color.FromRgb(random.Next(256), random.Next(256), random.Next(256));
			}

			//resting.BackgroundColor = Color.Black;

			int result = random.Next(0, 2);
			switch (result) {
				case 0:
					SelectYes();
					break;
				case 1:
					SelectNo();
					break;
			}

			await Task.Delay(5 * 1000);
			Reset();
		}

		void SelectYes() {
			Highlight(yesLabel,yesText,left);
		}

		void SelectNo()
		{
			Highlight(noLabel,noText,right);
		}

		void Highlight(ContentView view, Label text, Image image) {
			
			view.BackgroundColor = highlightedBackground;
            text.TextColor = Color.Black;

			resting.IsVisible = false;
			image.IsVisible = true;
		}

		void Unhighlight(ContentView view, Label text, Image image)
		{
            text.TextColor = Color.White;
			view.BackgroundColor = neutralBackground;
			image.IsVisible = false;
		}
	}
}


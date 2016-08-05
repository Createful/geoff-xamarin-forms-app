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

        //ImageSource left;
        //ImageSource resting;
        //ImageSource right;
        
		ContentView noLabel;
		ContentView yesLabel;

		Color neutralBackground = Color.FromRgb(100,100,100);
		Color highlightedBackground = Color.FromRgb(255,255,200);

		//Grid geoffContainer;

		Random random;

		public GeoffFormsPage()
		{
			InitializeComponent();

			//image = this.FindByName<Image>("geoffImage");


			noLabel = this.FindByName<ContentView>("no");
			yesLabel = this.FindByName<ContentView>("yes");

			random = new Random();

			//geoffContainer = this.FindByName<Grid>("geoffContainer");

			left = new Image();
			left.Source = ImageSource.FromFile("left_point.png");
			right = new Image();
			right.Source = ImageSource.FromFile("right_point.png");
			resting = new Image();
			resting.Source = ImageSource.FromFile("resting.png");

			geoffContainer.Children.Add(left);
			geoffContainer.Children.Add(right);
			geoffContainer.Children.Add(resting);




			left.IsVisible = false;
			right.IsVisible = false;

			//resting = ImageSource.FromFile("resting.png");
   //         left = ImageSource.FromFile("left_point.png");
   //         right = ImageSource.FromFile("right_point.png");

			Reset();
		}

		void Reset()
		{
			yesLabel.BackgroundColor = neutralBackground;
			noLabel.BackgroundColor = neutralBackground;

			Unhighlight(yes, left);
			Unhighlight(no, right);

			resting.IsVisible = true;

			resting.BackgroundColor = Color.Black;
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

			await Task.Delay(10 * 1000);
			Reset();
		}

		void SelectYes() {
			Highlight(yesLabel,left);
		}

		void SelectNo()
		{
			Highlight(noLabel,right);
		}

		void Highlight(ContentView view, Image image) {
			
			view.BackgroundColor = highlightedBackground;

			resting.IsVisible = false;
			image.IsVisible = true;

			//image.SetValue(ItemVisibilityEventArgs,"");

			//image.Source = imageSource;
		}

		void Unhighlight(ContentView view, Image image)
		{

			view.BackgroundColor = neutralBackground;
			image.IsVisible = false;

		}
	}
}


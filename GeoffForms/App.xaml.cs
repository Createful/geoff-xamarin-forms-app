using Xamarin.Forms;

namespace GeoffForms
{
	public partial class App : Application
	{
		public App()
		{
			//InitializeComponent();

			MainPage = new GeoffFormsPage();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}


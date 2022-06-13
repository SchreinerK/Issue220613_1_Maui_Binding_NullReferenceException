namespace Issue220613_1;

public partial class MainPage : ContentPage {
	
	public MainPage() {
		InitializeComponent();

		SequenceA();
		SequenceB();
		SequenceErr();
	}

	/* label.SetBinding(Label.TextProperty, new Binding());
		System.NullReferenceException: 'Object reference not set to an instance of an object.'
		   at Microsoft.Maui.Controls.Binding.Apply(Object context, BindableObject bindObj, BindableProperty targetProperty, Boolean fromBindingContextChanged)
		   at Microsoft.Maui.Controls.BindableObject.SetBinding(BindableProperty targetProperty, BindingBase binding, Boolean fromStyle)
		   at Microsoft.Maui.Controls.BindableObject.SetBinding(BindableProperty targetProperty, BindingBase binding)
		   at Issue220613_1.MainPage.SequenceErr() in D:\Develop\Local\KsWare\Maui\Issue220613_1\MainPage.xaml.cs:line 15
	 */

	private void SequenceErr() {
		var label = new Label();
		label.SetBinding(Label.TextProperty, new Binding()); //<-- NullReferenceException

		var contentView = new ContentView {
			BindingContext = "C#",
			Content = label
		};
		RootLayout.Children.Add(contentView);
	}


	private void SequenceB() {
		var label = new Label();
		label.SetBinding(Label.TextProperty, new Binding(".")); //<-- OK

		var contentView = new ContentView {
			BindingContext = "C#",
			Content = label
		};
		RootLayout.Children.Add(contentView);
	}

	private void SequenceA() {
		var label = new Label();

		var contentView = new ContentView {
			BindingContext = "C#",
			Content = label
		};

		label.SetBinding(Label.TextProperty, new Binding());	//<-- OK


		RootLayout.Children.Add(contentView);
	}

}


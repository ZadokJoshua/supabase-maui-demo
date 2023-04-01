using BooksTracker.ViewModels;

namespace BooksTracker.Views;

public partial class UpdateBookPage : ContentPage
{
	public UpdateBookPage(UpdateBookViewModel updateBookViewModel)
	{
		InitializeComponent();
        BindingContext = updateBookViewModel;
    }
}
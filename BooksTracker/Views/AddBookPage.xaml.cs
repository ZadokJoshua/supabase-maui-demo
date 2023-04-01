using BooksTracker.ViewModels;

namespace BooksTracker.Views;

public partial class AddBookPage : ContentPage
{
	public AddBookPage(AddBookViewModel addBookViewModel)
	{
		InitializeComponent();
        BindingContext = addBookViewModel;
    }
}
using BooksTracker.ViewModels;

namespace BooksTracker.Views;

public partial class BooksListingPage : ContentPage
{
    public BooksListingPage(BooksListingViewModel booksListingViewModel)
	{
		InitializeComponent();
        BindingContext = booksListingViewModel;
    }
}
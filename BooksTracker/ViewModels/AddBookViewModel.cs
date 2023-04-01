using BooksTracker.Models;
using BooksTracker.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BooksTracker.ViewModels;

public partial class AddBookViewModel : ObservableObject
{
    private readonly IDataService _dataService;

    [ObservableProperty]
    private string _bookTitle;
    [ObservableProperty]
    private string _bookAuthor;
    [ObservableProperty]
    private string _bookImageUrl;
    [ObservableProperty]
    private bool _bookIsFinished;

    public AddBookViewModel(IDataService dataService)
    {
        _dataService = dataService;
    }


    [RelayCommand]
    private async Task AddBook()
    {
        try
        {
            if (!string.IsNullOrEmpty(BookTitle))
            {
                Book book = new()
                {
                    Title = BookTitle,
                    Author = BookAuthor,
                    ImageUrl = BookImageUrl,
                    IsFinished = BookIsFinished
                };
                await _dataService.CreateBook(book);

                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "No title!", "OK");
            }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
        }

    }
}

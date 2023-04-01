using BooksTracker.Models;
using BooksTracker.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BooksTracker.ViewModels;

[QueryProperty(nameof(Book), "BookObject")]
public partial class UpdateBookViewModel : ObservableObject
{
    private readonly IDataService _dataService;
    
    [ObservableProperty]
    private Book _book;

    public UpdateBookViewModel(IDataService dataService)
    {
        _dataService = dataService;
    }

    [RelayCommand]
    private async Task UpdateBook()
    {
        if (!string.IsNullOrEmpty(Book.Title))
        {
            await _dataService.UpdateBook(Book);

            await Shell.Current.GoToAsync("..");
        }
        else
        {
            await Shell.Current.DisplayAlert("Error", "No title!", "OK");
        }
    }
}

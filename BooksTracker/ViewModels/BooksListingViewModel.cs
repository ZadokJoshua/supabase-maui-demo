using BooksTracker.Models;
using BooksTracker.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BooksTracker.ViewModels;

public partial class BooksListingViewModel : ObservableObject
{
    private readonly IDataService _dataService;

    public ObservableCollection<Book> Books { get; set; } = new();

    public BooksListingViewModel(IDataService dataService)
    {
        _dataService = dataService;
    }

    [RelayCommand]
    public async Task GetBooks()
    {
        Books.Clear();

        try
        {
            var books = await _dataService.GetBooks();

            if (books.Any())
            {
                foreach (var book in books)
                {
                    Books.Add(book);
                }
            }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
        }
    }

    [RelayCommand]
    private async Task AddBook() => await Shell.Current.GoToAsync("AddBookPage");

    [RelayCommand]
    private async Task DeleteBook(Book book)
    {
        var result = await Shell.Current.DisplayAlert("Delete", $"Are you sure you want to delete \"{book.Title}\"?", "Yes", "No");

        if (result is true)
        {
            try
            {
                await _dataService.DeleteBook(book.Id);
                await GetBooks();
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
    
    [RelayCommand]
    private async Task UpdateBook(Book book) => await Shell.Current.GoToAsync("UpdateBookPage", new Dictionary<string, object>
    {
        {"BookObject", book }
    });
}

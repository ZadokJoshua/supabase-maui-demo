using BooksTracker.Views;

namespace BooksTracker;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        RegisterForRoute<AddBookPage>();
        RegisterForRoute<UpdateBookPage>();
    }

    protected void RegisterForRoute<T>()
    {
        Routing.RegisterRoute(typeof(T).Name, typeof(T));
    }
}

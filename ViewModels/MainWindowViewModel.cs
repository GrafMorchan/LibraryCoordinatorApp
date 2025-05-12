using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia;
using LibraryCoordinatorApp.Models;
using LibraryCoordinatorApp.Models.Data;
using ReactiveUI;
using Tmds.DBus.Protocol;

namespace LibraryCoordinatorApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private List<Author> _authors = DataWorker.GetAllAuthors();
        public List<Author> Authors
        {
            get => _authors;
        }

        private List<Book> _books = DataWorker.GetAllBooks();
        public List<Book> Books
        {
            get => _books;
        }

        private List<BookCopy> _bookCopies = DataWorker.GetAllBookCopies();
        public List<BookCopy> BookCopies
        {
            get => _bookCopies;
        }

        private List<Genre> _genres = DataWorker.GetAllGenres();
        public List<Genre> Genres
        {
            get => _genres;
        }

        private List<Publisher> _publishers = DataWorker.GetAllPublishers();
        public List<Publisher> Publishers
        {
            get => _publishers;
        }


    }
}

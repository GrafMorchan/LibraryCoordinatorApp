using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using LibraryCoordinatorApp.Models.Data;
namespace LibraryCoordinatorApp.Models
{
    public static class DataWorker
    {
        //Получить все позиции
        public static List<Author> GetAllAuthors()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Authors.ToList();
                return result;
            }
        }

        public static List<Book> GetAllBooks()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Books.ToList();
                return result;
            }
        }

        public static List<BookCopy> GetAllBookCopies()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.BookCopies.ToList();
                return result;
            }
        }

        public static List<Genre> GetAllGenres()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Genres.ToList();
                return result;
            }
        }

        public static List<Publisher> GetAllPublishers()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Publishers.ToList();
                return result;
            }
        }

        //Создание позиций

        public static string AddNewAuthor(string first_name, string last_name, string biography)
        {
            string result = "Такой автор уже существует!";
            using(ApplicationContext db = new ApplicationContext())
            {
                bool checkIsExist = db.Authors.Any(el => el.First_name == first_name) && db.Authors.Any(el => el.Last_name == last_name);
                if (!checkIsExist)
                {
                    Author newAuthor = new Author { First_name = first_name, Last_name = last_name, Biography = biography };
                    db.Authors.Add(newAuthor);
                    db.SaveChanges();
                    result = "Автор добавлен!";
                }
                return result;
            }
        }

        public static string AddNewBook(string title, Author author, Genre genre, Publisher publisher, string isbn)
        {
            string result = "Такая книга уже существует!";
            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkIsExist = db.Books.Any(el => el.ISBN == isbn);
                if (!checkIsExist)
                {
                    Book newBook = new Book { Title = title, Author = author, Genre = genre, Publisher = publisher, ISBN = isbn };
                    db.Books.Add(newBook);
                    db.SaveChanges();
                    result = "Книга добавлена!";
                }
                return result;
            }
        }

        public static string AddNewCopyBook(Book book, string status, string barcode)
        {
            string result = "Такой экземпляр уже существует!";
            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkIsExist = db.BookCopies.Any(el => el.Barcode == barcode);
                if (!checkIsExist)
                {
                    BookCopy newBookCopy = new BookCopy { Book = book, Status = status, Barcode = barcode };
                    db.BookCopies.Add(newBookCopy);
                    db.SaveChanges();
                    result = "Экземпляр книги добавлен!";
                }
                return result;
            }
        }

        public static string AddNewGenre(string name)
        {
            string result = "Такой жанр уже существует!";
            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkIsExist = db.Genres.Any(el => el.Name == name);
                if (!checkIsExist)
                {
                    Genre newGenre = new Genre { Name = name };
                    db.Genres.Add(newGenre);
                    db.SaveChanges();
                    result = "Жанр добавлен!";
                }
                return result;
            }
        }

        public static string AddNewPublisher(string name, string adress, string phone)
        {
            string result = "Такой издатель уже существует!";
            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkIsExist = db.Publishers.Any(el => el.Name == name) && db.Publishers.Any(el => el.Address == adress);
                if (!checkIsExist)
                {
                    Publisher newPublisher = new Publisher { Name = name, Address = adress, Phone = phone };
                    db.Publishers.Add(newPublisher);
                    db.SaveChanges();
                    result = "Издатель добавлен!";
                }
                return result;
            }
        }

        //Удаление позиций

        public static string DeleteAuthor(Author author)
        {
            string result = "Такого автора не существует!";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Authors.Remove(author);
                db.SaveChanges();
                result = "Автор был удален!";
            }
            return result;
        }

        public static string DeleteBook(Book book)
        {
            string result = "Такой книги не существует!";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Books.Remove(book);
                db.SaveChanges();
                result = "Книга была удалена!";
            }
            return result;
        }

        public static string DeleteBookCopy(BookCopy bookcopy)
        {
            string result = "Такого экземпляра не существует!";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.BookCopies.Remove(bookcopy);
                db.SaveChanges();
                result = "Экземпляр был удален!";
            }
            return result;
        }

        public static string DeleteGenre(Genre genre)
        {
            string result = "Такого жанра не существует!";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Genres.Remove(genre);
                db.SaveChanges();
                result = "Жанр был удален!";
            }
            return result;
        }

        public static string DeletePublisher(Publisher publisher)
        {
            string result = "Такого издателя не существует!";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Publishers.Remove(publisher);
                db.SaveChanges();
                result = "Издатель был удален!";
            }
            return result;
        }

        //Редактирование позиций

        public static string EditAuthor(Author oldAuthor, string newFirst_name, string newLast_name, string newBiography)
        {
            string result = "Такого автора не существует!";
            using (ApplicationContext db = new ApplicationContext())
            {
                Author author = db.Authors.FirstOrDefault(el => el.Id == oldAuthor.Id);
                if (author != null)
                {
                    author.First_name = newFirst_name;
                    author.Last_name = newLast_name;
                    author.Biography = newBiography;
                    db.SaveChanges();
                    result = "Автор был изменен!";
                }
            }
            return result;
        }

        public static string EditBook(Book oldBook, string newTitle, Author newAuthor, Genre newGenre, Publisher newPublisher, string newISBN)
        {
            string result = "Такой книги не существует!";
            using (ApplicationContext db = new ApplicationContext())
            {
                Book book = db.Books.FirstOrDefault(el => el.Id == oldBook.Id);
                if (book != null)
                {
                    book.Title = newTitle;
                    book.Author = newAuthor;
                    book.Genre = newGenre;
                    book.Publisher = newPublisher;
                    book.ISBN = newISBN;
                    db.SaveChanges();
                    result = "Книга была изменена!";
                }
            }
            return result;
        }

        public static string EditBookCopy(BookCopy oldBookCopy, Book newBook, string newStatus, string newBarcode)
        {
            string result = "Такого экземпляра не существует!";
            using (ApplicationContext db = new ApplicationContext())
            {
                BookCopy bookCopy = db.BookCopies.FirstOrDefault(el => el.Id == oldBookCopy.Id);
                if (bookCopy != null)
                {
                    bookCopy.Book = newBook;
                    bookCopy.Status = newStatus;
                    bookCopy.Barcode = newBarcode;
                    db.SaveChanges();
                    result = "Экземпляр был изменен!";
                }
            }
            return result;
        }

        public static string EditGenre(Genre oldGenre, string newName)
        {
            string result = "Такого жанра не существует!";
            using (ApplicationContext db = new ApplicationContext())
            {
                Genre genre = db.Genres.FirstOrDefault(el => el.Id == oldGenre.Id);
                if (genre != null)
                {
                    genre.Name = newName;
                    db.SaveChanges();
                    result = "Жанр был изменен!";
                }
            }
            return result;
        }

        public static string EditPublisher(Publisher oldPublisher, string newName, string newAdress, string newPhone)
        {
            string result = "Такого издательства не существует!";
            using (ApplicationContext db = new ApplicationContext())
            {
                Publisher publisher = db.Publishers.FirstOrDefault(el => el.Id == oldPublisher.Id);
                if (publisher != null)
                {
                    publisher.Name = newName;
                    publisher.Address = newAdress;
                    publisher.Phone = newPhone;
                    db.SaveChanges();
                    result = "Издательство было изменено!";
                }
            }
            return result;
        }
    }
}

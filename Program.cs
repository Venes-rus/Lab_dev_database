using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;

namespace LibraryAppNHibernate
{
    class Program
    {
        private static ISessionFactory sessionFactory;

        static void Main(string[] args)
        {
            // конфигурация NHibernate
            var configuration = new Configuration();
            configuration.Configure();
            configuration.AddAssembly("LibraryAppNHibernate");
            sessionFactory = configuration.BuildSessionFactory();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Управление книгами");
                Console.WriteLine("2. Управление экземплярами");
                Console.WriteLine("3. Управление читателями");
                Console.WriteLine("4. Управление темами");
                Console.WriteLine("5. Выход");
                Console.Write("Выберите действие: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ManageBooks();
                        break;
                    case "2":
                        ManageCopies();
                        break;
                    case "3":
                        ManageReaders();
                        break;
                    case "4":
                        ManageThemes();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
                Console.WriteLine("Нажмите Enter для продолжения...");
                Console.ReadLine();
            }
        }

        static void ManageBooks()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Просмотреть все книги");
                Console.WriteLine("2. Добавить книгу");
                Console.WriteLine("3. Редактировать книгу");
                Console.WriteLine("4. Удалить книгу");
                Console.WriteLine("5. Поиск книги по названию");
                Console.WriteLine("6. Поиск книги по автору");
                Console.WriteLine("7. Поиск книги по издательству");
                Console.WriteLine("8. Вернуться в главное меню");
                Console.Write("Выберите действие: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowAllBooks();
                        break;
                    case "2":
                        AddBook();
                        break;
                    case "3":
                        EditBook();
                        break;
                    case "4":
                        DeleteBook();
                        break;
                    case "5":
                        SearchBookByTitle();
                        break;
                    case "6":
                        SearchBookByAuthor();
                        break;
                    case "7":
                        SearchBookByPublisher();
                        break;
                    case "8":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
                Console.WriteLine("Нажмите Enter для продолжения...");
                Console.ReadLine();
            }
        }

        static void ManageCopies()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Просмотреть все экземпляры");
                Console.WriteLine("2. Добавить экземпляр");
                Console.WriteLine("3. Редактировать экземпляр");
                Console.WriteLine("4. Удалить экземпляр");
                Console.WriteLine("5. Выдать книгу читателю");
                Console.WriteLine("6. Вернуть книгу");
                Console.WriteLine("7. Поиск экземпляра по инвентарному номеру");
                Console.WriteLine("8. Вернуться в главное меню");
                Console.Write("Выберите действие: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowAllCopies();
                        break;
                    case "2":
                        AddCopy();
                        break;
                    case "3":
                        EditCopy();
                        break;
                    case "4":
                        DeleteCopy();
                        break;
                    case "5":
                        IssueCopyToReader();
                        break;
                    case "6":
                        ReturnCopy();
                        break;
                    case "7":
                        SearchCopyByInventoryNumber();
                        break;
                    case "8":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
                Console.WriteLine("Нажмите Enter для продолжения...");
                Console.ReadLine();
            }
        }

        static void ManageReaders()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Просмотреть всех читателей");
                Console.WriteLine("2. Добавить читателя");
                Console.WriteLine("3. Редактировать читателя");
                Console.WriteLine("4. Удалить читателя");
                Console.WriteLine("5. Поиск читателя по ФИО");
                Console.WriteLine("6. Поиск читателя по телефону");
                Console.WriteLine("7. Вернуться в главное меню");
                Console.Write("Выберите действие: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowAllReaders();
                        break;
                    case "2":
                        AddReader();
                        break;
                    case "3":
                        EditReader();
                        break;
                    case "4":
                        DeleteReader();
                        break;
                    case "5":
                        SearchReaderByFullName();
                        break;
                    case "6":
                        SearchReaderByPhone();
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
                Console.WriteLine("Нажмите Enter для продолжения...");
                Console.ReadLine();
            }
        }

        static void ManageThemes()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Просмотреть все темы");
                Console.WriteLine("2. Добавить тему");
                Console.WriteLine("3. Редактировать тему");
                Console.WriteLine("4. Удалить тему");
                Console.WriteLine("5. Поиск темы по названию");
                Console.WriteLine("6. Вернуться в главное меню");
                Console.Write("Выберите действие: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowAllThemes();
                        break;
                    case "2":
                        AddTheme();
                        break;
                    case "3":
                        EditTheme();
                        break;
                    case "4":
                        DeleteTheme();
                        break;
                    case "5":
                        SearchThemeByName();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
                Console.WriteLine("Нажмите Enter для продолжения...");
                Console.ReadLine();
            }
        }

        static void ShowAllBooks()
        {
            try
            {
                using (var session = sessionFactory.OpenSession())
                {
                    var books = session.CreateQuery("from Book").List<Book>();
                    Console.WriteLine("Список книг:");
                    foreach (var book in books)
                    {
                        Console.WriteLine($"ID: {book.Id}, Шифр: {book.Cipher}, Название: {book.Title}, Автор: {book.FirstAuthor}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при получении списка книг: {ex.Message}");
            }
        }

        static void AddBook()
        {
            try
            {
                Console.Write("Введите шифр книги: ");
                var cipher = Console.ReadLine();
                Console.Write("Введите название книги: ");
                var title = Console.ReadLine();
                Console.Write("Введите автора книги: ");
                var author = Console.ReadLine();
                Console.Write("Введите издательство: ");
                var publisher = Console.ReadLine();
                Console.Write("Введите место издания: ");
                var place = Console.ReadLine();
                Console.Write("Введите год издания: ");
                var year = int.Parse(Console.ReadLine());
                Console.Write("Введите количество страниц: ");
                var pages = int.Parse(Console.ReadLine());
                Console.Write("Введите цену: ");
                var price = decimal.Parse(Console.ReadLine());
                Console.Write("Введите код темы: ");
                var themeCode = int.Parse(Console.ReadLine());

                if (year > DateTime.Now.Year)
                {
                    Console.WriteLine("Год издания не может быть больше текущего года.");
                    return;
                }

                if (price < 0)
                {
                    Console.WriteLine("Цена не может быть отрицательной.");
                    return;
                }

                var newBook = new Book
                {
                    Cipher = cipher,
                    Title = title,
                    FirstAuthor = author,
                    Publisher = publisher,
                    PublicationPlace = place,
                    PublicationYear = year,
                    Pages = pages,
                    Price = price,
                    ThemeCode = themeCode,
                    CopiesCount = 0
                };

                using (var session = sessionFactory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(newBook);
                    transaction.Commit();
                    Console.WriteLine("Книга успешно добавлена!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при добавлении книги: {ex.Message}");
            }
        }

        static void EditBook()
        {
            try
            {
                Console.Write("Введите ID книги для редактирования: ");
                var id = int.Parse(Console.ReadLine());
                using (var session = sessionFactory.OpenSession())
                {
                    var book = session.Get<Book>(id);
                    if (book == null)
                    {
                        Console.WriteLine("Книга не найдена!");
                        return;
                    }

                    Console.WriteLine($"Текущие данные книги (ID: {book.Id}):");
                    Console.WriteLine($"Шифр: {book.Cipher}");
                    Console.WriteLine($"Название: {book.Title}");
                    Console.WriteLine($"Автор: {book.FirstAuthor}");
                    Console.WriteLine($"Издательство: {book.Publisher}");
                    Console.WriteLine($"Место издания: {book.PublicationPlace}");
                    Console.WriteLine($"Год издания: {book.PublicationYear}");
                    Console.WriteLine($"Страницы: {book.Pages}");
                    Console.WriteLine($"Цена: {book.Price}");
                    Console.WriteLine($"Код темы: {book.ThemeCode}");

                    Console.Write("Введите новое название книги: ");
                    book.Title = Console.ReadLine();
                    Console.Write("Введите нового автора книги: ");
                    book.FirstAuthor = Console.ReadLine();
                    Console.Write("Введите новое издательство: ");
                    book.Publisher = Console.ReadLine();
                    Console.Write("Введите новое место издания: ");
                    book.PublicationPlace = Console.ReadLine();
                    Console.Write("Введите новый год издания: ");
                    book.PublicationYear = int.Parse(Console.ReadLine());
                    Console.Write("Введите новое количество страниц: ");
                    book.Pages = int.Parse(Console.ReadLine());
                    Console.Write("Введите новую цену: ");
                    book.Price = decimal.Parse(Console.ReadLine());
                    Console.Write("Введите новый код темы: ");
                    book.ThemeCode = int.Parse(Console.ReadLine());

                    if (book.PublicationYear > DateTime.Now.Year)
                    {
                        Console.WriteLine("Год издания не может быть больше текущего года.");
                        return;
                    }

                    if (book.Price < 0)
                    {
                        Console.WriteLine("Цена не может быть отрицательной.");
                        return;
                    }

                    using (var transaction = session.BeginTransaction())
                    {
                        session.Update(book);
                        transaction.Commit();
                        Console.WriteLine("Книга успешно обновлена!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при редактировании книги: {ex.Message}");
            }
        }

        static void DeleteBook()
        {
            try
            {
                Console.Write("Введите ID книги для удаления: ");
                var id = int.Parse(Console.ReadLine());
                using (var session = sessionFactory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    var book = session.Get<Book>(id);
                    if (book == null)
                    {
                        Console.WriteLine("Книга не найдена!");
                        return;
                    }

                    session.Delete(book);
                    transaction.Commit();
                    Console.WriteLine("Книга успешно удалена!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при удалении книги: {ex.Message}");
            }
        }

        static void SearchBookByTitle()
        {
            try
            {
                Console.Write("Введите часть названия книги для поиска: ");
                var searchTerm = Console.ReadLine();
                using (var session = sessionFactory.OpenSession())
                {
                    var query = session.CreateQuery("from Book where Title like :searchTerm");
                    query.SetParameter("searchTerm", $"%{searchTerm}%");
                    var books = query.List<Book>();

                    if (books.Count == 0)
                    {
                        Console.WriteLine("Книги не найдены.");
                        return;
                    }

                    Console.WriteLine("Результаты поиска:");
                    foreach (var book in books)
                    {
                        Console.WriteLine($"ID: {book.Id}, Название: {book.Title}, Автор: {book.FirstAuthor}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при поиске книги: {ex.Message}");
            }
        }

        static void SearchBookByAuthor()
        {
            try
            {
                Console.Write("Введите часть имени автора для поиска: ");
                var searchTerm = Console.ReadLine();
                using (var session = sessionFactory.OpenSession())
                {
                    var query = session.CreateQuery("from Book where FirstAuthor like :searchTerm");
                    query.SetParameter("searchTerm", $"%{searchTerm}%");
                    var books = query.List<Book>();

                    if (books.Count == 0)
                    {
                        Console.WriteLine("Книги не найдены.");
                        return;
                    }

                    Console.WriteLine("Результаты поиска:");
                    foreach (var book in books)
                    {
                        Console.WriteLine($"ID: {book.Id}, Название: {book.Title}, Автор: {book.FirstAuthor}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при поиске книги: {ex.Message}");
            }
        }

        static void SearchBookByPublisher()
        {
            try
            {
                Console.Write("Введите часть названия издательства для поиска: ");
                var searchTerm = Console.ReadLine();
                using (var session = sessionFactory.OpenSession())
                {
                    var query = session.CreateQuery("from Book where Publisher like :searchTerm");
                    query.SetParameter("searchTerm", $"%{searchTerm}%");
                    var books = query.List<Book>();

                    if (books.Count == 0)
                    {
                        Console.WriteLine("Книги не найдены.");
                        return;
                    }

                    Console.WriteLine("Результаты поиска:");
                    foreach (var book in books)
                    {
                        Console.WriteLine($"ID: {book.Id}, Название: {book.Title}, Автор: {book.FirstAuthor}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при поиске книги: {ex.Message}");
            }
        }

        static void ShowAllCopies()
        {
            try
            {
                using (var session = sessionFactory.OpenSession())
                {
                    var copies = session.CreateQuery("from Copy").List<Copy>();
                    Console.WriteLine("Список экземпляров:");
                    foreach (var copy in copies)
                    {
                        Console.WriteLine($"ID: {copy.Id}, ID книги: {copy.BookId}, Инвентарный номер: {copy.InventoryNumber}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при получении списка экземпляров: {ex.Message}");
            }
        }

        static void AddCopy()
        {
            try
            {
                Console.Write("Введите ID книги: ");
                var bookId = int.Parse(Console.ReadLine());
                Console.Write("Введите инвентарный номер: ");
                var inventoryNumber = Console.ReadLine();

                var newCopy = new Copy
                {
                    BookId = bookId,
                    InventoryNumber = inventoryNumber
                };

                using (var session = sessionFactory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(newCopy);
                    transaction.Commit();
                    Console.WriteLine("Экземпляр успешно добавлен!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при добавлении экземпляра: {ex.Message}");
            }
        }

        static void EditCopy()
        {
            try
            {
                Console.Write("Введите ID экземпляра для редактирования: ");
                var id = int.Parse(Console.ReadLine());
                using (var session = sessionFactory.OpenSession())
                {
                    var copy = session.Get<Copy>(id);
                    if (copy == null)
                    {
                        Console.WriteLine("Экземпляр не найден!");
                        return;
                    }

                    Console.WriteLine($"Текущие данные экземпляра (ID: {copy.Id}):");
                    Console.WriteLine($"ID книги: {copy.BookId}");
                    Console.WriteLine($"Инвентарный номер: {copy.InventoryNumber}");

                    Console.Write("Введите новый инвентарный номер: ");
                    copy.InventoryNumber = Console.ReadLine();

                    using (var transaction = session.BeginTransaction())
                    {
                        session.Update(copy);
                        transaction.Commit();
                        Console.WriteLine("Экземпляр успешно обновлён!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при редактировании экземпляра: {ex.Message}");
            }
        }

        static void DeleteCopy()
        {
            try
            {
                Console.Write("Введите ID экземпляра для удаления: ");
                var id = int.Parse(Console.ReadLine());
                using (var session = sessionFactory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    var copy = session.Get<Copy>(id);
                    if (copy == null)
                    {
                        Console.WriteLine("Экземпляр не найден!");
                        return;
                    }

                    session.Delete(copy);
                    transaction.Commit();
                    Console.WriteLine("Экземпляр успешно удалён!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при удалении экземпляра: {ex.Message}");
            }
        }

        static void IssueCopyToReader()
        {
            try
            {
                Console.Write("Введите ID экземпляра для выдачи: ");
                var copyId = int.Parse(Console.ReadLine());
                Console.Write("Введите ID читателя: ");
                var readerId = int.Parse(Console.ReadLine());

                using (var session = sessionFactory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    var copy = session.Get<Copy>(copyId);
                    if (copy == null)
                    {
                        Console.WriteLine("Экземпляр не найден!");
                        return;
                    }

                    var reader = session.Get<Reader>(readerId);
                    if (reader == null)
                    {
                        Console.WriteLine("Читатель не найден!");
                        return;
                    }

                    copy.IssueDate = DateTime.Now;
                    copy.ReaderId = readerId;

                    session.Update(copy);
                    transaction.Commit();
                    Console.WriteLine("Книга успешно выдана читателю!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при выдаче книги: {ex.Message}");
            }
        }

        static void ReturnCopy()
        {
            try
            {
                Console.Write("Введите ID экземпляра для возврата: ");
                var copyId = int.Parse(Console.ReadLine());

                using (var session = sessionFactory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    var copy = session.Get<Copy>(copyId);
                    if (copy == null)
                    {
                        Console.WriteLine("Экземпляр не найден!");
                        return;
                    }

                    copy.ReturnDate = DateTime.Now;
                    copy.ReaderId = null;

                    session.Update(copy);
                    transaction.Commit();
                    Console.WriteLine("Книга успешно возвращена!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при возврате книги: {ex.Message}");
            }
        }

        static void SearchCopyByInventoryNumber()
        {
            try
            {
                Console.Write("Введите часть инвентарного номера для поиска: ");
                var searchTerm = Console.ReadLine();
                using (var session = sessionFactory.OpenSession())
                {
                    var query = session.CreateQuery("from Copy where InventoryNumber like :searchTerm");
                    query.SetParameter("searchTerm", $"%{searchTerm}%");
                    var copies = query.List<Copy>();

                    if (copies.Count == 0)
                    {
                        Console.WriteLine("Экземпляры не найдены.");
                        return;
                    }

                    Console.WriteLine("Результаты поиска:");
                    foreach (var copy in copies)
                    {
                        Console.WriteLine($"ID: {copy.Id}, ID книги: {copy.BookId}, Инвентарный номер: {copy.InventoryNumber}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при поиске экземпляра: {ex.Message}");
            }
        }

        static void ShowAllReaders()
        {
            try
            {
                using (var session = sessionFactory.OpenSession())
                {
                    var readers = session.CreateQuery("from Reader").List<Reader>();
                    Console.WriteLine("Список читателей:");
                    foreach (var reader in readers)
                    {
                        Console.WriteLine($"ID: {reader.Id}, ФИО: {reader.FullName}, Дата рождения: {reader.BirthDate}, Телефон: {reader.Phone}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при получении списка читателей: {ex.Message}");
            }
        }

        static void AddReader()
        {
            try
            {
                Console.Write("Введите ФИО читателя: ");
                var fullName = Console.ReadLine();
                Console.Write("Введите дату рождения (ГГГГ-ММ-ДД): ");
                var birthDate = DateTime.Parse(Console.ReadLine());
                Console.Write("Введите телефон: ");
                var phone = Console.ReadLine();

                var newReader = new Reader
                {
                    FullName = fullName,
                    BirthDate = birthDate,
                    Phone = phone
                };

                using (var session = sessionFactory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(newReader);
                    transaction.Commit();
                    Console.WriteLine("Читатель успешно добавлен!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при добавлении читателя: {ex.Message}");
            }
        }

        static void EditReader()
        {
            try
            {
                Console.Write("Введите ID читателя для редактирования: ");
                var id = int.Parse(Console.ReadLine());
                using (var session = sessionFactory.OpenSession())
                {
                    var reader = session.Get<Reader>(id);
                    if (reader == null)
                    {
                        Console.WriteLine("Читатель не найден!");
                        return;
                    }

                    Console.WriteLine($"Текущие данные читателя (ID: {reader.Id}):");
                    Console.WriteLine($"ФИО: {reader.FullName}");
                    Console.WriteLine($"Дата рождения: {reader.BirthDate}");
                    Console.WriteLine($"Телефон: {reader.Phone}");

                    Console.Write("Введите новое ФИО: ");
                    reader.FullName = Console.ReadLine();
                    Console.Write("Введите новую дату рождения (ГГГГ-ММ-ДД): ");
                    reader.BirthDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("Введите новый телефон: ");
                    reader.Phone = Console.ReadLine();

                    using (var transaction = session.BeginTransaction())
                    {
                        session.Update(reader);
                        transaction.Commit();
                        Console.WriteLine("Читатель успешно обновлён!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при редактировании читателя: {ex.Message}");
            }
        }

        static void DeleteReader()
        {
            try
            {
                Console.Write("Введите ID читателя для удаления: ");
                var id = int.Parse(Console.ReadLine());
                using (var session = sessionFactory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    var reader = session.Get<Reader>(id);
                    if (reader == null)
                    {
                        Console.WriteLine("Читатель не найден!");
                        return;
                    }

                    session.Delete(reader);
                    transaction.Commit();
                    Console.WriteLine("Читатель успешно удалён!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при удалении читателя: {ex.Message}");
            }
        }

        static void SearchReaderByFullName()
        {
            try
            {
                Console.Write("Введите часть ФИО для поиска: ");
                var searchTerm = Console.ReadLine();
                using (var session = sessionFactory.OpenSession())
                {
                    var query = session.CreateQuery("from Reader where FullName like :searchTerm");
                    query.SetParameter("searchTerm", $"%{searchTerm}%");
                    var readers = query.List<Reader>();

                    if (readers.Count == 0)
                    {
                        Console.WriteLine("Читатели не найдены.");
                        return;
                    }

                    Console.WriteLine("Результаты поиска:");
                    foreach (var reader in readers)
                    {
                        Console.WriteLine($"ID: {reader.Id}, ФИО: {reader.FullName}, Дата рождения: {reader.BirthDate}, Телефон: {reader.Phone}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при поиске читателя: {ex.Message}");
            }
        }

        static void SearchReaderByPhone()
        {
            try
            {
                Console.Write("Введите часть телефона для поиска: ");
                var searchTerm = Console.ReadLine();
                using (var session = sessionFactory.OpenSession())
                {
                    var query = session.CreateQuery("from Reader where Phone like :searchTerm");
                    query.SetParameter("searchTerm", $"%{searchTerm}%");
                    var readers = query.List<Reader>();

                    if (readers.Count == 0)
                    {
                        Console.WriteLine("Читатели не найдены.");
                        return;
                    }

                    Console.WriteLine("Результаты поиска:");
                    foreach (var reader in readers)
                    {
                        Console.WriteLine($"ID: {reader.Id}, ФИО: {reader.FullName}, Дата рождения: {reader.BirthDate}, Телефон: {reader.Phone}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при поиске читателя: {ex.Message}");
            }
        }

        static void ShowAllThemes()
        {
            try
            {
                using (var session = sessionFactory.OpenSession())
                {
                    var themes = session.CreateQuery("from Theme").List<Theme>();
                    Console.WriteLine("Список тем:");
                    foreach (var theme in themes)
                    {
                        Console.WriteLine($"Код темы: {theme.Id}, Название: {theme.ThemeName}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при получении списка тем: {ex.Message}");
            }
        }

        static void AddTheme()
        {
            try
            {
                Console.Write("Введите название темы: ");
                var themeName = Console.ReadLine();

                var newTheme = new Theme
                {
                    ThemeName = themeName
                };

                using (var session = sessionFactory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(newTheme);
                    transaction.Commit();
                    Console.WriteLine("Тема успешно добавлена!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при добавлении темы: {ex.Message}");
            }
        }

        static void EditTheme()
        {
            try
            {
                Console.Write("Введите код темы для редактирования: ");
                var id = int.Parse(Console.ReadLine());
                using (var session = sessionFactory.OpenSession())
                {
                    var theme = session.Get<Theme>(id);
                    if (theme == null)
                    {
                        Console.WriteLine("Тема не найдена!");
                        return;
                    }

                    Console.WriteLine($"Текущие данные темы (Код: {theme.Id}):");
                    Console.WriteLine($"Название: {theme.ThemeName}");

                    Console.Write("Введите новое название темы: ");
                    theme.ThemeName = Console.ReadLine();

                    using (var transaction = session.BeginTransaction())
                    {
                        session.Update(theme);
                        transaction.Commit();
                        Console.WriteLine("Тема успешно обновлена!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при редактировании темы: {ex.Message}");
            }
        }

        static void DeleteTheme()
        {
            try
            {
                Console.Write("Введите код темы для удаления: ");
                var id = int.Parse(Console.ReadLine());
                using (var session = sessionFactory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    var theme = session.Get<Theme>(id);
                    if (theme == null)
                    {
                        Console.WriteLine("Тема не найдена!");
                        return;
                    }

                    session.Delete(theme);
                    transaction.Commit();
                    Console.WriteLine("Тема успешно удалена!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при удалении темы: {ex.Message}");
            }
        }

        static void SearchThemeByName()
        {
            try
            {
                Console.Write("Введите часть названия темы для поиска: ");
                var searchTerm = Console.ReadLine();
                using (var session = sessionFactory.OpenSession())
                {
                    var query = session.CreateQuery("from Theme where ThemeName like :searchTerm");
                    query.SetParameter("searchTerm", $"%{searchTerm}%");
                    var themes = query.List<Theme>();

                    if (themes.Count == 0)
                    {
                        Console.WriteLine("Темы не найдены.");
                        return;
                    }

                    Console.WriteLine("Результаты поиска:");
                    foreach (var theme in themes)
                    {
                        Console.WriteLine($"Код темы: {theme.Id}, Название: {theme.ThemeName}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при поиске темы: {ex.Message}");
            }
        }
    }
}
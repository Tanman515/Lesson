using UnityEngine;
using System.Collections.Generic;  // Нужно для работы с List

public class Book
{
    public string Title;
    public string Author;
    public int Year;
    
    public Book(string title, string author, int year)
    {
        Title = title;
        Author = author;
        Year = year;
    }
    
    public void DisplayInfo()
    {
        Debug.Log($"'{Title}' - {Author} ({Year})");
    }
}

public class TestOOP : MonoBehaviour
{
    // Список книг - может динамически изменять размер
    private List<Book> _library = new List<Book>();
    
    // Метод для добавления книги в библиотеку
    private void AddBook(string title, string author, int year)
    {
        Book newBook = new Book(title, author, year);
        _library.Add(newBook);  // Метод Add добавляет элемент в конец списка
        Debug.Log($"Книга '{title}' добавлена в библиотеку");
    }
    
    // Метод для вывода всех книг
    private void ShowAllBooks()
    {
        Debug.Log("=== Список всех книг ===");
        
        // Цикл for - используем когда нужен номер элемента
        for (int i = 0; i < _library.Count; i++)  // Count - количество элементов в списке
        {
            Debug.Log($"Книга #{i + 1}:");
            _library[i].DisplayInfo();
        }
    }
    
    // Метод для поиска книг по автору
    private void FindBooksByAuthor(string author)
    {
        Debug.Log($"=== Поиск книг автора {author} ===");
        bool found = false;
        
        // Цикл foreach - удобнее когда просто перебираем все элементы
        foreach (Book book in _library)
        {
            if (book.Author == author)
            {
                book.DisplayInfo();
                found = true;
            }
        }
        
        if (!found)
        {
            Debug.Log("Книги этого автора не найдены");
        }
    }
    
    void Start()
    {
        // Добавляем книги в библиотеку
        AddBook("C# для начинающих", "Иванов И.И.", 2020);
        AddBook("Unity разработка", "Петров П.П.", 2021);
        AddBook("Основы программирования", "Сидорова С.С.", 2019);
        AddBook("Продвинутый C#", "Петров П.П.", 2022);
        
        // Выводим все книги
        ShowAllBooks();
        
        // Ищем книги конкретного автора
        FindBooksByAuthor("Петров П.П.");
        FindBooksByAuthor("Неизвестный Автор");
    }
}
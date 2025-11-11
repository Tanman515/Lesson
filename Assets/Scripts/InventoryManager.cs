using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс для хранения данных о предмете.
/// </summary>
public class Item
{
    // Приватные поля (инкапсуляция)
    private string _name;
    private float _weight;
    private float _price;

    /// <summary>
    /// Конструктор. Сохраняет название, вес и цену.
    /// Если вес или цена меньше или равны нулю — заменяет их на 1 и пишет предупреждение.
    /// </summary>
    public Item(string name, float weight, float price)
    {
        _name = name;

        if (weight > 0)
        {
            _weight = weight;
        }
        else
        {
            _weight = 1f;
            Debug.Log("Вес был некорректным (<= 0). Установлено значение 1.");
        }

        if (price > 0)
        {
            _price = price;
        }
        else
        {
            _price = 1f;
            Debug.Log("Цена была некорректной (<= 0). Установлено значение 1.");
        }
    }

    // Методы доступа (геттеры)
    public string GetName()
    {
        return _name;
    }

    public float GetWeight()
    {
        return _weight;
    }

    public float GetPrice()
    {
        return _price;
    }

    /// <summary>
    /// Возвращает строку с полной информацией о предмете.
    /// </summary>
    public string GetInfo()
    {
        return $"Предмет: {_name}, Вес: {_weight}, Цена: {_price}";
    }

    /// <summary>
    /// Увеличивает цену на указанный процент.
    /// Например, percent = 10 означает +10% к цене.
    /// </summary>
    public void IncreasePrice(float percent)
    {
        if (percent < 0)
        {
            Debug.Log("Нельзя увеличить цену на отрицательный процент.");
            return;
        }

        float oldPrice = _price;
        _price = _price + _price * (percent / 100f);

        Debug.Log($"Цена предмета \"{_name}\" увеличена с {oldPrice} до {_price}");
    }
}

/// <summary>
/// Менеджер инвентаря.
/// </summary>
public class InventoryManager : MonoBehaviour
{
    // Приватное поле со списком предметов
    private List<Item> _items = new List<Item>();

    /// <summary>
    /// Добавляет предмет в список.
    /// </summary>
    public void AddItem(Item item)
    {
        if (item == null)
        {
            Debug.Log("Нельзя добавить пустой (null) предмет.");
            return;
        }

        _items.Add(item);
        Debug.Log($"Добавлен: {item.GetInfo()}");
    }

    /// <summary>
    /// Удаляет предмет по названию.
    /// Используется цикл for для поиска.
    /// Удаляется первый найденный предмет с таким названием.
    /// </summary>
    public void RemoveItem(string name)
    {
        // Цикл for, чтобы можно было удалить по индексу
        for (int i = 0; i < _items.Count; i++)
        {
            // Сравнение строк
            if (_items[i].GetName() == name)
            {
                Debug.Log($"Удалён: {_items[i].GetInfo()}");
                _items.RemoveAt(i);
                return;
            }
        }

        Debug.Log($"Предмет с названием \"{name}\" не найден для удаления.");
    }

    /// <summary>
    /// Показывает все предметы в инвентаре.
    /// Используется цикл foreach.
    /// </summary>
    public void ShowInventory()
    {
        if (_items.Count == 0)
        {
            Debug.Log("Инвентарь пуст.");
            return;
        }

        Debug.Log($"Содержимое инвентаря:");

        // Цикл foreach для вывода всех предметов
        foreach (Item item in _items)
        {
            Debug.Log(item.GetInfo());
        }
    }

    /// <summary>
    /// Считает и выводит суммарный вес всех предметов.
    /// Используется цикл for.
    /// </summary>
    public float GetTotalWeight()
    {
        float totalWeight = 0f;

        for (int i = 0; i < _items.Count; i++)
        {
            totalWeight += _items[i].GetWeight();
        }

        Debug.Log("Суммарный вес: " + totalWeight);
        return totalWeight;
    }

    /// <summary>
    /// Считает и выводит суммарную стоимость всех предметов.
    /// Используется цикл for.
    /// </summary>
    public float GetTotalValue()
    {
        float totalValue = 0f;

        for (int i = 0; i < _items.Count; i++)
        {
            totalValue += _items[i].GetPrice();
        }

        Debug.Log("Суммарная стоимость: " + totalValue);
        return totalValue;
    }

    /// <summary>
    /// Находит самый дорогой предмет.
    /// Используется цикл for.
    /// </summary>
    public Item FindMostExpensive()
    {
        if (_items.Count == 0)
        {
            Debug.Log("Инвентарь пуст. Нельзя найти самый дорогой предмет.");
            return null;
        }

        int indexMostExpensive = 0;

        for (int i = 1; i < _items.Count; i++)
        {
            if (_items[i].GetPrice() > _items[indexMostExpensive].GetPrice())
            {
                indexMostExpensive = i;
            }
        }

        Item mostExpensiveItem = _items[indexMostExpensive];
        Debug.Log("Самый дорогой предмет: " + mostExpensiveItem.GetInfo());

        return mostExpensiveItem;
    }

    /// <summary>
    /// Ищет предмет по названию и выводит его информацию.
    /// Используется цикл for.
    /// </summary>
    public Item FindByName(string name)
    {
        for (int i = 0; i < _items.Count; i++)
        {
            if (_items[i].GetName() == name)
            {
                Debug.Log("Найден предмет: " + _items[i].GetInfo());
                return _items[i];
            }
        }

        Debug.Log("Предмет с названием \"" + name + "\" не найден.");
        return null;
    }

    /// <summary>
    /// Здесь создаются тестовые предметы и вызываются все методы для демонстрации.
    /// </summary>
    private void Start()
    {
        // Создаём 6 тестовых предметов
        Item sword   = new Item("Меч",    3.5f, 100f);
        Item shield  = new Item("Щит",    5.0f, 150f);
        Item potion  = new Item("Зелье",  0.5f,  30f);
        Item bow     = new Item("Лук",    2.0f, 120f);
        Item arrows  = new Item("Стрелы", 1.0f,  40f);
        Item ring    = new Item("Кольцо", 0.1f, 300f);

        // Добавляем их в инвентарь
        AddItem(sword);
        AddItem(shield);
        AddItem(potion);
        AddItem(bow);
        AddItem(arrows);
        AddItem(ring);

        // Показываем инвентарь
        ShowInventory();

        // Ищем предмет по названию
        FindByName("Меч");
        FindByName("Кинжал"); // такого нет

        // Находим самый дорогой
        Item expensive = FindMostExpensive();

        // Считаем суммарный вес и стоимость
        GetTotalWeight();
        GetTotalValue();

        // Увеличиваем цену самого дорогого предмета на 20%
        if (expensive != null)
        {
            expensive.IncreasePrice(20f);
        }

        // Пересчитываем стоимость после изменения
        GetTotalValue();

        // Удаляем один предмет
        RemoveItem("Зелье");

        // Показываем инвентарь ещё раз
        ShowInventory();
    }
}

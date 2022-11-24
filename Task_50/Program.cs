/* Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.

Например, задан массив:

1 4 7 2

5 9 2 3

8 4 2 4

17 -> такого числа в массиве нет
*/

int[,] GetArray(int m, int n)                               //Метод создания массива
{
    int[,] Array = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            Array[i, j] = new Random().Next(0, 100);
        }
    }
    return Array;
}
void PrintArray(int[,] Array)                               //Метод вывода массива 
{
    int shiftRow = 1;
    int shiftColumn = 1;

    Console.Write(" \t");                                   //Сдвиг индексов колон массива вправо 
    for (int k = 0; k < Array.GetLength(1); k++)            //Печать индексов колон массива сверху
    {
        Console.Write($"({shiftColumn}) \t");
        shiftColumn++;
    }
    Console.WriteLine();                                    //Пропуск строки для визуального отделения индексов колон массива от значений массива.
    Console.WriteLine();                                    //Перенос последующих элементов строки массива на следующую строку
    for (int i = 0; i < Array.GetLength(0); i++)            //Печать элементов массива
    {
        for (int j = 0; j < Array.GetLength(1); j++)
        {
            if (j == 0)                                     //Печать индексы колон массива слевой стороны
            {
                Console.Write($"|{shiftRow}| \t");
                shiftRow++;
            }
            Console.Write($"{Array[i, j]}  \t");            //Непосредственная печать соответствующего элемента массива 
        }
        Console.WriteLine();
    }
}

string CheckArray(int[,] Array, int row, int column)        //Метод поиска элемента массива по заданным позициям 
{
    string result = "";
    if (row > Array.GetLength(0) - 1 || column > Array.GetLength(1) - 1)
        result = "Такого числа в массиве нет";
    else
    {
        result = Convert.ToString(Array[row, column]);
    }
    return result;
}

Console.Write("Количество строк: ");
int row = Convert.ToInt32(Console.ReadLine());
Console.Write("Количество столбцов: ");
int column = Convert.ToInt32(Console.ReadLine());
int[,] Array = GetArray(row, column);                       //Создание массива через метод
Console.WriteLine();
Console.WriteLine("Ваш массив:");
Console.WriteLine();
PrintArray(Array);                                          //Печать получившегося массива через метод с соответствующими номерами индексов строк и колонн.
                                                            //Чтобы можно было визуально определить позицию элемента массива.
Console.WriteLine();
Console.WriteLine("Поиск элемента массива по позиции: ");
Console.WriteLine();
Console.Write("Введите строку элемента: ");
int rowCheck = Convert.ToInt32(Console.ReadLine()) - 1;         //Строка массива для поиска элемента. Смещаем на -1, т.к. визуально индексы выводятся с 1-ого элемента, а не с 0-ого.
Console.Write("Введите столбец элемента: ");
int columnCheck = Convert.ToInt32(Console.ReadLine()) - 1;      //Столбец массива для поиска элемента. Смещаем на -1, т.к. визуально индексы выводятся с 1-ого элемента, а не с 0-ого.    
string result = CheckArray(Array, rowCheck, columnCheck);        //Поиск элемента через метод проверки
Console.WriteLine();
Console.WriteLine(result);

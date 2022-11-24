/*  Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.

Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3. 
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

double[] AverageColumnArray(int[,] Array)        //Метод подсчёта среднего по столбцам 
{
    double[] arrayAver = new double[Array.GetLength(1)];
    for (int i = 0; i < Array.GetLength(1); i++)
    {
        for (int j = 0; j < Array.GetLength(0); j++)
        {
            arrayAver[i] += Array[j, i];
        }
    }
    for (int i = 0; i < arrayAver.Length; i++)
    {
        arrayAver[i] /= Array.GetLength(0);
    }
    return arrayAver;
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
Console.Write("Среднее: ");
double[] result = AverageColumnArray(Array);        //Подсчёт среднего арифметического по столбцам через метод
for (int i = 0; i < result.Length; i++)
{
    Console.Write($"{result[i]:f1} \t");
}
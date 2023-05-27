// СОРТИРОВКА ПОДСЧЁТОМ спользуется при сортировке целых чисел, если они часто повторяются  в массиве
// АЛГОРИТМ: имеется массив с числами от MIN до MAX, которые многократно повторяются.
// Cоздаём доп массив, где индексы будут обозначать значения элементов из интервала от MIN до MAX из первончального массива,
// а элементы в нём будут обозначать количество этих элементов.
// Если каких-то элементов в начальном массиве нет, то значение в доп массиве будет нулевым, и при построении 
// отсортированного массива эти значения будут пропускаться.
// значение MIN начального массива используется для отпределения длины ДОП массива 
// и для сдвига индексов при построении отсортированного массива.

int UserInput(string message)
{
    Console.Write(message + "... ");
    Int32.TryParse(Console.ReadLine(), out int num);
    return num;
}

int[] GenerateArray(int min, int max, int size)
{
    int[] array = new int[size];
    for (int i = 0; i < size; i++)
        array[i] = new Random().Next(min, max + 1);

    System.Console.WriteLine("Сгенерированный массив:");
    System.Console.WriteLine(String.Join(",", array));
    return array;
}

void CountingSort(int[] array)
{
    int maxElement = array.Max();
    int minElement = array.Min();
    int[] tempArray = new int[maxElement - minElement + 1];
    for (int i = 0; i < array.Length; i++)
        tempArray[array[i] - minElement] += 1;
    // сложный алгоритм с 2мя циклами - сложность O(n^2)
    // int index = 0;
    // for (int i = 0; i < tempArray.Length; i++)
    //     for (int j = 0; j < tempArray[i]; j++)
    //     {
    //         array[index] = i;
    //         index += 1;
    //     }

    // более простой алгоритм - сложность О(n)   
    
    int counter = 0;
    int tempArrayIndex = 0;
    for (int i = 0; i < array.Length; i++)
    {        
        if (counter == tempArray[tempArrayIndex])
        {        
            tempArrayIndex +=1;
            counter = 0;
        }
        while(tempArray[tempArrayIndex] == 0)// пропуск нулевых значений
            tempArrayIndex +=1;

        array[i] = tempArrayIndex + minElement;
        counter +=1;
    }
    System.Console.WriteLine("Отсортированный массив:");
    System.Console.WriteLine(String.Join(",", array) + "\n");    
}


System.Console.WriteLine("===== С О Р Т И Р О В К А   П О Д С Ч Е Т О М ======");
// int arraySize = UserInput("Введите длину массива");
// int minBorder = UserInput("Введите значения элементов: от");
// int maxBorder = UserInput("                            до");
// int[] generatedArray = GenerateArray(minBorder, maxBorder, arraySize);
// CountingSort(generatedArray);

int arraySize = 15;

System.Console.WriteLine("ТЕСТ 1: от 0 до положительного");
int[] generatedArray = GenerateArray(0, 5, arraySize);
CountingSort(generatedArray);

System.Console.WriteLine("ТЕСТ 2; от отрицательного до 0");
generatedArray = GenerateArray(-2, 0, arraySize);
CountingSort(generatedArray);

System.Console.WriteLine("ТЕСТ 3: между положительными");
generatedArray = GenerateArray(5, 10, arraySize);
CountingSort(generatedArray);

System.Console.WriteLine("ТЕСТ 4: между отрицательными");
generatedArray = GenerateArray(-10, -5, arraySize);
CountingSort(generatedArray);

System.Console.WriteLine("ТЕСТ 5: между  ОТР и ПОЛОЖ короткий диапазон");
generatedArray = GenerateArray(-2, 2, arraySize);
CountingSort(generatedArray);

System.Console.WriteLine("ТЕСТ 6: между ОТР и ПОЛОЖ длинный диапазон");
generatedArray = GenerateArray(-5, 5, arraySize);
CountingSort(generatedArray);

// ===== С О Р Т И Р О В К А   П О Д С Ч Е Т О М ======
// ТЕСТ 1: от 0 до положительного
// Сгенерированный массив:
// 3,0,0,5,0,4,5,3,3,0,1,4,5,0,5
// Отсортированный массив:
// 0,0,0,0,0,1,3,3,3,4,4,5,5,5,5

// ТЕСТ 2; от 0 до отрицательного
// Сгенерированный массив:
// 0,0,0,-1,0,-1,-1,-2,-2,-1,0,0,-2,-2,-1
// Отсортированный массив:
// -2,-2,-2,-2,-1,-1,-1,-1,-1,0,0,0,0,0,0

// ТЕСТ 3: между положительными
// Сгенерированный массив:
// 5,8,10,6,10,5,5,9,9,5,5,6,8,9,9
// Отсортированный массив:
// 5,5,5,5,5,6,6,8,8,9,9,9,9,10,10

// ТЕСТ 4: между отрицательными
// Сгенерированный массив:
// -5,-8,-6,-5,-9,-5,-5,-7,-9,-9,-8,-5,-9,-9,-8
// Отсортированный массив:
// -9,-9,-9,-9,-9,-8,-8,-8,-7,-6,-5,-5,-5,-5,-5

// ТЕСТ 5: между  ОТР и ПОЛОЖ короткий диапазон
// Сгенерированный массив:
// 0,-2,0,2,0,2,-1,-1,-2,1,-1,1,2,-1,-2
// Отсортированный массив:
// -2,-2,-2,-1,-1,-1,-1,0,0,0,1,1,2,2,2

// ТЕСТ 6: между ОТР и ПОЛОЖ длинный диапазон
// Сгенерированный массив:
// -2,0,-3,-3,-2,2,-1,0,-5,0,2,4,-4,-4,2
// Отсортированный массив:
// -5,-4,-4,-3,-3,-2,-2,-1,0,0,0,2,2,2,4


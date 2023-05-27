// ЗАДАЧА
// Дан массив с повторяющимися целыми значениями. Необходимо вынести в начало 
// массива уникальные элементы и упорядочить их по возрастанию.

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
    System.Console.WriteLine(" " + String.Join(" ", array));
    return array;
}

bool IsUnique(int currentPosition, int uniqueAmount, int[] array)
{
    for (int i = 0; i < uniqueAmount; i++)
    { 
        if (array[currentPosition] == array[i])
            return false;
    }
    return true;
}

void MoveUniqueSimple(int[] array)
{
    int minElement = array.Min();
    int maxElement = array.Max();
    int[] arrayOfUnique = new int[maxElement - minElement + 1];

    int uniqueAmount = 1;
    for (int i = 1; i < array.Length; i++)
    {
        if (IsUnique(i, uniqueAmount, array))
        {
            array[uniqueAmount] = array[i];
            uniqueAmount +=1;
        }
    }
    Array.Sort(array, 0, uniqueAmount);
    PrintArrayOfUniques(array, uniqueAmount);
}

void MoveUniqueBySet(int[] array)
{
    Array.Sort(array);
    int index = 0;     
    foreach (int i in array.Distinct<int>())
    {
        array[index] = i;
        index++;
    }
    
    int uniqueAmount = array.Distinct<int>().Count();
    PrintArrayOfUniques(array, uniqueAmount);  
}

void PrintArrayOfUniques(int[] array, int uniqueAmount)
{
    System.Console.WriteLine("Массив с уникальными значениями в начале:");
    System.Console.Write("[");
    for (int i = 0; i < uniqueAmount; i++)
    {
        if (i == uniqueAmount - 1) 
            System.Console.Write(array[i]);
        else
            System.Console.Write(array[i] + " ");
    }
    System.Console.Write("] ");
    for (int i = uniqueAmount; i < array.Length; i++)
        System.Console.Write(array[i] + " ");
    System.Console.WriteLine("\n");
}


System.Console.WriteLine("\n==== способ 1  (алгоритм с базовыми конструкциями) ====");
int arraySize = UserInput("Введите длину массива");
int minBorder = UserInput("Введите значения элементов: от");
int maxBorder = UserInput("                            до");
int[] generatedArray = GenerateArray(minBorder, maxBorder, arraySize);
MoveUniqueSimple(generatedArray);

System.Console.WriteLine("==== способ 2 (с использованием коллекций: множества)====");
arraySize = UserInput("Введите длину массива");
minBorder = UserInput("Введите значения элементов: от");
maxBorder = UserInput("                            до");
generatedArray = GenerateArray(minBorder, maxBorder, arraySize);
MoveUniqueBySet(generatedArray);

// РЕШЕНИЕ
// ==== способ 1  (алгоритм с базовыми конструкциями) ====
// Введите длину массива... 30
// Введите значения элементов: от... 5
//                             до... 15
// Сгенерированный массив:
//  15 7 7 9 10 8 7 11 13 8 14 5 15 15 8 9 5 12 12 10 12 9 7 12 7 13 10 12 13 5
// Массив с уникальными значениями в начале:
// [5 7 8 9 10 11 12 13 14 15] 14 5 15 15 8 9 5 12 12 10 12 9 7 12 7 13 10 12 13 5

// ==== способ 2 (с использованием коллекций: множества)====
// Введите длину массива... 30
// Введите значения элементов: от... -2
//                             до... 20
// Сгенерированный массив:
//  2 11 20 2 15 18 14 12 3 19 3 -2 16 3 1 -1 8 14 17 6 15 19 8 0 14 2 10 2 5 18
// Массив с уникальными значениями в начале:
// [-2 -1 0 1 2 3 5 6 8 10 11 12 14 15 16 17 18 19 20] 14 14 15 15 16 17 18 18 19 19 20
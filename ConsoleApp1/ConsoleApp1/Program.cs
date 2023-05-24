using System;

class Program
{
    static void Main()
    {
        int[] array = new int[300];
        Random random = new Random();

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(-200, 201); // Заповнюємо масив випадковими числами в діапазоні від -200 до 200
        }

        Console.WriteLine("Початковий масив:");
        PrintArray(array);

        // Знаходимо послідовності від'ємних чисел і виконуємо обмін місцями для кожної послідовності
        bool negativeSequenceStarted = false;
        int startIndex = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0)
            {
                if (!negativeSequenceStarted)
                {
                    negativeSequenceStarted = true;
                    startIndex = i;
                }
            }
            else
            {
                if (negativeSequenceStarted)
                {
                    negativeSequenceStarted = false;
                    int minIndex = FindMinIndex(array, startIndex, i - 1);
                    int maxIndex = FindMaxIndex(array, startIndex, i - 1);
                    Swap(array, minIndex, maxIndex);
                }
            }
        }

        Console.WriteLine("Масив після обміну місцями для послідовностей від'ємних чисел:");
        PrintArray(array);
    }

    static int FindMinIndex(int[] array, int startIndex, int endIndex)
    {
        int minIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (array[i] < array[minIndex])
            {
                minIndex = i;
            }
        }
        return minIndex;
    }

    static int FindMaxIndex(int[] array, int startIndex, int endIndex)
    {
        int maxIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (array[i] > array[maxIndex])
            {
                maxIndex = i;
            }
        }
        return maxIndex;
    }

    static void Swap(int[] array, int index1, int index2)
    {
        int temp = array[index1];
        array[index1] = array[index2];
        array[index2] = temp;
    }

    static void PrintArray(int[] array)
    {
        foreach (int num in array)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}




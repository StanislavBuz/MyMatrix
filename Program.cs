using System;

class Program
{
    static void Main(string[] args)
    {
        bool continueProgram = true;

        while (continueProgram)
        {
            MyMatrix matrix1 = InputMatrix("Введіть першу матрицю:");

            Console.WriteLine("Чи бажаєте транспонувати цю матрицю?");
            Console.WriteLine("1. Так");
            Console.WriteLine("2. Ні");
            int transposeChoice = int.Parse(Console.ReadLine());

            if (transposeChoice == 1)
            {
                matrix1.TransposeMe();
                Console.WriteLine("Транспонована перша матриця:");
                Console.WriteLine(matrix1);
            }

            Console.WriteLine("Виберіть дію:");
            Console.WriteLine("1. Додавання двох матриць");
            Console.WriteLine("2. Множення двох матриць");
            Console.WriteLine("3. Створити транспоновану матрицю");
            Console.WriteLine("4. Завершити програму");
            int choice = int.Parse(Console.ReadLine());

            MyMatrix result = null;

            switch (choice)
            {
                case 1:
                    MyMatrix matrix2 = InputMatrix("Введіть другу матрицю:");
                    Console.WriteLine("Друга матриця:");
                    Console.WriteLine(matrix2);

                    Console.WriteLine("Чи бажаєте транспонувати цю матрицю?");
                    Console.WriteLine("1. Так");
                    Console.WriteLine("2. Ні");
                    int transposeChoice2 = int.Parse(Console.ReadLine());

                    if (transposeChoice2 == 1)
                    {
                        matrix2.TransposeMe();
                        Console.WriteLine("Транспонована друга матриця:");
                        Console.WriteLine(matrix2);
                    }

                    result = matrix1 + matrix2;
                    break;

                case 2:
                    MyMatrix matrix3 = InputMatrix("Введіть другу матрицю:");
                    Console.WriteLine("Друга матриця:");
                    Console.WriteLine(matrix3);

                    Console.WriteLine("Чи бажаєте транспонувати цю матрицю?");
                    Console.WriteLine("1. Так");
                    Console.WriteLine("2. Ні");
                    int transposeChoice3 = int.Parse(Console.ReadLine());

                    if (transposeChoice3 == 1)
                    {
                        matrix3.TransposeMe();
                        Console.WriteLine("Транспонована друга матриця:");
                        Console.WriteLine(matrix3);
                    }

                    result = matrix1 * matrix3;
                    break;

                case 3:
                    MyMatrix transposedMatrix = matrix1.GetTransposedCopy();
                    Console.WriteLine("Транспонована матриця:");
                    Console.WriteLine(transposedMatrix);
                    break;

                case 4:
                    continueProgram = false;
                    break;

                default:
                    Console.WriteLine("Невідома опція.");
                    break;
            }

            if (result != null)
            {
                Console.WriteLine("Результат операції:");
                Console.WriteLine(result);
            }
        }
    }

    static MyMatrix InputMatrix(string message)
    {
        Console.WriteLine(message);
        Console.Write("Введіть кількість рядків матриці: ");
        int rows = int.Parse(Console.ReadLine());

        Console.Write("Введіть кількість стовпців матриці: ");
        int cols = int.Parse(Console.ReadLine());

        double[,] inputMatrix = new double[rows, cols];

        Console.WriteLine("Введіть елементи матриці:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"Елемент [{i}, {j}]: ");
                inputMatrix[i, j] = double.Parse(Console.ReadLine());
            }
        }

        MyMatrix matrix = new MyMatrix(inputMatrix);

        Console.WriteLine("Матриця:");
        Console.WriteLine(matrix);

        return matrix;
    }
}

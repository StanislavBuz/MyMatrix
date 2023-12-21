using System;

partial class MyMatrix
{
    public static MyMatrix operator +(MyMatrix matrix1, MyMatrix matrix2)
    {
        if (matrix1.Height != matrix2.Height || matrix1.Width != matrix2.Width)
            throw new ArgumentException("Розміри матриць повинні бути однаковими для додавання");

        MyMatrix result = new MyMatrix(matrix1);
        for (int i = 0; i < matrix1.Height; i++)
        {
            for (int j = 0; j < matrix1.Width; j++)
            {
                result[i, j] += matrix2[i, j];
            }
        }

        return result;
    }

    public static MyMatrix operator *(MyMatrix matrix1, MyMatrix matrix2)
    {
        if (matrix1.Width != matrix2.Height)
            throw new ArgumentException("Кількість стовпців в першій матриці повинна дорівнювати кількості рядків у другій матриці для множення");

        int rows = matrix1.Height;
        int cols = matrix2.Width;
        int commonDim = matrix1.Width;

        MyMatrix result = new MyMatrix(new double[rows, cols]);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                double sum = 0;
                for (int k = 0; k < commonDim; k++)
                {
                    sum += matrix1[i, k] * matrix2[k, j];
                }
                result[i, j] = sum;
            }
        }

        return result;
    }

    private double[,] GetTransposedArray()
    {
        int rows = Height;
        int cols = Width;
        double[,] transposedArray = new double[cols, rows];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                transposedArray[j, i] = matrix[i, j];
            }
        }

        return transposedArray;
    }

    public MyMatrix GetTransposedCopy()
    {
        double[,] transposedArray = GetTransposedArray();
        return new MyMatrix(transposedArray);
    }

    public void TransposeMe()
    {
        double[,] transposedArray = GetTransposedArray();
        matrix = transposedArray;
    }
}

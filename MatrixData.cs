using System;

partial class MyMatrix
{
    private double[,] matrix;

    public MyMatrix(MyMatrix other)
    {
        this.matrix = (double[,])other.matrix.Clone();
    }

    public MyMatrix(double[,] array)
    {
        if (array == null)
            throw new ArgumentNullException("Масив не може бути пустим");

        int rows = array.GetLength(0);
        int cols = array.GetLength(1);

        if (rows == 0 || cols == 0)
            throw new ArgumentException("Розміри масиву повинні бути більше 0");

        for (int i = 0; i < rows; i++)
        {
            if (array.GetLength(1) != cols)
                throw new ArgumentException("Вхідний масив не є прямокутним");
        }

        this.matrix = (double[,])array.Clone();
    }

    public MyMatrix(double[][] jaggedArray)
    {
        if (jaggedArray == null)
            throw new ArgumentNullException("Зубчастий масив не може бути пустим");

        int rows = jaggedArray.Length;
        if (rows == 0)
            throw new ArgumentException("Зубчастий масив повинен містити принаймні один рядок");

        int cols = jaggedArray[0].Length;

        for (int i = 0; i < rows; i++)
        {
            if (jaggedArray[i].Length != cols)
                throw new ArgumentException("Вхідний зубчастий масив не є прямокутним");
        }

        this.matrix = new double[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                this.matrix[i, j] = jaggedArray[i][j];
            }
        }
    }

    public MyMatrix(string[] rowsData)
    {
        if (rowsData == null)
            throw new ArgumentNullException("Вхідний масив не може бути пустим");

        int rows = rowsData.Length;
        if (rows == 0)
            throw new ArgumentException("Вхідний масив повинен містити принаймні один рядок");

        string[] firstRow = rowsData[0].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        int cols = firstRow.Length;

        for (int i = 0; i < rows; i++)
        {
            string[] row = rowsData[i].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            if (row.Length != cols)
                throw new ArgumentException("Вхідні дані не є прямокутними");
        }

        this.matrix = new double[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            string[] row = rowsData[i].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < cols; j++)
            {
                if (!double.TryParse(row[j], out this.matrix[i, j]))
                    throw new ArgumentException("Невірний формат даних в вхідному масиві");
            }
        }
    }

    public int Height => matrix.GetLength(0);
    public int Width => matrix.GetLength(1);

    public double this[int row, int col]
    {
        get => matrix[row, col];
        set => matrix[row, col] = value;
    }

    public override string ToString()
    {
        string result = "";
        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                result += matrix[i, j].ToString() + "\t";
            }
            result += Environment.NewLine;
        }
        return result;
    }
}

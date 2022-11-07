/*---------------------------Data Types declaration------------------------------*/
double[,] result_of_inverse = new double[3, 3];
double[,] first_array = new double[3, 3];
double[,] second_array = new double[3, 3];
/*--------------------------Functions Defenation---------------------------------*/
static double get_det(double[,] matrix)
{
    double det = 0;
    for (int coulmn = 0; coulmn < 3; coulmn++)
    {
        det += (matrix[0, coulmn] * (matrix[1, (coulmn + 1) % 3] * matrix[2, (coulmn + 2) % 3] - matrix[1, (coulmn + 2) % 3] * matrix[2, (coulmn + 1) % 3]));
    }

    return det;
}
static double[,] get_inverse(double[,] matrix)
{
    double det = get_det(matrix);
    double[,] result = new double[3, 3];
    if (det == 0)
    {
        Console.WriteLine("Matrix is equal to 0");
        return null;
    }
    else
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                result[i, j] = ( (matrix[(j + 1) % 3, (i + 1) % 3] * matrix[(j + 2) % 3, (i + 2) % 3]) - (matrix[(j + 1) % 3, (i + 2) % 3] * matrix[(j + 2) % 3, (i + 1) % 3]) ) / det;
            }
        }
        return result;
    }
}
static void get_elements(double[,] matrix)
{
    for (int row = 0; row < 3; row++)
    {
        for (int coulmn = 0; coulmn < 3; coulmn++)
        {
            Console.WriteLine($"Enter the Element [{row},{coulmn}] :");
            matrix[row, coulmn] = int.Parse(Console.ReadLine());
        }
    }
}
static void multiply_2matrix(double[,] matrix1, double[,] matrix2)
{
    double[,] result = new double[3, 3];
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            for (int k = 0; k < 3; k++)
            {
                result[i, j] += matrix1[i, k] * matrix2[k, j];
            }
        }
    }
    for (int row = 0; row < 3; row++)
    {
        for (int coulmn = 0; coulmn < 3; coulmn++)
        {
            Console.Write($"{result[row, coulmn]}\t");
        }
        Console.WriteLine();
    }
}
/*--------------------------------Main function------------------------------------*/
Console.WriteLine("Enter elements of the first matrix :\n");
get_elements(first_array);
Console.WriteLine("Enter elements of the second matrix :\n");
get_elements(second_array);
result_of_inverse = get_inverse(second_array);
Console.WriteLine();
Console.WriteLine("Result of devision is :");
multiply_2matrix(first_array, result_of_inverse);

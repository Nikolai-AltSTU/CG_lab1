using System;
using System.Collections.Generic;
using System.Threading.Tasks;


/* использован код Джеймса Маккафри
 * https://docs.microsoft.com/ru-ru/archive/msdn-magazine/2012/december/csharp-matrix-decomposition
 */


namespace lab1
{
    class Matrix
    {
        int rows = 0, cols = 0;
        protected double[][] matr;
        public Matrix(int rows, int cols)
        {
            this.cols = cols;
            this.rows = rows;
            matr = MatrixCreate(rows, cols);
        }
        public Matrix(double[][] matrix)
        {
            this.rows = matrix.Length;
            this.cols = matrix[0].Length;
            this.matr = matrix;
        }

        public double[] this[int i]
        {
            get { return matr[i]; }
            set { matr[i] = value; }
        }

        static protected double[][] MatrixCreate(int rows, int cols)
        {
            // Создаем матрицу, полностью инициализированную
            // значениями 0.0. Проверка входных параметров опущена.
            double[][] result = new double[rows][];
            for (int i = 0; i < rows; ++i)
                result[i] = new double[cols]; // автоинициализация в 0.0
            return result;
        }
        static Matrix MatrixProduct(Matrix matrixA, Matrix matrixB)
        {
            int aRows = matrixA.rows, aCols = matrixA.cols, bCols = matrixB.cols;
            if (aCols != matrixB.rows)
                throw new Exception("Матрицы разной размерности");
            Matrix result = new Matrix(aRows, bCols);
            Parallel.For(0, aRows, i =>
            {
                for (int j = 0; j < bCols; ++j)
                    for (int k = 0; k < aCols; ++k)
                        result[i][j] += matrixA[i][k] * matrixB[k][j];
            }
            );
            return result;
        }

        public static Matrix operator!(Matrix A)
        {
            return MatrixInverse(A);
        }

        public static Matrix operator+ (Matrix A, Matrix B)
        {
            if(A.cols != B.cols || A.rows != B.rows)
                throw new Exception("Матрицы разной размерности");
            int aRows = A.rows, aCols = A.cols;
            Matrix result = new Matrix(aRows, aCols);
            Parallel.For(0, aRows, i =>
            {
                for (int k = 0; k < aCols; ++k)
                    result[i][k] = A[i][k] + B[i][k];
            });
            return result;
        }

        public static Matrix operator- (Matrix A, Matrix B)
        {
            if (A.cols != B.cols || A.rows != B.rows)
                throw new Exception("Матрицы разной размерности");
            int aRows = A.rows, aCols = A.cols;
            Matrix result = new Matrix(aRows, aCols);
            Parallel.For(0, aRows, i =>
            {
                for (int k = 0; k < aCols; ++k)
                    result[i][k] = A[i][k] - B[i][k];
            });
            return result;
        }

        public static Matrix operator *(Matrix A, double number)
        {
            int aRows = A.rows, aCols = A.cols;
            Matrix result = new Matrix(aRows, aCols);
            Parallel.For(0, aRows, i =>
            {
                for (int k = 0; k < aCols; ++k)
                    result[i][k] = A[i][k] * number;
            });
            return result;
        }
        
        public static double[] operator *(double[] arr, Matrix A)
        {
            int aRows = A.rows, aCols = A.cols;
            if (arr.Length != aRows)
                throw new Exception("Невозможно выполнить умножение");
            double[] result = new double[aCols];
            Parallel.For(0, aCols, j =>
            {
                result[j] = 0;
                for (int k = 0; k < aRows; ++k)
                    result[j] += A[k][j] * arr[k];
            });
            return result;
        }

        static private double[] HelperSolve(double[][] luMatrix, double[] b)
        {
            // Решаем luMatrix * x = b
            int n = luMatrix.Length;
            double[] x = new double[n];
            b.CopyTo(x, 0);
            for (int i = 1; i < n; ++i)
            {
                double sum = x[i];
                for (int j = 0; j < i; ++j)
                    sum -= luMatrix[i][j] * x[j];
                x[i] = sum;
            }
            x[n - 1] /= luMatrix[n - 1][n - 1];
            for (int i = n - 2; i >= 0; --i)
            {
                double sum = x[i];
                for (int j = i + 1; j < n; ++j)
                    sum -= luMatrix[i][j] * x[j];
                x[i] = sum / luMatrix[i][i];
            }
            return x;
        }
        protected static double[][] MatrixDuplicate(double[][] matrix)
        {
            // Предполагается, что матрица не нулевая
            double[][] result = MatrixCreate(matrix.Length, matrix[0].Length);
            for (int i = 0; i < matrix.Length; ++i) // Копирование значений
                for (int j = 0; j < matrix[i].Length; ++j)
                    result[i][j] = matrix[i][j];
            return result;
        }

        protected static double[][] MatrixDecompose(double[][] matrix, out int[] perm, out int toggle)
        {
            // Разложение LUP Дулитла. Предполагается,
            // что матрица квадратная.
            int n = matrix.Length; // для удобства
            double[][] result = MatrixDuplicate(matrix);
            perm = new int[n];
            for (int i = 0; i < n; ++i) { perm[i] = i; }
            toggle = 1;
            for (int j = 0; j < n - 1; ++j) // каждый столбец
            {
                double colMax = Math.Abs(result[j][j]); // Наибольшее значение в столбце j
                int pRow = j;
                for (int i = j + 1; i < n; ++i)
                {
                    if (result[i][j] > colMax)
                    {
                        colMax = result[i][j];
                        pRow = i;
                    }
                }
                if (pRow != j) // перестановка строк
                {
                    double[] rowPtr = result[pRow];
                    result[pRow] = result[j];
                    result[j] = rowPtr;
                    int tmp = perm[pRow]; // Меняем информацию о перестановке
                    perm[pRow] = perm[j];
                    perm[j] = tmp;
                    toggle = -toggle; // переключатель перестановки строк
                }
                if (Math.Abs(result[j][j]) < 1.0E-20)
                    return null;
                for (int i = j + 1; i < n; ++i)
                {
                    result[i][j] /= result[j][j];
                    for (int k = j + 1; k < n; ++k)
                        result[i][k] -= result[i][j] * result[j][k];
                }
            } // основной цикл по столбцу j
            return result;
        }

        static Matrix MatrixInverse(Matrix matrix)
        {
            int n = matrix.matr.Length;
            double[][] result = MatrixDuplicate(matrix.matr);
            int[] perm;
            int toggle;
            double[][] lum = MatrixDecompose(matrix.matr, out perm, out toggle);
            if (lum == null)
                throw new Exception("Unable to compute inverse");
            double[] b = new double[n];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (i == perm[j])
                        b[j] = 1.0;
                    else
                        b[j] = 0.0;
                }
                double[] x = HelperSolve(lum, b);
                for (int j = 0; j < n; ++j)
                    result[j][i] = x[j];
            }
            return new Matrix(result);
        }
    }

    
}

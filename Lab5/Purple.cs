using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;

            // code here
            answer = new int[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int cnt = 0;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[j, i] < 0) cnt++;
                }
                answer[i] = cnt;
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int[] MN = new int[matrix.GetLength(0)];
            int[] MNi = new int[matrix.GetLength(0)];
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int mn = int.MaxValue;
                int mni = int.MaxValue;
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    if (matrix[rows, cols] < mn)
                    {
                        mn = matrix[rows, cols];
                        mni = cols;
                    }

                }
                MN[rows] = mn;
                MNi[rows] = mni;
            }
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int temp = matrix[rows, 0], temp2;
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    if (cols < MNi[rows])
                    {
                        temp2 = temp;
                        temp = matrix[rows, cols + 1];
                        matrix[rows, cols + 1] = temp2;
                    }
                }
                matrix[rows, 0] = MN[rows];
            }
            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            answer = new int[matrix.GetLength(0), matrix.GetLength(1) + 1];
            int[] MX = new int[matrix.GetLength(0)];
            int[] MXi = new int[matrix.GetLength(0)];
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int mn = int.MinValue;
                int mni = int.MinValue;
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    if (matrix[rows, cols] > mn)
                    {
                        mn = matrix[rows, cols];
                        mni = cols;
                    }

                }
                MX[rows] = mn;
                MXi[rows] = mni;
            }

            for (int rows = 0; rows < answer.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    if (cols < MXi[rows])
                    {
                        answer[rows, cols] = matrix[rows, cols];
                    }
                    if (cols > MXi[rows])
                    {
                        answer[rows, cols + 1] = matrix[rows, cols];
                    }
                }
                answer[rows, MXi[rows] + 1] = MX[rows];
                answer[rows, MXi[rows]] = MX[rows];
            }
            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here
            int[] MX = new int[matrix.GetLength(0)];
            int[] MXi = new int[matrix.GetLength(0)];
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int mn = int.MinValue;
                int mni = int.MinValue;
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    if (matrix[rows, cols] > mn)
                    {
                        mn = matrix[rows, cols];
                        mni = cols;
                    }

                }
                MX[rows] = mn;
                MXi[rows] = mni;
            }

            int[] av = new int[matrix.GetLength(0)];
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int cnt = 0, a = 0;
                for (int cols = MXi[rows] + 1; cols < matrix.GetLength(1); cols++)
                {
                    if (matrix[rows, cols] > 0)
                    {
                        cnt++;
                        a += matrix[rows, cols];
                    }
                }
                if (a != 0 && cnt != 0) av[rows] = a / cnt;
                else av[rows] = 0;
                if (cnt == 0) av[rows] = int.MinValue;
            }

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < MXi[rows]; cols++)
                {
                    if (av[rows] != int.MinValue && matrix[rows, cols] < 0)
                    {
                        matrix[rows, cols] = av[rows];
                    }
                }
            }

            // end

        }
        public void Task5(int[,] matrix, int k)
        {

            // code here
            if (k < 0 || k >= matrix.GetLength(1)) return;
            int[] MX = new int[matrix.GetLength(0)];
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int mn = matrix[rows, 0];
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    if (matrix[rows, cols] > mn)
                    {
                        mn = matrix[rows, cols];
                    }

                }
                MX[matrix.GetLength(0) - rows - 1] = mn;
            }

            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                matrix[j, k] = MX[j];
            }
            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (array.Length != cols)
                return;
            for (int j = 0; j < cols; j++)
            {
                int mx = matrix[0, j];
                int mxR = 0;

                for (int i = 1; i < rows; i++)
                {
                    if (matrix[i, j] > mx)
                    {
                        mx = matrix[i, j];
                        mxR = i;
                    }
                }
                if (j < array.Length && array[j] > mx)
                {
                    matrix[mxR, j] = array[j];
                }
            }
            // end

        }
        public void Task7(int[,] matrix)
        {
            // code here
            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);
            int[] mi = new int[r];
            int[] ind = new int[r];

            for (int i = 0; i < r; i++)
            {
                ind[i] = i;
                int cur = matrix[i, 0];
                for (int j = 1; j < c; j++)
                {
                    if (matrix[i, j] < cur)
                    {
                        cur = matrix[i, j];
                    }
                }
                mi[i] = cur;
            }

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < r - 1 - i; j++)
                {
                    if (mi[j] < mi[j + 1])
                    {
                        int tVal = mi[j];
                        mi[j] = mi[j + 1];
                        mi[j + 1] = tVal;

                        int tnd = ind[j];
                        ind[j] = ind[j + 1];
                        ind[j + 1] = tnd;
                    }
                }
            }

            int[,] temp = new int[r, c];
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    temp[i, j] = matrix[ind[i], j];
                }
            }

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    matrix[i, j] = temp[i, j];
                }
            }
            // end
        }

        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return answer;

            int n = matrix.GetLength(0);
            answer = new int[n * 2 - 1];

            for (int k = 0; k < answer.Length; k++)
            {
                int sum = 0;
                int i, j;

                if (k < n)
                {
                    i = (n - 1) - k;
                    j = 0;
                }
                else
                {
                    i = 0;
                    j = k - (n - 1);
                }

                while (i < n && j < n)
                {
                    sum += matrix[i, j];
                    i++;
                    j++;
                }
                answer[k] = sum;
            }
            // end

            return answer;
        }

        public void Task9(int[,] matrix, int k)
        {
            // code here
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
            if (rows != cols || k > rows - 1 || k < 0)
                return;
            int abs = matrix[0, 0], iMx = 0, jMx = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (Math.Abs(matrix[i, j]) > Math.Abs(abs))
                    {
                        abs = matrix[i, j];
                        iMx = i;
                        jMx = j;
                    }
                }
            }

            for (int i = 0; i < rows; i++)
            {
                (matrix[i, k], matrix[i, jMx]) = (matrix[i, jMx], matrix[i, k]);
            }

            if (k < 2)
            {
                for (int j = k + 1; j < cols - 1; j++)
                {
                    for (int i = 0; i < rows; i++)
                    {
                        (matrix[i, j], matrix[i, j + 1]) = (matrix[i, j + 1], matrix[i, j]);
                    }
                }
            }

            for (int j = 0; j < cols; j++)
            {
                (matrix[iMx, j], matrix[k, j]) = (matrix[k, j], matrix[iMx, j]);
            }
            // end
        }

        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here
            if (A.GetLength(1) != B.GetLength(0))
                return answer;

            int Ar = A.GetLength(0);
            int Br = B.GetLength(1);
            int cl = A.GetLength(1);

            answer = new int[Ar, Br];

            for (int i = 0; i < Ar; i++)
            {
                for (int j = 0; j < Br; j++)
                {
                    int dot = 0;
                    for (int k = 0; k < cl; k++)
                    {
                        dot += A[i, k] * B[k, j];
                    }
                    answer[i, j] = dot;
                }
            }
            // end

            return answer;
        }

        public int[][] Task11(int[,] matrix)
        {
            int[][] answer = null;

            // code here
            answer = new int[matrix.GetLength(0)][];
            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);

            for (int i = 0; i < r; i++)
            {
                int cnt = 0;
                for (int j = 0; j < c; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        cnt++;
                    }
                }

                answer[i] = new int[cnt];
                int idx = 0;

                for (int j = 0; j < c; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        answer[i][idx] = matrix[i, j];
                        idx++;
                    }
                }
            }
            // end

            return answer;
        }

        public int[,] Task12(int[][] array)
        {
            int[,] answer = null;

            // code here
            int tl = 0;

            for (int i = 0; i < array.Length; i++)
            {
                tl += array[i].Length;
            }

            if (tl == 0)
                return new int[0, 0];

            int size = (int)Math.Ceiling(Math.Sqrt(tl));
            answer = new int[size, size];

            int r = 0;
            int c = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (c == size)
                    {
                        r++;
                        c = 0;
                    }
                    if (r < size)
                    {
                        answer[r, c] = array[i][j];
                        c++;
                    }
                }
            }
            // end

            return answer;
        }
    }

}

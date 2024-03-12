//public class IterativeSolver
//{
//    public double[,] GetAlpha(double[,] A)
//    {
//        double[,] alpha = new double[3, 3];
//        for (int i = 0; i <= 2; i++)
//        {
//            for (int j = 0; j <= 2; j++)
//            {
//                if (i == j) alpha[i, j] = 0;
//                else alpha[i, j] = -A[i, j] / A[i, i];
//            }
//        }
//        return alpha;
//    }

//    public double[,] GetBeta(double[,] b, double[,] A)
//    {
//        double[,] beta = new double[3, 1];
//        for (int i = 0; i <= 2; i++)
//        {
//            beta[i, 0] = b[i, 0] / A[i, i];
//        }
//        return beta;
//    }


//    public double[] Solve(double[,] alpha, double[,] beta, double[] initialGuess, double epsilon)
//    {

//        double[] previousX = new double[initialGuess.Length];
//        previousX = initialGuess;
//        double[] currentX = new double[initialGuess.Length];

//        Array.Copy(initialGuess, currentX, initialGuess.Length);

//        do
//        {
//            Array.Copy(currentX, previousX, currentX.Length); // Сохраняем предыдущие значения

//            for (int i = 0; i < currentX.Length; i++)
//            {
//                currentX[i] = beta[i, 0];
//                for (int j = 0; j < currentX.Length; j++)
//                {
//                    if (j != i)
//                        currentX[i] += alpha[i, j] * previousX[j];
//                }
//            }
//        } while (!HasConverged(previousX, currentX, epsilon));

//        return currentX;
//    }

//    private bool HasConverged(double[] previousX, double[] currentX, double epsilon)
//    {
//        double maxDifference = 0;
//        for (int i = 0; i < currentX.Length; i++)
//        {
//            double difference = Math.Abs(currentX[i] - previousX[i]);
//            if (difference > maxDifference)
//            {
//                maxDifference = difference;
//            }
//        }
//        return maxDifference >= epsilon;
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        IterativeSolver solver = new IterativeSolver();
//        double[,] A = { { 2.8333, 5, 1 }, 
//                        { 1.7, 3, 7 }, 
//                        { 8, 1, 1 } };

//        double[,] b = { { 11.66666 }, { 13.4 }, { 18 } };
//        double[,] alpha = solver.GetAlpha(A);
//        double[,] beta = solver.GetBeta(b, A);
//        /*double[] initialGuess = { beta[0,0] / alpha[0,0], beta[1, 0] / alpha[1, 1], beta[2, 0] / alpha[2, 2] };*/ // Начальное приближение
//        double epsilon = 1e-3; // Заданная точность
//        double[] initialGuess = { beta[0, 0], beta[1, 0], beta[2, 0] };



//        double[] solution = solver.Solve(alpha, beta, initialGuess, epsilon);


//        Console.WriteLine("Solution:");
//        for (int i = 0; i < solution.Length; i++)
//        {
//            Console.WriteLine("x[" + (i + 1) + "] = " + solution[i]);
//        }

//    }
//}
using System;

class SimpleIterations
{
    static void Main()
    {
        
        int n = 3;

        
        double[,] coefficients = {
            {2.8333, 5, 1},
            {1.7, 3, 7},
            {8, 1, 1}
        };

        
        double[] constants = { 11.66666, 13.4, 18 };

      
        double[] initialGuess = { 0, 0, 0 };

        
        int iterations = 30;

       
        double[] solution = Solve(coefficients, constants, initialGuess, iterations);

        
        Console.WriteLine("Решение системы уравнений:");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"x[{i + 1}] = {solution[i]}");
        }

        Console.ReadLine();
    }

    static double[] Solve(double[,] coefficients, double[] constants, double[] initialGuess, int iterations)
    {
        int n = constants.Length;
        double[] currentSolution = new double[n];
        double[] nextSolution = new double[n];

        
        for (int k = 0; k < iterations; k++)
        {
            
            for (int i = 0; i < n; i++)
            {
                double sum = 0;
                for (int j = 0; j < n; j++)
                {
                    if (j != i)
                    {
                        sum += coefficients[i, j] * initialGuess[j];
                    }
                }
                nextSolution[i] = (constants[i] - sum) / coefficients[i, i];
            }

            
            for (int i = 0; i < n; i++)
            {
                initialGuess[i] = nextSolution[i];
            }
        }

        return nextSolution;
    }
}
using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.NumberCalculations
{
    class NumberCalculations
    {
        static void Main(string[] args)
        {
            var intArray = new int[] 
                                    {
                                        3, 1, 10, 25, 7
                                    };
            var decimalArray = new decimal[] 
                                            {
                                                3m, 1m, 10m, 25m, 7m
                                            };
            var doubleArray = new double[] 
                                            {
                                                3d, 1d, 10d, 25d, 7d
                                            };
            var floatArray = new float[] 
                                            {
                                                3f, 1f, 10f, 25f, 7f
                                            };

            PrintMinMaxAvgSumProductOf(intArray);
            PrintMinMaxAvgSumProductOf(decimalArray);
            PrintMinMaxAvgSumProductOf(doubleArray);
            PrintMinMaxAvgSumProductOf(floatArray);
        }

        private static void PrintMinMaxAvgSumProductOf(int[] array)
        {
            Console.WriteLine("Target Array: [{0}]\n" + 
                              "Min: {1}\n" + 
                              "Max: {2}\n" +
                              "Avg: {3}\n" +
                              "Sum: {4}\n" +
                              "Product: {5}", 
                                            String.Join(", ", array),
                                            GetMinOf(array),
                                            GetMaxOf(array),
                                            GetAvgOf(array),
                                            GetSumOf(array),
                                            GetProductOf(array));
        }

        private static void PrintMinMaxAvgSumProductOf(decimal[] array)
        {
            Console.WriteLine("Target Array: [{0}]\n" +
                              "Min: {1}\n" +
                              "Max: {2}\n" +
                              "Avg: {3}\n" +
                              "Sum: {4}\n" +
                              "Product: {5}",
                                            String.Join(", ", array),
                                            GetMinOf(array),
                                            GetMaxOf(array),
                                            GetAvgOf(array),
                                            GetSumOf(array),
                                            GetProductOf(array));
        }

        private static void PrintMinMaxAvgSumProductOf(double[] array)
        {
            Console.WriteLine("Target Array: [{0}]\n" +
                              "Min: {1}\n" +
                              "Max: {2}\n" +
                              "Avg: {3}\n" +
                              "Sum: {4}\n" +
                              "Product: {5}",
                                            String.Join(", ", array),
                                            GetMinOf(array),
                                            GetMaxOf(array),
                                            GetAvgOf(array),
                                            GetSumOf(array),
                                            GetProductOf(array));
        }

        private static void PrintMinMaxAvgSumProductOf(float[] array)
        {
            Console.WriteLine("Target Array: [{0}]\n" +
                              "Min: {1}\n" +
                              "Max: {2}\n" +
                              "Avg: {3}\n" +
                              "Sum: {4}\n" +
                              "Product: {5}",
                                            String.Join(", ", array),
                                            GetMinOf(array),
                                            GetMaxOf(array),
                                            GetAvgOf(array),
                                            GetSumOf(array),
                                            GetProductOf(array));
        }

        private static int GetMinOf(int[] array)
        {
            var minValue = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < minValue)
                {
                    minValue = array[i];
                }
            }

            return minValue;
        }

        private static decimal GetMinOf(decimal[] array)
        {
            var minValue = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < minValue)
                {
                    minValue = array[i];
                }
            }

            return minValue;
        }

        private static double GetMinOf(double[] array)
        {
            var minValue = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < minValue)
                {
                    minValue = array[i];
                }
            }

            return minValue;
        }

        private static float GetMinOf(float[] array)
        {
            var minValue = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < minValue)
                {
                    minValue = array[i];
                }
            }

            return minValue;
        }

        private static int GetMaxOf(int[] array)
        {
            var maxValue = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > maxValue)
                {
                    maxValue = array[i];
                }
            }

            return maxValue;
        }

        private static decimal GetMaxOf(decimal[] array)
        {
            var maxValue = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > maxValue)
                {
                    maxValue = array[i];
                }
            }

            return maxValue;
        }

        private static double GetMaxOf(double[] array)
        {
            var maxValue = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > maxValue)
                {
                    maxValue = array[i];
                }
            }

            return maxValue;
        }

        private static float GetMaxOf(float[] array)
        {
            var maxValue = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > maxValue)
                {
                    maxValue = array[i];
                }
            }

            return maxValue;
        }

        private static int GetAvgOf(int[] array)
        {
            var sum = GetSumOf(array);
            return sum / array.Length;
        }

        private static decimal GetAvgOf(decimal[] array)
        {
            var sum = GetSumOf(array);
            return sum / array.Length;
        }

        private static double GetAvgOf(double[] array)
        {
            var sum = GetSumOf(array);
            return sum / array.Length;
        }

        private static float GetAvgOf(float[] array)
        {
            var sum = GetSumOf(array);
            return sum / array.Length;
        }

        private static int GetSumOf(int[] array)
        {
            var sum = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        private static decimal GetSumOf(decimal[] array)
        {
            var sum = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        private static double GetSumOf(double[] array)
        {
            var sum = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        private static float GetSumOf(float[] array)
        {
            var sum = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        private static int GetProductOf(int[] array)
        {
            var sum = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                sum *= array[i];
            }

            return sum;
        }

        private static decimal GetProductOf(decimal[] array)
        {
            var sum = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                sum *= array[i];
            }

            return sum;
        }

        private static double GetProductOf(double[] array)
        {
            var sum = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                sum *= array[i];
            }

            return sum;
        }

        private static float GetProductOf(float[] array)
        {
            var sum = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                sum *= array[i];
            }

            return sum;
        }
    }
}

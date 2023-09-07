using System;

namespace Flexion
{
    public class AdditionalMath
    {
        public enum Operation: int
        {
            Plus = 0,
            Moins = 1,
            Fois = 2,
            Divisé = 3,
            Puissance = 4,
        }
        public double[] OperationDoubleArray(double[] array1, double[] array2,Operation action)
        {
            int length = array1.Length;
            if (array2.Length < length)
            {
                length = array2.Length;
            }
            double[] final = new double[length];
            switch (action)
            {
                case Operation.Plus:
                    for (int i = 0; i < length; i++)
                    {
                        final[i] = array1[i] + array2[i];
                    }
                    break;
                case Operation.Moins:
                    for (int i = 0; i < length; i++)
                    {
                        final[i] = array1[i] - array2[i];
                    }
                    break;
                case Operation.Fois:
                    for (int i = 0; i < length; i++)
                    {
                        final[i] = array1[i] * array2[i];
                    }
                    break;
                case Operation.Divisé:
                    for (int i = 0; i < length; i++)
                    {
                        final[i] = array1[i] / array2[i];
                    }
                    break;
                case Operation.Puissance:
                    for (int i = 0; i < length; i++)
                    {
                        final[i] = Math.Pow(array1[i], array2[i]);
                    }
                    break;
            }
            return final;
        }

        public double[] OperationDoubleArray(double[] array, double value, Operation action)
        {
            double[] final = new double[array.Length];
            switch (action)
            {
                case Operation.Plus:
                    for (int i = 0; i < array.Length; i++)
                    {
                        final[i] = array[i] + value;
                    }
                    break;
                case Operation.Moins:
                    for (int i = 0; i < array.Length; i++)
                    {
                        final[i] = array[i] - value;
                    }
                    break;
                case Operation.Fois:
                    for (int i = 0; i < array.Length; i++)
                    {
                        final[i] = array[i] * value;
                    }
                    break;
                case Operation.Divisé:
                    for (int i = 0; i < array.Length; i++)
                    {
                        final[i] = array[i] / value;
                    }
                    break;
                case Operation.Puissance:
                    for (int i = 0; i < array.Length; i++)
                    {
                        final[i] = Math.Pow(array[i], value);
                    }
                    break;
            }
            return final;
        }
    }
}

using System;

namespace FlexionV2.Logic
{
    public static class AdditionalMath
    {
        public enum Operation
        {
            Plus = 0,
            Minus = 1,
            Multiplication = 2,
            Divided = 3,
            Power = 4,
        }
        public static double[] OperationDoubleArray(double[] array1, double[] array2, Operation action)
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
                case Operation.Minus:
                    for (int i = 0; i < length; i++)
                    {
                        final[i] = array1[i] - array2[i];
                    }
                    break;
                case Operation.Multiplication:
                    for (int i = 0; i < length; i++)
                    {
                        final[i] = array1[i] * array2[i];
                    }
                    break;
                case Operation.Divided:
                    for (int i = 0; i < length; i++)
                    {
                        final[i] = array1[i] / array2[i];
                    }
                    break;
                case Operation.Power:
                    for (int i = 0; i < length; i++)
                    {
                        final[i] = Math.Pow(array1[i], array2[i]);
                    }
                    break;
            }
            return final;
        }

        public static double[] OperationDoubleArray(double[] array, double value, Operation action)
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
                case Operation.Minus:
                    for (int i = 0; i < array.Length; i++)
                    {
                        final[i] = array[i] - value;
                    }
                    break;
                case Operation.Multiplication:
                    for (int i = 0; i < array.Length; i++)
                    {
                        final[i] = array[i] * value;
                    }
                    break;
                case Operation.Divided:
                    for (int i = 0; i < array.Length; i++)
                    {
                        final[i] = array[i] / value;
                    }
                    break;
                case Operation.Power:
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

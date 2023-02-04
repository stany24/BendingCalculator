using System;

namespace Flexion
{
    public class AdditionalMath
    {
        public double[] Add2DoubleArray(double[] array1, double[] array2)
        {
            int length = array1.Length;
            if (array2.Length < length)
            {
                length = array2.Length;
            }
            double[] final = new double[length];
            for (int i = 0; i < length; i++)
            {
                final[i] = array1[i] + array2[i];
            }
            return final;
        }

        public double[] DivideDoubleArrayByDoubleArray(double[] array1, double[] array2)
        {
            int length = array1.Length;
            if (array2.Length < length)
            {
                length = array2.Length;
            }
            double[] final = new double[length];
            for (int i = 0; i < length; i++)
            {
                final[i] = array1[i] / array2[i];
            }
            return final;
        }

        public double[] MultiplyDoubleArrayByDoubleArray(double[] array1, double[] array2)
        {
            int length = array1.Length;
            if (array2.Length < length)
            {
                length = array2.Length;
            }
            double[] final = new double[length];
            for (int i = 0; i < length; i++)
            {
                final[i] = array1[i] * array2[i];
            }
            return final;
        }

        public double[] DivideArrayBydouble(double[] array, double value) {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = array[i]/value;
            }
            return array;
        }

        public double[] MultiplyArrayBydouble(double[] array, double value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = array[i] * value;
            }
            return array;
        }

        public double[] PowerArrayBydouble(double[] array, double value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Math.Pow(array[i], value);
            }
            return array;
        }

        public double[] RemoveDoubleToArray(double[] array, double value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = array[i]-value;
            }
            return array;
        }

        public double[] AddDoubleToArray(double[] array, double value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = array[i] + value;
            }
            return array;
        }

    }
}

namespace Flexion
{
    public class AdditionalMath
    {
        public double[] AddDoubleArray(double[] array1, double[] array2)
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

        public double[] MultiplyDoubleArray(double[] array1, double[] array2)
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

        public double[] DivideArrayBydouble(double[] array, double value) {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = array[i]/2;
            }
            return array;
        }

    }
}

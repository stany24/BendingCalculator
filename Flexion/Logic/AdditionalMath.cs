// ReSharper disable SwitchStatementHandlesSomeKnownEnumValuesWithDefault

namespace Flexion.Logic;

public static class AdditionalMath
{
    public enum Operation
    {
        Plus = 0,
        Minus = 1,
        Multiplication = 2,
        Divided = 3,
        Power = 4
    }
    public static double[] OperationDoubleArray(double[] array1, double[] array2, Operation action)
    {
        int length = array1.Length;
        if (array2.Length < length)
        {
            length = array2.Length;
        }
        double[] final = new double[length];
        
        for (int i = 0; i < length; i++)
        {
            final[i] = action switch
            {
                Operation.Plus => array1[i] + array2[i],
                Operation.Minus => array1[i] - array2[i],
                Operation.Multiplication => array1[i] * array2[i],
                Operation.Divided => array1[i] / array2[i],
                Operation.Power => System.Math.Pow(array1[i], array2[i]),
                _ => final[i]
            };
        }
        
        return final;
    }

    public static double[] OperationDoubleArray(double[] array, double value, Operation action)
    {
        double[] final = new double[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            final[i] = action switch
            {
                Operation.Plus => array[i] + value,
                Operation.Minus => array[i] - value,
                Operation.Multiplication => array[i] * value,
                Operation.Divided => array[i] / value,
                Operation.Power => System.Math.Pow(array[i], value),
                _ => final[i]
            };
        }
        
        return final;
    }
}
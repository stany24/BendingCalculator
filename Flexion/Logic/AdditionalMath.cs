using System;
using System.Linq;

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
        if (array1.Length != array2.Length)
        {
            throw new ArgumentException("Arrays must have the same length.");
        }
        
        return action switch
        {
            Operation.Multiplication => array1.Zip(array2, (x, y) => x * y).ToArray(),
            Operation.Divided => array1.Zip(array2, (x, y) => x / y).ToArray(),
            Operation.Plus => array1.Zip(array2, (x, y) => x + y).ToArray(),
            Operation.Minus => array1.Zip(array2, (x, y) => x - y).ToArray(),
            Operation.Power => array1.Zip(array2, System.Math.Pow).ToArray(),
            _ => array1
        };
    }

    public static double[] OperationDoubleArray(double[] array, double value, Operation action)
    {
        return action switch
        {
            Operation.Multiplication => array.Select(x => x * value).ToArray(),
            Operation.Divided => array.Select(x => x / value).ToArray(),
            Operation.Plus => array.Select(x => x + value).ToArray(),
            Operation.Minus => array.Select(x => x - value).ToArray(),
            Operation.Power => array.Select(x => System.Math.Pow(x, value)).ToArray(),
            _ => array
        };
    }
}
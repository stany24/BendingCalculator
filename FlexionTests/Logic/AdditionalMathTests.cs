using FlexionV2.Logic;
using Xunit;

namespace FlexionTests.Logic;

public class AdditionalMathTests
{
    private readonly double[] _array1 = { 1, 2, 3, 4, 5 };
    private readonly double[] _array2 = { 1, 2, 3, 4, 5 };
    private const double Constant = 5;

    [Fact]
    public void ArrayArrayPlusTest()
    {
        double[] expected = { 2, 4, 6, 8, 10 };
        double[] result = AdditionalMath.OperationDoubleArray(_array1, _array2, AdditionalMath.Operation.Plus);
        Assert.Equal(expected,result);
    }
    
    [Fact]
    public void ArrayArrayMinusTest()
    {
        double[] expected = { 0, 0, 0, 0, 0 };
        double[] result = AdditionalMath.OperationDoubleArray(_array1, _array2, AdditionalMath.Operation.Minus);
        Assert.Equal(expected,result);
    }
    
    [Fact]
    public void ArrayArrayMultiplicationTest()
    {

        double[] expected = { 1, 4, 9, 16, 25 };
        double[] result = AdditionalMath.OperationDoubleArray(_array1, _array2, AdditionalMath.Operation.Multiplication);
        Assert.Equal(expected,result);
    }
    
    [Fact]
    public void ArrayArrayDividedTest()
    {
        double[] expected = { 1, 1, 1, 1, 1 };
        double[] result = AdditionalMath.OperationDoubleArray(_array1, _array2, AdditionalMath.Operation.Divided);
        Assert.Equal(expected,result);
    }
    
    [Fact]
    public void ArrayArrayPowerTest()
    {
        double[] expected = { 1, 4, 27, 256, 3125 };
        double[] result = AdditionalMath.OperationDoubleArray(_array1, _array2, AdditionalMath.Operation.Power);
        Assert.Equal(expected,result);
    }
    
    [Fact]
    public void ArrayConstantPlusTest()
    {
        double[] expected = { 6, 7, 8, 9, 10 };
        double[] result = AdditionalMath.OperationDoubleArray(_array1, Constant, AdditionalMath.Operation.Plus);
        Assert.Equal(expected,result);
    }
    
    [Fact]
    public void ArrayConstantMinusTest()
    {
        double[] expected = { -4, -3, -2, -1, 0 };
        double[] result = AdditionalMath.OperationDoubleArray(_array1, Constant, AdditionalMath.Operation.Minus);
        Assert.Equal(expected,result);
    }
    
    [Fact]
    public void ArrayConstantMultiplicationTest()
    {
        double[] expected = { 5, 10, 15, 20, 25 };
        double[] result = AdditionalMath.OperationDoubleArray(_array1, Constant, AdditionalMath.Operation.Multiplication);
        Assert.Equal(expected,result);
    }
    
    [Fact]
    public void ArrayConstantDividedTest()
    {
        double[] expected = { 1.0/5, 2.0/5, 3.0/5, 4.0/5, 1 };
        double[] result = AdditionalMath.OperationDoubleArray(_array1, Constant, AdditionalMath.Operation.Divided);
        Assert.Equal(expected,result);
    }
    
    [Fact]
    public void ArrayConstantPowerTest()
    {
        double[] expected = { 1, 32, 243, 1024, 3125 };
        double[] result = AdditionalMath.OperationDoubleArray(_array1, Constant, AdditionalMath.Operation.Power);
        Assert.Equal(expected,result);
    }
}
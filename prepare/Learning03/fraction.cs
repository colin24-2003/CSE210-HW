using System.Diagnostics;

public class Fraction
{
    private int _top;
    private int _bottom;

    // Constructors
    public Fraction()
    {
        _top = 1;
        _bottom = 1;

    }
    public Fraction(int bottom)
    {
         _top = 1;
         _bottom = bottom;
    }
    public Fraction(int top, int bottom)
    {
         _top = top;
         _bottom = bottom;
    }
    // Constructors don't return anything 
    // Constructors also have the same name as the class
    // Constructors put values into the attributes 

    //Getters and Setters

    public int GetTop()
    {
        return _top;
    }

    public void SetTop(int value){
        _top = value;
    }

    public int GetBottom(){

        return _bottom;
    }

    public void SetBottom(int value){

        _bottom = value;
    }

    //Getters and Setters

    public string GetFractionString(){
        return $"{_top}/{_bottom}";
    }

    public double GetDecimalValue(){
        return (double)_top / _bottom;
    }


    public void DisplayFraction(){
        Console.WriteLine($"{_top}/{_bottom}");
    }

    
}
public class Vehicle
{
    private int _yearManufactured;
    private string _manufacturer;
    private string _modelName;

    public Vehicle(int yearManufactured, string manufacturer, string modelName) // initialize attributes in the class
    {
        _yearManufactured = yearManufactured;
        _manufacturer = manufacturer;
        _modelName = modelName;
    }

    public int getYearManufactured()
    {
        return _yearManufactured;
    }
    public string getManufacturer()
    {
        return _manufacturer;
    }
    public string modelName()
    {
        return _modelName;
    }
}


public class Car : Vehicle
{
    private int _numOfDoors;

    public Car(int yearManufactured, string manufacturer, string modelName, int numOfDoors)
     : base(yearManufactured, manufacturer, modelName)
    {
        _numOfDoors = numOfDoors;
    }

}

public class Ford : Car
{
    public Ford(int yearManufactured, string modelName, int numOfDoors)
    : base(yearManufactured, "Ford", modelName, numOfDoors) // calls attributes from the parent class
    {
        
    }
}

public class Program2
{
    public static void Main2(string[] args)
    {
        Car car1 = new Car(2006, "Hyundai", "Sonata", 4);
        Ford ford1 = new Ford(2008, "F-150", 2);
        Console.WriteLine(ford1.getYearManufactured());
    }
}


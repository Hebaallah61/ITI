using task1.Validators;

namespace task1.Models;

public class Car
{
    public int Id { set; get; }
    public string Model { set; get; }
    public string Color { set; get; }
    [DateAnnotation(ErrorMessage =("Date Not in the Past"))]
    public DateTime ProductionDate { get; set; }
    public string Type { get; set; } = "Gas";

}

public class CarList
{
    public static List<Car> Cars = new List<Car>() {
        new Car() { Id = 1 ,Model="kl" , ProductionDate = new DateTime(2020, 1, 5)  },
        new Car() { Id = 2 ,Model="kl"  , ProductionDate = new DateTime(2020, 1, 5)  },
        new Car() { Id = 3 ,Model="kl" , ProductionDate = new DateTime(2020, 1, 5)  },
        new Car() { Id = 4 ,Model="kl", ProductionDate = new DateTime(2020, 1, 5)  }
 };
    }

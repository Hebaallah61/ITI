using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace task1.Models
{
    public class CarList
    {
        public static List<Car> Cars = new List<Car>()
       {
            new Car() { Num = 1, Color = "red", Model = "k55", Manfacture = "Tesla" },
            new Car() { Num= 2, Color= "selver", Model = "45fg", Manfacture = "Tokyo" },
            new Car() { Num= 3, Color= "blue", Model = "566gg", Manfacture = "Toyota" },
            new Car() { Num= 4, Color= "gold", Model = "88448", Manfacture = "Marcedes" },
            new Car() { Num= 5, Color= "pink", Model = "54gg5", Manfacture = "Krella" }
       };
    }
}
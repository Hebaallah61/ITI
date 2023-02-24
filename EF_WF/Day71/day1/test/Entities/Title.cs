using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Entities
{
    // 4 Mapping Ways
    // 1. EF Convension (Default)
    // 2. Attributes [Mapping Attribute] , Data Annotations
    // 3. Fluent API (onModelCreating (ModelBuilder){})
    // 4. Configuration Classes
 
    // using EF Convensions
    public class Title
    {
        //3ways to remove the worning of referance type 
        //1-initialize it ===> = string.Empty;
        //2-define contructor and et it by value
        //3-ue required keyword

        public int ID { get; set; } //public Numeric Attribute , ID or EntityNameID ::PK , identity

        ///Non Nullable Reference Type 
        public /*required*/ string AuthorName { get; set; } = string.Empty;

        //public Title(int iD, string authorName, decimal price, string? forward)
        //{
        //    ID = iD;
        //    AuthorName = authorName;
        //    Price = price;
        //    Forward = forward;
        //}

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }
        //Nullable Value Type , Nullable<Decimal>
        public decimal? PromotionalPrice { get; set; }

        //Nullable Refrence Type
        public string? Forward { get; set; }

        public virtual Branch? Branch { get; set; }
    }
}

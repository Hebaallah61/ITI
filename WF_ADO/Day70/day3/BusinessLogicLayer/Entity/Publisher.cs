using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Entity
{
    public class Publisher:EntityBase
    {
        
        public string pub_id { get; set; }
        public string pub_name { get; set; }
        public string city { get; set; }
        public string state { get ; set; }
        public string country { get; set; }

        /*string pub_id;
        string pub_name;
        string city;
        string state;
        string country;
        public string Pub_id { get => pub_id; set { if (value != pub_id) { this.State = EntityState.Changed; pub_id = value; } } }
        public string Pub_name { get=>pub_name; set; }
        public string City { get=>city; set; }
        public string State { get=>state; set; }
        public string Country { get=>country; set; }
        */

    }
}

using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotalDAL.Entities
{
    public class Reservation
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [NotNull]
        public string first_name { get; set; }

        [MaxLength(50)]
        [NotNull]
        public string last_name { get; set; }

        [MaxLength(50)]
        [NotNull]
        public string birth_day { get; set; }

        [MaxLength(50)]
        [NotNull]
        public string gender { get; set; }

        [MaxLength(50)]
        [NotNull]
        public string phone_number { get; set; }


        [NotNull]
        public string email_address { get; set; }


        [NotNull]
        public int number_guest { get; set; }


        [NotNull]
        public string street_address { get; set; }

        [MaxLength(50)]
        [NotNull]
        public string apt_suite { get; set; }


        [NotNull]
        public string city { get; set; }

        [MaxLength(50)]
        [NotNull]
        public string state { get; set; }

        [MaxLength(10)]
        [NotNull]
        public string zip_code { get; set; }

        [MaxLength(10)]
        [NotNull]
        public string room_type { get; set; }

        [MaxLength(10)]
        [NotNull]
        public string room_floor { get; set; }

        [MaxLength(10)]
        [NotNull]
        public string room_number { get; set; }


        [NotNull]
        public float total_bill { get; set; }

        [MaxLength(10)]
        [NotNull]
        public string payment_type { get; set; }

        [MaxLength(10)]
        [NotNull]
        public string card_type { get; set; }

        [MaxLength(50)]
        [NotNull]
        public string card_number { get; set; }

        [MaxLength(50)]
        [NotNull]
        public string card_exp { get; set; }

        [MaxLength(10)]
        [NotNull]
        public string card_cvc { get; set; }

        [Column(TypeName = "date")]
        [NotNull]
        public DateTime arrival_time { get; set; }

        [Column(TypeName = "date")]
        [NotNull]
        public DateTime leaving_time { get; set; }


        [NotNull]
        public bool check_in { get; set; }



        [NotNull]
        public int break_fast { get; set; }


        [NotNull]
        public int lunch { get; set; }

        [NotNull]
        public int dinner { get; set; }

        [NotNull]
        public bool cleaning { get; set; }

        [NotNull]
        public bool towel { get; set; }

        [NotNull]
        public bool s_surprise { get; set; }

        [NotNull]
        public bool supply_status { get; set; }

        [NotNull]
        public int food_bill { get; set; }
    }
}

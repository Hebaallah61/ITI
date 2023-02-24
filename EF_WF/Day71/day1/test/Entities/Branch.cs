using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Entities
{
    // 2. Data annotation

    [Table("LibraryBranches")]
    public class Branch
    {
        [Key]
        public int BID { get; set; }
        [MaxLength(40)]
        public string City { get; set; } = string.Empty;
        [MaxLength(10)]
        [Required]
        public string? ZipCode { get; set; }
        [Column(TypeName = "smallint")]
        public int OpenHour { get; set; }

        public virtual ICollection<Title> Titles { get; set; } = new HashSet<Title>();
    }
}

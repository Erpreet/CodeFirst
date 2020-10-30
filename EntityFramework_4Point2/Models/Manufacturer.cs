using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EntityFramework_4Point2.Models
{
    [Table("manufacturer")]
    class Manufacturer
    {

        public Manufacturer()
        {
            Vehicles = new HashSet<Vehicle>();
        }
        [Key]
        [Column("ID", TypeName = "int(10)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ID { get; set; }

        [Column(TypeName = "varchar(30)")]

        public string Name { get; set; }

        [InverseProperty(nameof(Vehicle.Manufacturer))]
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        
    }
}

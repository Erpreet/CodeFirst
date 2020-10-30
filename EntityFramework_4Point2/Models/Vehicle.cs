using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EntityFramework_4Point2.Models
{
    [Table("vehicle")]
    class Vehicle
    {
        [Key]
        [Column("ID",TypeName ="int(10)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ID { get; set; }

        [Column(TypeName = "varchar(30)")]
        public int ManufacturerID { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string Model { get; set; }

        [Column(TypeName = "int(10)")]
        public int ModelYear { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string Colour { get; set; }

        [ForeignKey(nameof(ManufacturerID))]
        [InverseProperty(nameof(Models.Manufacturer.Vehicles))]
        public virtual Manufacturer Manufacturer { get; set; }


    }
}

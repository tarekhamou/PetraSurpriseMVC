namespace PetraSurpriseMvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Gift")]
    public partial class Gift
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        public int? Category { get; set; }

        [StringLength(50)]
        public string Date { get; set; }

        public string Description { get; set; }

        public string Photo { get; set; }

        public decimal? Price { get; set; }

        [StringLength(50)]
        public string Manufacturer { get; set; }

        [StringLength(50)]
        public string Size { get; set; }
    }
}

namespace PetraSurpriseMvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Recipient")]
    public partial class Recipient
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string Region { get; set; }

        public int? PostalCode { get; set; }

        [StringLength(50)]
        public string Street { get; set; }

        [StringLength(50)]
        public string ApartmentNumber { get; set; }

        [StringLength(50)]
        public string AdditionalInfo { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        public string RelationShip { get; set; }
    }
}

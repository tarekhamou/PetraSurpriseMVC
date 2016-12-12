namespace PetraSurpriseMvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? Recipient { get; set; }

        public int? Sender { get; set; }

        public string CardMessage { get; set; }

        [StringLength(50)]
        public string DeliveryDate { get; set; }

        [StringLength(50)]
        public string DeliveryLocationType { get; set; }

        [StringLength(50)]
        public string Time { get; set; }

        public int? Paid { get; set; }

        [StringLength(50)]
        public string RelationShip { get; set; }
    }
}

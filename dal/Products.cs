namespace Mvc.dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Products
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(260)]
        public string ImageName { get; set; }

        public virtual ProductCategories ProductCategories { get; set; }
    }
}

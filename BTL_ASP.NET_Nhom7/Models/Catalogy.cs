namespace BTL_ASP.NET_Nhom7.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Catalogy")]
    public partial class Catalogy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Catalogy()
        {
            Product = new HashSet<Product>();
        }
        [Key]
        [Required]
        [Display(Name ="Mã bài viết")]
        public int CatalogyId { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên")]

        public string CatalogyName { get; set; }

        [Display(Name = "Mô tả")]

        [Column(TypeName = "ntext")]
        public string Description { get; set; }
        [Display(Name = "Ngày tạo")]

        public DateTime? CreateDate { get; set; }
        [Display(Name = "Ngày cập nhật")]

        public DateTime? ModifiedDate { get; set; }
        [Display(Name = "Là mục cha")]

        public bool? ParentId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Product { get; set; }
    }
}

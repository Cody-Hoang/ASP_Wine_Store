namespace BTL_ASP.NET_Nhom7.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }
        [Key]
        [Required]
        [Display(Name = "Mã sản phẩm")]

        public int ProductId { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên sản phẩm")]

        public string ProductName { get; set; }


        [Column(TypeName = "ntext")]
        [Display(Name = "Mô tả")]

        public string Description { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = "Giá bán")]

        public decimal? PurchasePrice { get; set; }

        [Column(TypeName = "money")]
        [Display(Name ="Giá nhập")]

        public decimal? Price { get; set; }
        [Display(Name = "Số lượng")]

        public int? Quantity { get; set; }

        [StringLength(50)]
        [Display(Name = "Năm rượu")]

        public string Vintage { get; set; }

        [StringLength(50)]
        [Display(Name = "Ảnh")]

        public string Image { get; set; }

        [StringLength(50)]
        [Display(Name = "Xuất xứ")]

        public string Region { get; set; }
        [Display(Name = "Thể tích")]


        public int? Capacity { get; set; }
        [Display(Name = "Ngày tạo")]


        public DateTime? CreateDate { get; set; }
        [Display(Name = "Ngày cập nhật")]

        public DateTime? ModifiedDate { get; set; }
        [Display(Name = "Mã danh mục")]

        public int CatalogyId { get; set; }

        public virtual Catalogy Catalogy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}

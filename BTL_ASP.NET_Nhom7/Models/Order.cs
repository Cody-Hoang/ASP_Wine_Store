namespace BTL_ASP.NET_Nhom7.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }
        [Key]
        [Required]
        [Display(Name ="Mã hóa đơn")]
        public int OrderId { get; set; }
        [Display(Name = "Trạng thái")]


        public bool? Status { get; set; }
        [Display(Name = "Ngày tạo")]

        public DateTime? CreateDate { get; set; }
        [Display(Name = "Ngày cập nhật")]


        public DateTime? ModifiedDate { get; set; }
        [Display(Name ="Mã khách hàng")]

        public int UserId { get; set; }
        [Display(Name = "Khách hàng")]


        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}

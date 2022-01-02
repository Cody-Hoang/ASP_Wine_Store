namespace BTL_ASP.NET_Nhom7.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Order = new HashSet<Order>();
        }

        public int UserId { get; set; }

        [Required]
        [Display(Name ="Tên")]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Email")]

        public string Email { get; set; }

        [StringLength(15)]
        [Display(Name = "Số điện thoại")]

        public string Phone { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Mật khẩu")]

        public string Password { get; set; }

        [StringLength(255)]
        [Display(Name = "Địa chỉ")]

        public string Address { get; set; }
        [Display(Name = "Trạng thái")]

        public bool? Status { get; set; }

        [Display(Name ="Ngày tạo")]
        public DateTime? CreateDate { get; set; }

        [Display(Name = "Ngày cập nhật")]

        public DateTime? ModifiedDate { get; set; }
        [Display(Name = "Mã nhóm")]

        public int GroupId { get; set; }

        public virtual GroupUsers GroupUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }
    }
}

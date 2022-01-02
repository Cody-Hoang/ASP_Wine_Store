namespace BTL_ASP.NET_Nhom7.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Blog")]
    public partial class Blog
    {
        [Key]
        [Display(Name ="Mã bài viết")]
        public int BlogId { get; set; }

        [StringLength(50)]
        [Display(Name = "Tiêu đề")]

        public string Title { get; set; }
        [Display(Name = "Nội dung")]


        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        [StringLength(50)]
        [Display(Name = "Ảnh")]

        public string Image { get; set; }
        [Display(Name = "Ngày tạo")]


        public DateTime? CreateDate { get; set; }
        [Display(Name = "Ngày sửa")]


        public DateTime? ModifiedDate { get; set; }
    }
}

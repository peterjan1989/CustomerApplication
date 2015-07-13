namespace CustomerApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(客戶聯絡人MetaData))]
    public partial class 客戶聯絡人
    {
    }
    
    public partial class 客戶聯絡人MetaData
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "客戶Id 必填")]
        public int 客戶Id { get; set; }

        [Required(ErrorMessage = "職稱 必填")]
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string 職稱 { get; set; }

        [Required(ErrorMessage = "姓名 必填")]
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string 姓名 { get; set; }

        [Required(ErrorMessage = "Email 必填")]
        [EmailAddress]
        [StringLength(250, ErrorMessage="欄位長度不得大於 250 個字元")]
        public string Email { get; set; }

        [CheckCell]
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string 手機 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string 電話 { get; set; }

        public Nullable<bool> 是否已刪除 { get; set; }
    
        public virtual 客戶資料 客戶資料 { get; set; }
    }
}

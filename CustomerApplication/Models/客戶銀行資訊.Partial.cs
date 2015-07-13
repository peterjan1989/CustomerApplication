namespace CustomerApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(客戶銀行資訊MetaData))]
    public partial class 客戶銀行資訊
    {
    }
    
    public partial class 客戶銀行資訊MetaData
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "客戶Id 必填")]
        public int 客戶Id { get; set; }

        [Required(ErrorMessage = "銀行名稱 必填")]
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string 銀行名稱 { get; set; }

        [Required(ErrorMessage = "銀行代碼 必填")]
        public int 銀行代碼 { get; set; }

        public Nullable<int> 分行代碼 { get; set; }

        [Required(ErrorMessage = "帳戶名稱 必填")]
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string 帳戶名稱 { get; set; }

        [Required(ErrorMessage = "帳戶號碼 必填")]
        [StringLength(20, ErrorMessage="欄位長度不得大於 20 個字元")]
        public string 帳戶號碼 { get; set; }

        public Nullable<bool> 是否已刪除 { get; set; }
    
        public virtual 客戶資料 客戶資料 { get; set; }
    }
}

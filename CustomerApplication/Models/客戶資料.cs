//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace CustomerApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class 客戶資料
    {
        public 客戶資料()
        {
            this.客戶銀行資訊 = new HashSet<客戶銀行資訊>();
            this.客戶聯絡人 = new HashSet<客戶聯絡人>();
        }
    
        public int Id { get; set; }

        [Required(ErrorMessage = "客戶名稱 必填")]
        [StringLength(50)]
        [MinLength(2)]
        public string 客戶名稱 { get; set; }

        [Required(ErrorMessage = "統一編號 必填")]
        [StringLength(8)]
        public string 統一編號 { get; set; }

        [Required(ErrorMessage = "電話 必填")]
        [StringLength(50)]
        public string 電話 { get; set; }

        [StringLength(50)]
        public string 傳真 { get; set; }

        [StringLength(100)]
        public string 地址 { get; set; }

        [StringLength(250)]
        [EmailAddress]
        public string Email { get; set; }

        [Display(AutoGenerateField = false)]
        public Nullable<bool> 是否已刪除 { get; set; }
    
        public virtual ICollection<客戶銀行資訊> 客戶銀行資訊 { get; set; }
        public virtual ICollection<客戶聯絡人> 客戶聯絡人 { get; set; }
    }
}

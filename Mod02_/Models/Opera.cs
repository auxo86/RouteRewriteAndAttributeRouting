using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Mod02_.Models
{
    public class Opera
    {
        [DisplayName("編號")]
        public int OperaID { get; set; }

        [Required(ErrorMessage = "歌劇名稱不可以為空白")]
        [StringLength(200)]
        [DisplayName("歌劇名稱")]
        public string Title { get; set; }
        
        [DisplayName("年代")]
        //[CheckValidYear]
        public int? Year { get; set; }

        [Required]
        [DisplayName("作者")]
        //using System.Web.Mvc;
        [Remote("CheckName","Opera", ErrorMessage ="{0} can't be tony")] 
        //[RegularExpression]
        public string Composer { get; set; }

    }
}



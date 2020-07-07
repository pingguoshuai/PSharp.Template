using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Util.Applications.Dtos;

namespace PSharp.Template.Core.Applications.Dtos
{
    public class RequestBase : Util.Applications.Dtos.RequestBase ,IKey
    {
        public string Id { get; set; }
        /// <summary>
        /// 版本号
        /// </summary>
        [Display(Name = "版本号")]
        public Byte[] Version { get; set; }
    }
}

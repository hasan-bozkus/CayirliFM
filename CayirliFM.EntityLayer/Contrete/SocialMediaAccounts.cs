﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.EntityLayer.Contrete
{
    public class SocialMediaAccounts
    {
        [Key]
        public int SocialMediaID { get; set; }
        public string Icon { get; set; }
        public string SocialMediaName { get; set; }
        public string SocialMediaUrl { get; set; }
        public DateTime SocialMediaCreateAtTime { get; set; }
    }
}

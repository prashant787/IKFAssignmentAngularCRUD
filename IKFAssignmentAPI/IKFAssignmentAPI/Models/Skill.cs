using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IKFAssignmentAPI.Models
{
    public class Skill
    {
        //public int SkillId { get; set; }
        [Key]
        public string SkillName { get; set; }
    }
}
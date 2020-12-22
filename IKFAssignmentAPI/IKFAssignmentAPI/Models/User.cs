using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace IKFAssignmentAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Designation { get; set; }
        public string Skill { get; set; }
    }
}
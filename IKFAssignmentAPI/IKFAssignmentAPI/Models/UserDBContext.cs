﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace IKFAssignmentAPI.Models
{
    public class UserDBContext : DbContext 
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
    }
}
﻿using DomainLib.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Database
{
    public class JobSearchContext : DbContext
    {
        public JobSearchContext(DbContextOptions<JobSearchContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Job> Jobs { get; set; }
    }
}

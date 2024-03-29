﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoreWebApp.Models;

namespace CoreWebApp.Models
{
    public class RECRMDBContext : DbContext
    {
        public RECRMDBContext (DbContextOptions<RECRMDBContext> options)
            : base(options)
        {
        }

        public DbSet<CoreWebApp.Models.Prospect> Prospects { get; set; }

        public DbSet<CoreWebApp.Models.Client> Clients { get; set; }
    }
}

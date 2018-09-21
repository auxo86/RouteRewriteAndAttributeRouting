using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Mod02_.Models;


namespace Mod02_.DAL
{
    public class OperaContext : DbContext
    {
        public DbSet<Opera> Operas { get; set; }
    }
}
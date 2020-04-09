using Microsoft.EntityFrameworkCore;
using ProjIMago.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjIMago.Data
{
	public class IMagoContext : DbContext
	{
		public IMagoContext(DbContextOptions<IMagoContext>op) : base(op)
		{

		}

		public DbSet<ImagesGos> ImagesGos { get; set; }
	}
}

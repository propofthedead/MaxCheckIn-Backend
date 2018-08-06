using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ClassSignIn_Hackathon_BE.Models {
	public class LogDbContext: DbContext {
		public DbSet<Class> Classes { get; set; }
		public DbSet<Student> Students { get; set; }
		public DbSet<TimeStamp> TimeStamps { get; set; }

		public LogDbContext() : base() { }
		}
	}
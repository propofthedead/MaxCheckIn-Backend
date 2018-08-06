using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ClassSignIn_Hackathon_BE.Models {
	public class LogDbContext: DbContext {
		//public DbSet<User> Users { get; set; }
		//public DbSet<Vendor> Vendors { get; set; }
		//public DbSet<Product> Products { get; set; }
		//public DbSet<PurchaseRequest> PurchaseRequests { get; set; }
		//public DbSet<PurchaseRequestLineItem> PurchaseRequestLineItems { get; set; }

		public LogDbContext() : base() { }
		}
	}
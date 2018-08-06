using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClassSignIn_Hackathon_BE.Models {
	public class TimeStamp {
		public int Id { get; set; }
		public DateTime? CheckIn { get; set; }
		public DateTime? CheckOut { get; set; }
		
		public int StudentId { get; set; }
		public virtual Student Student { get; set; }

		public int ClassId { get; set; }
		public virtual Class Class { get; set; }

		[Required]
		public bool Active { get; set; } = true;

		public TimeStamp() {
		}
	}
}
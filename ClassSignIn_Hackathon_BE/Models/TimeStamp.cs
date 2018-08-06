using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClassSignIn_Hackathon_BE.Models {
	public class TimeStamp {
		public int Id { get; set; }
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		public string UserName { get; set; }
		[Required]
		public string Pin { get; set; }
		[Required]
		public bool IsAdmin { get; set; } = false;
		[Required]
		public bool Active { get; set; } = true;

		public int StudentId { get; set; }
		public virtual Student Student { get; set; }

		public int ClassId { get; set; }
		public virtual Class Class { get; set; }

		public TimeStamp() {
		}
	}
}
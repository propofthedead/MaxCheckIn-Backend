using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClassSignIn_Hackathon_BE.Models {
	public class Class {
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		[Required]
		public string Location { get; set; }
		[Required]
		public bool Active { get; set; } = true;

		public List<int> StudentIds { get; set; }
		public virtual List<Student> Students { get; set; }

		public Class() {
		}
	}
}
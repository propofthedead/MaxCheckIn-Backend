using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClassSignIn_Hackathon_BE.Models {
	public class Student {
		public int Id { get; set; }
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		public string Pin { get; set; }
		[Required]
		public bool IsAdmin { get; set; } = false;
		[Required]
		public bool Active { get; set; } = true;


		public List<int> ClassIds { get; set; }
		[JsonIgnore]
		public virtual List<Class> Classes { get; set; }

		public Student() {
		}
	}
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClassSignIn_Hackathon_BE.Models
{
	public class Teacher
	{
		[Required]
		public int Id { get; set; }
		[Required]
		public string Firstname { get; set; }
		[Required]
		public string Lastname { get; set; }
		[Required]
		public int Pin { get; set; }
		[Required]
		public virtual List<Class> Classes { get; set; }

	}
}
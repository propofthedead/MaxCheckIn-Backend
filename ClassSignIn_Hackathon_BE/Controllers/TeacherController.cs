using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ClassSignIn_Hackathon_BE.Models;
using ClassSignIn_Hackathon_BE.Utility;

namespace ClassSignIn_Hackathon_BE.Controllers
{
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	public class TeacherController : ApiController
    {
		private LogDbContext db = new LogDbContext();

		[HttpGet]
		[ActionName("List")]
		public JsonResponse List()
		{
			var teach = db.Teachers.ToList();
			return new JsonResponse { Data = teach };
		}
    }
}

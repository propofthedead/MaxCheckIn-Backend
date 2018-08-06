using ClassSignIn_Hackathon_BE.Models;
using ClassSignIn_Hackathon_BE.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using System.Web.Http.Cors;

namespace ClassSignIn_Hackathon_BE.Controllers
{
	//[EnableCors(origins: "*", headers: "*", methods: "*")]
	public class ClassesController : ApiController {

		private LogDbContext db = new LogDbContext();

		////Authenticate user
		//[HttpGet]
		//[ActionName("Authenticate")]
		//public JsonResponse Authenticate(string username, string password) {
		//	if(username == null || password == null) {
		//		return new JsonResponse { Result = "Failed", Message = "Authentication Failed: No Username or Password" };
		//	}
		//	var user = db.Users.SingleOrDefault(u => u.UserName == username && u.Password == password);
		//	if(user == null) {
		//		return new JsonResponse { Result = "Failed", Message = "Authentication Failed: Incorrect Username/Password" };
		//	}
		//	return new JsonResponse { Data = user };
		//}


		//GET-ALL
		//indicates that a get method will be used to get this info vs. post which updates
		[HttpGet]
		[ActionName("List")] //this is the name the client will use to call this method
		public JsonResponse List() {
			return new JsonResponse {
				Data = db.Classes.ToList()
			};
		}

		//GET-ONE
		[HttpGet]
		[ActionName("Get")]
		public JsonResponse Class(int? id) {
			if(id == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Id does not exist"
				};
			}
			return new JsonResponse {
				Data = db.Classes.Find(id)
			};
		}

		//POST
		[HttpPost]
		[ActionName("Create")]
		public JsonResponse Create(Class tgClass) {
			if(tgClass == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Create requires an instance of Class"
				};
			}
			if(!ModelState.IsValid) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Model state is invalid. See data.",
					Error = ModelState
				};
			}

			db.Classes.Add(tgClass);
			db.SaveChanges();
			return new JsonResponse {
				Message = "Create successful.",
				Data = tgClass
			};
		}

		//CHANGE
		[HttpPost]
		[ActionName("Change")]
		public JsonResponse Change(Class tgClass) {
			if(tgClass == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Create requires an instance of Class"
				};
			}
			if(!ModelState.IsValid) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Model state is invalid. See data.",
					Error = ModelState
				};
			}
			db.Entry(tgClass).State = System.Data.Entity.EntityState.Modified;
			db.SaveChanges();
			return new JsonResponse {
				Message = "Change successful.",
				Data = tgClass
			};
		}

		//DELETE
		[HttpPost]
		[ActionName("Remove")]
		public JsonResponse Remove(Class tgClass) {
			if(tgClass == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Create requires an instance of Class"
				};
			}
			if(!ModelState.IsValid) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Model state is invalid. See data.",
					Error = ModelState
				};
			}
			db.Entry(tgClass).State = System.Data.Entity.EntityState.Deleted;
			db.SaveChanges();
			return new JsonResponse {
				Message = "Remove successful.",
				Data = tgClass
			};
		}

		//REMOVE/ID
		[HttpPost]
		[ActionName("RemoveId")]
		public JsonResponse Remove(int? id) {
			if(id == null)
				return new JsonResponse {
					Result = "Failed",
					Message = "RemoveId requires a Class.Id"
				};
			var tgClass = db.Classes.Find(id);
			if(tgClass == null)
				return new JsonResponse {
					Result = "Failed",
					Message = $"No Classes have Id of {id}"
				};
			db.Classes.Remove(tgClass);
			db.SaveChanges();
			return new JsonResponse {
				Message = "Remove successful.",
				Data = tgClass
			};
		}

	}
}


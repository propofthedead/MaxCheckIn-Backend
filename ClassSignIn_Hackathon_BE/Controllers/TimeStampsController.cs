using ClassSignIn_Hackathon_BE.Models;
using ClassSignIn_Hackathon_BE.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ClassSignIn_Hackathon_BE.Controllers
{
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	public class TimeStampsController : ApiController { 
		private Models.LogDbContext db = new LogDbContext();


	//GET-ALL
	//indicates that a get method will be used to get this info vs. post which updates
	[HttpGet]
	[ActionName("List")] //this is the name the client will use to call this method
	public JsonResponse List() {
		return new JsonResponse {
			Data = db.TimeStamps.ToList()
		};
	}

	//GET-ONE
	[HttpGet]
	[ActionName("Get")]
	public JsonResponse TimeStamp(int? id) {
		if(id == null) {
			return new JsonResponse {
				Result = "Failed",
				Message = "Id does not exist"
			};
		}
		return new JsonResponse {
			Data = db.TimeStamps.Find(id)
		};
	}

	//POST
	[HttpPost]
	[ActionName("Create")]
	public JsonResponse Create(TimeStamp timeStamp) {
		if(timeStamp == null) {
			return new JsonResponse {
				Result = "Failed",
				Message = "Create requires an instance of Time Stamp"
			};
		}
		if(!ModelState.IsValid) {
			return new JsonResponse {
				Result = "Failed",
				Message = "Model state is invalid. See data.",
				Error = ModelState
			};
		}

		db.TimeStamps.Add(timeStamp);
		db.SaveChanges();
		return new JsonResponse {
			Message = "Create successful.",
			Data = timeStamp
		};
	}

	//CHANGE
	[HttpPost]
	[ActionName("Change")]
	public JsonResponse Change(TimeStamp timeStamp) {
		if(timeStamp == null) {
			return new JsonResponse {
				Result = "Failed",
				Message = "Create requires an instance of Time Stamp"
			};
		}
		if(!ModelState.IsValid) {
			return new JsonResponse {
				Result = "Failed",
				Message = "Model state is invalid. See data.",
				Error = ModelState
			};
		}
		db.Entry(timeStamp).State = System.Data.Entity.EntityState.Modified;
		db.SaveChanges();
		return new JsonResponse {
			Message = "Change successful.",
			Data = timeStamp
		};
	}

	//DELETE
	[HttpPost]
	[ActionName("Remove")]
	public JsonResponse Remove(TimeStamp timeStamp) {
		if(timeStamp == null) {
			return new JsonResponse {
				Result = "Failed",
				Message = "Create requires an instance of Time Stamp"
			};
		}
		if(!ModelState.IsValid) {
			return new JsonResponse {
				Result = "Failed",
				Message = "Model state is invalid. See data.",
				Error = ModelState
			};
		}
		db.Entry(timeStamp).State = System.Data.Entity.EntityState.Deleted;
		db.SaveChanges();
		return new JsonResponse {
			Message = "Remove successful.",
			Data = timeStamp
		};
	}

	//REMOVE/ID
	[HttpPost]
	[ActionName("RemoveId")]
	public JsonResponse Remove(int? id) {
		if(id == null)
			return new JsonResponse {
				Result = "Failed",
				Message = "RemoveId requires a TimeStamp.Id"
			};
		var timeStamp = db.TimeStamps.Find(id);
		if(timeStamp == null)
			return new JsonResponse {
				Result = "Failed",
				Message = $"No Time Stamp have Id of {id}"
			};
		db.TimeStamps.Remove(timeStamp);
		db.SaveChanges();
		return new JsonResponse {
			Message = "Remove successful.",
			Data = timeStamp
		};
	}

}
}

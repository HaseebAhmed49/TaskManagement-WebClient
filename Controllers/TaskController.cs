using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskManagement_WebClient.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagement_WebClient.Controllers
{
    public class TaskController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var action = "api/Tasks/get-all-tasks";
            var request = ClientHttp.client.GetAsync(action);
            var response = request.Result.Content.ReadAsAsync<List<TaskData>>();
            return View(response.Result);
        }
    }
}
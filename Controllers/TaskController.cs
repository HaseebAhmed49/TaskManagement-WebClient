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


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaskData taskDetails)
        {
            if(!ModelState.IsValid)
            {
                return View(taskDetails);
            }
            var action = "api/Tasks/add-task";
            var request = ClientHttp.client.PostAsJsonAsync(action, taskDetails);
            var response = request.Result.Content.ReadAsStringAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var action = $"api/Tasks/get-task-by-id/{id}";
            var request = ClientHttp.client.GetAsync(action);
            var response = request.Result.Content.ReadAsAsync<TaskData>();
            return (response.Result != null) ? View(response.Result) : View("NotFound");
        }

        [HttpPost]
        public IActionResult Edit(int id,TaskData taskDetails)
        {
            var action = $"api/Tasks/get-task-by-id/{id}";
            var request = ClientHttp.client.GetAsync(action);
            var response = request.Result.Content.ReadAsAsync<TaskData>();
            if(response.Result!=null && response.Result.id==id)
            {
                action = $"api/Tasks/update-task-by-id/{id}";
                request = ClientHttp.client.PutAsJsonAsync(action, taskDetails);
                var result = request.Result.Content.ReadAsStringAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("NotFound");
        }

        public IActionResult Delete(int id)
        {
            var action = $"api/Tasks/get-task-by-id/{id}";
            var request = ClientHttp.client.GetAsync(action);
            var response = request.Result.Content.ReadAsAsync<TaskData>();
            return View(response.Result);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var action = $"api/Tasks/get-task-by-id/{id}";
            var request = ClientHttp.client.GetAsync(action);
            var response = request.Result.Content.ReadAsAsync<TaskData>();
            if (response.Result != null && response.Result.id == id)
            {
                action = $"api/Tasks/delete-task-by-id/{id}";
                request = ClientHttp.client.DeleteAsync(action);
                var result = request.Result.Content.ReadAsStringAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("NotFound");
        }

    }
}
using DepartmentWEBAPP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace DepartmentWEBAPP.Controllers
{
    public class DepartmentController : Controller
    {
        private HttpClient _httpClient = new();
        // GET: DepartmentController
        public ActionResult Index(string searchString)
        {
            if(searchString != null)
            {
                var sresponse = _httpClient.GetAsync($"https://localhost:7109/api/Department/{searchString}").Result;
                string sr = sresponse.Content.ReadAsStringAsync().Result;
                var departments = JsonConvert.DeserializeObject<List<Department>>($"[{sr}]");

                if (!string.IsNullOrEmpty(searchString))
                {
                    departments = departments.Where(d => d.Name.ToLower().Contains(searchString.ToLower())).ToList();
                }

                return View(departments);
            }
            var response = _httpClient.GetAsync("https://localhost:7109/api/Department").Result;
            string s=response.Content.ReadAsStringAsync().Result;
            var content= JsonConvert.DeserializeObject<List<Department>>(s);
            return View(content);
        }

        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            var response = _httpClient.GetAsync($"https://localhost:7109/api/Department/{id}").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string s = response.Content.ReadAsStringAsync().Result;
                var content = JsonConvert.DeserializeObject<Department>(s);
                return View(content);
            }
            else
            {
                return NotFound();
            }
        }


        public ActionResult DetailsbyName(string name)
        {
            var response = _httpClient.GetAsync($"https://localhost:7109/api/Department/{name}").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string s = response.Content.ReadAsStringAsync().Result;
                var content = JsonConvert.DeserializeObject<Department>(s);
                return View(content);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department department)
        {
            try
            {
                var responce = _httpClient.PostAsync($"https://localhost:7109/api/Department", new StringContent(JsonSerializer.Serialize(department), Encoding.UTF8, "application/json")).Result;
                if (responce.StatusCode == HttpStatusCode.Created)
                    return RedirectToAction(nameof(Index));

                throw new Exception();
            }
            catch
            {
                return View(department);
            }
        }




        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            var responce = _httpClient.GetAsync($"https://localhost:7109/api/Department/{id}").Result;
            if (responce.StatusCode == HttpStatusCode.OK)
            {
                string x = responce.Content.ReadAsStringAsync().Result;
                var content = JsonConvert.DeserializeObject<Department>(x);
                return View(content);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Department department)
        {
            try
            {
                var responce = _httpClient.PutAsync($"https://localhost:7109/api/Department/{id}", new StringContent(JsonSerializer.Serialize(department), Encoding.UTF8, "application/json")).Result;
                if (responce.StatusCode == HttpStatusCode.NoContent)
                    return RedirectToAction(nameof(Index));

                throw new Exception();
            }
            catch
            {
                return View(department);
            }
        }

        // GET: DepartmentController/Delete/5
        public ActionResult Delete(int id)
        {
            var responce = _httpClient.GetAsync($"https://localhost:7109/api/Department/{id}").Result;
            if (responce.StatusCode == HttpStatusCode.OK)
            {
                string x = responce.Content.ReadAsStringAsync().Result;
                var content = JsonConvert.DeserializeObject<Department>(x);
                return View(content);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: DepartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Department department)
        {
            try
            {
                var responce = _httpClient.DeleteAsync($"https://localhost:7109/api/Department/{id}").Result;
                if (responce.StatusCode == HttpStatusCode.NoContent && id == department.Id)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return View(department);
            }
        }
    }
}

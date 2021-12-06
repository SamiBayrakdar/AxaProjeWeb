using AxaProjeWeb.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AxaProjeWeb.UI.Conrollers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var client = new RestClient("http://localhost:2903/User");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var content =JsonConvert.DeserializeObject<ApiResponse>(response.Content);

                if (content.Code==200)
                {
                    var customers = JsonConvert.DeserializeObject<List<CustomerListModel>>(content.Set.ToString());
                    return View(customers);
                }
            }
            
            return View(new List<CustomerModel>());
        }

        public IActionResult Login()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            var client = new RestClient("http://localhost:2903/Auth");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);     
            request.AddJsonBody(loginModel);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<ApiResponse>(response.Content);

                if (content.Code == 200)
                {
                    return RedirectToAction("Index");
                }
            }
            

            return View();
        }

      
        [HttpGet]
        public IActionResult DeleteCustomer(int? id)
        {
            var client = new RestClient("http://localhost:2903/User?id="+ id);
            client.Timeout = -1;
            var request = new RestRequest(Method.DELETE);
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<ApiResponse>(response.Content);

                if (content.Code == 200)
                {
                    
                    return Json("200");//Başarılı
                }
            }

            return Json("0"); 
        }

        public IActionResult CustomerEdit(int? id)
        {
            if (id == 0) return RedirectToAction("Index", "Home");

            var client = new RestClient("http://localhost:2903/User/"+id);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<ApiResponse>(response.Content);

                if (content.Code == 200)
                {
                    var customers = JsonConvert.DeserializeObject< List<CustomEditModel>>(content.Set.ToString()).FirstOrDefault();


                    return View(customers);
                }
            }

            return View();
        }
       
        [HttpPost]
        public IActionResult CustomerEdit([FromForm] CustomerListModel customer)
        {
            CustomerEditPostModel mdl = new CustomerEditPostModel();

            mdl.Id = customer.Id;
            mdl.FullName = customer.FullName;
            mdl.Adress = customer.Adress;
            mdl.CostumerCategoriesId = customer.CategoriesId;

            var client = new RestClient("http://localhost:2903/User");
            client.Timeout = -1;
            var request = new RestRequest(Method.PUT);
            request.AddJsonBody(mdl);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<ApiResponse>(response.Content);

                if (content.Code == 200)
                {
                    return RedirectToAction("Index");
                }

            }
                return View();
        }


        public IActionResult CustomerNew()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult CustomerNew([FromForm] CustomerListModel customer)
        {
            CustomerEditPostModel mdl = new CustomerEditPostModel();

            mdl.Id = customer.Id;
            mdl.FullName = customer.FullName;
            mdl.Adress = customer.Adress;
            mdl.CostumerCategoriesId = customer.CategoriesId;

            var client = new RestClient("http://localhost:2903/User");
            client.Timeout = -1;
            var request = new RestRequest(Method.PUT);
            request.AddJsonBody(mdl);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<ApiResponse>(response.Content);

                if (content.Code == 200)
                {
                    return RedirectToAction("Index");
                }

            }
            return View();
        }
    }
}

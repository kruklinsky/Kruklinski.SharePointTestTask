using BLL.Interface.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MvcUI.Controllers
{
    public class HomeController : Controller
    {
        ITestListQueryService testListQueryService;

        public HomeController(ITestListQueryService testListQueryService)
        {
            if(testListQueryService == null)
            {
                throw new System.ArgumentNullException("testListQueryService", "Test list query service is null.");
            }
            this.testListQueryService = testListQueryService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GetTestList()
        {
            var result = new JsonResult();
            result.ContentType = "application/json";
            result.Data = await this.testListQueryService.GetTestListAsync();
            return result;
        }

        //[HttpPost]
        //public JsonResult GetTestList()
        //{
        //    System.Threading.Thread.Sleep(2000);
        //    var result = new JsonResult();
        //    result.ContentType = "application/json";
        //    result.Data = "{ \"d\": { \"results\": [{\"Title\":\"Title\",\"Experience\":1},{\"Title\":\"2\",\"Experience\":2},{\"Title\":\"3\",\"Experience\":3},{\"Title\":\"2\",\"Experience\":2},{\"Title\":\"3\",\"Experience\":3},{\"Title\":\"2\",\"Experience\":2},{\"Title\":\"3\",\"Experience\":3},{\"Title\":\"2\",\"Experience\":2},{\"Title\":\"3\",\"Experience\":3},{\"Title\":\"2\",\"Experience\":2},{\"Title\":\"3\",\"Experience\":3},{\"Title\":\"2\",\"Experience\":2},{\"Title\":\"3\",\"Experience\":3},{\"Title\":\"2\",\"Experience\":2},{\"Title\":\"3\",\"Experience\":3},{\"Title\":\"2\",\"Experience\":2},{\"Title\":\"3\",\"Experience\":3}]}}";
        //    //Response.StatusCode = 500;
        //    return result;
        //}
    }
}

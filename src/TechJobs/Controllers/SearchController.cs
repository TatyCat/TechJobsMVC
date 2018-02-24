using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results

        [HttpPost]
        [Route("search/")]
        public IActionResult Results(string searchType, string searchTerm)
        {
            ViewBag.searchType = searchType;
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";

            if (!System.String.IsNullOrEmpty(searchTerm))
            {
                if (searchType.Equals("all"))
                {
                    ViewBag.results = JobData.FindByValue(searchTerm);
                }

                else
                {
                    ViewBag.results = JobData.FindByColumnAndValue(searchType, searchTerm);
                    //searchType = column
                    //searchTerm = string / contain
                }

                return View("Index");
            }
            else
            {
                return Redirect("/Search");
            }
        }
    }
}

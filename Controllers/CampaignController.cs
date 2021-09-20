using Assignment.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Assignment.Controllers
{
    public class CampaignController : Controller
    {
        static HttpClient cons = new HttpClient();
        static List<Campaign> _Data = new List<Campaign>();
        public ActionResult Index()
        {
            ViewBag.Title = "Campaign Page";

            return View();
        }
        static CampaignController()
        {
            cons.BaseAddress = new Uri("https://testapi.donatekart.com/");
            cons.DefaultRequestHeaders.Accept.Clear();
            cons.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            Task.Run(() => GetDataAsync().GetAwaiter().GetResult());
        }


        /// <summary>
        /// Gets campaigns ordered by order amount descending order
        /// </summary>
        /// <returns></returns>
        // GET api/<controller>/order
        [System.Web.Http.ActionName("order")]
        public ActionResult order()
        {
            List<Campaign> sorted = _Data.OrderByDescending(x => x.TotalAmount).ToList();
            ViewBag.Campaign = sorted;
            return View("OrderedCampaigns");
        }

        /// <summary>
        /// Gets active campaigns
        /// </summary>
        /// <returns></returns>
        // GET api/<controller>/active
        [System.Web.Http.ActionName("active")]
        public ActionResult active()
        {
            List<Campaign> activeCampaigns = _Data.FindAll(x => x.EndDate >= DateTime.Today).ToList();
            List<Campaign> filteredActiveCampaigns = activeCampaigns.FindAll(p => p.Created.Day - DateTime.Today.Day <= 30).ToList();
            ViewBag.Campaign = filteredActiveCampaigns;
            return View("Campaigns");
        }

        /// <summary>
        /// Gets closed campaigns
        /// </summary>
        /// <returns></returns>
        // GET api/<controller>/active
        [System.Web.Http.ActionName("closed")]
        public ActionResult closed()
        {
            List<Campaign> closdCampaigns = _Data.FindAll(x => x.EndDate <= DateTime.Today || x.ProcuredAmount >= x.TotalAmount).ToList();
            ViewBag.Campaign = closdCampaigns;
            return View("Campaigns");
        }

        private static async Task GetDataAsync()
        {
            try
            {
                using (cons)
                {
                    HttpResponseMessage res = await cons.GetAsync("/api/campaign");
                    res.EnsureSuccessStatusCode();
                    if (res.IsSuccessStatusCode)
                    {
                        var jsonString = await res.Content.ReadAsStringAsync();
                        _Data = JsonConvert.DeserializeObject<List<Campaign>>(jsonString);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
using EMSVAPIModel;
using EMSVAPIModel.InuputModel;
using EMSVU.API.Models;
using EMSVUAPIBusiness.Respositories.IServices;
using EMSVUAPIBusiness.Respositories.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EMSUVAPI.Controllers
{
    public class HomeController : Controller
    {
        public IAdminServices _adminServices;
        public HomeController()
        {
            _adminServices = new AdminServices();
        }
        public async Task<ActionResult> Index()
        {


            return View();
        }
    }
}

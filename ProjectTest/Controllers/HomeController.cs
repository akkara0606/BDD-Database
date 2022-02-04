using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using ProjectTest.Data.UnitOfWork;
using ProjectTest.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUnitOfWork _uow;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork uow)

        {
            _logger = logger;
            _uow = uow;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult List()
        {
            return View();
        }

        public IActionResult Upload()
        {
            return View();
        }
        public IActionResult Rqe()
        {
            return View();
        }
        public IActionResult Quotation()
        {
            return View();
        }

        public IActionResult Invoice()
        {
            return View();
        }

        public IActionResult Login()
        {
            
            return View();
        }

        [HttpPost]
        public JsonResult Getdata()
        {
            var docData = _uow.DocumentRepository.GetAll().OrderByDescending(d => d.Tdate);
            return Json(docData);
        }

        [HttpPost]
        public JsonResult GetLgEmp([FromBody] Employee obj)
        {
            try
            {
                var lEmpData = _uow.EmployeeRepository.GetAll().Where(w => w.Employee_id == obj.Employee_id && w.Emp_Password == obj.Emp_Password).FirstOrDefault();
                if (lEmpData != null)
                {
                    return Json(true);
                }
                else
                {
                    return Json(false);
                }
            }
            catch(Exception ex)
            {
                return Json(false);
          }
        }

        [HttpPost]
        public JsonResult GetDataRqe()
        {
            var rqeData = _uow.DocumentRepository.GetAll().Where(w =>  w.Name == "RQE").OrderByDescending(d => d.Tdate);
            return Json(rqeData);
        }

        [HttpPost]
        public JsonResult GetDataQua()
        {
            var quaData = _uow.DocumentRepository.GetAll().Where(w => w.Name == "ใบประเมินราคา").OrderByDescending(d => d.Tdate);
            return Json(quaData);
        }

        [HttpPost]
        public JsonResult GetDataInv()
        {
            var invData = _uow.DocumentRepository.GetAll().Where(w => w.Name == "ใบแจ้งหนี้").OrderByDescending(d => d.Tdate);
            return Json(invData);
        }

        [HttpPost]
        public JsonResult GetNameFile()
        {
            var nameData = _uow.ConfigRepository.GetAll().Where(w => w.ConfigSystem == "Document" && w.ConfigType == "Name");
            return Json(nameData);
        }

        [HttpPost]
        public JsonResult GetDepartment()
        {
            var deData = _uow.ConfigRepository.GetAll().Where(w => w.ConfigSystem == "Document" && w.ConfigType == "Department");
            return Json(deData);
        }

        [HttpPost]
        public JsonResult GetRespons()
        {
            var reData = _uow.ConfigRepository.GetAll().Where(w => w.ConfigSystem == "Document" && w.ConfigType == "Responsible");
            return Json(reData);
        }

        [HttpPost]
        public JsonResult GetLocker()
        {
            var locData = _uow.ConfigRepository.GetAll().Where(w => w.ConfigSystem == "Document" && w.ConfigType == "Locker");
            return Json(locData);
        }

        [HttpPost]
        public JsonResult GetUploader()
        {
            var loadData = _uow.ConfigRepository.GetAll().Where(w => w.ConfigSystem == "Document" && w.ConfigType == "Uploader");
            return Json(loadData);
        }

        [HttpPost]
        public JsonResult AddNewDoc([FromBody] Document obj)
        {
            if (obj != null)
            {
                var doc = new Document()
                {
                    No = obj.No,
                    RQE = obj.RQE,
                    Nameproj = obj.Nameproj,
                    Name = obj.Name,
                    Department = obj.Department,
                    Responsible = obj.Responsible,
                    Locker = obj.Locker,
                    Tdate = obj.Tdate.AddDays(1),
                    Uploader = obj.Uploader,
                    Year = obj.Year,

                };
                _uow.DocumentRepository.Insert(doc);
                _uow.Commit();
                return Json(true);
            }
            else
            {
                return Json(false);
            }

        }



        [HttpPost]
        public JsonResult DeleteDoc([FromBody] string no)
        {
            if (no != null)
            {
                var doc = _uow.DocumentRepository.GetAll().Where(w => w.No == no).FirstOrDefault();
                _uow.DocumentRepository.Delete(doc);
                _uow.Commit();
                return Json(true);
            }
            else
            {
                return Json(false);
            }

        }

        [HttpPost]
        public JsonResult DataDoc([FromBody] string no)
        {
            if (no != null)
            {
                var dAll = _uow.DocumentRepository.GetAll().Where(w => w.No == no).FirstOrDefault();
                return Json(dAll);
            }
            else
            {
                return Json(false);
            }

        }

        [HttpPost]
        public JsonResult UpdateDoc([FromBody] Document obj)
        {
            if (obj != null)
            {
                var doc = new Document()
                {
                    No = obj.No,
                    Name = obj.Name,
                    Department = obj.Department,
                    Locker = obj.Locker,
                    Responsible = obj.Responsible,
                    Tdate = obj.Tdate,
                    
                };
                _uow.DocumentRepository.Update(doc);
                _uow.Commit();
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
//using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
//using Newtonsoft.Json;
//using PhysioWeb.Hubs;
using PhysioWeb.Models;
using PhysioWeb.Repository;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Security.Claims;
using static System.Net.Mime.MediaTypeNames;

namespace PhysioWeb.Controllers
{
    public class ManagementController : Controller
    {
        private readonly ILogger<ManagementController> _logger;
        private readonly IManagementRepository _managementRepository;
        public ManagementController(ILogger<ManagementController> logger, IManagementRepository managementRepository)
        {
            _logger = logger;
            _managementRepository = managementRepository;

        }

        public async Task<ActionResult> Services()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> ListServices()
        {
            var form = Request.Form;

            // ✅ Map DataTables default parameters
            var dataTablePara = new DataTablePara
            {
                iDisplayStart = Convert.ToInt32(form["start"]),
                iDisplayLength = Convert.ToInt32(form["length"]),
                iSortCol_0 = Convert.ToInt32(form["order[0][column]"]),
                sSortDir_0 = form["order[0][dir]"],
                sSearch = form["search[value]"]
            };

            // ✅ Map column filters dynamically (for first 10 columns)
            for (int i = 0; i < 30; i++)
            {
                string key = $"columns[{i}][search][value]";
                if (Request.Form.ContainsKey(key))
                {
                    typeof(DataTablePara)
                        .GetProperty($"sSearch_{i}")
                        ?.SetValue(dataTablePara, Request.Form[key].ToString());
                }
            }
            //dataTablePara.UserID = User.FindFirst(ClaimTypes.PrimarySid)?.Value;
            //dataTablePara.AgencyId = User.FindFirst(ClaimTypes.GroupSid)?.Value;
            var result = await _managementRepository.ListServices(dataTablePara);
            var requestForm = Request.Form;
            return Json(new
            {
                draw = requestForm["draw"],                     // Echo back the draw count
                recordsTotal = result.iTotalRecords,            // Total records in DB
                recordsFiltered = result.iTotalDisplayRecords,  // Total records after filtering
                data = result.aaData                            // Actual paged data
            });

        }

        public async Task<ActionResult> ServicesOffered()
        {
            return View();
        }

    }
}

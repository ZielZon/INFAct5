using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Dynamic;
using API_Prac.Models;
using System.Web.Http;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net.Http;
using System.Net;

namespace API_Prac.Controllers
{
    public class MonitorController : ApiController
    {
        /* These 2 functions are basic data return functions returning a list of keyboards */
        [System.Web.Http.Route("api/Monitor/getAllKeyboards")]
        [System.Web.Mvc.HttpPost]
        public HttpResponseMessage getAllKeyboards()
        {
            API_DBEntities db = new API_DBEntities();
            db.Configuration.ProxyCreationEnabled = false;
            return getKeyboardsReturnList(db.Keyboards.ToList());
        }

        public HttpResponseMessage getKeyboardsReturnList(List<Keyboard> forClient)
        {
            List<dynamic> dynamicKeyboards = new List<dynamic>();
            foreach (Keyboard KB in forClient)
            {
                dynamic dynamicKN = new ExpandoObject();
                dynamicKN.Keyoard_ID = KB.Keyboard_ID;
                dynamicKN.Keyoard_Name = KB.Keyboard_Name;
                dynamicKN.Brand_ID = KB.Brand_ID;
                dynamicKeyboards.Add(dynamicKN);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK, dynamicKeyboards);
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            return response;
        }

        /* these functions return all monitors nested within their related brand */
        [System.Web.Http.Route("api/Keyboards/getAllBrandsWithMonitors")]
        [System.Web.Mvc.HttpPost]
        public List<dynamic> getAllBrandsWithMonitors()
        {
            API_DBEntities db = new API_DBEntities();
            db.Configuration.ProxyCreationEnabled = false;
            List<Brand> Brands = db.Brands.Include(zz => zz.Monitors).ToList();
            return getAllBrandsWithMonitors(Brands);
        }
        public List<dynamic> getAllBrandsWithMonitors(List<Brand> forClient)
        {
            List<dynamic> dynBrands = new List<dynamic>();
            foreach (Brand Brand in forClient)
            {
                dynamic ret = new ExpandoObject();
                ret.Brand_ID = Brand.Brand_ID;
                ret.Brand_Name = Brand.Brand_Name;
                ret.Monitors = getMonitors(Brand);
                dynBrands.Add(ret);
            }
            return dynBrands;
        }

        private List<dynamic> getMonitors(Brand Brand)
        {
            List<dynamic> dynMon = new List<dynamic>();
            foreach(Monitor Mon in Brand.Monitors)
            {
                dynamic dynMoni = new ExpandoObject();
                dynMoni.Monitor_ID = Mon.Monitor_ID;
                dynMoni.Monitor_Name = Mon.Monitor_Name;
                dynMon.Add(dynMoni);
            }
            return dynMon;
        }



        /* these functions return all keyboards nested within their related brand */
        [System.Web.Http.Route("api/Keyboards/getAllBrandsWithKeyboards")]
        [System.Web.Mvc.HttpPost]
        public List<dynamic> getAllBrandsWithKeyboards()
        {
            API_DBEntities db = new API_DBEntities();
            db.Configuration.ProxyCreationEnabled = false;
            List<Brand> Brands = db.Brands.Include(zz => zz.Keyboards).ToList();
            return getAllBrandsWithKeyboards(Brands);
        }
        public List<dynamic> getAllBrandsWithKeyboards(List<Brand> forClient)
        {
            List<dynamic> dynBrands = new List<dynamic>();
            foreach (Brand Brand in forClient)
            {
                dynamic ret = new ExpandoObject();
                ret.Brand_ID = Brand.Brand_ID;
                ret.Brand_Name = Brand.Brand_Name;
                ret.Keyboards = getKeyboards(Brand);
                dynBrands.Add(ret);
            }
            return dynBrands;
        }

        private List<dynamic> getKeyboards(Brand Brand)
        {
            List<dynamic> dynKB = new List<dynamic>();
            foreach (Keyboard KB in Brand.Keyboards)
            {
                dynamic dynKBi = new ExpandoObject();
                dynKBi.Keyboard_ID = KB.Keyboard_ID;
                dynKBi.Keyboard_Name = KB.Keyboard_Name;
                dynKB.Add(dynKBi);
            }
            return dynKB;
        }


        /* Add brands with keyboards
         * This function only a brand and keyboards */
        [System.Web.Http.Route("api/Keyboards/addBrandsWithKeyboards")]
        [System.Web.Mvc.HttpPost]
        public List<dynamic> addBrandsWithKeyboards([FromBody] List<Brand> Brands)
        {
            API_DBEntities db = new API_DBEntities();
            db.Configuration.ProxyCreationEnabled = false;
            db.Brands.AddRange(Brands);
            db.SaveChanges();
            return getAllBrandsWithKeyboards();
        }


        /* Add brands with keyboards
         * This function only adds a brand*/
        [System.Web.Http.Route("api/Keyboards/addBrandWithKeyboards")]
        [System.Web.Mvc.HttpPost]
        public List<dynamic> addBrandWithKeyboards([FromBody] Brand Brand)
        {
            API_DBEntities db = new API_DBEntities();
            db.Configuration.ProxyCreationEnabled = false;
            db.Brands.Add(Brand);
            db.SaveChanges();
            return getAllBrandsWithKeyboards();
        }
    }

    
}
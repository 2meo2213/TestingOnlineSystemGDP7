using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Model;
using Newtonsoft.Json;
using Services;
using WebApi.Commons;

namespace WebApi.Controllers
{


    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SubjectController : ApiController
    {

        private SubjectService service;

        public SubjectController()
        {
            service = new SubjectService();
        }
        [HttpGet]
        [ValidateSSID(ActionId =1)]
        public string Get()
        {
            var result = service.GetAll().ToList();
            return JsonConvert.SerializeObject(result, Formatting.Indented, new JsonSerializerSettings
            {
ReferenceLoopHandling=ReferenceLoopHandling.Ignore
            });
        }
       [HttpGet]
       [ValidateSSID(ActionId =2)]
       public string Get(int id)
        {
            var result = service.GetById(id);
            return JsonConvert.SerializeObject(result, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }
       

        [HttpPost]
        [ValidateSSID(ActionId =3)]
        public string Get([FromUri]string action, [FromBody]string value)
        {
            if (value != null && !"".Equals(value))
            {
                if ("search".Equals(action))
                {
                    return JsonConvert.SerializeObject(service.Search(value));
                }
                
            }
            var result = service.GetAll().ToList();
            return JsonConvert.SerializeObject(result);

        }
        [HttpPost]
        [ValidateSSID(ActionId = 4)]
        public string Post([FromBody]object value)
        {
            if (value != null)
            {
                var subject = JsonConvert.DeserializeObject<Subject>(value.ToString());
                subject.CreatdeDate = DateTime.Now;
                var result = service.Insert(subject);
                return JsonConvert.SerializeObject(result);
            }
            return "FALSE";
        }

        [HttpPut]
        [ValidateSSID(ActionId = 2)]
        public string Put(int id, [FromBody]object value)
        {
            if (value != null)
            {
                var subject = JsonConvert.DeserializeObject<Subject>(value.ToString());
                subject.SubjectID = id;
                subject.CreatdeDate = DateTime.Now;
                var result = service.Update(subject);
                return JsonConvert.SerializeObject(result);
            }
            return "FALSE";
        }
        [HttpDelete]
        [ValidateSSID(ActionId = 3)]
        public string Put(int id)
        {
            try
            {
                var result = service.Delete(id);
                return JsonConvert.SerializeObject(result);
            }
            catch
            {
                return "0";
            }
        }
    }
}
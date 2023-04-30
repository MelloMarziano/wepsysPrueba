using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PersonController : ApiController
    {

        public List<Persona> Get()
        {
            return PersonData.getAllPersons();
        }

        // POST api/<controller>
        //public bool Postss([FromBody] Persona persona) {
        //    return PersonData.registerPerson(persona);
        //}

        // POST api/<controller>
        public HttpResponseMessage Post(Persona persona) {
            if (ModelState.IsValid)
            {
               var result =  PersonData.registerPerson(persona);
                if (result)
                {
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
               
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        public Persona Get(string matricula)
        {
            return PersonData.getByMatricula(matricula);
        }

    }
}

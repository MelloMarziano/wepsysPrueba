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
        public bool Post([FromBody] Persona persona) {
            return PersonData.registerPerson(persona);
        }

        public Persona Get(string matricula)
        {
            return PersonData.getByMatricula(matricula);
        }

    }
}

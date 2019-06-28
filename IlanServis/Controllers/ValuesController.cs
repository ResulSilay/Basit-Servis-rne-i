using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IlanServis.Methods;
using IlanServis.Models;
using Microsoft.AspNetCore.Mvc;

namespace IlanServis.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        Database database;

        public void Connect()
        {
            database = Database.Instance();
            database.IsConnect();
        }

        [HttpPost]
        public IEnumerable<Advertisement> Get()
        {
            Connect();
            return database.get_Advertisement();
        }

        [HttpPost("{id}")]
        public IEnumerable<Advertisement> Get(int id)
        {
            Connect();
            Debug.WriteLine("GET: --> " + id.ToString());
            return database.get_Advertisement(id);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Advertisement advertisement)
        {
            Connect();
            if (database.get_Bool("select id from advertisements where id=" + id.ToString()))
                database.command("update advertisements set subject='" + advertisement.subject + "',description='" + advertisement.description + "' where id=" + id.ToString());
            else
                database.command("insert into advertisements (subject,description) values('" + advertisement.subject + "','" + advertisement.description + "')");
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Connect();
            database.command("delete from advertisements where id=" + id.ToString());
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Text;
using MVVMApi_ISRPO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private static string connString = "Initial Catalog=ISRPO;Integrated Security=true;Server=BULLDOG;Encrypt=False";
        private static SqlConnection conn = new SqlConnection(connString);
        // GET: api/<ContactsController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<ContactsController>/5
        [HttpGet]
        public string Get()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM contacts", conn);
            conn.Open();
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            conn.CloseAsync();

            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(dt);
            return JSONresult;
        }

        // DELETE api/<ContactsController>/5
        [HttpDelete]
        public void Delete()
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM contacts WHERE id = (SELECT min(id) FROM contacts)", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.CloseAsync();
            return;
        }

        // PUT /contacts/put
        // insert into contacts(name, surname, phone) values('Вася','Пупкин','1111')
        [HttpPut]
        public void Put(Contact contact)
        {
            SqlCommand cmd = new SqlCommand($"insert into contacts(name, surname, phone) values('{contact.Name}','{contact.Surname}','{contact.Phone}')", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.CloseAsync();
        }
    }
}

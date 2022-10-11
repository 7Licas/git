using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace WebApplication1.Controllers
{
    public class TestController : ApiController
    {
        public IHttpActionResult GetHello ()
        {
            return Json("hello world!");
        }
        public IHttpActionResult GetStudentList()
        {
            string strConn = ConfigurationManager.ConnectionStrings["StudentDB"].ConnectionString;
            var sql = "select * from data";
            using (var conn = new SqlConnection(strConn))
            {
                var result = conn.Query<dynamic>(sql);
                return Json(result.ToList());
            }
        }
    }
}

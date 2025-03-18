using System.Collections.Generic;
using System.Web.Http;
using PayrollApi.Models;
using PayrollApi.Services;

namespace PayrollApi.Controllers
{
    [RoutePrefix("api/payroll")]
    public class PayrollController : ApiController
    {
       private static readonly List<Payroll> Payrolls = new List<Payroll>();

       [HttpGet]
       [Route("")]
       public IHttpActionResult GetAll()
       {
           return Ok(Payrolls);
       }

       [HttpGet]
       [Route("{id:int}")]
       public IHttpActionResult Get(int id)
       {
           var payroll = Payrolls.Find(x => x.Id == id);
           if (payroll == null)
           {
               return NotFound();
           }
           
           return Ok(payroll);
       }

       [HttpPost]
       [Route("")]
       public IHttpActionResult Add([FromBody]Payroll payroll)
       {
           var isPayrollValid = PayrollService.ValidatePayrollObject(payroll);
           
           if (!isPayrollValid)
           {
               return BadRequest("Object is not a valid Payroll");
           }
           
           payroll.Id = Payrolls.Count + 1;
           Payrolls.Add(payroll);
           return Ok(payroll);
       }

       [HttpDelete]
       [Route("{id:int}")]
       public IHttpActionResult Delete(int id)
       {
           var payroll = Payrolls.Find(x => x.Id == id);
           
           if(payroll == null) return BadRequest("Payroll not found");
           
           Payrolls.Remove(payroll);
           
           return Ok(payroll);
       }

       [HttpPut]
       [Route("{id:int}")]
       public IHttpActionResult Put(int id, [FromBody] Payroll payroll)
       {
           
           var isPayrollValid = PayrollService.ValidatePayrollObject(payroll);
           
           if (!isPayrollValid)
           {
               return BadRequest("Object is not a valid Payroll");
           }
           
           var index = Payrolls.FindIndex(x => x.Id == id);
           Payrolls[index] = payroll;
           return Ok(Payrolls[index]);
       }
    }
}
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using PayrollApi.Data;
using PayrollApi.Models;
using PayrollApi.Services;

namespace PayrollApi.Controllers
{
    [RoutePrefix("api/payroll")]
    public class PayrollController : ApiController
    {

        private readonly DbContextOracle _context;

        public PayrollController(DbContextOracle context) 
        { 
            _context = context;
        }

       [HttpGet]
       [Route("")]
       public IHttpActionResult GetAll()
       {
            var allPayrolls = _context.Payrolls.ToList();
            return Ok(allPayrolls);
       }

       [HttpGet]
       [Route("{id:int}")]
       public IHttpActionResult Get(int id)
       {
           var payroll = _context?.Payrolls?.Where(x => x.Id == id).FirstOrDefault();
           if (payroll == null)
           {
               return NotFound();
           }
           
           return Ok(payroll);
       }

       [HttpPost]
       [Route("")]
       public async Task<IHttpActionResult> Add([FromBody]Payroll payroll)
       {
           var isPayrollValid = PayrollService.ValidatePayrollObject(payroll);
           
           if (!isPayrollValid)
           {
               return BadRequest("Object is not a valid Payroll");
           }
           
           _context.Payrolls.Add(payroll);
           await _context.SaveChangesAsync();
           return Ok(payroll);
       }

       [HttpDelete]
       [Route("{id:int}")]
       public async Task<IHttpActionResult> Delete(int id)
       {
           var payroll = _context?.Payrolls?.Where(x => x.Id == id).FirstOrDefault();
           
           if(payroll == null) return BadRequest("Payroll not found");

            _context.Payrolls.Remove(payroll);
            await _context.SaveChangesAsync();

            return Ok(payroll);
       }

       [HttpPut]
       [Route("{id:int}")]
       public async Task<IHttpActionResult> Put(int id, [FromBody] Payroll payroll)
       {
           
           var isPayrollValid = PayrollService.ValidatePayrollObject(payroll);
           
           if (!isPayrollValid)
           {
               return BadRequest("Object is not a valid Payroll");
           }
           
           var updatePayroll = _context?.Payrolls?.Where(x => x.Id == id).FirstOrDefault();

           if (updatePayroll == null) return BadRequest();

           updatePayroll = payroll;
           await _context.SaveChangesAsync();

           return Ok(updatePayroll);
       }
       
    }
}
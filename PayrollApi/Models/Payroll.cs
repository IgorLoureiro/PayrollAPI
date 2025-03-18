using System;

namespace PayrollApi.Models
{
    public class Payroll
    {
        public int  Id { get; set; }
        public string EmployeeName { get; set; }
        public decimal Salary { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
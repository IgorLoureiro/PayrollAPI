using PayrollApi.Models;

namespace PayrollApi.Services
{
    public static class PayrollService
    {
        public static bool ValidatePayrollObject(Payroll payroll)
        {
            if (payroll == null) return false;
            if (string.IsNullOrEmpty(payroll.EmployeeName)) return false;
            return payroll.Salary >= 0;
        }
    }
}
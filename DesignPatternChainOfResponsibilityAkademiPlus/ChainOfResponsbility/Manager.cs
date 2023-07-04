using DesignPatternChainOfResponsibilityAkademiPlus.DAL;
using DesignPatternChainOfResponsibilityAkademiPlus.Models;

namespace DesignPatternChainOfResponsibilityAkademiPlus.ChainOfResponsbility
{
    public class Manager : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            Context context= new Context();
            if (req.Amount <= 250000)
            {
                CustomerProcess customerProcess= new CustomerProcess();
                customerProcess.Amount= req.Amount;
                customerProcess.CustomerName= req.CustomerName;
                customerProcess.CustomerSurname= req.CustomerSurname;
                customerProcess.EmployeeName = "Şube Müdürü Beyza Yaprak";
                customerProcess.Description = "Müşterinin talep ettiği tutar şube müdürü tarafından ödenmiştir";
                context.Add(customerProcess);
                context.SaveChanges();
            }
            else if(NextApprover!=null)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.CustomerSurname = req.CustomerSurname;
                customerProcess.EmployeeName = "Şube Müdürü Beyza Yaprak";
                customerProcess.Description = "Müşterinin talep ettiği tutar şube müdürü tarafından ödenememiştir, işlem bölge müdürüne aktarılmıştır";
                context.Add(customerProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(req);
            }
        }
    }
}

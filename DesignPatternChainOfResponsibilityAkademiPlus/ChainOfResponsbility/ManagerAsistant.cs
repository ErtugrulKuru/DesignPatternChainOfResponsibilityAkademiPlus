using DesignPatternChainOfResponsibilityAkademiPlus.DAL;
using DesignPatternChainOfResponsibilityAkademiPlus.Models;

namespace DesignPatternChainOfResponsibilityAkademiPlus.ChainOfResponsbility
{
    public class ManagerAsistant : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            Context context= new Context();
            if (req.Amount <= 150000)
            {
                CustomerProcess customerProcess= new CustomerProcess();
                customerProcess.Amount= req.Amount;
                customerProcess.CustomerName= req.CustomerName;
                customerProcess.CustomerSurname= req.CustomerSurname;
                customerProcess.EmployeeName = "Şube Müdür Yardımcısı Büşra Yıldırım";
                customerProcess.Description = "Müşterinin talep ettiği tutar müşteriye şube müdür yardımcısı tarafından ödenmiştir";
                context.Add(customerProcess);
                context.SaveChanges();
            }
            else if (NextApprover!=null)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.CustomerSurname = req.CustomerSurname;
                customerProcess.EmployeeName = "Şube Müdür Yardımcısı Büşra Yıldırım";
                customerProcess.Description = "Müşterinin talep ettiği tutar müşteriye şube müdür yardımcısı tarafından ödenemedi, işlem şube müdürüne aktarıldı";
                context.Add(customerProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(req);
            }
        }
    }
}

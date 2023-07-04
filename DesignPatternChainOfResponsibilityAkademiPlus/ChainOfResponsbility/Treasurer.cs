using DesignPatternChainOfResponsibilityAkademiPlus.DAL;
using DesignPatternChainOfResponsibilityAkademiPlus.Models;

namespace DesignPatternChainOfResponsibilityAkademiPlus.ChainOfResponsbility
{
    public class Treasurer : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            Context context= new Context();
            if (req.Amount <= 80000)
            {
                CustomerProcess customerProcess= new CustomerProcess();
                customerProcess.Amount= req.Amount;
                customerProcess.CustomerName= req.CustomerName;
                customerProcess.CustomerSurname= req.CustomerSurname;
                customerProcess.EmployeeName= "Gişe Memuru Alya Irmak";
                customerProcess.Description = "Müşterinin talep ettiği tutar müşteriye gişe memuru tarafından ödenmiştir";
                context.Add(customerProcess);
                context.SaveChanges();
            }
            else if(NextApprover!=null)
            {
                CustomerProcess customerProcess= new CustomerProcess();
                customerProcess.Amount=req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.CustomerSurname = req.CustomerSurname;
                customerProcess.EmployeeName = "Gişe Memuru Alya Irmak";
                customerProcess.Description = "Müşterinin talep ettiği tutar gişe memuru tarafından ödenemedi işlem şube müdür yardımcısına aktarıldı";
                context.Add(customerProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(req);
            }
        }
    }
}

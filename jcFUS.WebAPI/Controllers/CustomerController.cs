using jcFUS.PCL.Transports.Customer;
using jcFUS.PCL.Transports.Global;
using jcFUS.WebAPI.Managers;

namespace jcFUS.WebAPI.Controllers {
    public class CustomerController : BaseController {
        public ReturnSet<bool> POST(CustomerCreationRequestItem requestItem) => new CustomerManager().Create(requestItem);
    }
}
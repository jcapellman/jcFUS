using jcFUS.PCL.Transports.Customer;
using jcFUS.WebAPI.Managers;

namespace jcFUS.WebAPI.Controllers {
    public class CustomerController : BaseController {
        public bool POST(CustomerCreationRequestItem requestItem) => new CustomerManager().Create(requestItem);
    }
}
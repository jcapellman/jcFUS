using System.Threading.Tasks;

using jcFUS.PCL.Transports.Customer;
using jcFUS.PCL.Transports.Global;

namespace jcFUS.PCL.Handlers {
    public class CustomerHandler : BaseHandler {
        protected override string BaseControllerName() => "Customer";

        public async Task<ReturnSet<bool>> CreateCustomer(CustomerCreationRequestItem requestItem)
            => await PostAsync<CustomerCreationRequestItem, ReturnSet<bool>>(requestItem);
    }
}
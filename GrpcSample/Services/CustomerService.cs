using Grpc.Core;

namespace GrpcSample.Services
{
    public class CustomerService:Customer.CustomerBase
    {
        private readonly ILogger<CustomerService> logger;
        public CustomerService(ILogger<CustomerService> logger)
        {
            this.logger = logger;
        }
        public override Task<CustomerList> GetCustomers(CustomerInput request, ServerCallContext context)
        {
            var cuList = new CustomerData();
            var cus = new CustomerList();
            cus.Customers.AddRange(cuList.customers);
            return Task.FromResult(cus);
        }
    }
}

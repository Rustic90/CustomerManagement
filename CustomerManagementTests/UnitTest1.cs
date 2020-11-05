using System;
using Xunit;
using CustomerManagement;
using Xunit.Sdk;

namespace CustomerManagementTest
{
    public class CustomerTests
    {
        [Fact]
        public void TestCustomerCreation()
        {
            Customer testCustomer = new Customer("test", "customer", "502-555-1234", "01/01/1980");
            Assert.Equal("test", testCustomer.FirstName);
            Assert.Equal("customer", testCustomer.LastName);
            Assert.Equal("502-555-1234", testCustomer.PhoneNumber);
            Assert.Equal("01/01/1980", testCustomer.Birthday);
        }
        [Fact]
        public void TestSearchSingleCustomer()
        {
            Menu testMenu = new Menu();
            Customer testCustomer = testMenu.SearchSingleCustomer("Curtis");
            Assert.Equal("Alcorn", testCustomer.LastName);

        }
    }
}
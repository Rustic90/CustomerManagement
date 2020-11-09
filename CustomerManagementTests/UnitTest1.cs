using System;
using Xunit;
using CustomerManagement;
using Xunit.Sdk;
using System.Collections.Generic;

namespace CustomerManagementTest
{
    public class CustomerTests
    {
        [Fact]
        public void testSearchCustomers()
        {
            Menu testMenu = new Menu();
            List<Customer> Customers = testMenu.SearchCustomers();
            Assert.NotEmpty(Customers);

        }
        [Fact]
        public void testCustomerCreation()
        {
            Customer testCustomer = new Customer("test", "customer", "502-555-1234", "01/01/1980");
            Assert.Equal("test", testCustomer.FirstName);
            Assert.Equal("customer", testCustomer.LastName);
            Assert.Equal("502-555-1234", testCustomer.PhoneNumber);
            Assert.Equal("01/01/1980", testCustomer.Birthday);
        }
        [Fact]
        public void testSearchSingleCustomer()
        {
            Menu testMenu = new Menu();
            Customer testCustomer = testMenu.SearchSingleCustomer("Curtis");
            string expected = "Alcorn";
            Assert.Equal(expected, testCustomer.LastName);

        }
    }
}
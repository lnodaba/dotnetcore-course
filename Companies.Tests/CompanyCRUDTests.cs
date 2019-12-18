using System;
using Trailers.MVC.DAL;
using Trailers.MVC.Models;
using Xunit;

namespace Companies.Tests
{
    public class CompanyCRUDTests
    {
        [Fact]
        public void TestCreate()
        {
            //Arrange
            Company company = new Company()
            {
                Contact = "John Doe",
                Country = "Romania",
                Name = "DELL"
            };
            CompaniesDAL dal = new CompaniesDAL();

            //Act
            bool succeed = dal.AddCompany(company);
            
            //Assert
            bool expected = true;
            Assert.Equal(expected, succeed);
        }

        [Fact]
        public void TestDelete()
        {
            Company company = new Company()
            {
                Contact = "John Doe",
                Country = "Romania",
                Name = "DELL"
            };

            CompaniesDAL dal = new CompaniesDAL();

            //Act
            bool succeed = dal.RemoveCompany(company);

            //Assert
            bool expected = true;
            Assert.Equal(expected, succeed);
        }

        [Fact]
        public void TestRead()
        {

        }

        [Fact]
        public void TestUpdate()
        {

        }

       
    }
}

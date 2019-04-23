using CJ.DAL;
using CJ.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJ.UnitTest
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestCreate()
        {
            //User user = new User();
            //user.Name = "ceshi";
            //user.Phone = "phone";
            //user.CreateTime = DateTime.Now;
            //Assert.IsTrue(SqlHelper.Create(user));
        }


        [Test]
        public void TestRetrieve()
        {
            User user = SqlHelper.Retrieve<User>(1033);
            Assert.IsNotNull(user);
        }
    }
}

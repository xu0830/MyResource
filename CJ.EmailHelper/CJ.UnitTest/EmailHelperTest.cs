using CJ.SMS;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJ.UnitTest
{
    [TestFixture]
    public class EmailHelperTest
    {
        [Test]
        public void TestMethod()
        {
            EmailHelper.Send("1126818689@qq.com", "这是一条主题", "邮件内容");
        }
    }
}

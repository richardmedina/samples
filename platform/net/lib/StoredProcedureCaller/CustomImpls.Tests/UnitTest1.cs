using CustomImpls.Data;
using CustomImpls.Tests.StoredProcedures;

namespace CustomImpls.Tests
{
    [TestClass]
    public class UnitTest1
    {   
        [TestMethod]
        public void TestMethod1()
        {
            var sp = new AddUserStoredProcedure();
            sp.Id = "ricki9@gmail.com";//Guid.NewGuid().ToString();
            sp.FirstName = "Manuel";
            sp.LastName = "Medina Lopez";
            using(var context = new DataDbContext())
            {
                context.CallStoredProcedure(sp);
            }
        }
    }
}
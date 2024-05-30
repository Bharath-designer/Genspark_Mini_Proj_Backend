using EventManagementApp.Models;

namespace EventManagementTest
{
    class RefundTest
    {
        private TestDBContext _context;

        [SetUp]
        public void Setup()
        {
            _context = new TestDBContext(TestDBContext.GetInMemoryOptions());

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }


        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test]
        public void CreateRefund()
        {
            Refund refund = new Refund
            {
                OrderId = 1,
                RefundAmount = 1000,
                RefundDate = DateTime.Now,
            };

            Assert.IsNotNull(refund);
        }


    }
}

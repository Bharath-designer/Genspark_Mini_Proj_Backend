
using EventManagementApp.Context;
using EventManagementApp.DTOs.EventCategory;
using EventManagementApp.Exceptions;
using EventManagementApp.Interfaces.Repository;
using EventManagementApp.Interfaces.Service;
using EventManagementApp.Repositories;
using EventManagementApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EventManagementTest
{
    class AdminTest
    {
        private EventManagementDBContext _context;
        private IAdminService _adminService;

        [SetUp]
        public void Setup()
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder().UseInMemoryDatabase("EventManagementDB");
            _context = new EventManagementDBContext(optionsBuilder.Options);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();


            IConfiguration configuration = new InMemoryConfiguration().Configuration;

            
            IEventCategoryRepository _eventCategoryRepo = new EventCategoryRepository(_context);
            IScheduledEventRepository _scheduledRepo = new ScheduledEventRepository(_context);
            IQuotationRequestRepository _quotationRequestRepo = new QuotationRequestRepository(_context);

            _adminService = new AdminService(_eventCategoryRepo, _scheduledRepo, _quotationRequestRepo);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test]
        public async Task CreateEventCategoryTest()
        {
            // Arrange
            CreateEventCategoryDTO createEventCategoryDTO = new CreateEventCategoryDTO
            {
                EventName = "Testing Event",
                Description = "Testing Description"
            };

            // Act
            await _adminService.CreateEventCategory(createEventCategoryDTO);

            // Assert
            var eventCategory = await _context.EventCategories.FirstOrDefaultAsync(e=>e.EventName == createEventCategoryDTO.EventName);
            Assert.IsNotNull(eventCategory);
        }

        [Test]
        public async Task GetScheduledEvents()
        {
            // Act
            var events = await _adminService.GetScheduledEvents();

            // Assert
            Assert.IsNotNull(events);
        }

        [Test]
        public async Task UpdateEventDetails()
        {
            // Arrange
            CreateEventCategoryDTO createEventCategoryDTO = new CreateEventCategoryDTO
            {
                EventName = "Testing Event",
                Description = "Testing Description"
            };

            var updateEventCategoryDTO = new UpdateEventCategoryDTO
            {
                EventName = "Updated Event Name",
                Description = "Updated Description",
                IsActive = true
            };

            // Act
            await _adminService.CreateEventCategory(createEventCategoryDTO);
            await _adminService.UpdateEventDetails(1,updateEventCategoryDTO);

            // Assert
            var eventCategory = await _context.EventCategories.FirstOrDefaultAsync(e => e.EventName == updateEventCategoryDTO.EventName);
            Assert.IsNotNull(eventCategory);

        }

        [Test]
        public void UpdateEventDetailsFail1()
        {
            // Arrange
           
            var updateEventCategoryDTO = new UpdateEventCategoryDTO
            {
                EventName = "Updated Event Name",
                Description = "Updated Description",
                IsActive = true
            };

            Assert.ThrowsAsync<NoEventCategoryFoundException>(async () =>
            { 
                await _adminService.UpdateEventDetails(999, updateEventCategoryDTO);
            });
        }

        [Test]
        public async Task UpdateEventDetailsFail2()
        {
            // Arrange

            CreateEventCategoryDTO createEventCategoryDTO = new CreateEventCategoryDTO
            {
                EventName = "Testing Event",
                Description = "Testing Description"
            };

            await _adminService.CreateEventCategory(createEventCategoryDTO);

            var updateEventCategoryDTO = new UpdateEventCategoryDTO();


            Assert.ThrowsAsync<NullReferenceException>(async () =>
            {
                await _adminService.UpdateEventDetails(1, updateEventCategoryDTO);
            });
        }

        [Test]
        public async Task GetAllEventCategories()
        {
            var eventCategories = await _adminService.GetAllEventCategories();
            Assert.IsNotNull(eventCategories);
        }

        [Test]
        public async Task GetQuotations()
        {
            // Act
            var events = await _adminService.GetQuotations(isNew: true);

            // Assert
            Assert.IsNotNull(events);
        }
    }
}

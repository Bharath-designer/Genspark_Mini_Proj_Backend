using EventManagementApp.Context;
using EventManagementApp.DTOs.NotificationDTOs;
using EventManagementApp.Interfaces.Repository;
using EventManagementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementApp.Repositories
{
    public class NotificationRepository : Repository<Notification, int>, INotificationRepository 
    {
        public NotificationRepository(EventManagementDBContext _context) : base(_context)
        {
        }

        public async Task<NotificationReturnDTO> GetNotificationByIdWithUserId(int notificationId, int userId)
        {
            NotificationReturnDTO? returnDTO = await _context.Notifications
                .Where(n => n.NotificationId == notificationId && n.UserId == userId)
                .Select(n => new NotificationReturnDTO
                {
                    IsRead = n.IsRead,
                    Message = n.Message,
                    NotificationDate = n.NotificationDate,
                    SourceURL = n.SourceURL,
                    NotificationId = n.NotificationId,
                })
                .FirstOrDefaultAsync();

            return returnDTO;
        }

        public async Task<List<NotificationReturnDTO>> GetNotificationsWithUserId(int userId)
        {
            List<NotificationReturnDTO> returnDTO = await _context.Notifications
                            .Where(n => n.UserId == userId)
                            .Select(n => new NotificationReturnDTO
                            {
                                IsRead = n.IsRead,
                                Message = n.Message,
                                NotificationDate = n.NotificationDate,
                                SourceURL = n.SourceURL,
                                NotificationId = n.NotificationId
                            })
                            .OrderByDescending(n=>n.NotificationDate)
                            .ToListAsync();
            return returnDTO;
        }
    }
}

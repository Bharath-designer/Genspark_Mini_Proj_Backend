using EventManagementApp.DTOs.NotificationDTOs;
using EventManagementApp.Models;

namespace EventManagementApp.Interfaces.Repository
{
    public interface INotificationRepository:IRepository<Notification, int>
    {
        public Task<NotificationReturnDTO> GetNotificationByIdWithUserId(int notificationId, int userId);
        public Task<List<NotificationReturnDTO>> GetNotificationsWithUserId(int userId);
    }
}

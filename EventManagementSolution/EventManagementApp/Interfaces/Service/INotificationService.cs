using EventManagementApp.DTOs.NotificationDTOs;

namespace EventManagementApp.Interfaces.Service
{
    public interface INotificationService
    {
        public Task CreateNotification(int userId,string Message, string SourceURL);
        public Task<NotificationReturnDTO> GetNotificationById(int userId, int NotificatinId);
        public Task<List<NotificationReturnDTO>> GetAllNotifications(int userId);


    }
}

using EventManagementApp.DTOs.NotificationDTOs;
using EventManagementApp.Exceptions;
using EventManagementApp.Interfaces.Repository;
using EventManagementApp.Interfaces.Service;
using EventManagementApp.Models;
using EventManagementApp.Repositories;

namespace EventManagementApp.Services
{
    public class NotificationService : INotificationService
    {
        private INotificationRepository _notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task CreateNotification(int UserId, string Message, string SourceURL)
        {
            Notification notification = new Notification
            {
                UserId = UserId,
                Message = Message,
                SourceURL = SourceURL,
            };

            await _notificationRepository.Add(notification);
        }

        public async Task<NotificationReturnDTO> GetNotificationById(int userId, int NotificatinId)
        {
            var notificationDTO = await _notificationRepository.GetNotificationByIdWithUserId(NotificatinId, userId);
            if (notificationDTO == null)
            {
                throw new NoNotificationFoundException();
            }
            if (notificationDTO.IsRead == false)
            {
                var notification = await _notificationRepository.GetById(NotificatinId);
                notification.IsRead = true;
                await _notificationRepository.Update(notification);
            }

            return notificationDTO;
        }

        public async Task<List<NotificationReturnDTO>> GetAllNotifications(int userId)
        {
            var notifications = await _notificationRepository.GetNotificationsWithUserId(userId);
            return notifications;
        }

    }
}

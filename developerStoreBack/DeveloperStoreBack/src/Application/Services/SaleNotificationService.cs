using DeveloperStoreBack.Application.DTOs;

namespace DeveloperStoreBack.Application.Notifications
{
    public class SaleNotificationService
    {
        public void Notify(SaleNotificationDto notification)
        {
            Console.WriteLine($"Notifica��o: {notification.Message} para a venda ID: {notification.SaleId}");
        }
    }
}
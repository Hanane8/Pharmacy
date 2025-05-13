using System;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using PharmacyApp.Models;

namespace PharmacyApp.Services
{
    public class EmailService
    {
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpUsername;
        private readonly string _smtpPassword;
        private readonly string _supplierEmail;

        public EmailService(string smtpServer, int smtpPort, string smtpUsername, string smtpPassword, string supplierEmail)
        {
            _smtpServer = smtpServer;
            _smtpPort = smtpPort;
            _smtpUsername = smtpUsername;
            _smtpPassword = smtpPassword;
            _supplierEmail = supplierEmail;
        }

        public async Task SendOrderToSupplier(Order order)
        {
            try
            {
                using var client = new SmtpClient(_smtpServer, _smtpPort)
                {
                    EnableSsl = true,
                    Credentials = new NetworkCredential(_smtpUsername, _smtpPassword)
                };

                var message = new MailMessage
                {
                    From = new MailAddress(_smtpUsername),
                    Subject = $"New Order from {order.CustomerName}",
                    Body = GenerateOrderEmailBody(order),
                    IsBodyHtml = true
                };

                message.To.Add(_supplierEmail);

                await client.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to send email: {ex.Message}", ex);
            }
        }

        private string GenerateOrderEmailBody(Order order)
        {
            var body = $@"
                <html>
                <body>
                    <h2>New Order Details</h2>
                    <p><strong>Customer Name:</strong> {order.CustomerName}</p>
                    <p><strong>Delivery Address:</strong> {order.Address}</p>
                    <p><strong>Email:</strong> {order.Email}</p>
                    <p><strong>Phone:</strong> {order.Phone}</p>
                    <h3>Order Items:</h3>
                    <table border='1' cellpadding='5' cellspacing='0'>
                        <tr>
                            <th>Item</th>
                            <th>Quantity</th>
                            <th>Price</th>
                            <th>Total</th>
                        </tr>";

            foreach (var item in order.Items)
            {
                body += $@"
                    <tr>
                        <td>{item.Medication?.Name}</td>
                        <td>{item.Quantity}</td>
                        <td>{item.Medication?.Price:C}</td>
                        <td>{item.Total:C}</td>
                    </tr>";
            }

            body += $@"
                    </table>
                    <p><strong>Total Order Amount:</strong> {order.Total:C}</p>
                </body>
                </html>";

            return body;
        }
    }
} 
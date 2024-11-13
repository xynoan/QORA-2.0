using MailKit.Net.Smtp;
using MimeKit;
using System;
using static System.Net.WebRequestMethods;

public class EmailService
{
    private readonly string _smtpServer = "smtp.gmail.com"; // Your SMTP server
    private readonly int _smtpPort = 587; // Common port for SMTP
    private readonly string _smtpUser = "ask.qora.concerns@gmail.com"; // Your email
    private readonly string _smtpPass = "duyl uqse cayv vobd"; // Your email password

    public void SendPasswordResetEmail(string toEmail, string otp)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("QORA Support", _smtpUser));
        message.To.Add(new MailboxAddress("", toEmail));
        message.Subject = "Password Reset Request";

        var bodyBuilder = new BodyBuilder
        {
            HtmlBody = $@"
            <html>
                <head>
                    <style>
                        .otp-container {{
                            background-color: #f2f2f2;
                            border-radius: 10px;
                            padding: 50px;
                            padding-left: 100px;
                            padding-right: 100px;
                        }}
                        .otp-code {{
                            font-size: 40px;
                            font-weight: bold;
                            color: #010641;
                        }}
                    </style>
                </head>
                <body>
                    <div class='otp-container'>
                        <p>Hello,</p>
                        <p>You have requested to reset your password for your QORA account.</p>
                        <p>To complete the verification process, please use the following verification code:</p>
                        <center><p class='otp-code'>{otp}</p></center>
                        <p>If you did not request this, please disregard this email.</p>
                        <p>Thank you for using QORA!</p>
                        <p>Sincerely,<br>The QORA Team</p>
                    </div>
                </body>
            </html>"
        };
        message.Body = bodyBuilder.ToMessageBody();

        try
        {
            using (var client = new SmtpClient())
            {
                client.Connect(_smtpServer, _smtpPort, MailKit.Security.SecureSocketOptions.StartTls);
                client.Authenticate(_smtpUser, _smtpPass);
                client.Send(message);
                client.Disconnect(true);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sending email: {ex.Message}");
        }
    }

    public void SendAccountCreationEmail(string toEmail, string otp)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("QORA Support", _smtpUser));
        message.To.Add(new MailboxAddress("", toEmail));
        message.Subject = "Welcome to QORA!";

        var bodyBuilder = new BodyBuilder
        {
            HtmlBody = $@"
            <html>
                <head>
                    <style>
                        .welcome-container {{
                           background-color: #f2f2f2;
                            border-radius: 10px;
                            padding: 50px;
                            padding-left: 100px;
                            padding-right: 100px;
                        }}
                        .welcome-message {{
                            font-size: 24px;
                            color: #00796b;
                        }}
                        .otp-code {{
                            font-size: 40px;
                            font-weight: bold;
                            color: #010641;
                        }}
                    </style>
                </head>
                <body>
                    <div class='welcome-container'>
                        <p>Hello {toEmail},</p>
                        <p>Thank you for creating an account with QORA!</p>
                        <p>To complete the verification process, please use the following verification code:</p>
                        <center><p class='otp-code'>{otp}</p></center>
                        <p>We are excited to have you on board. If you have any questions, feel free to contact us.</p>
                        <p>Thank you for joining us!</p>
                        <p>Sincerely,<br>The QORA Team</p>
                    </div>
                </body>
            </html>"
        };
        message.Body = bodyBuilder.ToMessageBody();

        try
        {
            using (var client = new SmtpClient())
            {
                client.Connect(_smtpServer, _smtpPort, MailKit.Security.SecureSocketOptions.StartTls);
                client.Authenticate(_smtpUser, _smtpPass);
                client.Send(message);
                client.Disconnect(true);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sending email: {ex.Message}");
        }
    }

    public string GenerateOtp()
    {
        Random random = new Random();
        return random.Next(100000, 999999).ToString(); // Generates a random 6-digit OTP
    }
}

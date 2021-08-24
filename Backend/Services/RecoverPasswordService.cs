using NovaGaming.DbContexts;
using NovaGaming.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using static NovaGaming.Services.RecoverPasswordService;

namespace NovaGaming.Services
{
    public interface IRecoverPasswordService
    {
        public State ForgotPass(ForgotPassword forgotPassword);
    }
    public class RecoverPasswordService : IRecoverPasswordService
    {
        public enum State
        {
            InvalidEmailOrPass,
            ServerIssue,
            OK
        }
        IConfiguration _config;
        ConquerDbContext _context;
        public RecoverPasswordService(IConfiguration config, ConquerDbContext context)
        {
            _config = config;
            _context = context;
        }
        private string _randStr = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private Random getRandom = new Random();
        private string RandomToken(int n)
        {
            string rndTok = "";
            for (int i = 0; i < n; i++)
                rndTok += _randStr[getRandom.Next(0, _randStr.Length)];
            return rndTok;

        }
        public State ForgotPass(ForgotPassword forgotPassword)
        {
            var result = _context.Accounts.Where(e => e.Username == forgotPassword.Username && e.Email == forgotPassword.Email).FirstOrDefault();
            if (result == null) return State.InvalidEmailOrPass;

            string token = RandomToken(100);
            string recoveryEmail = _config["RestoreGmail:Email"],
                recoveryPassword = _config["RestoreGmail:Password"];
            try
            {
                string content = $"Hello {forgotPassword.Username},\n\nYou have requested a new token for changing your password, if this wasn't you please contact us ASAP.\n"
        + "\nYou can visit our website and change the password here \n\nhttp://Nologista.com/Account/ResetPassword?user=" + forgotPassword.Username + "&token=" + token +
        "\n\nPlease dont give your info to anyone.\n\nNostalgiaCo."
        + "\n\n\nTHIS IS A NO REPLY MESSAGE. ANY REPLY TO THIS WILL NOT BE READ.";

                using (SmtpClient client = new SmtpClient())
                {
                    client.Host = "smtp.gmail.com";
                    client.Port = 587;
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Credentials = new System.Net.NetworkCredential(recoveryEmail, recoveryPassword);
                    client.Timeout = 600000;
                    using (MailMessage mm = new MailMessage(recoveryEmail,
                        forgotPassword.Email,
                        $"Nologista - Password Recovery",
                        content))
                        client.Send(mm);

                }
                result.TokenChangePass = token;
                _context.SaveChanges();
                return State.OK;
            }
            catch
            {
                return State.ServerIssue;
            }
        }
    }
}

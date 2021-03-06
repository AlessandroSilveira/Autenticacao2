﻿using System.Net;
using System.Net.Mail;
using Application2.Domain.Interfaces.Service;

namespace Application2.Domain.Services
{
	public class EnviardorDeEmail : IEnviadorEmail
	{
		private readonly IConfiguration _configuration;

		public EnviardorDeEmail(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public void EnviarTokenPorEmail(EnviaEmailBuilder dadosEmail)
		{
			using (
				var message = new MailMessage(
					dadosEmail.From, dadosEmail.To,
					dadosEmail.Subject, dadosEmail.Body)
					)
			{
				var client = new SmtpClient(dadosEmail.SmtpServer)
				{
					UseDefaultCredentials = false,
                    //Credentials = new NetworkCredential(_configuration.ObterEmailFrom(), _configuration.ObterPasswordEmail()),
                    Credentials = new NetworkCredential("alesilver.si@gmail.com","Alesilver224482"),
                    EnableSsl = true
				};
				client.Send(message);
			}
		}
	}
}

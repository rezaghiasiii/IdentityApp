﻿namespace IdentityApp.Repositories;

public interface IMessageSender
{
    public Task SendEmailAsync(string email,string subject,string message,bool isMessageHtml = false);
}
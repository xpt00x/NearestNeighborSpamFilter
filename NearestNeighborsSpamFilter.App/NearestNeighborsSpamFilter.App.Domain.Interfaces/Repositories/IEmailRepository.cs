using NearestNeighborsSpamFilter.App.Domain.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NearestNeighborsSpamFilter.App.Domain.Interfaces.Repositories
{
    public interface IEmailRepository
    {
        ICollection<Email> GetAllEmails();
        ICollection<Email> GetEmailsByWord(string word);

        Email CreateOrUpdateEmail(Email email);
        ICollection<Email> CreateOrUpdateEmails(ICollection<Email> email);

        void RemoveEmail(Email email);
        void RemoveEmailByWord(string word);
        void RemoveEmails(ICollection<Email> email);
    }
}

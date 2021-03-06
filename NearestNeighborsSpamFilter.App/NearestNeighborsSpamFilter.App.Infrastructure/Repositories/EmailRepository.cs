﻿
using AutoMapper;
using NearestNeighborsSpamFilter.App.Domain.Interfaces.Entities;
using NearestNeighborsSpamFilter.App.Domain.Interfaces.Repositories;
using NearestNeighborsSpamFilter.App.Infrastructure.Db;
using System.Collections.Generic;

namespace NearestNeighborsSpamFilter.App.Infrastructure.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        public EmailRepository(NnDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        private NnDbContext _dbContext { get; }
        private IMapper _mapper { get; set; }
        public Email CreateOrUpdateEmail(Email email)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Email> CreateOrUpdateEmails(ICollection<Email> email)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Email> GetAllEmails()
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Email> GetEmailsByWord(string word)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveEmail(Email email)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveEmailByWord(string word)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveEmails(ICollection<Email> email)
        {
            throw new System.NotImplementedException();
        }
    }
}

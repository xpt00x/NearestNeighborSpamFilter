using System;
using System.Collections.Generic;

namespace NearestNeighborsSpamFilter.App.Infrastructure.Db.DTO
{
    public partial class Emails
    {
        public int Id { get; set; }
        public DateTime DateImported { get; set; }
        public DateTime? DateUpdated { get; set; }
        public bool Classification { get; set; }
        public string Body { get; set; }
    }
}

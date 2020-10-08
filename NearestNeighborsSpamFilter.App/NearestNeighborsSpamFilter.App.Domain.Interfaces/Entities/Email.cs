using System;
using System.Collections.Generic;
using System.Text;

namespace NearestNeighborsSpamFilter.App.Domain.Interfaces.Entities
{
    public class Email
    {
        public bool Classification { get; set; }
        public string Body { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace NearestNeighborsSpamFilter.App.Domain.Interfaces.Entities
{
    public class DataPoint
    {
        public string Word { get; set; }
        public int Frequency { get; set; }
        public bool Classification { get; set; }
    }
}

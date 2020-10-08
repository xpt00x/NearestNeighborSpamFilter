using System;
using System.Collections.Generic;

namespace NearestNeighborsSpamFilter.App.Infrastructure.Db.DTO
{
    public partial class TrainingPoints
    {
        public int Id { get; set; }
        public int IdWord { get; set; }
        public int Frequency { get; set; }
        public bool Classification { get; set; }

        public virtual BowDictionary IdWordNavigation { get; set; }
    }
}

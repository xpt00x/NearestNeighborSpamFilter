using System;
using System.Collections.Generic;

namespace NearestNeighborsSpamFilter.App.Infrastructure.Db.DTO
{
    public partial class Dictionary
    {
        public Dictionary()
        {
            DataPoints = new HashSet<DataPoints>();
            TrainingPoints = new HashSet<TrainingPoints>();
        }

        public int Id { get; set; }
        public string Word { get; set; }
        public DateTime DateImported { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual ICollection<DataPoints> DataPoints { get; set; }
        public virtual ICollection<TrainingPoints> TrainingPoints { get; set; }
    }
}

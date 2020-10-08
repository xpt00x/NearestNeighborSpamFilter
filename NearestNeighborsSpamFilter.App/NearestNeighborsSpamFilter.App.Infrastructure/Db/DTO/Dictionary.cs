using System;
using System.Collections.Generic;

namespace NearestNeighborsSpamFilter.App.Infrastructure.Db.DTO
{
    public partial class Dictionary
    {
        public Dictionary()
        {
            ModelDataPoints = new HashSet<ModelDataPoints>();
            TrainingPoints = new HashSet<TrainingPoints>();
        }

        public int Id { get; set; }
        public string Word { get; set; }
        public DateTime DateImported { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual ICollection<ModelDataPoints> ModelDataPoints { get; set; }
        public virtual ICollection<TrainingPoints> TrainingPoints { get; set; }
    }
}

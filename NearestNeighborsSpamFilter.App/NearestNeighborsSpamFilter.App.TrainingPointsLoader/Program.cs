using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NearestNeighborsSpamFilter.App.Domain.Interfaces.Entities;
using NearestNeighborsSpamFilter.App.Domain.Interfaces.Repositories;
using NearestNeighborsSpamFilter.App.Infrastructure;
using NearestNeighborsSpamFilter.App.Infrastructure.Db;
using NearestNeighborsSpamFilter.App.Infrastructure.Db.DTO;
using NearestNeighborsSpamFilter.App.Infrastructure.Repositories;
using System.IO;

namespace NearestNeighborsSpamFilter.App.TrainingPointsLoader
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Build configs
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json");
            var config = builder.Build();
            #endregion

            #region Inject deps
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddNearestNeighborSpamFilter(config.GetConnectionString("NNSpamFilterConnection"));
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var mapper = serviceProvider.GetRequiredService<IMapper>();
            #endregion

            #region Test insertion and db conn
            BowDictionaryPair pair = new BowDictionaryPair()
            {
                Word = "CARALHO"
            };

            TrainingPoint point = new TrainingPoint()
            {
                Word = "CARALHO",
                Classification = true,
                Frequency = 2
            };

            UnitOfWork unitOfWork = new UnitOfWork(serviceProvider);
            unitOfWork.BowDictionaryRepository.CreateOrUpdateBowDictionaryPair(pair);
            unitOfWork.Commit();
            unitOfWork.TrainingPointRepository.CreateOrUpdateTrainingPoint(point);
            unitOfWork.Commit();
            #endregion
        }
    }
}

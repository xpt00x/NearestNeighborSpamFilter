using NUnit.Framework;
using NearestNeighborsSpamFilter.App.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using NearestNeighborsSpamFilter.App.Infrastructure.Db;
using NearestNeighborsSpamFilter.App.Domain.Interfaces.Entities;
using NearestNeighborsSpamFilter.App.Infrastructure.Db.DTO;

namespace NearestNeighborsSpamFilter.App.Infrastructure.Tests.Repositories
{
    public class TrainingPointRepositoryTests
    {
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<NnDbContext>().UseInMemoryDatabase(databaseName : "NNSPAMFILTER").Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new NnDbContext(options))
            {
                context.TrainingPoints.Add(new TrainingPoints()
                {
                    Id = 0,
                    IdWord = 0,
                    //Classification = 0
                });
                //context.TrainingPoints.Add(new Movie { Id = 2, Title = "Movie 2", YearOfRelease = 2018, Genre = "Action" });
                //context.TrainingPoints.Add(new Movie { Id = 3, Title = "Movie 3", YearOfRelease = 2019, Genre = "Action"});
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new MovieDbContext(options))
            {
                MovieRepository movieRepository = new MovieRepository(context);
                List<Movies> movies == movieRepository.GetAll()
    
            Assert.Equal(3, movies.Count);
            }
            TrainingPointRepository repository = new TrainingPointRepository();
        }

        [Test]
        public void HappyPath()
        {
            
        }
    }
}
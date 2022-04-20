using Moq;
using MovieDbApp.Logic;
using MovieDbApp.Models;
using MovieDbApp.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using static MovieDbApp.Logic.MovieLogic;

namespace MovieDbApp.Test
{
    [TestFixture]
    public class MovieLogicTester
    {
        MovieLogic logic;
        Mock<IRepository<Movie>> mockMovieRepo;

        [SetUp]
        public void Init()
        {
            mockMovieRepo = new Mock<IRepository<Movie>>();
            mockMovieRepo.Setup(m => m.ReadAll()).Returns(new List<Movie>()
            {
                new Movie("1#MovieA#100#1#2008*05*02#5"),
                new Movie("2#MovieB#200#1#2009*05*02#6"),
                new Movie("3#MovieC#300#1#2009*05*02#7"),
                new Movie("4#MovieD#400#1#2010*05*02#8"),
            }.AsQueryable());
            logic = new MovieLogic(mockMovieRepo.Object);
        }

        [Test]
        public void AvgRatePerYearTest()
        {
            double? avg = logic.GetAverageRatePerYear(2009);
            Assert.That(avg, Is.EqualTo(6.5));
        }

        [Test]
        public void YearStatisticsTest()
        {
            var actual = logic.YearStatistics().ToList();
            var expected = new List<YearInfo>()
            {
                new YearInfo()
                {
                    Year = 2008,
                    AvgRating = 5,
                    MovieNumber = 1
                },
                new YearInfo()
                {
                    Year = 2009,
                    AvgRating = 6.5,
                    MovieNumber = 2
                },
                new YearInfo()
                {
                    Year = 2010,
                    AvgRating = 8,
                    MovieNumber = 1
                }
            };

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CreateMovieTestWithCorrectTitle()
        {
            var movie = new Movie() { Title = "Vukk" };
            
            //ACT
            logic.Create(movie);

            //ASSERT
            mockMovieRepo.Verify(r => r.Create(movie), Times.Once);
        }

        [Test]
        public void CreateMovieTestWithInCorrectTitle()
        {
            var movie = new Movie() { Title = "24" };
            try
            {
                //ACT
                logic.Create(movie);
            }
            catch
            {

            }

            //ASSERT
            mockMovieRepo.Verify(r => r.Create(movie), Times.Never);
        }
    }
}

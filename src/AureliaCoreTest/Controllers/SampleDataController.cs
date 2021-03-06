using System;
using System.Collections.Generic;
using System.Linq;
using AureliaCoreTest.Data;
using AureliaCoreTest.Model;
using Microsoft.AspNetCore.Mvc;

namespace AureliaTest.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private readonly PeopleContext _dbContext;
        public SampleDataController(PeopleContext dbContext)
        {
            _dbContext = dbContext;
        }

        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var person = new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "Stefan",
                LastName = "dfsdf"
            };

            _dbContext.Add(person);
            _dbContext.SaveChanges();

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(this.TemperatureC / 0.5556);
                }
            }
        }
    }
}

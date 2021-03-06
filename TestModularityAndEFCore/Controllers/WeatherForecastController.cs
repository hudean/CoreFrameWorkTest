using CoreFrameWork.Domain.Repositories;
using CoreFrameWork.Domain.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestModularityAndEFCore.Entities;

namespace TestModularityAndEFCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IRepository<Student> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public WeatherForecastController(ILogger<WeatherForecastController> logger,
           IRepository<Student> repository,
           CustomerDbContext customerDbContext,
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _repository = repository;
            _repository.InitialDbContext(customerDbContext);
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet("add")]
        public async Task<string> Add(int i)
        {
            var student = new Student()
            {
                Name = "张三"
            };
            _repository.Add(student);
            await _unitOfWork.CommitAsync();
            return "ok";
        }
    }
}

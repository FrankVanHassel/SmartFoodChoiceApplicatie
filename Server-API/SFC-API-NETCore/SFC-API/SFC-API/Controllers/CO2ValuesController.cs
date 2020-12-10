using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace SFC_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CO2ValuesController : ControllerBase
    {

        private readonly ILogger<CO2ValuesController> _logger;

        public CO2ValuesController(ILogger<CO2ValuesController> logger)
        {
            _logger = logger;
        }





        [HttpGet("{X}/{Y}")]

        public int Get(string x, string y)
        {
            int[,] dataset =
            {
                {3, 2, 3 },
                {6, 6, 6 },
                {4, 7, 2 }
            };

            int newX = Int32.Parse(x);
            int newY = Int32.Parse(y);

            return dataset[newY, newX];
        }


        [HttpGet("{Y}")]

        public int[] Get(string y)
        {
            int[,] dataset =
            {
                {3, 2, 3 },
                {6, 6, 6 },
                {4, 7, 2 }
            };

            int newY = Int32.Parse(y);
            int[] newArr = new int[3];

            for (int i = 0; i < 3; i++)
            {
                newArr[i] = dataset[newY, i];
            }

            return newArr;
        }


        [HttpGet]

        public string Get()
        {
            int[,] dataset =
            {
                {3, 2, 3 },
                {6, 6, 6 },
                {4, 7, 2 }
            };

            //string json = JsonSerializer.Serialize(dataset);
            return JsonSerializer.Serialize(dataset);
        }

        
    }
}

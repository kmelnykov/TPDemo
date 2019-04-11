using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TpDemo.BLL.TourCatalogueService;
using TpDemo.BLL.ServiceFacade;
using TpDemo.BLL.DTO;
using AutoMapper;
using TpDemo.BLL.TourCatalogueService.SearchOptions;

namespace TpDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //private readonly ServiceFacade serviceFacade;
        private readonly ITourCatalogueService tourCatalogueService;
       
        private readonly IMapper mapper;


        public ValuesController(ITourCatalogueService tourCatalogueService, IMapper mapper)
        {
            this.tourCatalogueService = tourCatalogueService;
            this.mapper = mapper;
        }

        // GET api/values
        [HttpGet]
        public Task<List<TourDTO>> Get()
        {
            Task<List<TourDTO>> tours = tourCatalogueService.ShowAllToursAsync();
            return tours;

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Task<List<TourDTO>> Get(int id)
        {
            //Task<List<TourDTO>> tours = tourCatalogueService.ShowFilteredToursAsync();
           // return tours;
           return null;
        }

        // POST api/values
        [HttpPost]
        public Task<List<TourDTO>> Post([FromBody] TourSearchModel model)
        {
            return tourCatalogueService.ShowFilteredToursAsync(model);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTApi.Data;
using RESTApi.Models;

namespace RESTApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly AddDbContext dbContext;

        public RegionsController(AddDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllRegions()
        {
            var AllRegions = this.dbContext.Regions.ToList();
            return Ok(AllRegions);
        }
        [HttpGet("{id}")]
        public IActionResult GetRegionById([FromRoute] Guid id)
        {
            var region = this.dbContext.Regions.FirstOrDefault(i => i.Id == id);

            if (region == null)
                return NotFound();

            return Ok(region);
        }


        [HttpPost]
        public IActionResult CreateRegion([FromBody] Region datatobesave)
        {
            var region = new Region
            {
                code = datatobesave.code,
                Name = datatobesave.Name,
                RegionImageUrl = datatobesave.RegionImageUrl

            };
            dbContext.Regions.Add(region);
            dbContext.SaveChanges();


            return Ok(region);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateRegion([FromBody] Region updatedData, [FromRoute] Guid id)
        {

            var existingRegion = dbContext.Regions.FirstOrDefault(r => r.Id == id);
            if (existingRegion == null)
                return NotFound("Region not found");
            existingRegion.Name = updatedData.Name;
            existingRegion.code = updatedData.code;
            existingRegion.RegionImageUrl = updatedData.RegionImageUrl;


            dbContext.SaveChanges();

            return Ok(existingRegion);

        }
    }







}

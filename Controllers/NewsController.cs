using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using my_own_json_api.Models;
using my_own_json_api.Models.Context;
using my_own_json_api.Services;

namespace my_own_json_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly NewsService newsService;
        public NewsController(NewsService newsService)
        {
            this.newsService = newsService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<BitOfNews>> GetNews()
        {
            IEnumerable<BitOfNews> news =  newsService.GetNews();
            if (news.Count() == 0)
                return NoContent();
            else
                return Ok(new { news });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBitOfNews(string id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            BitOfNews bitOfNews = await newsService.GetBitOfNews(id);

            if (bitOfNews == null)
                return NotFound();

            return Ok(bitOfNews);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBitOfNews(string id, BitOfNews bitOfNews)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != bitOfNews.Id)
                return BadRequest();

            bool updateResult = await newsService.Update(id, bitOfNews);

            if (!updateResult)
                return NotFound();

            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> PostBitOfNews(BitOfNews bitOfNews)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await newsService.Save(bitOfNews);

            return CreatedAtAction("GetBitOfNews", new { id = bitOfNews.Id }, bitOfNews);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBitOfNews(string id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            BitOfNews bitOfNews = await newsService.GetBitOfNews(id);
            if (bitOfNews == null)
                return NotFound();

            bool deleteResult = await newsService.Delete(bitOfNews);

            if (!deleteResult)
                return BadRequest();

            return Ok(bitOfNews);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using my_own_json_api.Models;
using my_own_json_api.Models.Context;
using my_own_json_api.Models.UIModels;
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
        public ActionResult<IEnumerable<BitOfNews>> GetNews(int limit, string search)
        {
            IEnumerable<BitOfNews> news =  newsService.GetNews();

            if (news.Count() == 0)
                return NoContent();

            if (search != null && search != "" && search != "undefined")
                news = newsService.Search(search, news);

            if (limit > 0)
                news = news.Take(limit);

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

            return Ok(new { bitOfNews });
        }
        [HttpPost]
        public IActionResult PostBitOfNews(BitOfNewsUI bitOfNewsUI)
        {
            if (bitOfNewsUI == null)
                return BadRequest();

            BitOfNews bitOfNews = newsService.Init(bitOfNewsUI);

            newsService.Save(bitOfNews);

            return CreatedAtAction("GetBitOfNews", new { id = bitOfNews.Id }, bitOfNews);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBitOfNews(string id)
        {
            if (id == null || id == "")
                return BadRequest(new { message = "id is empty or null" });

            BitOfNews bitOfNews = await newsService.GetBitOfNews(id);

            if (bitOfNews == null)
                return NotFound();

            newsService.Delete(bitOfNews);

            return Ok(bitOfNews);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using my_own_json_api.Models;
using my_own_json_api.Models.Context;
using my_own_json_api.Models.UIModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_own_json_api.Services
{
    public class NewsService
    {
        private readonly JSONContext context;
        public NewsService(JSONContext context)
        {
            this.context = context;
        }
        public IEnumerable<BitOfNews> GetNews() => context.News.OrderBy(bit => bit.Date);
        public IEnumerable<BitOfNews> Search(string search, IEnumerable<BitOfNews> news) => news.Where(todo => todo.Title.ToLower().Contains(search));
        public async Task<BitOfNews> GetBitOfNews(string id) => await context.News.FindAsync(id);
        public bool BitOfNewsExists(string id) => context.News.Any(e => e.Id == id);
        public async void Save(BitOfNews bitOfNews)
        {
            context.News.Add(bitOfNews);
            await context.SaveChangesAsync();
        }

        public async Task<bool> Update(string id, BitOfNews bitOfNews)
        {
            context.Entry(bitOfNews).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BitOfNewsExists(id))
                    return false;
                else
                    throw;
            }
            return true;
        }
        public BitOfNews Init(BitOfNewsUI bitOfNewsUI) => new BitOfNews
        {
            Id = Guid.NewGuid().ToString(),
            Date = DateTime.Now.ToString("dd-MM-yyyy, hh:mm:ss"),
            Title = bitOfNewsUI.Title,
            Body = bitOfNewsUI.Body,
            ImageUrl = bitOfNewsUI.ImageUrl
        };
        public async void Delete(BitOfNews bitOfNews)
        {
            context.News.Remove(bitOfNews);
            await context.SaveChangesAsync();
        }
    }
}

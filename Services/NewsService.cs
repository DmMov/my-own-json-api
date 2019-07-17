using Microsoft.EntityFrameworkCore;
using my_own_json_api.Models;
using my_own_json_api.Models.Context;
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
        public IEnumerable<BitOfNews> GetNews() => context.News;

        public async Task<BitOfNews> GetBitOfNews(string id) => await context.News.FindAsync(id);
        public bool BitOfNewsExists(string id)
        {
            return context.News.Any(e => e.Id == id);
        }
        public async Task<bool> Save(BitOfNews bitOfNews)
        {
            context.News.Add(bitOfNews);
            await context.SaveChangesAsync();

            return context.News.Any(bit => bit.Id == bitOfNews.Id);
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

        public async Task<bool> Delete(BitOfNews bitOfNews)
        {
            context.News.Remove(bitOfNews);
            await context.SaveChangesAsync();

            return !context.News.Any(bit => bit.Id == bitOfNews.Id);
        }
    }
}

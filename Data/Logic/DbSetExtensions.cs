using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace TftTracker.Data.Logic
{
    public static class DbSetExtensions
    {
        public static void SeedTable<TEntity>(this DbSet<TEntity> dbSet, string fileName, IWebHostEnvironment environment) where TEntity : class
        {
            if (dbSet.Any())
                return;

            var data = ReadDataFromFile<IEnumerable<TEntity>>(fileName, environment);
            dbSet.AddRange(data);
        }

        private static T ReadDataFromFile<T>(string fileName, IWebHostEnvironment environment)
        {
            var filePath = Path.Combine(environment.ContentRootPath, fileName);
            var json = File.ReadAllText(filePath);
            T data = JsonSerializer.Deserialize<T>(json);
            return data;   
        }
    }
}
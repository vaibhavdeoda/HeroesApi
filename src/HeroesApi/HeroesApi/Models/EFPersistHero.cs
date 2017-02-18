using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.SqlTypes;
using System.Linq;

namespace HeroesApi.Models
{
    public class EfPersistHero : IPersistHero
    {
        public IEnumerable<Hero> GetHeroes()
        {
            using (var dbContext = new HeroDbContext())
            {
                return dbContext.Heroes.Where(x => x.Active).ToList();
            }
        }

        public Hero GetHeroById(int id)
        {
            using (var dbContext = new HeroDbContext())
            {
                return dbContext.Heroes.FirstOrDefault(x => x.Active && x.Id == id);
                
            }
        }

        public void SaveHero(string name)
        {
            using (var dbContext = new HeroDbContext())
            {
                dbContext.Heroes.Add(new Hero {Name = name, Active = true});
                dbContext.SaveChanges();
            }
        }

        public void DeleteHero(int id)
        {
            using (var dbContext = new HeroDbContext())
            {
                var hero = dbContext.Heroes.FirstOrDefault(x => x.Id == id);
                if (hero != null)
                {
                    if (hero.Active)
                    {
                        hero.Active = false;
                        dbContext.Heroes.AddOrUpdate(hero);
                        dbContext.SaveChanges();
                    }
                }
            }
        }
    }
}
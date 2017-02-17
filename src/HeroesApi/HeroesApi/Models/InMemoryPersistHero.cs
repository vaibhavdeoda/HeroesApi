using System.Linq;
using System.Web;

namespace HeroesApi.Models
{
    using System.Collections.Generic;

    public class InMemoryPersistHero : IPersistHero
    {
        List<Hero> _heroes;
        private const string Cache = "HeroesCache";
        public InMemoryPersistHero()
        {
            _heroes = HttpContext.Current.Cache[Cache] as List<Hero> ??
                      new List<Hero> { new Hero { Id = 1, Name = "Bombasta" }, new Hero { Id = 2, Name = "Superman" } };
            HttpContext.Current.Cache.Insert(Cache, _heroes);
        }

        public IEnumerable<Hero> GetHeroes()
        {
            return HttpContext.Current.Cache[Cache] as List<Hero>;
        }

        public Hero GetHeroById(int id)
        {
            return (HttpContext.Current.Cache[Cache] as List<Hero>)?.FirstOrDefault(x => x.Id == id);
        }

        public void SaveHero(string name)
        {
            var list = HttpContext.Current.Cache[Cache] as List<Hero>;
            list?.Add(new Hero { Id = list.Count() + 1, Name = name });
        }

        public void DeleteHero(int id)
        {
            var list = HttpContext.Current.Cache[Cache] as List<Hero>;
            list?.Remove(list?.FirstOrDefault(x => x.Id == id));
        }
    }
}
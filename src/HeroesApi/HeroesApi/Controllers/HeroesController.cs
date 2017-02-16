using System.Linq;

namespace HeroesApi.Controllers
{
    using System.Collections.Generic;
    using Models;

    using System.Web.Http;

    public class HeroesController : ApiController
    {
        private List<Hero> _list;
        public HeroesController()
        {
            _list = new List<Hero> { new Hero { Id = 1, Name = "Bombasta" }, new Hero { Id = 2, Name = "Superman" } };
        }

        public IEnumerable<Hero> GetAllHeroes()
        {
            return _list;
        }

        public Hero GetHero(int id)
        {
            return _list.FirstOrDefault(x => x.Id == id);
        }

        public void DeleteHero(int id)
        {
           
        }

        public void PostHero([FromBody]PostHeroContract name)
        {
            _list.Add(new Hero { Id = _list.Count() + 1, Name = name.HeroName});
        }
    }

    public class PostHeroContract
    {
        public string HeroName { get; set; }
    }
}

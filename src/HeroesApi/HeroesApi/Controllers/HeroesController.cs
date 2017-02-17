using System.Linq;

namespace HeroesApi.Controllers
{
    using System.Collections.Generic;
    using Models;

    using System.Web.Http;

    public class HeroesController : ApiController
    {
        private readonly IPersistHero _persistHero;
        public HeroesController(IPersistHero persistHero)
        {
            _persistHero = persistHero;
        }

        public IEnumerable<Hero> GetAllHeroes()
        {
            return _persistHero.GetHeroes();
        }

        public Hero GetHero(int id)
        {
            return _persistHero.GetHeroById(id);
        }

        public void DeleteHero(int id)
        {
           _persistHero.DeleteHero(id);
        }

        public void PostHero([FromBody]PostHeroContract name)
        {
            _persistHero.SaveHero(name.HeroName);
        }
    }

    public class PostHeroContract
    {
        public string HeroName { get; set; }
    }
}

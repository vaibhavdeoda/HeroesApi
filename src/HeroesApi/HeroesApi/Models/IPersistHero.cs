namespace HeroesApi.Models
{
    using System.Collections.Generic;

    public interface IPersistHero
    {
        IEnumerable<Hero> GetHeroes();
        Hero GetHeroById(int id);
        void SaveHero(string name);
        void DeleteHero(int id);
    }
}

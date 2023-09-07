using HackatonApi.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Test.Helpers;

public static class DbUtilities
{
    public static SeedDataIds ReinitializeDbForTests(ApplicationDbContext db)
    {
        // throw new Exception(db.ContextId.ToString());
        // db.Genres.RemoveRange(db.Genres);
        // db.Actors.RemoveRange(db.Actors);
        SeedDataIds seedData =  InitializeDbForTests(db);
        return seedData;
    }

    private static SeedDataIds InitializeDbForTests(ApplicationDbContext db)
    {
        // var seedGenres = GetSeedingGenres();
        // var seedActors = GetSeedingActors();        

        // db.Genres.AddRange(seedGenres);
        // db.Actors.AddRange(seedActors);
        db.SaveChanges();

        // List<int> seedGenresIds = seedGenres.Select(genre => genre.Id).ToList();
        // List<int> seedActorsIds = seedActors.Select(actor => actor.Id).ToList();

        SeedDataIds seedData = new SeedDataIds();
        return seedData;
    }
}

public class SeedDataIds
{
}
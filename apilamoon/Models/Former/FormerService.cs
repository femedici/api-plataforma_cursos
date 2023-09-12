using MainProfiles.Models;

namespace MainProfiles.Services;

public static class FormerService
{
    static List<Former> Formers { get; }
    static int nextId = 3;
    static FormerService()
    {
        Formers = new List<Former>
        {
            new Former { Id = 1, Name = "abaco", Email = "fe@gmail.com", Password = "senha123"},
            new Former { Id = 2, Name = "fermeto", Email = "tifu@gmail.com", Password = "senha123"}
        };
    }

    public static List<Former> GetAll() => Formers;

    public static Former? Get(int id) => Formers.FirstOrDefault(p => p.Id == id);

    public static void Add(Former Former)
    {
        Former.Id = nextId;
        nextId++;
        Formers.Add(Former);
    }

    public static void Delete(int id)
    {
        var Former = Get(id);
        if (Former is null)
            return;
        Formers.Remove(Former);
    }

    public static void Update(Former Former)
    {
        var index = Formers.FindIndex(p => p.Id == Former.Id);
        if (index == -1)
            return;

        Formers[index] = Former;
    }
}
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
            new Former { id = 1, Name = "abaco", email = "fe@gmail.com", password = "senha123"},
            new Former { id = 2, Name = "fermeto", email = "tifu@gmail.com", password = "senha123"}
        };
    }

    public static List<Former> GetAll() => Formers;

    public static Former? Get(int id) => Formers.FirstOrDefault(p => p.id == id);

    public static void Add(Former Former)
    {
        Former.id = nextId;
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
        var index = Formers.FindIndex(p => p.id == Former.id);
        if (index == -1)
            return;

        Formers[index] = Former;
    }
}
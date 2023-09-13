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
            new Former { Id = 1, Cpf = "1", Name = "abaco", Email = "fe@gmail.com", Password = "senha123"},
            new Former { Id = 2, Cpf = "2" ,Name = "fermeto", Email = "tifu@gmail.com", Password = "senha123"}
        };
    }

    public static List<Former> GetAll() => Formers;

    public static Former? Get(string cpf) => Formers.FirstOrDefault(p => p.Cpf == cpf);

    public static void Add(Former Former)
    {
        for (int i = 0; i < Formers.Count; i++)
        {
            if (Formers[i].Cpf == Former.Cpf)
            {
                return;
            }
        }

        Former.Id = nextId;
        nextId++;
        Formers.Add(Former);
    }

    public static void Delete(string cpf)
    {
        var Former = Get(cpf);
        if (Former is null)
            return;
        Formers.Remove(Former);
    }

    public static void Update(Former Former)
    {
        var index = Formers.FindIndex(p => p.Cpf == Former.Cpf);
        if (index == -1)
            return;

        Formers[index] = Former;
    }
}
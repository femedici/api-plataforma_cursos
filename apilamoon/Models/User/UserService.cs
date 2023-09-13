using MainProfiles.Models;

namespace MainProfiles.Services;

public static class UserService
{
    static List<User> Users { get; }
    static int nextId = 3;
    static UserService()
    {
        Users = new List<User>
        {
            new User { Id = 1, Cpf = "1", Name = "Felipe Mourudo", Email = "fe@gmail.com", Password = "senha123"},
            new User { Id = 2, Cpf = "2", Name = "Tilanbu Cano", Email = "tifu@gmail.com", Password = "senha123"}
        };
    }

    public static List<User> GetAll() => Users;

    public static User? Get(string Cpf) => Users.FirstOrDefault(p => p.Cpf == Cpf);

    public static void Add(User User)
    {
        for (int i = 0; i < Users.Count; i++)
        {
            if (Users[i].Cpf == User.Cpf)
            {
                return;
            }
        }
        User.Id = nextId;
        nextId++;
        Users.Add(User);
    }

    public static void Delete(string Cpf)
    {
        var User = Get(Cpf);
        if (User is null)
            return;
        Users.Remove(User);
    }

    public static void Update(User User)
    {
        var index = Users.FindIndex(p => p.Cpf == User.Cpf);
        if (index == -1)
            return;

        Users[index] = User;
    }
}
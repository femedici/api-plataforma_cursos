using MainProfiles.Models;

namespace MainProfiles.Services;

public static class UserService
{
    static List<User> Users { get; }
    static UserService()
    {
        Users = new List<User>
        {
            new User { cpf = "445340234-1", Name = "Felipe Mourudo", email = "fe@gmail.com", password = "senha123"},
            new User { cpf = "324013293-1", Name = "Tilanbu Cano", email = "tifu@gmail.com", password = "senha123"}
        };
    }

    public static List<User> GetAll() => Users;

    public static User? Get(string cpf) => Users.FirstOrDefault(p => p.cpf == cpf);

    public static void Add(User User)
    {
        Users.Add(User);
    }

    public static void Delete(string cpf)
    {
        var User = Get(cpf);
        if(User is null)
            return;
        Users.Remove(User);
    }

    public static void Update(User User)
    {
        var index = Users.FindIndex(p => p.cpf == User.cpf);
        if(index == -1)
            return;

        Users[index] = User;
    }
}
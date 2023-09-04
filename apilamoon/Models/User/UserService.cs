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
            new User { id = 1, Name = "Felipe Mourudo", email = "fe@gmail.com", password = "senha123"},
            new User { id = 2, Name = "Tilanbu Cano", email = "tifu@gmail.com", password = "senha123"}
        };
    }

    public static List<User> GetAll() => Users;

    public static User? Get(int id) => Users.FirstOrDefault(p => p.id == id);

    public static void Add(User User)
    {
        User.id = nextId;
        nextId++;
        Users.Add(User);
    }

    public static void Delete(int id)
    {
        var User = Get(id);
        if(User is null)
            return;
        Users.Remove(User);
    }

    public static void Update(User User)
    {
        var index = Users.FindIndex(p => p.id == User.id);
        if(index == -1)
            return;

        Users[index] = User;
    }
}
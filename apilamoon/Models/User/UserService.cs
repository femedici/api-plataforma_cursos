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
            new User { Id = 1, Name = "Felipe Mourudo", Email = "fe@gmail.com", Password = "senha123"},
            new User { Id = 2, Name = "Tilanbu Cano", Email = "tifu@gmail.com", Password = "senha123"}
        };
    }

    public static List<User> GetAll() => Users;

    public static User? Get(int Id) => Users.FirstOrDefault(p => p.Id == Id);

    public static void Add(User User)
    {
        User.Id = nextId;
        nextId++;
        Users.Add(User);
    }

    public static void Delete(int Id)
    {
        var User = Get(Id);
        if(User is null)
            return;
        Users.Remove(User);
    }

    public static void Update(User User)
    {
        var index = Users.FindIndex(p => p.Id == User.Id);
        if(index == -1)
            return;

        Users[index] = User;
    }
}
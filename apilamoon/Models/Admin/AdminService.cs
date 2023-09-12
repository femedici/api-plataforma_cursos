using MainProfiles.Models;

namespace MainProfiles.Services;

public static class AdminService
{
    static List<Admin> Admins { get; }
    static int nextId = 3;
    static AdminService()
    {
        Admins = new List<Admin>
        {
            new Admin { Id = 1, Email = "fe@gmail.com", Password = "senha123"},
            new Admin { Id = 2, Email = "tifu@gmail.com", Password = "senha123"}
        };
    }

    public static List<Admin> GetAll() => Admins;

    public static Admin? Get(int id) => Admins.FirstOrDefault(p => p.Id == id);

    public static void Add(Admin admin)
    {
        admin.Id = nextId;
        nextId++;
        Admins.Add(admin);
    }

    public static void Delete(int id)
    {
        var admin = Get(id);
        if (admin is null)
            return;
        Admins.Remove(admin);
    }

    public static void Update(Admin admin)
    {
        var index = Admins.FindIndex(p => p.Id == admin.Id);
        if (index == -1)
            return;

        Admins[index] = admin;
    }
}
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
            new Admin { id = 1, email = "fe@gmail.com", password = "senha123"},
            new Admin { id = 2, email = "tifu@gmail.com", password = "senha123"}
        };
    }

    public static List<Admin> GetAll() => Admins;

    public static Admin? Get(int id) => Admins.FirstOrDefault(p => p.id == id);

    public static void Add(Admin admin)
    {
        admin.id = nextId;
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
        var index = Admins.FindIndex(p => p.id == admin.id);
        if (index == -1)
            return;

        Admins[index] = admin;
    }
}
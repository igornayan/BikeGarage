using WebAPIbikegarage.Models;

namespace WebAPIbikegarage.Services;

public class ServiçoService
{
    private static List<Serviço> Serviços {get;}
    private static int nextId = 3;
    static ServiçoService()
    {
        Serviços = new List<Serviço>
        {
            new Serviço {Id = 1, Name = "Lubrificação"},
            new Serviço {Id = 2, Name = "Manutenção"}
        };
    }

    public static List<Serviço> GetAll() => Serviços;

    public static Serviço? Get(int id) => Serviços.FirstOrDefault(p => p.Id == id);
    public static void Add(Serviço serviço)
    {
        serviço.Id = nextId++;
        Serviços.Add(serviço);
    }
    public static void Delete(int id)
    {
        var serviço = Get(id);
        if(serviço is null)
            return;

        Serviços.Remove(serviço);
    }

    public static void Update(Serviço serviço)
    {
        var index = Serviços.FindIndex(p => p.Id == serviço.Id);
        if (index == -1)
            return;

        Serviços[index] = serviço;
    }
}

namespace PatternsLab.Problems.Prototype;

public class Weapon
{
    public string Name { get; set; }
    public int Damage { get; set; }
}

public abstract class Enemy
{
    private string _modelData;

    public string Name { get; set; }
    public int Health { get; set; }
    public Weapon Weapon { get; set; }
    public List<string> Abilities { get; set; } = new();
    public string ModelId => _modelData;

    protected Enemy()
    {
        Console.WriteLine("   ...loading 3D model (slow)...");
        Thread.Sleep(500);
        _modelData = "MODEL_" + Guid.NewGuid().ToString("N")[..6];
    }


    public Enemy Copy()
    {
        Enemy e = (Enemy)MemberwiseClone();
        e.Weapon = new Weapon() { Damage = Weapon.Damage, Name = Weapon.Name };
        e.Abilities = new List<string>(Abilities);
        return e;
    }
}

public class Orc : Enemy
{
    public Orc()
    {
        Name = "Orc";
        Health = 100;
        Weapon = new Weapon { Name = "Axe", Damage = 25 };
        Abilities.Add("Rage");
    }
}

public class Elf : Enemy
{
    public Elf()
    {
        Name = "Elf";
        Health = 70;
        Weapon = new Weapon { Name = "Bow", Damage = 18 };
        Abilities.Add("Stealth");
    }
}

public class EnemyRegistry
{
    private readonly Dictionary<string, Enemy> _prototypes = new();

    public void Register(string key, Enemy prototype)
    {
        _prototypes[key] = prototype;
    }

    public Enemy Create(string key)
    {
        if (!_prototypes.TryGetValue(key, out var prototype))
            throw new KeyNotFoundException($"No prototype named '{key}'");

        return prototype.Copy();
    }
}
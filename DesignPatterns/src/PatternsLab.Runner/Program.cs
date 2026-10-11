using System.Diagnostics;
using PatternsLab.Problems.Builder;
using PatternsLab.Problems.Prototype;
using PatternsLab.Problems.Singleton;

Console.WriteLine("=== SINGLETON: After ===\n");

var db = new DatabaseService();
var ui = new UiService();

Console.WriteLine();

db.Config.Theme = "Dark";
Console.WriteLine("Admin changed theme to Dark.");

ui.Render();

Console.WriteLine($"\nSame config object? {ReferenceEquals(db.Config, ui.Config)}");
Console.WriteLine($"Times config was loaded from disk: {AppConfig.LoadCount}");

Console.WriteLine("\n=== PROTOTYPE: After ===\n");

var sw = Stopwatch.StartNew();
var army = new List<Enemy>();
var registry = new EnemyRegistry();

var orc = new Orc();
registry.Register("Orc", orc);

for (int i = 1; i <= 5; i++)
{
    var orcEnemy = registry.Create("Orc");
    orcEnemy.Name = $"Orc-{i}";
    army.Add(orcEnemy);
}
Console.WriteLine($"Created 5 orcs in {sw.ElapsedMilliseconds} ms\n");

Enemy original = registry.Create("Orc");
original.Name = "Boss Orc";
Enemy copy = original.Copy();

Console.WriteLine($"\nOriginal model id: {original.ModelId}");
Console.WriteLine($"Copy model id:     {copy.ModelId}");

copy.Weapon.Damage = 999;
Console.WriteLine($"\nWe changed the COPY's weapon damage to 999.");
Console.WriteLine($"Original's weapon damage is now: {original.Weapon.Damage}");

copy.Abilities.Add("Fire Breath");
Console.WriteLine($"Original abilities: {string.Join(", ", original.Abilities)}");

Console.WriteLine("\n=== BUILDER: After ===\n");
Console.WriteLine(RegistrationCallSites.CreateLiveStudentUgly());
Console.WriteLine(RegistrationCallSites.CreateVideosOnlyUgly());

using System;

namespace ConsoleSlap.Models
{
  public class Player
  {
    int baseStrength = 1;
    public int Damage { get { return Weapon.Damage + baseStrength; } }
    public string Name { get; private set; }
    public Item Weapon { get; private set; } = new Item("Fist", 1);

    public int GetDamage()
    {
      return baseStrength + Weapon.Damage;
    }

    public void GiveWeapon(Item item)
    {
      if (Weapon == null)
      {
        Weapon = item;
        return;
      }

      if (Weapon.Damage > item.Damage)
      {
        Console.Write("Are you sure you want to switch weapons? Y/n: ");
        var choice = Console.ReadLine();
        if (choice == "Y")
        {
          Weapon = item;
        }
      }
      Weapon = item;
    }

    public Player(string name)
    {
      if (name == "jake")
      {
        baseStrength = 50;
      }
      Name = name;
    }

    internal void PrintStats()
    {
      var bgColor = Console.BackgroundColor;
      var fgColor = Console.ForegroundColor;
      Console.BackgroundColor = ConsoleColor.Gray;
      Console.ForegroundColor = ConsoleColor.DarkRed;
      Console.Clear();
      System.Console.WriteLine($@"
      ----------------
      |    Weapon    |
      ----------------
      👍 {Weapon.Name} : {Damage}
      ");
      Console.BackgroundColor = bgColor;
      Console.ForegroundColor = fgColor;
    }
  }
}
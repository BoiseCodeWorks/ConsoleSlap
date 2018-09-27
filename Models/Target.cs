using System;
using System.Collections.Generic;

namespace ConsoleSlap.Models
{
  public class Target
  {
    public int Health { get; set; }
    public string Name { get; set; }
    public Dictionary<string, Target> NextFighterChoice { get; set; }
    public List<Item> Items = new List<Item>();

    public Target(string name, int health)
    {
      Name = name;
      Health = health;
      NextFighterChoice = new Dictionary<string, Target>();
    }

    internal void GetDescription()
    {
      if (Health > 0)
      {
        System.Console.WriteLine("You are fighting");
        System.Console.WriteLine($"Name: {Name} Health: {Health}");
        return;
      }

      System.Console.WriteLine($"You just killed {Name}");
      if (Items.Count > 0)
      {
        System.Console.WriteLine("Looks like he dropped some stuff");
        Items.ForEach(i => System.Console.WriteLine(i.Name));
      }

    }

    public Item TryToTakeItem(string itemName)
    {
      if (Health <= 0)
      {
        return Items.Find(i => i.Name == itemName);
      }
      return null;
    }

    public void PrintNextFighterChoiceDirection()
    {
      foreach (var choice in NextFighterChoice)
      {
        System.Console.WriteLine(choice.Key);
      }
    }
  }
}
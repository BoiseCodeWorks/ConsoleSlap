using System;

namespace ConsoleSlap.Models
{
  public class Game
  {
    bool playing = false;
    Target _currentTarget;
    Player _player;

    public void StartGame()
    {
      Setup();
      while (playing)
      {
        GetUserInput();
      }
    }
    void Setup()
    {
      playing = true;
      //Target Creation
      var joe = new Target("Glass Jaw Joe", 1);
      var moe = new Target("Glass Eye Moe", 10);
      var hector = new Target("Hector the wise", 450);
      var bo = new Target("Bobo the Clown", 5000);

      //Item Creation
      var bat = new Item("Lucille", 580);
      var saber = new Item("A mysterious device", 1000);
      var monkeyFist = new Item("Monkey Fist", 59);

      //Assign Items to Targets
      joe.Items.Add(saber);
      moe.Items.Add(bat);
      moe.Items.Add(monkeyFist);


      //relationships
      joe.NextFighterChoice.Add("right", moe);
      moe.NextFighterChoice.Add("left", joe);
      joe.NextFighterChoice.Add("north", hector);
      hector.NextFighterChoice.Add("south", joe);
      joe.NextFighterChoice.Add("sewer", bo);

      //where do we start?
      _currentTarget = joe;

      //Create our player
      Console.Clear();
      System.Console.WriteLine("What is your Name brave warrior?");
      var name = Console.ReadLine();
      _player = new Player(name);

    }

    private void GetUserInput()
    {
      _currentTarget.GetDescription();
      System.Console.WriteLine("What you wanna do: ");
      string input = Console.ReadLine();
      input = input.ToLower();
      switch (input)
      {
        case "quit":
          playing = false;
          break;
        case "fight":
          _currentTarget.Health -= _player.Damage;
          break;
        case "take":
        case "loot":
          if (_currentTarget.Health > 0)
          {
            System.Console.WriteLine($"{_currentTarget.Name} just punched your face");
            return;
          }
          System.Console.WriteLine("Take what?");
          var itemName = Console.ReadLine();
          Item lootedItem = _currentTarget.TryToTakeItem(itemName);
          if (lootedItem != null)
          {
            _player.GiveWeapon(lootedItem);
          }
          break;
        case "advance":
        case "open":
          if (_currentTarget.Health > 0)
          {
            System.Console.WriteLine($"{_currentTarget.Name} just punched your face");
            System.Console.WriteLine($"You better fight");
            return;
          }
          System.Console.WriteLine("Which way?");
          _currentTarget.PrintNextFighterChoiceDirection();
          var direction = Console.ReadLine();
          if (_currentTarget.NextFighterChoice.ContainsKey(direction))
          {
            _currentTarget = _currentTarget.NextFighterChoice[direction];
          }
          else
          {
            System.Console.WriteLine("Bye Felicia");
            System.Console.WriteLine("You messed up, da police gotcha");
            playing = false;
          }
          break;
        case "stats":
          _player.PrintStats();
          break;
        default:
          System.Console.WriteLine("Yo, stop messin round");
          break;
      }
    }
  }
}
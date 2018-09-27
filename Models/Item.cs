namespace ConsoleSlap.Models
{
  public class Item
  {
    public int Damage { get; set; }
    public string Name { get; set; }

    public Item(string name, int damage)
    {
      Name = name;
      Damage = damage;
    }

  }
}
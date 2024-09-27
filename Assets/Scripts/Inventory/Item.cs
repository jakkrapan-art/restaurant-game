public class Item
{
  public readonly int Id;
  public int Stack { get; private set; }
  public int MaxStack { get; private set; }
  public bool Stackable { get; private set; }

  public Item(int id, int amount, int maxStack)
  {
    Id = id;
    Stack = amount;
    MaxStack = maxStack;
    Stackable = maxStack > 1;
  }

  public int StackItem(int amount)
  {
    if (!Stackable) return amount;

    Stack += amount;

    if (Stack > MaxStack)
    {
      int remain = Stack - MaxStack;
      Stack = MaxStack;
      return remain;
    }

    return 0;
  }

  public int UnstackItem(int amount)
  {
    if (!Stackable) return amount;

    Stack -= amount;

    if (Stack < 0)
    {
      int remain = 0 - Stack;
      Stack = 0;
      return remain;
    }

    return 0;
  }
}

using System.Collections.Generic;

public class Inventory
{
  private Dictionary<int, List<Item>> items = new Dictionary<int, List<Item>>();
  private int _currentSlot;
  private int _maxSlot;

  public Inventory(int maxSize)
  {
    _maxSlot = maxSize;
    _currentSlot = 0;
  }

  public List<Item> GetItem(int id)
  {
    return items.GetValueOrDefault(id);
  }

  public int AddItem(Item itemToAdd)
  {
    if (items.ContainsKey(itemToAdd.Id))
    {
      var lastItem = items[itemToAdd.Id][^1];

      if (!lastItem.Stackable)
      {
        return AddItemToNewSlot(itemToAdd);
      }
      else
      {
        var remain = lastItem.StackItem(itemToAdd.Stack);
        if (remain == 0) return 0;

        var separatedItem = new Item(itemToAdd.Id, remain, itemToAdd.MaxStack);
        return AddItemToNewSlot(separatedItem);
      }
    }
    else
    {
      return AddItemToNewSlot(itemToAdd);
    }
  }

  private int AddItemToNewSlot(Item itemToAdd)
  {
    if (!CanAddNewItem()) return itemToAdd.Stack;

    if (items.ContainsKey(itemToAdd.Id))
    {
      items[itemToAdd.Id].Add(itemToAdd);
    }
    else
    {
      items.Add(itemToAdd.Id, new List<Item>() { itemToAdd });
    }

    _currentSlot++;
    return 0;
  }

  public bool RemoveItem(int id, int amount)
  {
    if (!items.ContainsKey(id) || amount <= 0) return false;

    int remainingAmount = amount;

    while (remainingAmount > 0 && items[id].Count > 0)
    {
      var item = items[id][^1];

      if (item.Stack >= remainingAmount)
      {
        item.UnstackItem(remainingAmount);
        if (item.Stack == 0)
        {
          items[id].RemoveAt(items[id].Count - 1);
          _currentSlot--;
        }
        return true;
      }

      remainingAmount -= item.Stack;
      items[id].RemoveAt(items[id].Count - 1);
      _currentSlot--;
    }

    if (items[id].Count == 0)
    {
      items.Remove(id);
    }

    return remainingAmount <= 0;
  }

  public bool CanAddNewItem()
  {
    return _currentSlot < _maxSlot;
  }
}

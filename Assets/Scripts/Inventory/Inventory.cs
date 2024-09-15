using System.Collections.Generic;

public class Inventory
{
  private Dictionary<int, List<Item>> items = new Dictionary<int, List<Item>>();
  private int _currentSlot;
  private int _maxSlot;
  public Inventory(int maxSize)
  {
    _maxSlot = maxSize;
  }

  public List<Item> GetItem(int id)
  {
    return items.GetValueOrDefault(id);
  }

  public int AddItem(Item itemToAdd)
  {
    if(items.ContainsKey(itemToAdd.Id)) 
    {
      var lastIndexItem = items[itemToAdd.Id][^1];

      if(!lastIndexItem.Stackable)
      {
        return AddItemNewSlot(itemToAdd);
      }
      else
      {
        var remain = lastIndexItem.StackItem(itemToAdd.Stack);
        if (remain == 0) return 0;
        
        var seperatedItem = new Item(itemToAdd.Id, remain, itemToAdd.Stack);
        return AddItemNewSlot(seperatedItem);
      }
    }
    else
    {
      return AddItemNewSlot(itemToAdd);
    }
  }

  private int AddItemNewSlot(Item itemToAdd)
  {
    if (_currentSlot == _maxSlot) return itemToAdd.Stack;

    if(items.ContainsKey(itemToAdd.Id)) 
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
    if(!items.ContainsKey(id) || amount < 0) return false;

    var item = items[id][^1];
    if(item.Stack >= amount)
    {
      item.UnstackItem(amount);
      return true;
    }
    else
    {
      var temp = new List<Item>(items[id]);

      var remain = amount;
      do
      {
        var diff = remain - item.Stack;
        remain = item.UnstackItem(diff);
        items[id].RemoveAt(items[id].Count - 1);
        if (items[id].Count == 0)
        {
          items[id] = temp;
          return false;
        }

        item = items[id][^1];
      }
      while (remain == 0);

      return true;
    }
  }
}

using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Data/Item/Item", order = 0)]
public class ItemData : ScriptableObject
{
  [field: SerializeField] public int ItemId { get; private set; }
  [field: SerializeField] public Sprite ItemIcon { get; private set; }
  [field: SerializeField] public int MaxStack { get; private set; } = 1;
}

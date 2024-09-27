using UnityEngine;

public interface IController
{
  public Vector2 GetMoveInput();
  public bool GetKeyInput(string keyName);
}

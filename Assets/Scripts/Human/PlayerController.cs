using System.Collections.Generic;
using UnityEngine;

public class PlayerController : IController
{
  private Dictionary<string, KeyCode> _keyMap = new Dictionary<string, KeyCode>();

  public PlayerController()
  {
    SetupKeyMapping();
  }

  private void SetupKeyMapping()
  {

  }

  public bool GetKeyInput(string keyName)
  {
    if (_keyMap.TryGetValue(keyName, out KeyCode key))
    {
      return Input.GetKeyDown(key);
    }
    return false;
  }

  public Vector2 GetMoveInput()
  {
    return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
  }
}

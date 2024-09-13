using UnityEngine;

public class CookingPot : MonoBehaviour, IInteractable
{
  public IInteractRequest[] GetRequestArguments()
  {
    return new IInteractRequest[0];
  }

  public IInteractResult Interact(params IInteractRequest[] requests)
  {
    return null;
  }
}

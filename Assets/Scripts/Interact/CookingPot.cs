using UnityEngine;

public class CookingPot : MonoBehaviour, IInteractable
{
  private IInteractRequest[] interactRequests;

  public IInteractResult Interact(IInteractor interactor)
  {
    return null;
  }
}

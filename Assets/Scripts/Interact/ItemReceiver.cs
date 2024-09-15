using UnityEngine;

public class ItemReceiver : MonoBehaviour, IInteractable
{
  private IInteractRequest[] requestList;

  private void Awake()
  {
    requestList = new IInteractRequest[]
    {
      new ItemRequest(1, 1)
    };
  }

  public IInteractResult Interact(IInteractor interactor)
  {
    foreach (var request in requestList)
    {
      if(!request.ValidateRequest(interactor))
      {
        return null; //return invalid request check result
      }
    }

    return null; //return result
  }
}

using UnityEngine;

public class InteractorController : MonoBehaviour
{
  [SerializeField]
  private IInteractor _interactor = null;

  public void InteractTo(IInteractable target)
  {
    if (target == null) return;

    IInteractResult result = target.Interact(_interactor);
    ExecuteResult(result);
  }

  private void ExecuteResult(IInteractResult result)
  {
    if (result == null) return;

    switch(result)
    {
      case InteractActionResult actionResult:
        ExecuteActionResult(actionResult);
        break;
    }
  }

  private void ExecuteActionResult(InteractActionResult actionResult)
  {
    actionResult.Action?.Invoke();
  }
}

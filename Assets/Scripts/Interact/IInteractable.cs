public interface IInteractable
{
  public IInteractRequest[] GetRequestArguments();

  public IInteractResult Interact(params IInteractRequest[] requests);
}

public interface IInteractResult
{
  // Define interaction result properties or methods
}

public interface IInteractRequest
{
  // Define request data
}

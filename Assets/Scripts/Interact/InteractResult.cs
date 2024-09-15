using System;

public interface IInteractResult
{
  // Define interaction result properties or methods
}

public class InteractActionResult : IInteractResult
{
  public Action Action { get; private set; }

  public InteractActionResult(Action action)
  {
    Action = action;
  }
}
public interface IInteractRequest
{
  public bool ValidateRequest(IInteractor interactor);
}

public class ItemRequest : IInteractRequest
{
  private readonly int _id;
  private readonly int _amount;

  public ItemRequest(int id, int amount)
  {
    _id = id;
    _amount = amount;
  }

  public bool ValidateRequest(IInteractor interactor)
  {
    return interactor.HasItem(_id, _amount);
  }
}
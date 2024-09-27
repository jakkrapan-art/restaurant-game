using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Human : MonoBehaviour
{
  private Rigidbody2D _rb;
  private Vector2 _moveInput;
  private IController _controller;

  private float _moveSpeed = 250;

  private void Awake()
  {
    _rb = GetComponent<Rigidbody2D>();
    _controller = new PlayerController();
  }


  private void Update()
  {
    _moveInput = _controller?.GetMoveInput() ?? Vector2.zero;
  }

  private void FixedUpdate()
  {
    Move();
  }

  public void SetController(IController controller)
  {
    _controller = controller;
  }

  private void Move()
  {
    if (_rb == null) return;

    _rb.velocity = new Vector2(_moveInput.x * _moveSpeed * Time.fixedDeltaTime, _rb.velocity.y);
  }
}

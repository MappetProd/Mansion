using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkingState : PlayerGroundedState
{
    private float _horizontalInput;
    private float _verticalInput;
    private float _moveSpeed = 7f;
    private Rigidbody2D _rb;
    private Transform _transform;
    

    public PlayerWalkingState(string name, StateMachine stateMachine) : base(name, stateMachine) { }

    public override void OnEnter()
    {
        base.OnEnter();
        _rb = _sm.rb;
        _moveSpeed = _sm.moveSpeed;
        _sm.animator.SetBool("isWalking", true);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");

        _sm.animator.SetFloat("Horizontal", _horizontalInput);
        _sm.animator.SetFloat("Vertical", _verticalInput);
        _sm.animator.SetFloat("Speed", new Vector2(_horizontalInput, _verticalInput).magnitude);
        if (Mathf.Abs(_horizontalInput) < Mathf.Epsilon && Mathf.Abs(_verticalInput) < Mathf.Epsilon)
            stateMachine.ChangeState(_sm.idleState);
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        Vector2 moveDirection = new Vector2(_horizontalInput, _verticalInput).normalized;
        _rb.velocity = new Vector2(moveDirection.x * _moveSpeed, moveDirection.y * _moveSpeed);
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}

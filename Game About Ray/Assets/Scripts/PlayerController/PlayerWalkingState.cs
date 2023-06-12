using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerWalkingState : PlayerGroundedState
{
    //private PlayerSM _sm;
    private float _horizontalInput;
    private float _verticalInput;
    private float _moveSpeed = 7f;
    private Rigidbody2D _rb;
    private Transform _transform;
    
    public PlayerWalkingState(string name, StateMachine stateMachine) : base(name, stateMachine) 
    {
        //_sm = (PlayerSM)stateMachine;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        _rb = _sm.rb;
        _moveSpeed = _sm.moveSpeed;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(_horizontalInput) < Mathf.Epsilon && Mathf.Abs(_verticalInput) < Mathf.Epsilon)
            stateMachine.ChangeState(_sm.idleState);
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        Vector2 moveDirection = new Vector2(_horizontalInput, _verticalInput).normalized;
        
        //_rb.MovePosition(_rb.position + moveDirection * _sm.moveSpeed * Time.fixedDeltaTime);

        
        _rb.velocity = new Vector2(moveDirection.x * _moveSpeed, moveDirection.y * _moveSpeed);
        /*Vector3 moveDir = new Vector3(_horizontalInput, _verticalInput).normalized;
        _sm.transform.position += moveDir * _moveSpeed * Time.deltaTime;*/
    }
}

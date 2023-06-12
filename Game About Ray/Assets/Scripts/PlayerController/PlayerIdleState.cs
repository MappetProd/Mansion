using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    private float _horizontalInput;
    private float _verticalInput;

    private PlayerSM _sm;

    public PlayerIdleState(string name, StateMachine stateMachine) : base(name, stateMachine) 
    { 
        _sm = (PlayerSM)stateMachine;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        _sm.rb.velocity = Vector2.zero;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        if (Mathf.Abs(_horizontalInput) > Mathf.Epsilon || Mathf.Abs(_verticalInput) > Mathf.Epsilon)
            stateMachine.ChangeState(((PlayerSM)stateMachine).walkingState);
    }
}

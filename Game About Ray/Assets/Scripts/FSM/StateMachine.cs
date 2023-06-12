using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private BaseState _currentState;

    void Start()
    {
        _currentState = GetInitialState();
    }

    private void Update()
    {
        if (_currentState != null)
            _currentState.UpdateLogic();
    }

    private void FixedUpdate()
    {
        if (_currentState != null)
            _currentState.UpdatePhysics();
    }

    public void ChangeState(BaseState newState)
    {
        _currentState.OnExit();
        _currentState = newState;
        _currentState.OnEnter();
    }

    protected virtual BaseState GetInitialState()
    {
        return null;
    }
}

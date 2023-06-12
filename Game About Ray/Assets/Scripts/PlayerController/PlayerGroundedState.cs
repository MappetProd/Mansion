using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
    public void Interact(PlayerSM _sm);
}

public class PlayerGroundedState : BaseState
{
    protected PlayerSM _sm;
    protected ContactFilter2D _filterInteractable;
    public PlayerGroundedState(string name, StateMachine stateMachine) : base(name, stateMachine) 
    { 
        _sm = (PlayerSM)stateMachine;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        _filterInteractable = new ContactFilter2D();
        _filterInteractable.useLayerMask = true;
        _filterInteractable.layerMask = 6;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider2D interactableItems = Physics2D.OverlapCircle(_sm.transform.position, 1f, _sm.interactableItemsLayerMask);
            if (interactableItems.gameObject.TryGetComponent(out IInteractable interactObj))
                interactObj.Interact(_sm);
        }
    }
}

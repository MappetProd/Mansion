using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSM : StateMachine
{
    #region PLAYER_COMPONENTS
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public Animator animator;
    public InventoryManager inventoryManager;
    #endregion

    #region PLAYER_STATS
    public float moveSpeed = 7f;
    #endregion

    #region PLAYERS_STATES
    public PlayerIdleState idleState;
    public PlayerWalkingState walkingState;
    #endregion

    #region INTERACTABLES_LOGIC
    public LayerMask interactableItemsLayerMask;
    public Collider2D interactableAreaCollider;
    #endregion

    private void Awake()
    {
        idleState = new PlayerIdleState("player_idle", this);
        walkingState = new PlayerWalkingState("player_walking", this);
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    protected override BaseState GetInitialState()
    {
        return idleState;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public PlayerState CurrentState { get; set; }
    public PlayerJumpState PlayerJumpState = new PlayerJumpState();
    public PlayerRunState PlayerRunState = new PlayerRunState();
    public PlayerIdleState PlayerIdleState = new PlayerIdleState();

    private void Start()
    {
        CurrentState = PlayerIdleState;

        CurrentState.EnterState(this);
    }

    private void Update()
    {
        CurrentState.UpdateState(this);
    }

    public void SwitchState(PlayerState state)
    {
        CurrentState = state;
        state.EnterState(this);
    }

}

using UnityEngine;

public abstract class PlayerState
{
    public abstract void EnterState(PlayerStateMachine player);
    public abstract void UpdateState(PlayerStateMachine player);
}

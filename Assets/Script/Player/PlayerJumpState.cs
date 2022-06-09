using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public override void EnterState(PlayerStateMachine player)
    {
        Debug.Log("Hello Enter State Jump");
    }


    public override void UpdateState(PlayerStateMachine player)
    {
    }

}

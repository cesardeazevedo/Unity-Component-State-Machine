using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Jump))]
[RequireComponent(typeof(Dead))]
[RequireComponent(typeof(Heath))]
[RequireComponent(typeof(Movement))]
[AddComponentMenu("Component/Person/PlayerBehaviour")]
public class PlayerBehaviour : GameStateMachine<PlayerBehaviour>
{

    ///Make sure that the name of this states, are the same name of the components respectively.
    public enum States
    {
        Idle
      , Movement
      , Jump
      , Attacking
      , Dead
    }

    [HideInInspector]
    public Animator anim;

    private Dead death;

    private void Awake()
    {
        base.Initialize<States>();

        anim  = GetComponent<Animator>();
        death = GetComponent<Dead>();
    }

    private void Update()
    {
    }

    public void Jump()
    {
        if(IsAlive())
            base.ChangeState(States.Jump);
    }

    public void Movement()
    {
        base.ChangeState(States.Movement);
    }

    /// <summary>
    /// Dead this instance.
    /// </summary>
    private void Dead()
    {
        base.ChangeState(States.Dead);
    }

    /// <summary>
    /// Determines whether this instance is alive.
    /// </summary>
    /// <returns><c>true</c> if this instance is alive; otherwise, <c>false</c>.</returns>
    public bool IsAlive()
    {
        return death.IsAlive;
    }
}

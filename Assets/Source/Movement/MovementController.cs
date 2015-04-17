using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(PlayerBehaviour))]
public class MovementController : MonoBehaviour 
{
    private Jump JumpBehaviour;
    private PlayerBehaviour behaviour;
    private Movement Movementbehaviour;

    private void Awake () 
	{
        behaviour = GetComponent<PlayerBehaviour>();
        Movementbehaviour = GetComponent<Movement>();
        JumpBehaviour = GetComponent<Jump>();
    }

    private void Update () 
    {
        if(!behaviour.IsAlive())
            return;

        float Horizontal = Input.GetAxis("Horizontal");

        Movementbehaviour.SetPosition(Horizontal);

        if(Mathf.Abs(Horizontal) > 0 && JumpBehaviour.IsGround)
            behaviour.Movement();

        if(Movementbehaviour.IsMoving && JumpBehaviour.IsGround && Mathf.Abs(Horizontal) == 0)
            behaviour.ChangeState(PlayerBehaviour.States.Idle);

    }
}

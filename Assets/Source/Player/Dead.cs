using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Heath))]
public class Dead : StateComponentBase<PlayerBehaviour>
{

    private Heath heath;

    [HideInInspector]
    public bool IsAlive = true;

    public override void Awake ()
    {
        base.Awake();
        heath = GetComponent<Heath>();
    }

    public override void EnterState()
    {
        if(Behaviour.anim != null)
            Behaviour.anim.SetTrigger("Death");
    }

    public override void ExitState()
    {
    }

    private void Update ()
    {
        if(heath.IsZero() && !base.IsActive){
            IsAlive = false;
            Behaviour.ChangeState(PlayerBehaviour.States.Dead);
            //Destroy the GameObject
        }
    }
}

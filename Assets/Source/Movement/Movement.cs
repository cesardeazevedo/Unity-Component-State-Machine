using System;
using UnityEngine;
using System.Collections;

[AddComponentMenu("Component/Person/Movement")]
public class Movement : StateComponentBase<PlayerBehaviour>
{

    [SerializeField]
    private float Speed = 5;

    [HideInInspector]
    public bool IsMoving;

    public override void Awake()
    {
        base.Awake();
    }

    public override void EnterState()
    {
        IsMoving = true;
    }

    public override void ExitState()
    {
        IsMoving = false;
    }

    public void SetPosition(Vector3 Position)
    {
        transform.position = Vector3.MoveTowards(transform.position, Position, 0.05f * Speed);
    }

    public void SetPosition(float Horizontal)
    {
        Vector3 MoveTo = new Vector3(Horizontal * Speed * Time.deltaTime, 0, 0);
        this.transform.Translate(MoveTo);

        Behaviour.anim.SetFloat("Speed", Mathf.Abs(Horizontal));
    }
}

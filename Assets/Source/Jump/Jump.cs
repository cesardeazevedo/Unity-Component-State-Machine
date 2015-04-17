using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[AddComponentMenu("Component/Person/Jump")]
public class Jump : StateComponentBase<PlayerBehaviour>
{

    [SerializeField]
    private float JumpForce = 5f;

    [HideInInspector]
    public bool IsGround = true;

    private Rigidbody Rigidbody;

    /// <summary>
    /// Awake this instance.
    /// </summary>
    public override void Awake()
    {
        base.Awake();

        Rigidbody = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Enters the state.
    /// </summary>
    public override void EnterState()
    {
        if(IsGround) {
            IsGround = false;
            Rigidbody.velocity = new Vector3(0, JumpForce, 0);
            Behaviour.anim.SetTrigger("Jump");
        }
    }

    /// <summary>
    /// Exits the state.
    /// </summary>
    public override void ExitState()
    {
       IsGround = true;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
            Behaviour.ChangeToPreviousState();
    }
}
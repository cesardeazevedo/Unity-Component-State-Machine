using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(PlayerBehaviour))]
public class EnemyMovementController : MonoBehaviour {

    private Movement MovBehaviour;
    private PlayerBehaviour Behaviour;

    [SerializeField]
    private Transform Target;

    [SerializeField]
    private float smooth = 1f;

    private float speed;

	private void Awake () 
    {
        MovBehaviour = GetComponent<Movement>();
        Behaviour = GetComponent<PlayerBehaviour>();
	}
	
	private void Update () 
    {
        Vector3 pos = Target.position;
        pos.x = Mathf.SmoothDamp(transform.position.x, pos.x > transform.position.x ? pos.x - 1f : pos.x + 1f , ref speed, smooth);
        pos.y = 0;
        MovBehaviour.SetPosition(pos);
        Behaviour.Movement();
	}
}

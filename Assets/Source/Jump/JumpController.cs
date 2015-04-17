using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Jump))]
public class JumpController : MonoBehaviour 
{

    private PlayerBehaviour behaviour;

    private void Awake() {
        behaviour = GetComponent<PlayerBehaviour>();
    }

    private void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            behaviour.Jump();
    }
}

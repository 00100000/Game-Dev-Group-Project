using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithEnemy : MonoBehaviour
{
    public bool kill;
    public bool destoryDestructibles;

    //AudioSource audioSource;
    void Start()
    {
       // audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision other)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        if (body == null || body.isKinematic)
        {
            return;
        }

        // don't push ground or platform GameObjects below player
        if (hit.moveDirection.y < -0.3)
        {
            return;
        }
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(kill && hit.GameObject.tag == "Enemy" || destoryDestructibles && hit.GameObject.tag == "DestructibleEnvironment")
        {
            Destroy(hit.gameObject);
        }
    }

}
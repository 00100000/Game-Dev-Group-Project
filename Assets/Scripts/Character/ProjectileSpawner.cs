using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject projectile;
    public float launchVelocity = 700f;

    Vector3 launcherV;

    void update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject Projectile = Instantiate(projectile, transform.position, transform.rotation);
            ball.GetComponent<RigidBody>().AddRelativeForce(new Vector3(0, launchVelocity, 0));
        }

        launcherV = transform.localPosition;
        launcherV.x += Input.GetAxis("Horizontal") * Time.deltaTime * 10;
        launcherV.y += Input.GetAxis("Vertical") * Time.deltaTime * 10;
        transform.localPosition = launcherV;
    }
}
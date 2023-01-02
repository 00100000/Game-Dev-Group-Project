using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public TextMeshProUGUI healthDisplay;
    public float health;

    // Start is called before the first frame update
    //Only has Health right now
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthDisplay.SetText(health + " HP");    
    }
    public void removeHealth(float healthRemove)
    {
        health -= healthRemove;
    }
    public void addHealth(float healthAdd)
    {
        health += healthAdd;
    }
    //Collision with incoming projectiles
    void OnTriggerEnter(Collider other)
    {

    }
}

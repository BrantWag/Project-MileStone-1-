using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellMotor : MonoBehaviour
{
    [HideInInspector] public ShellData data;
    [HideInInspector] public Rigidbody rb;

    // Use this for initialization
    private void Start()
    {
        data = GetComponent<ShellData>();
        rb = GetComponent<Rigidbody>();

        Destroy(this.gameObject, data.Lifespan);

        pushForward();
    }
    private void OnTriggerEnter(Collider other)
    {
        // check to see if the target his is either a player tank or an enemy tank
        if (GameManager.instance.player.Contains(other.gameObject.GetComponent<TankData>()) ||
            GameManager.instance.AI.Contains(other.gameObject.GetComponent<TankData>()))
        {
            // if it is a player or an enemy tank then reduce their health
             Debug.Log("Enemy Tank Hit"); // Used in testing successful collisions with other tanks
            other.gameObject.GetComponent<Health>().reducecurrentHealth(data.shellDamage);
        }
        // destroy the projectile
        //Debug.Log("Collision Detected!"); // Used in testing successful collisions
        Destroy(this.gameObject);
    }
    public void pushForward()
    {
        rb.AddForce(transform.forward * data.shellSpeed);
    }
}

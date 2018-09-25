using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMotor : MonoBehaviour
{
    public Transform firingPoint;
    public GameObject smallShellPrefab;
    public GameObject largeShellPrefab;

    [HideInInspector] public TankData data;

    private void Start()
    {
        data = GetComponent<TankData>();
    }
    //reduce cooldown 
    private void Update()
    {
        if (data.LgshellCooldownCurrent >= 0)
        {
            data.LgshellCooldownCurrent -= Time.deltaTime;
        }
        if (data.SmshellCooldownCurrent >= 0)
        {
            data.SmshellCooldownCurrent -= Time.deltaTime;
        }
    }
    //moves character
    public void move(Vector3 movement)
    {
        transform.Translate(movement);
    }
    //rotates character
    public void rotate(Vector3 rotation)
    {
        transform.Rotate(rotation);
    }
    //checks cooldown
    bool checkCooldown(float cooldown)
    {
        if (cooldown >= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    //for shooting shells that are small
    public void ShootsmallShell()
    {
        if (checkCooldown(data.SmshellCooldownCurrent))
        {
            data.SmshellCooldownCurrent = data.SmshellCooldownMax;
            Instantiate(smallShellPrefab, firingPoint.position, firingPoint.rotation);
        }
    }
    //for shooting shells that are large 
    public void ShootLargeShell()
    {
        if (checkCooldown(data.LgshellCooldownCurrent))
        {
            data.LgshellCooldownCurrent = data.LgshellCooldownMax;
            Instantiate(largeShellPrefab, firingPoint.position, firingPoint.rotation);
        }
    }
}

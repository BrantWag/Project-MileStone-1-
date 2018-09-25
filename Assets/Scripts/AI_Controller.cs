using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Controller : MonoBehaviour
{
    [HideInInspector] public TankData data;
    [HideInInspector] public TankMotor motor;

    // Use this for initialization
    void Start()
    {
        data = GetComponent<TankData>();
        motor = GetComponent<TankMotor>();
        GameManager.instance.AI.Add(this.data);
    }

    // Update is called once per frame
    void Update()
    {
        motor.ShootLargeShell();
    }
}

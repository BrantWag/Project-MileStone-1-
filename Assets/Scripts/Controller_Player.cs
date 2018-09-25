using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Player : MonoBehaviour
{
    [HideInInspector] private TankData info;
    [HideInInspector] private TankMotor motor;

    void Start()
    {
        info = GetComponent<TankData>();
        motor = GetComponent<TankMotor>();

        GameManager.instance.player.Add(info);
    }


    void Update()
    {

        if (Input.GetButton("Fire1"))
        {
            // Shoot small shell when pressing assigned key
            motor.ShootsmallShell();
        }
        if (Input.GetButton("Fire2"))
        {
            // Shoot Large shell when pressing assigned key
            motor.ShootLargeShell();
        }
        if (Input.GetButton("Forward"))
        {
            // Move player Forward when pressing assigned key
            Vector3 movementVector = (Vector3.forward * info.movementSpeed * Time.deltaTime);
            motor.move(movementVector);
        }
        if (Input.GetButton("Backward"))
        {
            // Move Backward when pressing assigned key
            Vector3 movementVector = (Vector3.forward * info.movementSpeed * Time.deltaTime);
            motor.move(-movementVector);
        }
        if (Input.GetButton("RotateRight"))
        {
            // Rotate Right when pressing assigned key
            Vector3 vectorRotation = Vector3.up * info.rotationSpeed * Time.deltaTime;
            motor.rotate(vectorRotation);
        }
        if (Input.GetButton("RotateLeft"))
        {
            // Rotate Left when pressing assigned key
            Vector3 vectorRotation = Vector3.up * info.rotationSpeed * Time.deltaTime;
            motor.rotate(-vectorRotation);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simplemove : MonoBehaviour
{

    private CharacterController cc;
    [HideInInspector] public Transform tf;
    private TankData data;

    // Use this for initialization
    void Start()
    {
        cc = GetComponent<CharacterController>();
        tf = GetComponent<Transform>();
        data = GetComponent<TankData>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Move(Vector3 moveVector)
    {
        // Move in the direction of moveVector & speed from tank data
        cc.SimpleMove(moveVector.normalized * data.movementSpeed);
    }

    public void Turn(float direction)
    {
        // Turn in the direction at turn speed from tank data
        tf.Rotate(0, Mathf.Sign(direction) * data.rotationSpeed * Time.deltaTime, 0);
    }

    public void TurnTowards(Vector3 targetDirection)
    {
        // Find the rotation that looks down the vector "targetDirection"
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        // Rotate "less than turnspeed" degrees towards targetRotation
        tf.rotation = Quaternion.RotateTowards(tf.rotation, targetRotation, data.rotationSpeed * Time.deltaTime);
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [Header("Player Speed Variables")]
    public float defaultMovementSpeed;
    public float extraAccelerationSpeed;
    public float defaultTurnSpeed;
    public float breakingFactor;

    private void FixedUpdate()
    {
        float movementSpeed = this.defaultMovementSpeed;

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            movementSpeed += this.extraAccelerationSpeed;
        }else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            movementSpeed *= this.breakingFactor;
        }

        this.transform.Translate(movementSpeed * Vector3.up * Time.deltaTime);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Rotate(Vector3.forward, defaultTurnSpeed*Time.deltaTime); 
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Rotate(-Vector3.forward, defaultTurnSpeed * Time.deltaTime);
        }
    }
}

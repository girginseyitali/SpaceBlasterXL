using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementContoller : MonoBehaviour
{
    public Vector3 movementDirection;
    public float movementSpeed;

    private void FixedUpdate()
    {
        transform.Translate(movementDirection * movementSpeed * Time.deltaTime);
    }
}

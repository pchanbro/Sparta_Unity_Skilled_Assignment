using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingBox : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        collision.rigidbody.AddForce(Vector2.up * 10 , ForceMode.Impulse);
        Debug.Log("Jump");
    }
}

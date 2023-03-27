using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProyectile : MonoBehaviour
{
    private Rigidbody2D _myRigidBody2D;
    // Start is called before the first frame update
    void Start()
    {
        _myRigidBody2D = GetComponent<Rigidbody2D>();
        _myRigidBody2D.velocity = new Vector2(-5f, 0f);
    }
}

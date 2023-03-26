using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiempreHaciaDerecha : MonoBehaviour
{
    private Rigidbody2D _myRigidBody2D;
    // Start is called before the first frame update
    void Start()
    {
        _myRigidBody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _myRigidBody2D.velocity = new Vector2(1f, _myRigidBody2D.velocity.y);
    }
}

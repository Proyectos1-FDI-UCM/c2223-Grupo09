using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Créditos : MonoBehaviour
{
    private Rigidbody2D _myRigidBody2D;    
    // Start is called before the first frame update
    void Start()
    {
        _myRigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(Timer());
        _myRigidBody2D.velocity = new Vector2(_myRigidBody2D.velocity.x, 100f);
    }

    // Update is called once per frame
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(24.5f);        
        _myRigidBody2D.velocity = new Vector2(0f, 0f);
    }
}

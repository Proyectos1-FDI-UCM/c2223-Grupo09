using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Créditos : MonoBehaviour
{
    private Rigidbody2D _myRigidBody2D;
    private bool _stop=false;
    // Start is called before the first frame update
    void Start()
    {
        _myRigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        if (!_stop)
        {
            _myRigidBody2D.velocity = new Vector2(_myRigidBody2D.velocity.x, 100f);
        }        
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(24.5f);
        _stop = true;
        _myRigidBody2D.velocity = new Vector2(0f, 0f);
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletEnemy : MonoBehaviour
{
    #region Parameters
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _damage;
    #endregion

    #region Methods
    public float Damage()
    { return _damage; }


    public void BalaRight()
    {
        Debug.Log("Bala se mueve dcha");
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }

    public void BalaLeft()
    {
        Debug.Log("Bala se mueve izq");
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > -11.0f)
        {
            BalaLeft();
        }
        else if (transform.position.x < 10.0f)
        {
            BalaRight();
        }

        if((transform.position.x < -11.0f || transform.position.x > 10.0f)) 
        {
           Destroy(gameObject);
        }
    }
    #endregion

}


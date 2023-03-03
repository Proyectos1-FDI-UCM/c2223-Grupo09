using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    #region Parameters
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _damage;
    #endregion

    #region References
    [SerializeField]
    private Transform _myPlayerTransform;
    #endregion

    #region Methods
    public float Damage()
    { return _damage; }

    // Update is called once per frame
    void Update()
    {
        if(_myPlayerTransform.position.x > transform.position.x)
        {
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
        }
        
        else if (_myPlayerTransform.position.x < transform.position.x)
        {
            transform.Translate(Vector3.left * _speed * Time.deltaTime);
        }

        if(transform.position.x < -5.0f || transform.position.x > 10.0f)
        {
            Destroy(gameObject);
        }
    }
    #endregion

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletComponent : MonoBehaviour
{
    #region Parameters
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _damage;
    [HideInInspector]
    private Vector2 _dir;
    #endregion

    #region Methods
    public float getDamage() 
    { return _damage; }
    public Vector2 setDir(Vector2 d)
    { return _dir = d; }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_dir * _speed * Time.deltaTime);
    }
    
    #endregion
}
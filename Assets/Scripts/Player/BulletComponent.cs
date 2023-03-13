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
    [SerializeField]
    private Vector2 _dir;
    #endregion

    #region References
    private ShootComponent _shootComponent;
    #endregion

    #region Methods
    public float getDamage() 
    { return _damage; }
    public void setDir(Vector2 v)
    { _dir = v; }
    private void Start()
    {
        _speed = 5.0f;
        _shootComponent = GetComponent<ShootComponent>();
    }   
    // Update is called once per frame
    void Update()
    {
        transform.Translate(_dir * _speed * Time.deltaTime);
    }
    #endregion
}
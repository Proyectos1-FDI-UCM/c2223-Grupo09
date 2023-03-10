using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootComponent : MonoBehaviour
{
    #region Parameters
    [SerializeField]
    private Transform _myShootController;
    [SerializeField]
    private GameObject _bullet;
    #endregion
    #region References
    private BulletComponent _bulletComponent;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _bulletComponent = GetComponent<BulletComponent>();
    }
    public void Shoot(Vector2 dir)
    {
        Instantiate(_bullet, _myShootController.position, _myShootController.rotation);
        _bullet.GetComponent<BulletComponent>().setDir(dir);
    }
}

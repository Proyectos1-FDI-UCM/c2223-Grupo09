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

    #region Methods
    // Start is called before the first frame update
    void Start()
    {
        _bulletComponent = GetComponent<BulletComponent>();
    }
    public void Shoot(Vector2 dir)
    {
        //Assigns the dir to the bullet instaciated
        GameObject go = Instantiate(_bullet, _myShootController.position, _myShootController.rotation);
        go.GetComponent<BulletComponent>().setDir(dir);
    }
    #endregion
}

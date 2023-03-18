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
    [SerializeField]
    private AudioClip _bulletSound;
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
        AudioControler.Instance.PlaySound(_bulletSound);
        //Assigns the dir to the bullet instanciated
        GameObject go = Instantiate(_bullet, _myShootController.position, _myShootController.rotation);
        go.GetComponent<BulletComponent>().setDir(dir);
    }
    #endregion
}

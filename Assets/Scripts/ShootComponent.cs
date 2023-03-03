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
    public void Shoot()
    {
        Instantiate(_bullet, _myShootController.position, _myShootController.rotation);
    }
}

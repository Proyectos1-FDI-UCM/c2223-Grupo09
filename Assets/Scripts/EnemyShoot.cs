using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    #region Parameters
    [SerializeField]
    private Transform _myEnemyController;
    [SerializeField]
    private GameObject _bullet;
    private float _restingTime = 2.0f;
    #endregion

    #region References
    [SerializeField]
    private Transform _myPlayerTransform;

    BulletEnemy bulletEnemy;
    #endregion

    void Start()
    {
        bulletEnemy = GetComponent<BulletEnemy>();
        bulletEnemy = _bullet.GetComponent<BulletEnemy>();
    }

    IEnumerator BulletTime()
    {
        for(int i = 0; i < 3; i++)
        {
           yield return new WaitForSeconds(0.2f);
           _bullet = Instantiate(_bullet, _myEnemyController.position, _myEnemyController.rotation);  
            
           if(_myPlayerTransform.position.x > transform.position.x)
           {
                Debug.Log("bala derecha");
                bulletEnemy.BalaRight();
           }

           else if (_myPlayerTransform.position.x < transform.position.x)
           {
                Debug.Log("bala izquierda");
                bulletEnemy.BalaLeft();
           }
        }
    }

    // Update is called once per frame
    void Update()
    {
        _restingTime -= Time.deltaTime;

        if (_restingTime <= 0)
        {
            StartCoroutine(BulletTime());
            _restingTime = 2.0f;
        }
    }
}

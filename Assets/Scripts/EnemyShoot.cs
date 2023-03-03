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

    // Start is called before the first frame update

    IEnumerator BulletTime()
    {
        for(int i = 0; i < 3; i++)
        {
           yield return new WaitForSeconds(0.2f);
           _bullet = Instantiate(_bullet, _myEnemyController.position, _myEnemyController.rotation);           
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _restingTime -= Time.deltaTime;

        if (_restingTime <= 0)
        {
            //Instantiate(_bullet, _myEnemyController.position, _myEnemyController.rotation);
            StartCoroutine(BulletTime());
            _restingTime = 2.0f;
        }
    }
}

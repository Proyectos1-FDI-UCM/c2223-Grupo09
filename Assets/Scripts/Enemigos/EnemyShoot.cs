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
    public Animator _animator;
    [SerializeField]
    private AudioClip _shootsSound;
    #endregion

    IEnumerator BulletTime()
    {
        for(int i = 0; i < 3; i++)
        {
           yield return new WaitForSeconds(0.2f);
            AudioControler.Instance.PlaySound(_shootsSound);
           Instantiate(_bullet, _myEnemyController.position, _myEnemyController.rotation);
           _animator.SetBool("Dispara", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        _restingTime -= Time.deltaTime;

        if (_restingTime <= 0)
        {
            StartCoroutine(BulletTime());
            _restingTime = 1.3f;
        }
    }
}

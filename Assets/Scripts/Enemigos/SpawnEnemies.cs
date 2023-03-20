using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    private float _restingTime = 5.0f;
    [SerializeField] GameObject Enemigo1;
    [SerializeField] GameObject Enemigo2;
    void Update()
    {
        _restingTime -= Time.deltaTime;

        if (_restingTime <= 0)
        {
            int i = Random.Range(0, 2);
            if (i == 0)
            {
                Instantiate(Enemigo1, transform.position, transform.rotation);
            }
            else if (i == 1)
            {
                Instantiate(Enemigo2, transform.position, transform.rotation);
            }
            _restingTime = 5.0f;
        }
    }
}

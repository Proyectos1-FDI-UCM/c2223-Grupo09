using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTimeComponent : MonoBehaviour
{
    #region Parameters
    [SerializeField]
    private float lifeTime;
    #endregion

    #region Methods
    void Start() 
    {
        Destroy(gameObject, lifeTime); //se destruye el objeto cuando llegue su tiempo maximo de vida
    }
    #endregion
}

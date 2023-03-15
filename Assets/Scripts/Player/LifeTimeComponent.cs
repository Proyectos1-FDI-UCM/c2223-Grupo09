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
    // Start is called before the first frame update
    void Start()
    {
        lifeTime = 1.5f;
        Destroy(gameObject, lifeTime); 
    }
    #endregion
}

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
        Destroy(gameObject, lifeTime); 
    }
    #endregion
}

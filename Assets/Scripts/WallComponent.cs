using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallComponent : MonoBehaviour
{
    private CapsuleCollider2D _myCapsuleCollider;
    // Start is called before the first frame update
    void Start()
    {
        _myCapsuleCollider = GetComponent<CapsuleCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<BulletComponent>() != null)
        {
            Destroy(this.gameObject);
        }
    }
}

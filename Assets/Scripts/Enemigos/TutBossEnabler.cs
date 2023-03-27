using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutBossEnabler : MonoBehaviour
{
    [SerializeField] CapsuleCollider2D _myCollider;
    [SerializeField] CircleCollider2D _otherCollider;
    public void Enable()
    {
        _myCollider.enabled = true;
        _otherCollider.enabled = true;
    }
}

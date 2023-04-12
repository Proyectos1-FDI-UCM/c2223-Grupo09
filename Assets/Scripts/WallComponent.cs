using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallComponent : MonoBehaviour
{
    private CapsuleCollider2D _myCapsuleCollider;
    // Start is called before the first frame update

    private Animator _animator;
    [SerializeField]
    private AudioClip explosion;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _myCapsuleCollider = GetComponent<CapsuleCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<BulletComponent>() != null)
        {
            _animator.SetBool("Muerte", true);
            AudioControler.Instance.PlaySound(explosion);
            StartCoroutine(Wait());
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.4f);
        Dead();
    }

    private void Dead()
    {
        Destroy(this.gameObject);
    }
}

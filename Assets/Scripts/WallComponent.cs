using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallComponent : MonoBehaviour
{
    private BoxCollider2D _myBoxCollider;
    private Rigidbody2D _myRigidBody;
    // Start is called before the first frame update

    private Animator _animator;
    [SerializeField]
    private AudioClip explosion;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _myBoxCollider = GetComponent<BoxCollider2D>();
        _myRigidBody = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<BulletComponent>() != null)
        {
            _myRigidBody.gravityScale = 0f;
            _animator.SetBool("Muerte", true);
            AudioControler.Instance.PlaySound(explosion);
            _myBoxCollider.enabled = false;
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

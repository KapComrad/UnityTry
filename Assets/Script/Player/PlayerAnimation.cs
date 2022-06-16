using UnityEngine;
using System.Threading.Tasks;
using Player;

public class PlayerAnimation : MonoBehaviour
{
    private Transform _transform;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private PlayerMovement _playerMovement;

    [SerializeField] private bool _turningRight = true;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _transform = GetComponent<Transform>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerMovement = GetComponent<PlayerMovement>();

    }
    void Update()
    {
        if (!_turningRight && _rigidbody2D.velocity.x > 0.1f)
        {
            _transform.localScale = new Vector3(1f, 1f, 0f);
            _turningRight = true;
        }
        else if (_turningRight && _rigidbody2D.velocity.x < -0.1f)
        {
            _transform.localScale = new Vector3(-1f, 1f, 0f);
            _turningRight = false;
        }
        RunAnimationPlay();
        JumpAnimationPlay();
    }

    private void RunAnimationPlay()
    {
        _animator.SetFloat("Speed", Mathf.Abs(_rigidbody2D.velocity.x));
    }

    private void JumpAnimationPlay()
    {
        _animator.SetFloat("JumpVelocity", _rigidbody2D.velocity.y);
        _animator.SetBool("IsGrounded", _playerMovement.IsGrounded());
    }

    public async void TakeDamageAnimationPlay(float time)
    {
        Debug.Log("Entered");
        _animator.SetBool("TakedDamage", true);
        await Task.Delay((int)(time * 1000));
        Debug.Log("Exit");
        _animator.SetBool("TakedDamage", false);
    }

}

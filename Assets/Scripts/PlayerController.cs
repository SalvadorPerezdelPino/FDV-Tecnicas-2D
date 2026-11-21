using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputActionReference _moveAction;
    [SerializeField] private Animator _animator;
    //[SerializeField] private float _speed; 
    [SerializeField] private SpriteRenderer _spriteRenderer; 

    [SerializeField] private ScrollManager _scroll;

    private float _direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _moveAction.action.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        _direction = _moveAction.action.ReadValue<float>();
        _scroll.ScrollBackgrounds(_direction);
        if (_direction > 0)
        {
            _spriteRenderer.flipX = false;
            _animator.SetBool("isRunning", true);
        } 
        else if (_direction < 0)
        {
            _spriteRenderer.flipX = true;
            _animator.SetBool("isRunning", true);
        }
        else
        {
            _animator.SetBool("isRunning", false);
        }
    }
}

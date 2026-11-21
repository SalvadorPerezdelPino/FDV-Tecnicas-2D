using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputActionReference _moveAction;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _moveSpeed = 5.0f; 
    [SerializeField] private SpriteRenderer _spriteRenderer; 

    //[SerializeField] private Parallax _parallax;
    [SerializeField] private ScrollManager[] _scrolls;
    //private float _textureOffset;

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
        for (int i = 0; i < _scrolls.Length; i++)
        {
            _scrolls[i].ScrollBackgrounds(_direction);
        }
        //transform.Translate(_direction * _moveSpeed * Time.deltaTime, 0, 0);
        //_textureOffset = _direction * _moveSpeed * Time.deltaTime;
        //_parallax.UpdateParallaxTexturesOffset(_textureOffset);
        //_wrappedBackground.UpdateBackgroundOffset(_textureOffset);

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

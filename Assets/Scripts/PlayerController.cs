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

    public delegate void Message(float distance);
    public event Message OnPlayerMove;

    private float _timer = 0f;
    [SerializeField] private ObjectPool _pool;



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

        OnPlayerMove?.Invoke(_direction * _moveSpeed * Time.deltaTime);

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

        _timer += Time.deltaTime;
        if (_timer > 5f)
        {
            GameObject obj = _pool.RequestItem();
            obj.SetActive(true);
            obj.transform.position = transform.position + new Vector3(4, 0, 0);
            _timer = 0f;
        }

    }
}

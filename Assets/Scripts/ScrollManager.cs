using UnityEngine;

public class ScrollManager : MonoBehaviour
{
    [SerializeField] private Transform _currentBackground;
    [SerializeField] private Transform _leftBackground;
    [SerializeField] private Transform _rightBackground;
    private Transform _tempBackground;

    [SerializeField] private GameObject _camera;
    [SerializeField] private float _spriteWidth;
    [SerializeField] private float _scrollSpeed = 5.0f;

    private float _initialX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _initialX = _currentBackground.position.x;
        _leftBackground.position = new Vector2(_initialX - _spriteWidth, _currentBackground.position.y);
        _rightBackground.position = new Vector2(_initialX + _spriteWidth, _currentBackground.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        //CheckCameraDistance();
    }

    public void ScrollBackgrounds(float direction)
    {
        _currentBackground.Translate(-direction * _scrollSpeed * Time.deltaTime, 0, 0);
        _leftBackground.position = new Vector2(_currentBackground.position.x - _spriteWidth, _currentBackground.position.y);
        _rightBackground.position = new Vector2(_currentBackground.position.x + _spriteWidth, _currentBackground.position.y);
        if (_currentBackground.position.x < _initialX - _spriteWidth)
        {
            _tempBackground = _currentBackground;
            _currentBackground = _rightBackground;
            _rightBackground = _leftBackground;
            _leftBackground = _tempBackground;
            _initialX = _currentBackground.position.x;
        }
        else if (_currentBackground.position.x > _initialX + _spriteWidth)
        {
            _tempBackground = _currentBackground;
            _currentBackground = _leftBackground;
            _leftBackground = _rightBackground;
            _rightBackground = _tempBackground;
            _initialX = _currentBackground.position.x;
        }
    }

    private void CheckCameraDistance()
    {
        float cameraX = _camera.transform.position.x;
        if (cameraX > _initialX + _spriteWidth)
        {
            _tempBackground = _currentBackground;
            _currentBackground = _rightBackground;
            _rightBackground = _leftBackground;
            _leftBackground = _tempBackground;

            _initialX = _currentBackground.position.x;
            _rightBackground.position = new Vector2(_initialX + _spriteWidth, _currentBackground.position.y);
        }
        else if (cameraX < _initialX - _spriteWidth)
        {
            _tempBackground = _currentBackground;
            _currentBackground = _leftBackground;
            _leftBackground = _rightBackground;
            _rightBackground = _tempBackground;
            
            _initialX = _currentBackground.position.x;
            _leftBackground.position = new Vector2(_initialX - _spriteWidth, _currentBackground.position.y);
        }
    }
}

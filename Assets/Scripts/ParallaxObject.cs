using UnityEngine;

public class ParallaxObject : MonoBehaviour
{

    public ObjectPool pool;

    private GameObject _player;

    private PlayerController _playerController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _playerController = _player.GetComponent<PlayerController>();
        _playerController.OnPlayerMove += Move;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Move(float distance)
    {
        transform.Translate(-distance, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pool.ReturnItem(gameObject);
        }
    }

}

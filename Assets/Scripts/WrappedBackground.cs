using UnityEngine;

public class WrappedBackground : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    private float _offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateBackgroundOffset(float offset)
    {
        _offset += offset;

        _renderer.material.mainTextureOffset = new Vector2(_offset, 0);
    }
}

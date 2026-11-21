using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private float _speedDifference = 0.5f;
    [SerializeField] private float _baseSpeed = 0.1f;

    private Material[] _layers;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _layers = _renderer.materials;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateParallaxTexturesOffset(float offset)
    {
        for (int i = 0; i < _layers.Length; i++)
        {
            Material m = _layers[i];
            Vector2 offset2D = new Vector2(offset, 0);
            m.SetTextureOffset("_MainTex", m.GetTextureOffset("_MainTex") + offset2D * (i * _speedDifference + _baseSpeed));
        }
    }
}

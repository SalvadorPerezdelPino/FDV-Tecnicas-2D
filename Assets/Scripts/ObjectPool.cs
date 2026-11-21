using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _baseObject;
    [SerializeField] private int _poolSize;
    [SerializeField] private List<GameObject> _pool;


    void Awake()
    {
        _pool = new List<GameObject>();
        for (int i = 0; i < _poolSize; i++)
        {
            GameObject obj = Instantiate(_baseObject);
            obj.GetComponent<ParallaxObject>().pool = this;
            obj.SetActive(false);
            _pool.Add(obj);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject RequestItem()
    {
        if (_pool.Count > 0)
        {
            GameObject obj = _pool[0];
            _pool.RemoveAt(0);
            return obj;
        }

        Debug.Log("No quedan objetos en el pool! Creando uno nuevo!");
        GameObject newObj = Instantiate(_baseObject);
        _poolSize++;
        newObj.GetComponent<ParallaxObject>().pool = this;
        return newObj;
    }

    public void ReturnItem(GameObject obj)
    {
        obj.SetActive(false);
        _pool.Add(obj);
    }


}

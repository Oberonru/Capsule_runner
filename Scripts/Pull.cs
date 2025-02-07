using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pull<T> where T: MonoBehaviour
{
    private T _prefab;
    private List<T> _objects;

    public Pull(T prefab, int pullSize)
    {
        this._prefab = prefab;
        this._objects = new List<T>(100);

        for (int i = 0; i < pullSize; i++)
        {
            T newObject = GameObject.Instantiate(prefab);
            newObject.gameObject.SetActive(false);
            _objects.Add(newObject);
        }
    }

    public T Get()
    {
        T obj = _objects.FirstOrDefault(o => !o.isActiveAndEnabled);

        if (obj == null)
        {
           obj = Create();
        }
        obj.gameObject.SetActive(true);
        
        return obj;
    }

    public T Create()
    {
        T newObject = GameObject.Instantiate(_prefab);
        _objects.Add(newObject);

        return newObject;
    }

    public void Release(T obj)
    {
        obj.gameObject.SetActive(true);
    }
}

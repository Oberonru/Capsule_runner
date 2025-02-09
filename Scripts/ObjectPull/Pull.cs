using UnityEngine;
using System.Collections.Generic;
using System.Linq;

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

    public T Get(UnityEngine.Vector3 position, UnityEngine.Quaternion rotation)
    {
        T obj = _objects.FirstOrDefault(o => !o.isActiveAndEnabled);

        if (obj == null)
        {
           obj = Create();
        }
        obj.gameObject.transform.position = position;
        obj.gameObject.transform.rotation = rotation;
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
        obj.gameObject.SetActive(false);
    }
}

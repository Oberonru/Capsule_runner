using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ObjectPull
{
    public class CustomPull<T> where T: MonoBehaviour
    {
        private T _prefab;
        private List<T> _objects;

        public CustomPull(T prefab, int startCount)
        {
            this._prefab = prefab;
            this._objects = new List<T>();

            for (int i = 0; i < startCount; i++)
            {
                T obj = GameObject.Instantiate(_prefab);
                obj.gameObject.SetActive(false);
                _objects.Add(obj);
            }
        }

        public T Get()
        {
            T obj = _objects.FirstOrDefault(el => !el.isActiveAndEnabled);

            if (obj == null)
            {
                obj = Create();
            }
            
            obj.gameObject.SetActive(true);

            return obj;
        }

        public void Release(T obj)
        {
            obj.gameObject.SetActive(false);
        }

        public T Create()
        {
            T obj = GameObject.Instantiate(_prefab);
            _objects.Add(obj);
            return obj;
        }
    }
}
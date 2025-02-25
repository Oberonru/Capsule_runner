using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject prefab;

    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.G))
        {
            GameObject carrot = Instantiate(prefab, transform.position, transform.rotation);
            Vector3 direction = player.position - transform.position;

            carrot.GetComponent<Rigidbody>().velocity = direction.normalized * 10;
        }
    }
}

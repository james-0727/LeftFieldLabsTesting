using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // destroy 5 seconds after launching
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    public ParticleSystem hitGroundEffect;
    public ParticleSystem hitEnemyEffect;
    // Start is called before the first frame update
    void Start()
    {
        // destroy 5 seconds after launching
        Destroy(gameObject, 5);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Enemy>())
        {
            hitEnemyEffect.gameObject.SetActive(true);
        }
        else
        {
            hitGroundEffect.gameObject.SetActive(true);
        }
    }
}

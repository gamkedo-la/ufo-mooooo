using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    public string explosionResourcesPrefabName = "BoomBlocksDesert";
    // on by default to be used for adding more chaos to scene...
    public bool explodesIfHitByUfoBeam = true; // turn off for things only rockets or something else should affect
    public bool explodesIfHitByUfoShip = true; // turn off for things only rockets or something else should affect
    public bool explodesIfHitByGround = true;

    void Blast() {
        GameObject spawnEffect = Resources.Load(explosionResourcesPrefabName) as GameObject;
        if(spawnEffect) {
            GameObject.Instantiate(spawnEffect, transform.position, transform.rotation);
        }
        Destroy(gameObject);        
    }

    private void OnTriggerEnter(Collider other) {
        if (explodesIfHitByUfoBeam && other.tag == "Beam") {
            Blast();
        }

        if (explodesIfHitByUfoShip && other.tag == "Player")
        {
            Blast();
        }

        if (explodesIfHitByGround && other.tag == "Ground")
        {
            Blast();
        }
    }
}

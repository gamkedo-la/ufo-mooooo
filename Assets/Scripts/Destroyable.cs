using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    public string explosionResourcesPrefabName = "BoomBlocksDesert";
    // on by default to be used for adding more chaos to scene...
    public bool explodesIfHitByUfoBeam = true; // turn off for things only rockets or something else should affect

    void Blast() {
        GameObject spawnEffect = Resources.Load(explosionResourcesPrefabName) as GameObject;
        if(spawnEffect) {
            GameObject.Instantiate(spawnEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);        
    }

    private void OnTriggerEnter(Collider other) {
        if (explodesIfHitByUfoBeam && other.tag == "Beam") {
            Blast();
        }
    }
}

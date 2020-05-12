using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Collider collider;

    public Collider getCollider() {
        if (collider == null) {
            collider = GetComponent<Collider>();
        }

        return collider;
    }
    
    private void OnTriggerEnter(Collider other) {
        if (Game.getInstance().isHero(other.gameObject)) {
            Game.getInstance().collectCoin();
            
            Game.getInstance().addUnusedCoin(this);
        }
    }
}

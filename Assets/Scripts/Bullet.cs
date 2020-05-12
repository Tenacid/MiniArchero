using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private int damage;

    private Collider collider;
    private Rigidbody rigidbody;


    public Rigidbody getRigidbody() {
        if (rigidbody == null) {
            rigidbody = GetComponent<Rigidbody>();
        }

        return rigidbody;
    }

    public Collider getCollider() {
        if (collider == null) {
            collider = GetComponent<Collider>();
        }

        return collider;
    }

    public void addForce(Vector3 target) {

        getRigidbody().AddForce((target - transform.position).normalized * speed, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision) {

        Enemy enemy = Game.getInstance().getEnemyByGO(collision.gameObject);

        if (enemy != null) {
            enemy.dealDamage(damage);
        }

        Game.getInstance().addUnusedBullet(this);
    }
}

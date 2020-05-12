using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float fireDelay;
    [SerializeField]
    private Bullet bullet;
    [SerializeField]
    private Transform bulletEmitter;

    private CharacterController controller;

    

    private Enemy focusedEnemy;
    private float fireTime;

    private HeroState state;
    //private bool isMoving = false;

    private void Start() {
        controller = GetComponent<CharacterController>();
    }

    public void moveHero(Vector3 moveVec) {
        focusedEnemy = null;

        state = HeroState.MOVING;

        controller.Move(moveVec * speed);
    }

    public void stop() {
        if (state == HeroState.MOVING) {
            state = HeroState.SHOOTING;

            controller.Move(Vector3.zero);

            fireTime = 0;
            focusedEnemy = Game.getInstance().getNearestEnemy(transform.position);
        }
    }

    public void resetFocusedEnemy() {
        fireTime = 0;
        focusedEnemy = Game.getInstance().getNearestEnemy(transform.position); ;
    }

    

    private void Update() {
        if (state == HeroState.SHOOTING) {
            if (focusedEnemy != null) {
                fireTime += Time.deltaTime;

                transform.LookAt(focusedEnemy.transform.position);

                if (fireTime >= fireDelay) {
                    fire(focusedEnemy.transform.position);
                    fireTime = 0;
                }

            }
        }
    }


    private void fire(Vector3 targetPos) {
        Bullet newBullet = Game.getInstance().getBullet(bullet);
        newBullet.transform.position = bulletEmitter.position;
        newBullet.addForce(targetPos);
    }

}

public enum HeroState {
    INITIAL,
    MOVING,
    SHOOTING
}

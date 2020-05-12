using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private int maxHP;
    [SerializeField]
    private int coinsReward;
    private int curHP;
    private List<Vector3> route;    

    private CharacterController controller;
    private Animator animator;

    private int curRoutePointIndex=0;

    private void Start() {
        controller = GetComponent<CharacterController>();
        curHP = maxHP;
    }

    public void setRoute(List<Vector3> newRoute) {
        route = newRoute;
    }

    public void dealDamage(int damage) {
        curHP -= damage;

        if (curHP > 0) {
            getAnimator().SetTrigger("damage");
        } else {
            controller.Move(Vector3.zero);
            getAnimator().SetTrigger("death");
        }
    }

    public Animator getAnimator() {
        if (animator == null) {
            animator = GetComponent<Animator>();
        }

        return animator;
    }

    public void death() {
        dropCoins();
        Game.getInstance().removeEnemy(this);
    }

    public void dropCoins() {
        for (int i = 0; i < coinsReward; i++) {
            Vector3 pos = transform.position + new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
            Coin coin = Game.getInstance().getCoin();
            
            coin.transform.position = pos;
        }
    }

    public void correctRouteY(float newY) {
        for (int i = 0; i < route.Count; i++) {
            route[i] = new Vector3(route[i].x, newY, route[i].z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (route.Count > 0 && curHP > 0) {
            //CharacterController за счет параметра skin вытесняет персонажа с привычной позиции
            if (Mathf.Abs(transform.position.y - route[curRoutePointIndex].y) > Constants.mathDelta) {
                correctRouteY(transform.position.y);
            }

            if (Vector3.Distance(transform.position, route[curRoutePointIndex]) < Constants.mathDelta) {
                curRoutePointIndex++;

                if (curRoutePointIndex >= route.Count) {
                    curRoutePointIndex = 0;
                }
            }


            Vector3 moveVec = route[curRoutePointIndex] - transform.position;
            Vector3 normalizedMoveVec = moveVec.normalized * speed * Time.deltaTime;

            if (normalizedMoveVec.magnitude < moveVec.magnitude) {
                controller.Move(normalizedMoveVec);
            } else {
                controller.Move(moveVec);
            }

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
    private static ControlManager instance;

    public static ControlManager getInstance() {
        return instance;
    }

    public void checkKeyboardControl(float dt) {
        if (Input.anyKey) {
            Vector3 moveVec = Vector3.zero;

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
                moveVec += new Vector3(0, 0, 1);
            }

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
                moveVec += new Vector3(0, 0, -1);
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
                moveVec += new Vector3(-1, 0, 0);
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
                moveVec += new Vector3(1, 0, 0);
            }

            Game.getInstance().getHero().moveHero(moveVec * dt);

        } else {
            Game.getInstance().getHero().stop();
        }
    }


    private void Update() {
        
        checkKeyboardControl(Time.deltaTime);
        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Vector3 offset;

    [SerializeField]
    private float speed;


    private void Update() {
        Vector3 heroPos = Game.getInstance().getHero().transform.position;
        heroPos += offset;

        transform.position = Vector3.Lerp(transform.position, heroPos, Time.deltaTime * speed);
    }
}

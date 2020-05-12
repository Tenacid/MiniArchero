using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{
    private static InterfaceManager instance;

    [SerializeField]
    private Text uiCoinsCount;

    public static InterfaceManager getInstance() {
        if (instance == null) {
            instance = FindObjectOfType<InterfaceManager>();
        }

        return instance;
    }

    public void redrawCoinsCount(int newCoinsCount) {
        uiCoinsCount.text = newCoinsCount.ToString();
    }
}

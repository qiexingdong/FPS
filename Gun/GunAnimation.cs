using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAnimation : MonoBehaviour
{

    public string updateAmmo;
    public string fire;
    public AnimationAction action;
    private void Awake()
    {
        action = new AnimationAction(GetComponentInChildren<Animation>());
    }
}



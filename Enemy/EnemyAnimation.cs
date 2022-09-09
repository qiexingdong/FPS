using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// µ–»À∂Øª≠
/// </summary>
public class EnemyAnimation : MonoBehaviour
{
    public string runAnim;
    public string attackAnim; 
    public string idleAnim;
    public string dieAnim;
    public string reloadAnim;
    public AnimationAction action;
    private void  Awake()
    {
        action = new AnimationAction(this.GetComponentInChildren<Animation>());
    }
}



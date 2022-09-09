using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 动画行为类
/// </summary>
public class AnimationAction
{
    public Animation anim;
    public AnimationAction(Animation anim)
    {
        this.anim = anim;
    }
    //播放动画
    public void Play(string animName)
    {
        anim.CrossFade(animName);
    }
    //判断该动画是否在播
    public bool IsPlaying(string name)
    {
        return anim.IsPlaying(name);
    }
    //
    public void PlayQueue(string animName) {
        anim.PlayQueued(animName);
    }
}

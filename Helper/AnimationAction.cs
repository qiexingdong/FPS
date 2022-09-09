using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ������Ϊ��
/// </summary>
public class AnimationAction
{
    public Animation anim;
    public AnimationAction(Animation anim)
    {
        this.anim = anim;
    }
    //���Ŷ���
    public void Play(string animName)
    {
        anim.CrossFade(animName);
    }
    //�жϸö����Ƿ��ڲ�
    public bool IsPlaying(string name)
    {
        return anim.IsPlaying(name);
    }
    //
    public void PlayQueue(string animName) {
        anim.PlayQueued(animName);
    }
}

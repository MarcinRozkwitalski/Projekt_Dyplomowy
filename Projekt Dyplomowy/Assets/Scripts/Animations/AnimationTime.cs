using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTime : MonoBehaviour
{
    public float GetAnimationTimeFromName(Animator animator, string animationName)
    {
        float animationTime = 0.0f;
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            if (clip.name == animationName)
            {
                animationTime = clip.length;
            }
        }
        return animationTime;
    }
}

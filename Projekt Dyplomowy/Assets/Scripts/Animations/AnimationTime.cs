using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTime : MonoBehaviour
{
    public float GetAnimationTimeFromName(Animator animator, string animationName)
    {
        float animationTime = 0.0f;
        Debug.Log("animationName = " + animationName);
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            Debug.Log("clip = " + clip.name);
            if (clip.name == animationName)
            {
                animationTime = clip.length;
                Debug.Log("Found clip length");
            }
        }
        return animationTime;
    }
}

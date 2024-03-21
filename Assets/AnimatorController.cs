using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    /*
    public Animator animator;
    public GameObject myHeart;
    public bool explosionTrigger = false;

    void Update()
    {
        if(!myHeart.activeSelf && !explosionTrigger)
        {
            gameObject.SetActive(true);
        }
    }
    private void onEnable()
    {
        animator = GetComponent<Animator>();
        // Animator'ın bağlı olduğu animasyonun bitimini takip etmek için bir event ekleyin
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            if (clip.isLooping == false)
            {
                Invoke("CloseObject", clip.length);
            }
        }
    }

    public void CloseObject()
    {
        gameObject.SetActive(false);
        myHeart.SetActive(false);
        explosionTrigger = true;
    }
    */
}

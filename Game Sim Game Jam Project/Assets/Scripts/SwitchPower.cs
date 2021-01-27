using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPower : MonoBehaviour
{
    private Animator anim;
    private AnimatorOverrideController overrider;
    public AnimationClip[] lightAnimationClips;
    public AnimationClip[] darkAnimationClips;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
        overrider = new AnimatorOverrideController(anim.runtimeAnimatorController);
        anim.runtimeAnimatorController = overrider;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(ToggleManager.Instance.isLight)
            {
                ToggleManager.Instance.isLight = false;
                overrider["Light_Player_Idle"] = darkAnimationClips[0];
                overrider["Light_Player_Run"] = darkAnimationClips[1];
                overrider["Light_Player_Jump"] = darkAnimationClips[2];

            }
            else
            {
                ToggleManager.Instance.isLight = true;
                overrider["Light_Player_Idle"] = lightAnimationClips[0];
                overrider["Light_Player_Run"] = lightAnimationClips[1];
                overrider["Light_Player_Jump"] = lightAnimationClips[2];
            }
        }
        
    }

}

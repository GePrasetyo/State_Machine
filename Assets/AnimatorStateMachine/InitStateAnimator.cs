using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitStateAnimator : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        FSMHandler.RegisterActorFSM(animator);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAnimator : StateMachineBehaviour
{
    private ActorFSM myActor;
    private float timer;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var a = Random.Range(3, 10);
        var flag = a < 5;

        myActor = animator.RetrieveActorFSM();
        //Debug.LogError($"name : {myActor}");

        if (myActor.Update)
            return;
        else
            timer = a;

        if (flag)
            animator.SetTrigger("Done");
        else
            animator.SetTrigger("Failed");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //var actor = animator.RetrieveActorFSM();
        //Debug.LogError($"name : {myActor.name}");

        if (!myActor.Update)
            return;

        timer -= 1*Time.deltaTime;

        if(timer < 0)
        {
            var a = Random.Range(3, 10);
            var flag = a < 5;

            if (flag)
                animator.SetTrigger("Done");
            else
                animator.SetTrigger("Failed");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}

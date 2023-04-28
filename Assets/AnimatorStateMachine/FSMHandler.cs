using UnityEngine;
using System.Collections.Generic;

public static class FSMHandler
{
    private static Dictionary<Animator, ActorFSM> dictionary = new Dictionary<Animator, ActorFSM>();

    public static void RegisterActorFSM(Animator animator)
    {
        if(animator.TryGetComponent<ActorFSM>(out var actor))
        {
            dictionary[animator] = actor;
        }
        else
        {
            dictionary[animator] = animator.gameObject.AddComponent<ActorFSM>();
        }
    }

    public static ActorFSM RetrieveActorFSM(this Animator self)
    {
        return dictionary[self];
    }
}

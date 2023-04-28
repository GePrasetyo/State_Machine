using UnityEngine;

public class ActorFSM : MonoBehaviour
{
    public string myName;
    public bool Update;

    private void Awake()
    {
        myName = gameObject.name;
    }
}

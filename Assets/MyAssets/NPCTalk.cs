using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTalk : MonoBehaviour
{
    //int rnd = 0;
    private Animator animator;
    public string dialog;
    public string animation = "Talk";
    void Update()
    {
        animator = GetComponent<Animator> ();
        //rnd = Random.Range(0, 4);
    }

    public void Interact()
    {
        animator.SetTrigger(animation);
        ChatBubble.Create(transform.transform, new Vector3(0f, 2f, 0f), dialog);
    }
    
}

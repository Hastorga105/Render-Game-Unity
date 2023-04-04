using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable1 : MonoBehaviour
{
    //int rnd = 0;

    void Update()
    {
        //rnd = Random.Range(0, 4);
    }

    public void Interact(int rnd)
    {

        ChatBubble.Create(transform.transform, new Vector3(0f, 2.5f, 0f), "");
    }
}

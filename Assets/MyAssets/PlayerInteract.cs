using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    int rnd = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        rnd = Random.Range(0, 4);
    }

    // Update is called once per frame
    void Update()
    {
        float interactRange = 1f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
           if( collider.TryGetComponent(out NPCInteractable npcInteractable))
            {
                npcInteractable.Interact(rnd);
            }
           else if (collider.TryGetComponent(out NPCTalk npcTalk))
            {
                npcTalk.Interact();
            }
        }
        
    }
}

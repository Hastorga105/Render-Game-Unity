using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    //int rnd = 0;

    void Update()
    {
        //rnd = Random.Range(0, 4);
    }

    public void Interact(int rnd)
    {
        string text = "";
        if(rnd == 0)
        {
            text = "Hola, bienvenido a la UTLD";
        }else if (rnd == 1)
        {
            text = "¡Alguien instalo linux en las computadoras!";
        }
        else if (rnd == 2)
        {
            text = "Vamos a estudiar";
        }
        else if (rnd == 3)
        {
            text = "Espero que no se me pase el camión";
        }
        else if (rnd == 4)
        {
            text = "Ave";
        }
        ChatBubble.Create(transform.transform, new Vector3(0f, 2.5f, 0f), text);
    }
}

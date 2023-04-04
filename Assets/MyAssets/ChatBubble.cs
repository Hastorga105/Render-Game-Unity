using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatBubble : MonoBehaviour
{
    public static void Create(Transform parent, Vector3 localPosition, string texto)
    {
        Transform chatBubbleTransform = Instantiate(GameAssets.i.pfChatBubble,parent);
        chatBubbleTransform.localPosition = localPosition;
        //chatBubbleTransform.transform.localScale = new Vector3(0.1,0.1,0.1);

        chatBubbleTransform.GetComponent<ChatBubble>().Setup(texto);

        Destroy (chatBubbleTransform.gameObject, 6f);
    }

    private SpriteRenderer backgroundSpriteRenderer;
    private SpriteRenderer iconSpriteRenderer;
    private TextMeshPro textMeshPro;
    private TextMeshPro textMeshPro2;

    private void Awake()
    {
        backgroundSpriteRenderer = transform.Find("Background").GetComponent<SpriteRenderer>();
        iconSpriteRenderer = transform.Find("Icon").GetComponent<SpriteRenderer>();
        textMeshPro = transform.Find("Text").GetComponent<TextMeshPro>();
        textMeshPro2 = transform.Find("Text2").GetComponent<TextMeshPro>();
    }

    private void Start()
    {
        //Setup("Instalemos Linux");
    }

    private void Setup(string text)
    {
        textMeshPro.SetText(text);
        textMeshPro.ForceMeshUpdate();
        Vector2 textSize = textMeshPro.GetRenderedValues(false);
        textMeshPro2.SetText(text);
        textMeshPro2.ForceMeshUpdate();
        //Vector2 textSize = textMeshPro2.GetRenderedValues(false);

        Vector2 padding = new Vector2(7f, 2f);
        //textMeshPro.size = textMeshPro.scale / 10;
        backgroundSpriteRenderer.size = (textSize + padding);
       
       /*backgroundSpriteRenderer.transform.localPosition = 
            new Vector3(backgroundSpriteRenderer.size.x / 2f, 0f);*/
    }
}

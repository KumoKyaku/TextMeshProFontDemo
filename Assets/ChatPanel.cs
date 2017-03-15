using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ChatPanel : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public TMP_SpriteAsset Emoji;
    public TMP_InputField Input;

    public UnityEngine.UI.ScrollRect TextRect;
    //public EmojiInput EmojiInput;
    // Use this for initialization
    void Start () {
        Text.text = "哈哈";
        //Text.spriteAsset;
        if (Input && Input.textComponent.spriteAsset == null)
        {
            Input.textComponent.spriteAsset = Emoji;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InsertEmoji(string emoji)
    {
        Input.text = emoji;
    }

    public void InputSubmit(string input)
    {
        Text.text += "\n" + input ;
        TextRect.content.sizeDelta = 
            new Vector2(TextRect.content.sizeDelta.x, Text.renderedHeight + Text.fontSize+ 20);

        ///解决verticalScrollbar设定值无法为0的问题
        StartCoroutine(SetVerticalScrollbarValue(0));
    }

    private IEnumerator SetVerticalScrollbarValue(int v)
    {
        yield return new WaitForEndOfFrame();
        TextRect.verticalScrollbar.value = v;
    }
}

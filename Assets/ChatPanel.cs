using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatPanel : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public TMP_SpriteAsset Emoji;
    public int Row = 5;
    public int Column = 10;
    // Use this for initialization
    void Start () {
        Text.text = "哈哈";
        //Text.spriteAsset;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EmojiInput : MonoBehaviour
{
    [SerializeField]
    private TMP_SpriteAsset emojiAsset;
    [SerializeField]
    private GameObject emojiElementTemplate;
    [SerializeField]
    private GridLayoutGroup Panel;

    [SerializeField]
    private int row = 5;
    public int Row { get { return row; } }
    [SerializeField]
    private int column = 10;
    public int Column { get { return column; } }

    // Use this for initialization
    void Start () {
        if (emojiAsset && emojiAsset.spriteGlyphTable.Count > 0)
        {
            float x = emojiAsset.spriteGlyphTable[0].glyphRect.width;
            float y = emojiAsset.spriteGlyphTable[0].glyphRect.height;
            Panel.cellSize = new Vector2(x, y);
            (Panel.transform as RectTransform).sizeDelta = new Vector2(column * x, row * y);


            foreach (var item in emojiAsset.spriteGlyphTable)
            {
                GameObject ele = Instantiate(emojiElementTemplate);
                RectTransform trans = ele.GetComponent<RectTransform>();
                trans.SetParent(Panel.transform);
                trans.localPosition = Vector3.zero;
                trans.localScale = Vector3.one;
                trans.sizeDelta = new Vector2(item.glyphRect.width, item.glyphRect.width);
                Image img = ele.GetComponent<Image>();
                img.sprite = item.sprite;

                Button but = ele.GetComponent<Button>();
                but.onClick.AddListener(() => 
                {
                    Submit.Invoke("<sprite="+ item.index+">");
                    Panel.gameObject.SetActive(false);

                });

                ele.SetActive(true);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public InputField.SubmitEvent Submit;

    public void OnOff()
    {
        Panel.gameObject.SetActive(!Panel.gameObject.activeSelf);
    }
}

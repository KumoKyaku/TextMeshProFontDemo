using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChatPanel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textTemplate;
    public TMP_SpriteAsset Emoji;
    public TMP_SpriteAsset Emoji2X;
    public TMP_InputField Input;

    public UnityEngine.UI.ScrollRect TextRect;

    UnityEngine.UI.VerticalLayoutGroup group;
    void Start () {
        
        if (Input && Input.textComponent.spriteAsset == null)
        {
            Input.textComponent.spriteAsset = Emoji;
            Input.onSubmit.AddListener(InputSubmit);
        }

        group = TextRect.content.GetComponent<VerticalLayoutGroup>();

    }
	
	// Update is called once per frame
	void Update () {
        if (Input && Input.caretPosition != 0)
        {
            LogCaretPosition();
        }

    }

    public void InsertEmoji(string emoji)
    {
        Input.text = Input.text.Insert(caretPosition, emoji);
    }

    float ContentHeight = 0f;

    [SerializeField,Tooltip("输入提交后是否自动清除")]
    private bool autoClear = true;

    /// <summary>
    /// 输入框插入符位置
    /// </summary>
    public int caretPosition { get; private set; }

    public void InputSubmit(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return;
        }

        ShowInputMySelf(input);

        if (autoClear)
        {
            ClearInputFeild();
        }

        caretPosition = 0;
    }

    public void ClearInputFeild()
    {
        Input.text = "";
    }

    /// <summary>
    /// 显示输入的文字
    /// </summary>
    /// <param name="input"></param>
    private void ShowInputMySelf(string input)
    {
        TextMeshProUGUI newtext = Instantiate(textTemplate, TextRect.content.transform);

        newtext.text = input;

        newtext.gameObject.SetActive(true);

        var height = ReSizeFontSize(newtext, newtext.fontSize);



        ///设置容器高度
        ContentHeight += height;
        TextRect.content.sizeDelta = new Vector2(0, ContentHeight);
        ///解决verticalScrollbar设定值无法为0的问题
        StartCoroutine(SetVerticalScrollbarValue(0));
    }

    /// <summary>
    /// 重设字体大小
    /// </summary>
    /// <param name="newtext"></param>
    /// <param name="fontsize"></param>
    /// <returns>返回重设后高度</returns>
    private float ReSizeFontSize(TextMeshProUGUI newtext,float fontsize)
    {
        newtext.fontSize = fontsize;

        ///是否含有表情
        var containEmoji = newtext.text.Contains("<sprite=") && newtext.text.Contains(">");
        /// 额外的字体的1/5分页高度附加
        float tempHeight = newtext.fontSize / 5;
        if (containEmoji)
        {
            tempHeight *= 2;
            newtext.lineSpacing = newtext.fontSize / 2;
            tempHeight += newtext.preferredHeight + newtext.lineSpacing;
        }
        else
        {
            tempHeight += newtext.preferredHeight;

        }

        newtext.rectTransform.sizeDelta =
                new Vector2(TextRect.content.rect.width, tempHeight);

        return tempHeight;
    }

    private IEnumerator SetVerticalScrollbarValue(int v)
    {
        yield return new WaitForEndOfFrame();
        TextRect.verticalScrollbar.value = v;
    }

    public void LogCaretPosition()
    {
        caretPosition = Input.stringPosition;
        Debug.Log(caretPosition);
    }

    public void Test(int a)
    {
        //Debug.Log(a);
    }
}

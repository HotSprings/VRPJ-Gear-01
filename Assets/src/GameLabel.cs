using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameLabel : MonoBehaviour {

    private Text m_text = null;
    private int m_maxLineSize = 8;

    void Start () {
        m_text = this.gameObject.GetComponent<Text>();
	}
	
    void Update () {
	
	}

    public void setText(string text) {
        m_text.text = text;
    }
    public string getText() {
        return m_text.text;
    }
    public void addText(string text) {
        string str = m_text.text + text + '\n';
        m_text.text = "";
        string[] strList = str.Split('\n');
        for (int i = 0; i < strList.Length; i ++) {
            if(i >= strList.Length - m_maxLineSize)
            m_text.text += strList[i] + '\n';
        }
        m_text.text = m_text.text.Substring(0, m_text.text.Length - 1);
    }
}

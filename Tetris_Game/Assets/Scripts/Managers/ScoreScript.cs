using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

    int m_score = 0;

    const int m_minLines = 1; //Минимум линий за раз
    const int m_maxLines = 4; //Максимум линий за раз

    public Text m_ScoreText;

    public void ScoreLines(int n)
    {
        n = Mathf.Clamp(n, m_minLines, m_maxLines);
        switch (n)
        {
            case 1:
                m_score += 100;
                break;
            case 2:
                m_score += 300;
                break;
            case 3:
                m_score += 700;
                break;
            case 4:
                m_score += 1500;
                break;
        }
        UpdateText();
    }

    void UpdateText()
    {
        m_ScoreText.text = m_score.ToString();
    }

    public void Reset()
    {

    }

    void Start () {
		
	}
	
	void Update () {
		
	}
}

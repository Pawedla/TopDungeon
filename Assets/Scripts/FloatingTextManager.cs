using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject textContainer;
    public GameObject textPrefab;

    private List<FloatingText> floatingTexts = new List<FloatingText>();

    private void Update()
    {
        foreach(FloatingText txt in floatingTexts)
        {
            txt.UpdateFloatingText();
        }
    }


    public void Show(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        FloatingText floaingText = GetFloatingText();
        floaingText.txt.text = msg;
        floaingText.txt.fontSize = fontSize;
        floaingText.txt.color = color;
        floaingText.go.transform.position = Camera.main.WorldToScreenPoint(position);
        floaingText.motion = motion;
        floaingText.duration = duration;

        floaingText.Show();
    }
    private FloatingText GetFloatingText()
    {
        FloatingText txt = floatingTexts.Find(t => !t.active);

        if(txt == null)
        {
            txt = new FloatingText();
            txt.go = Instantiate(textPrefab);
            txt.go.transform.SetParent(textContainer.transform);
            txt.txt = txt.go.GetComponent<Text>();
            floatingTexts.Add(txt);
        }

        return txt;
    }
}

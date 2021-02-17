using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEditor;
using TMPro;

public class ChangeFont : MonoBehaviour
{
    public Dropdown fontDropDown;
    private Text[] textArray;
    public Slider fontSlider;
    private int maxFontSize = 60;

    void Start()
    {
        fontDropDown.onValueChanged.AddListener(delegate
        {
            DropDownValueChanged(fontDropDown);
        });

        textArray = Resources.FindObjectsOfTypeAll<Text>();
        fontSlider.value = 0.87f;
    }

    public void DropDownValueChanged(Dropdown change)
    {
        switch (change.value)
        {
            case 0:
                ChangeFontCol(Color.white);
                break;
            case 1:
                ChangeFontCol(Color.yellow);
                break;
            case 2:
                ChangeFontCol(Color.cyan);
                break;
            default:
                break;
        }
    }

    void ChangeFontCol(Color color)
    {
        foreach (Text textItem in textArray)
        {
            if (textItem != null)
            {

                if (textItem.name != "Label" && textItem.name != "Item Label")
                {
                    textItem.color = color;
                }
            }
        }
    }

    public void ChangeFontSize()
    {

        int newFontSize = (int)Mathf.Round(fontSlider.value * maxFontSize);
        foreach (Text textItem in textArray)
        {
            if (textItem != null) { 

            if (textItem.name != "Label" && textItem.name != "TitleCard" && textItem.name != "Item Label" && textItem.name != "InstructionText")
            {
                if (textItem.name != "DescriptionText" && textItem.name != "VideoInfoText" )
                {
                textItem.fontSize = newFontSize;
                }

            }
        }}
    }

}

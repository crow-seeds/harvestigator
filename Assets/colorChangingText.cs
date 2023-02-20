using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class colorChangingText : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI textmeshPro = GetComponent<TextMeshProUGUI>();
        textmeshPro.outlineWidth = 0.2f;
        textmeshPro.outlineColor = new Color32(0, 0, 0, 255);
    }

    // Update is called once per frame
    void Update()
    {
        float h, s, v;
        Color.RGBToHSV(gameObject.GetComponent<TextMeshProUGUI>().color, out h, out s, out v);
        Color newColor = Color.HSVToRGB(h + Time.deltaTime * .5f, 1, 1);

        gameObject.GetComponent<TextMeshProUGUI>().color = new Color(newColor.r, newColor.g, newColor.b, gameObject.GetComponent<TextMeshProUGUI>().color.a);
    }
}

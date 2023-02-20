using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class boldOutline : MonoBehaviour
{
    private void Awake()
    {
        TextMeshProUGUI textmeshPro = GetComponent<TextMeshProUGUI>();
        textmeshPro.outlineWidth = 0.3f;
        textmeshPro.outlineColor = new Color32(0, 0, 0, 255);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

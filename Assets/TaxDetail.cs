using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TaxDetail : MonoBehaviour
{
    public bool shouldBeSelected;
    public bool isSelected;
    public string detail1;
    public string detail2;


    // Start is called before the first frame update
    void Start()
    {
        EventTrigger trigger = GetComponentInParent<EventTrigger>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry.callback.AddListener((eventData) => { onEnter(); });
        trigger.triggers.Add(entry);

        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry2.eventID = EventTriggerType.PointerExit;
        entry2.callback.AddListener((eventData) => { onExit(); });
        trigger.triggers.Add(entry2);

        EventTrigger.Entry entry3 = new EventTrigger.Entry();
        entry3.eventID = EventTriggerType.PointerClick;
        entry3.callback.AddListener((eventData) => { toggle(); });
        trigger.triggers.Add(entry3);

        if (!isSelected)
        {
            GetComponent<RawImage>().color = new Color(.92f, .92f, .92f, 1f);
        }
        else
        {
            GetComponent<RawImage>().color = new Color(1, 1, .20f, 1f);
        }
    }

    public void onEnter()
    {
        GetComponent<RawImage>().color = new Color(.96f, .96f, .56f, 1f);
    }

    public void onExit()
    {
        if (!isSelected)
        {
            GetComponent<RawImage>().color = new Color(.92f, .92f, .92f, 1f);
        }
        else
        {
            GetComponent<RawImage>().color = new Color(1, 1, .20f, 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [SerializeField] AudioSource soundFx;

    public void toggle()
    {
        soundFx.PlayOneShot(Resources.Load<AudioClip>("Sounds/highlight" + Random.Range(0,4).ToString()));
        isSelected = !isSelected;
        if (isSelected)
        {
            GetComponent<RawImage>().color = new Color(1, 1, .20f, 1f);
        }
        else
        {
            GetComponent<RawImage>().color = new Color(.92f, .92f, .92f, 1f);
        }
    }
}

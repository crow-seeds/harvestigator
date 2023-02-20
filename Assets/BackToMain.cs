using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BackToMain : MonoBehaviour
{
    public bool isSelected;
    [SerializeField] AudioSource soundFx;
    [SerializeField] AuditHandler au;


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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onEnter()
    {
        if (!isSelected)
        {
            GetComponent<RawImage>().color = new Color(.96f, .96f, .56f, 1f);
        }
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

    public void toggle()
    {
        if (!isSelected)
        {
            soundFx.PlayOneShot(Resources.Load<AudioClip>("Sounds/highlight" + Random.Range(0, 4).ToString()));
            isSelected = true;
            GetComponent<RawImage>().color = new Color(1, 1, .20f, 1f);
            au.backToMenu();
        }
        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameStarter : MonoBehaviour
{
    [SerializeField] AuditHandler au;
    [SerializeField] bool isStory;

    // Start is called before the first frame update
    void Start()
    {
        EventTrigger trigger = GetComponentInParent<EventTrigger>();


        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.EndDrag;
        entry.callback.AddListener((eventData) => { startGame(); });
        trigger.triggers.Add(entry);
    }

    public void startGame()
    {
        Vector2 pos = gameObject.GetComponent<RectTransform>().localPosition;

        if(pos.x > 300 && pos.x < 700 && pos.y < 150 && pos.y > -300)
        {
            au.startGame(isStory);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

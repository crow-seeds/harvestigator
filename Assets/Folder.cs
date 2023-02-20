using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Folder : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isOpened;
    public GameObject closedFolder;
    public GameObject openFolder;
    public AuditHandler ah;
    public bool canBeOpened;
    [SerializeField] AudioSource soundFx;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openFolderAction()
    {
        if (canBeOpened)
        {
            soundFx.PlayOneShot(Resources.Load<AudioClip>("Sounds/folder"));
            closedFolder.SetActive(false);
            openFolder.SetActive(true);
            isOpened = true;
            ah.randomizePositions();
        }
    }
}

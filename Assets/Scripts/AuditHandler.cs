using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Globalization;
using System;
using Random = UnityEngine.Random;

public class AuditHandler : MonoBehaviour
{
    [SerializeField] RectTransform filesContainer;
    [SerializeField] TextMeshProUGUI plotText;
    [SerializeField] TextMeshProUGUI guidelines;
    [SerializeField] List<TaxDetail> cropYields;
    [SerializeField] List<TaxDetail> subsidies;
    [SerializeField] Folder fold;
    [SerializeField] TextMeshProUGUI name;
    [SerializeField] AudioSource music;

    string nameString;
    float timer = 0;
    float health = 65;
    float damageRate = .92f;
    bool endlessStarted = false;
    bool hasFailedFarmer = false;


    public bool storyMode = true;

    achivementHandler aHandler;

    List<string> potentialNames = new List<string>() { "Arlo", "Austin", "Autumn", "Brooke", "Clementine", "Clay", "Cliff", "Eugene", "Flint", "Heather", "Hazel", "Jasper", "June", "Palmer", "Ryder", "Scott", "Viola", "Walter", "Xjorph", "Said", "Emmanuel", "Labib", "Jesse", "Bella", "Maurice", "Mike" };


    Dictionary<string, int> countyRegistry;

    Dictionary<string, List<string>> subsidiesNames = new Dictionary<string, List<string>>()
    {
        {"Potatoes", new List<string>(){ "Charles Grant of Potatoes", "Potato Grant of 2020", "Potato Panic Patch", "Obama's Potato Push" } },
        {"Carrots", new List<string>(){ "Carrot Support Law of 1908", "International Carrot Grant", "Carrot Relief Bill", "CarrotCare" } },
        {"Peas", new List<string>() { "Biden's Pea Injection", "Pea PUSH Act", "Peas for Peace", "Papers Peas Bill" } },
        {"Beets", new List<string>(){ "The Washington Beet Act", "Operation B.E.E.T", "Beets for Meats", "Beet Emergency Fund" } },
        {"Pumpkins", new List<string>(){"Pumpkin Subsidy II", "Pumpkin Halloween Fund", "Pumpkin Pump Package", "Act of Pumpkin Fairness"} }
    };

    public List<string> plots = new List<string>();

    int points = 0;
    int level = 0;


    // Start is called before the first frame update
    void Start()
    {
        aHandler = FindObjectOfType<achivementHandler>();
        initializeMenuStats();
        potentialNames = new List<string>() { "Arlo", "Austin", "Autumn", "Brooke", "Clementine", "Clay", "Cliff", "Eugene", "Flint", "Heather", "Hazel", "Jasper", "June", "Palmer", "Ryder", "Scott", "Viola", "Walter", "Xjorph", "Said", "Emmanuel", "Labib", "Jesse", "Bella", "Maurice", "Mike", "Maru", "Elena", "Gary", "Paul", "August" };
        countyRegistry = new Dictionary<string, int>()
        {
        {"Arlo", 892},
        {"Austin", 208},
        {"Autumn", 692},
        {"Brooke", 795},
        {"Clementine", 943},
        {"Clay", 429},
        {"Cliff", 665},
        {"Eugene", 369},
        {"Flint", 191},
        {"Heather", 479},
        {"Hazel", 523},
        {"Jasper", 145},
        {"June", 917},
        {"Palmer", 28},
        {"Ryder", 370},
        {"Scott", 907},
        {"Viola", 742},
        {"Walter", 494},
        {"Xjorph", 767},
        };

        
        //getAudit();
    }

    public void renewStory()
    {
        dialogue = new List<string>()
        {
        "Welcome to the Internal Revenue Service! First day on the job, huh?",
        "No worries, I’ll be here to help. Today you’ll be highlighting tax return discrepancies from our county’s farmers.",
        "I have to warn you however, they’ve just finished this season’s harvest and with today’s economy…",
        "Let’s just say tensions are high right now.",
        "I’ll be giving you folders of tax returns. Open them, ruffle through the documents, and highlight anything outlined in the guidelines!",
        "You’ll get bonuses for accuracy and speed, good luck!",
        "",
        "Now listen partner, I'd really appreciate it if you kept your eyes to yourself.",
        "Look, I don't know if you think I'm some sort of Al Capone or Shakira, but I don't even got hips to lie with!",
        "",
        "YEEEEE HAWWWW! The Lord is on my side!;Oh dog garnit! You went and did it! I'm finished right about now!",
        "Now, if you'll excuse me, I'm bout to go sprinkle some GMOs on my chicken so they taste a little nicer.;Sigh, I really should have majored in computer science :(",
        "",
        "Wasn’t too bad, right?",
        "Oh, by the way, our county keeps adding new rules to our tax guidelines every so often.",
        "Dumb, right? Be sure to check the new guidelines!",
        "",
        "Now, Mr. Government Agent, I understand yous got a job to do.",
        "But I've paid my fair share. Every one of those horses out back has spent more than 51% of the time on business.",
        "Except Lassie, she's special.",
        "",
        "Ah, well Mr. Tax Man, I'm quite pleased that we can come to such an amicible agreement!;Dag nabbit! I understand, perhaps I should have spread those deductions over more calendar years.",
        "I wish you well in the future. But I also hope that future does not include me.;Oh it's not that... Well fuck you garden snake-",
        "",
        "There have been reports of large amounts of identity fraud in our area, so they’re making us include a registry of our jurisdiction’s farmers.",
        "There are imposters among us, so look out!",
        "",
        "Heyo friendo! Don't mind me, just a little guy!",
        "A little funny guy doin some farmin', causin' no harmin' y'know?",
        "Just living life like a snug bug in a rug!",
        "",
        "My family will rejoice knowing they wont have to starve tonight, thank you person of unspecified gender!;You bastard, how am I supposed to support my family now? Ya know how much it took to get the royalties to the name \"Ant Farm\"?",
        "",
        "With the economic downturn, more and more farmers are applying for government subsidies.",
        "Unfortunately, the treasury has gotten pretty dry, so it’s important to make sure the applications are legitimate.",
        "Hope this isn’t too much on your plate!",
        "",
        "Look man, I'm just an alien.",
        "Like come on, isn't the fact that I'm proof of life beyond earth more interesting than my bank account?",
        "",
        "Oh, I passed??? Heh, see I told you nothing suspicious was going on here!;The stars shall now weep in your passing. No true humility...as you face armageddon.",
        "I'm just an ordinary farmer with his porcine pal, come on Lewis!;Pray to your silent gods that watch your demise with apathetic pity...",
        "",
        "*Monkey noises*",
        "",
        "*Happy monkey noises*;*Sad monkey noises*",
        "",
        "Uh oh, our automated performance check software has detected low quality work from you.|There were a couple of mistakes here and there...|Wow!",
        "It also claims that you’re intentionally messing up tax audits. You will now be fired…|...but congrats on surviving your first day of work!|I’ve never seen anyone as good as you at tax auditing!",
        "...in the head with a bullet by a firing squad.|Hopefully the farmers didn’t cause too much trouble for you.|Because of your efforts, our county has seized almost a third of the land owned by our local farmers!",
        "As it turns out, sabotaging the IRS is considered treason of the highest order. Sorry!|See you tomorrow!|Excellent work, see you tomorrow!",
        "",
        "",
        "",
        "",
        "",
        };
    }

    public void startGame(bool isStoryMode)
    {
        StartCoroutine(startGameCo(isStoryMode));
    }

    [SerializeField] GameObject dialogueStuff;
    [SerializeField] RectTransform everything;
    [SerializeField] RawImage storyPaper;
    [SerializeField] RawImage endlessPaper;
    [SerializeField] RawImage barBottomImage;
    [SerializeField] RectTransform auditButton;
    [SerializeField] RectTransform pinkSlip;
    [SerializeField] BackToMain pinkSlipButton;
    [SerializeField] BackToMain paySlipButton;

    [SerializeField] AudioClip mainMenuSong;
    [SerializeField] AudioClip calmSong;
    [SerializeField] AudioClip gameSong;

    [SerializeField] TextMeshProUGUI paySlipCoinsText;
    IEnumerator startGameCo(bool isStoryMode)
    {
        guidelines.text = "1) Highlight yields in Doc A if crop is <u>not</u> in Doc B.1";
        DOB.gameObject.SetActive(false);
        expiry.gameObject.SetActive(false);
        countyRegistryPage.SetActive(false);
        existsInRegistry.gameObject.SetActive(false);
        subsidiesPage.SetActive(false);
        level = 0;
        points = 0;

        storyMode = isStoryMode;
        dialoguePhase = 0;
        dialogueNum = 0;
        onDialogue = false;

        music.Stop();
        music.clip = calmSong;
        music.time = 0;
        music.Play();

        pinkSlip.localPosition = new Vector2(0, 824);
        pinkSlipButton.isSelected = false;
        pinkSlipButton.gameObject.GetComponent<RawImage>().color = new Color(.92f, .92f, .92f, 1f);

        payslip.localPosition = new Vector2(0, 824);
        paySlipButton.isSelected = false;
        paySlipButton.gameObject.GetComponent<RawImage>().color = new Color(.92f, .92f, .92f, 1f);

        foreach(RawImage i in paySlipStars)
        {
            i.color = new Color(.75f, .75f, .75f);
        }

        storyMode = isStoryMode;
        AlphaFader a = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/AlphaFader")).GetComponent<AlphaFader>();
        if (isStoryMode)
        {
            hasFailedFarmer = false;
            if (aHandler != null) { aHandler.unlockAchievement(0); }
            renewStory();
            a.set(storyPaper, 0, 2f);

            AlphaFader ar2 = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/AlphaFader")).GetComponent<AlphaFader>();
            ar2.set(storyPaper.GetComponentInChildren<TextMeshProUGUI>(), 0, 2f);
            foreach (RawImage r in storyPaper.GetComponentsInChildren<RawImage>())
            {
                AlphaFader ar = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/AlphaFader")).GetComponent<AlphaFader>();
                ar.set(r, 0, 2f);
            }
            pointTotalText.gameObject.SetActive(false);
            barBottomImage.texture = Resources.Load<Texture>("Sprites/barImage");
            pinkSlip.gameObject.SetActive(true);

            barFill.fillAmount = .1f;

            foreach (RawImage s in stars)
            {
                s.color = Color.black;
            }

            for (int i = 0; i < starsNumbers.Count; i++)
            {
                starsNumbers[i].color = Color.white;
                starsNumbers[i].texture = Resources.Load<Texture>("Sprites/starNum" + (i + 1).ToString());
            }
        }
        else
        {
            music.Stop();
            music.clip = gameSong;
            music.time = Random.Range(0f, music.clip.length);
            music.Play();

            a.set(endlessPaper, 0, 2f);

            AlphaFader ar2 = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/AlphaFader")).GetComponent<AlphaFader>();
            ar2.set(endlessPaper.GetComponentInChildren<TextMeshProUGUI>(), 0, 2f);
            foreach (RawImage r in endlessPaper.GetComponentsInChildren<RawImage>())
            {
                AlphaFader ar = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/AlphaFader")).GetComponent<AlphaFader>();
                ar.set(r, 0, 2f);
            }

            barFill.fillAmount = 1;

            foreach(RawImage s in stars)
            {
                s.color = Color.yellow;
            }

            for(int i = 0; i < starsNumbers.Count; i++)
            {
                starsNumbers[i].texture = Resources.Load<Texture>("Sprites/starNum" + (i + 1).ToString() + "endless");
                starsNumbers[i].color = Color.black;
            }

            pointTotalText.gameObject.SetActive(true);
            barBottomImage.texture = Resources.Load<Texture>("Sprites/barImage2");
            pinkSlip.gameObject.SetActive(true);
        }
        storyPaper.gameObject.GetComponent<Draggable>().enabled = false;
        endlessPaper.gameObject.GetComponent<Draggable>().enabled = false;
        yield return new WaitForSeconds(1);
        Mover m = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Mover")).GetComponent<Mover>();
        m.set(everything, new Vector2(0, -900), 1f);
        yield return new WaitForSeconds(1);

        if (storyMode)
        {
            dialogueStuff.SetActive(true);
            beginDialoguePhase();
            Debug.Log("something else");
        }
        else
        {
            Debug.Log("something");
            health = 60;
            damageRate = .92f;
            getAudit();
            endlessStarted = true;
        }
    }


    int dialoguePhase = 0;
    int dialogueNum = 0;
    bool onDialogue = false;


    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] TextMeshProUGUI dialogueNameText;
    List<string> dialogue;

    public void beginDialoguePhase()
    {
        string[] dialogueChoices;
        onDialogue = true;
        switch (dialoguePhase)
        {
            case 0:
                dialogueNameText.text = "Boss Woman";
                playDialogueClip(dialogueNum.ToString());
                dialogueText.text = dialogue[0];
                dialogue.RemoveAt(0);
                showDialogueScreen();
                creature.texture = Resources.Load<Texture>("Sprites/Characters/bosswoman");
                playDialogueClip(dialogueNum.ToString());
                break;
            case 1:
                dialogueNum++;
                playDialogueClip(dialogueNum.ToString());
                nameString = potentialNames[Random.Range(0, potentialNames.Count)];
                name.text = "Name: " + nameString;
                dialogueNameText.text = nameString;
                dialogueText.text = dialogue[0];
                dialogue.RemoveAt(0);
                break;
            case 2:
                dialogueNum++;
                dialogueChoices = dialogue[0].Split(';');

                if (hasSelected())
                {
                    dialogueText.text = dialogueChoices[1];
                    hasFailedFarmer = true;
                }
                else
                {
                    dialogueText.text = dialogueChoices[0];
                }

                dialogue.RemoveAt(0);
                showDialogueScreen();
                creature.texture = Resources.Load<Texture>("Sprites/Characters/stickman_portrait");
                playDialogueClip(dialogueNum.ToString() + "_" + (!hasSelected() ? "pass" : "fail"));
                break;
            case 3:
                dialogueNameText.text = "Boss Woman";
                dialogueNum++;
                playDialogueClip(dialogueNum.ToString());
                dialogueText.text = dialogue[0];
                dialogue.RemoveAt(0);
                break;
            case 4:
                nameString = potentialNames[Random.Range(0, potentialNames.Count)];
                name.text = "Name: " + nameString;
                dialogueNameText.text = nameString;
                dialogueNum++;
                playDialogueClip(dialogueNum.ToString());
                dialogueText.text = dialogue[0];
                dialogue.RemoveAt(0);
                break;
            case 5:
                dialogueNum++;
                dialogueChoices = dialogue[0].Split(';');

                if (hasSelected())
                {
                    hasFailedFarmer = true;
                    dialogueText.text = dialogueChoices[1];
                }
                else
                {
                    dialogueText.text = dialogueChoices[0];
                }

                dialogue.RemoveAt(0);
                showDialogueScreen();
                creature.texture = Resources.Load<Texture>("Sprites/Characters/buff_portrait");
                playDialogueClip(dialogueNum.ToString() + "_" + (!hasSelected() ? "pass" : "fail"));
                break;
            case 6:
                dialogueNameText.text = "Boss Woman";
                dialogueNum++;
                playDialogueClip(dialogueNum.ToString());
                dialogueText.text = dialogue[0];
                dialogue.RemoveAt(0);
                break;
            case 7:
                nameString = potentialNames[Random.Range(0, potentialNames.Count)];
                name.text = "Name: " + nameString;
                dialogueNameText.text = nameString;
                dialogueNum++;
                playDialogueClip(dialogueNum.ToString());
                dialogueText.text = dialogue[0];
                dialogue.RemoveAt(0);
                break;
            case 8:
                dialogueNum++;
                dialogueChoices = dialogue[0].Split(';');

                if (hasSelected())
                {
                    hasFailedFarmer = true;
                    dialogueText.text = dialogueChoices[1];
                }
                else
                {
                    dialogueText.text = dialogueChoices[0];
                }

                dialogue.RemoveAt(0);
                showDialogueScreen();
                creature.texture = Resources.Load<Texture>("Sprites/Characters/bug_portrait");
                playDialogueClip(dialogueNum.ToString() + "_" + (!hasSelected() ? "pass" : "fail"));
                break;
            case 9:
                dialogueNameText.text = "Boss Woman";
                dialogueNum++;
                playDialogueClip(dialogueNum.ToString());
                dialogueText.text = dialogue[0];
                dialogue.RemoveAt(0);
                break;
            case 10:
                nameString = potentialNames[Random.Range(0, potentialNames.Count)];
                name.text = "Name: " + nameString;
                dialogueNameText.text = nameString;
                dialogueNum++;
                playDialogueClip(dialogueNum.ToString());
                dialogueText.text = dialogue[0];
                dialogue.RemoveAt(0);
                break;
            case 11:
                dialogueNum++;
                dialogueChoices = dialogue[0].Split(';');

                if (hasSelected())
                {
                    hasFailedFarmer = true;
                    dialogueText.text = dialogueChoices[1];
                }
                else
                {
                    dialogueText.text = dialogueChoices[0];
                }

                dialogue.RemoveAt(0);
                showDialogueScreen();
                creature.texture = Resources.Load<Texture>("Sprites/Characters/alien_portrait");
                playDialogueClip(dialogueNum.ToString() + "_" + (!hasSelected() ? "pass" : "fail"));
                break;
            case 12:
                nameString = potentialNames[Random.Range(0, potentialNames.Count)];
                name.text = "Name: " + nameString;
                dialogueNameText.text = nameString;
                dialogueNum++;
                playDialogueClip(dialogueNum.ToString());
                dialogueText.text = dialogue[0];
                dialogue.RemoveAt(0);
                break;
            case 13:
                dialogueNum++;
                dialogueChoices = dialogue[0].Split(';');

                if (hasSelected())
                {
                    hasFailedFarmer = true;
                    dialogueText.text = dialogueChoices[1];
                }
                else
                {
                    dialogueText.text = dialogueChoices[0];
                }

                dialogue.RemoveAt(0);
                showDialogueScreen();
                creature.texture = Resources.Load<Texture>("Sprites/Characters/monkey_portrait");
                playDialogueClip(dialogueNum.ToString() + "_" + (!hasSelected() ? "pass" : "fail"));
                break;
            case 14:
                dialogueNameText.text = "Boss Woman";
                dialogueNum++;

                dialogueChoices = dialogue[0].Split('|');
                string addOn = "";

                if (points < 8)
                {
                    dialogueText.text = dialogueChoices[0];
                    addOn = "_bad";
                }
                else if(points < 24)
                {
                    dialogueText.text = dialogueChoices[1];
                    addOn = "_good";
                }
                else
                {
                    dialogueText.text = dialogueChoices[2];
                    addOn = "_perfect";
                }

                playDialogueClip(dialogueNum.ToString() + addOn);
                dialogue.RemoveAt(0);
                break;
        }
    }

    public void playDialogueClip(string s)
    {
        dialogueAudio.Stop();
        dialogueAudio.clip = Resources.Load<AudioClip>("Sounds/Dialogue/" + s);
        dialogueAudio.time = 0;
        dialogueAudio.Play();
    }

    public bool hasSelected()
    {
        foreach (TaxDetail t in cropYields)
        {
            if (t.isActiveAndEnabled)
            {
                if (t.isSelected)
                {
                    return true;
                }
            }
        }

        if (DOB.isSelected && DOB.isActiveAndEnabled)
        {
            return true;
        }

        if (expiry.isSelected && expiry.isActiveAndEnabled)
        {
            return true;
        }

        if (existsInRegistry.isSelected && existsInRegistry.isActiveAndEnabled)
        {
            return true;
        }

        foreach (TaxDetail t in subsidies)
        {
            if (t.isActiveAndEnabled)
            {
                if (t.isSelected)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public void nextDialogue()
    {
        if(dialogue[0] == "")
        {
            Debug.Log("nothing!!!!!");
            dialogue.RemoveAt(0);
            endDialoguePhase();
            return;
        }
        dialogueNum++;

        if (dialogue[0].Contains(';'))
        {
            string[] dialogueChoices = dialogue[0].Split(';');

            if (hasSelected())
            {
                dialogueText.text = dialogueChoices[1];
            }
            else
            {
                dialogueText.text = dialogueChoices[0];
            }

            playDialogueClip(dialogueNum.ToString() + "_" + (!hasSelected() ? "pass" : "fail"));
        }
        else if (dialogue[0].Contains('|'))
        {
            string[] dialogueChoices = dialogue[0].Split('|');
            string addOn = "";

            if (points < 8)
            {
                dialogueText.text = dialogueChoices[0];
                addOn = "_bad";
            }
            else if (points < 24)
            {
                dialogueText.text = dialogueChoices[1];
                addOn = "_good";
            }
            else
            {
                dialogueText.text = dialogueChoices[2];
                addOn = "_perfect";
            }

            playDialogueClip(dialogueNum.ToString() + addOn);
        }
        else
        {
            playDialogueClip(dialogueNum.ToString());
            dialogueText.text = dialogue[0];
        }

        dialogue.RemoveAt(0);
    }

    public void endDialoguePhase()
    {
        dialoguePhase++;
        Debug.Log(dialoguePhase - 1);
        switch (dialoguePhase - 1) //cases are which dialogue phase just ended
        {
            case 0:
                StartCoroutine(changeCharacterPortrait("Sprites/Characters/stickman_portrait"));
                beginDialoguePhase();
                break;
            case 1:
                onDialogue = false;
                leaveDialogueScreen();
                music.Stop();
                music.clip = gameSong;
                music.time = 0;
                music.Play();
                pictureOnID.texture = Resources.Load<Texture>("Sprites/Photos/photo0");
                getAudit();
                playDialogueClip("background_stick");
                break;
            case 2:
                StartCoroutine(changeCharacterPortrait("Sprites/Characters/bosswoman"));
                beginDialoguePhase();
                break;
            case 3:
                StartCoroutine(changeCharacterPortrait("Sprites/Characters/buff_portrait"));
                beginDialoguePhase();
                break;
            case 4:
                onDialogue = false;
                leaveDialogueScreen();
                music.Stop();
                music.clip = gameSong;
                music.time = Random.Range(0f, music.clip.length);
                music.Play();
                pictureOnID.texture = Resources.Load<Texture>("Sprites/Photos/photo1");
                getAudit();
                playDialogueClip("background_buff");
                break;
            case 5:
                StartCoroutine(changeCharacterPortrait("Sprites/Characters/bosswoman"));
                beginDialoguePhase();
                break;
            case 6:
                StartCoroutine(changeCharacterPortrait("Sprites/Characters/bug_portrait"));
                beginDialoguePhase();
                break;
            case 7:
                onDialogue = false;
                leaveDialogueScreen();
                music.Stop();
                music.clip = gameSong;
                music.time = Random.Range(0f, music.clip.length);
                music.Play();
                pictureOnID.texture = Resources.Load<Texture>("Sprites/Photos/photo2");
                getAudit();
                playDialogueClip("background_bug");
                break;
            case 8:
                StartCoroutine(changeCharacterPortrait("Sprites/Characters/bosswoman"));
                beginDialoguePhase();
                break;
            case 9:
                StartCoroutine(changeCharacterPortrait("Sprites/Characters/alien_portrait"));
                beginDialoguePhase();
                break;
            case 10:
                onDialogue = false;
                leaveDialogueScreen();
                music.Stop();
                music.clip = gameSong;
                music.time = Random.Range(0f, music.clip.length);
                music.Play();
                pictureOnID.texture = Resources.Load<Texture>("Sprites/Photos/photo3");
                getAudit();
                playDialogueClip("background_alien");
                break;
            case 11:
                StartCoroutine(changeCharacterPortrait("Sprites/Characters/monkey_portrait"));
                beginDialoguePhase();
                break;
            case 12:
                onDialogue = false;
                leaveDialogueScreen();
                music.Stop();
                music.clip = gameSong;
                music.time = Random.Range(0f, music.clip.length);
                music.Play();
                pictureOnID.texture = Resources.Load<Texture>("Sprites/Photos/photo4");
                getAudit();
                playDialogueClip("background_monkey");
                break;
            case 13: //Ending
                StartCoroutine(changeCharacterPortrait("Sprites/Characters/bosswoman"));
                beginDialoguePhase();
                break;
            case 14:
                onDialogue = false;
                StartCoroutine(ending());
                break;
            default:
                return;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(storyMode && onDialogue && Input.GetKeyDown(KeyCode.Mouse0) && !isMoving)
        {
            nextDialogue();
        }

        if(!storyMode && health > 0 && endlessStarted)
        {
            float oldHealth = health;
            health -= Time.deltaTime * damageRate;
            updateBarEndless(oldHealth);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Screen.fullScreen = !Screen.fullScreen;
        }
    }

    [SerializeField] RectTransform payslip;
    [SerializeField] List<RawImage> paySlipStars;

    IEnumerator ending()
    {
        leaveDialogueScreen();
        yield return new WaitForSeconds(.5f);

        if (!hasFailedFarmer)
        {
            if (aHandler != null) { aHandler.unlockAchievement(4); }
        }


        if (points < 8)
        {
            Mover m1 = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Mover")).GetComponent<Mover>();
            m1.set(pinkSlip, new Vector2(0, 0), 1f);

            if (aHandler != null) { aHandler.unlockAchievement(3); }
        }
        else
        {
            if (aHandler != null) { aHandler.unlockAchievement(1); }

            Mover m2 = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Mover")).GetComponent<Mover>();
            m2.set(payslip, new Vector2(0, 0), 1f);

            if(points >= 8)
            {
                paySlipStars[0].color = Color.yellow;
            }

            if (points >= 16)
            {
                paySlipStars[1].color = Color.yellow;
            }

            if (points >= 24)
            {
                paySlipStars[2].color = Color.yellow;
                if (aHandler != null) { aHandler.unlockAchievement(2); }
            }

            PlayerPrefs.SetInt("starsInStory", Mathf.Max(PlayerPrefs.GetInt("starsInStory", 0), points / 8));

            paySlipCoinsText.text = "Coins Earned: " + points.ToString();
        }
        
        soundFx.PlayOneShot(Resources.Load<AudioClip>("Sounds/paper" + Random.Range(0, 3).ToString()));
    }

    public void updateBarEndless(float oldHealth)
    {
        

        if (oldHealth > 60 && health < 60)
        {
            StartCoroutine(unspinStar(2));
        }

        if (oldHealth > 40 && health < 40)
        {
            if(stars[2].color == Color.yellow)
            {
                StartCoroutine(unspinStar(2));
            }

            StartCoroutine(unspinStar(1));
        }

        if (oldHealth > 20 && health < 20)
        {
            if (stars[2].color == Color.yellow)
            {
                StartCoroutine(unspinStar(2));
            }

            if (stars[1].color == Color.yellow)
            {
                StartCoroutine(unspinStar(1));
            }

            StartCoroutine(unspinStar(0));
        }

        if (health > 60 && oldHealth < 60)
        {
            StartCoroutine(spinStar(2));
        }

        if (health > 40 && oldHealth < 40)
        {
            StartCoroutine(spinStar(1));
        }

        if (health > 20 && oldHealth < 20)
        {
            StartCoroutine(spinStar(0));
        }

        health = Mathf.Min(80, health);
        health = Mathf.Max(0, health);

        barFill.fillAmount = (health / 60f) * .9f + .1f;

        if (health <= 0 && endlessStarted)
        {
            endlessStarted = false;
            StartCoroutine(gameOverEndless());
        }
    }

    public IEnumerator gameOverEndless()
    {
        PlayerPrefs.SetInt("coinsInEndless", Mathf.Max(points, PlayerPrefs.GetInt("coinsInEndless", 0)));

        Mover m4 = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Mover")).GetComponent<Mover>();
        m4.set(auditButton, new Vector2(900, -350), .6f);

        if(PlayerPrefs.GetInt("coinsInEndless", 0) >= 30)
        {
            if (aHandler != null) { aHandler.unlockAchievement(5); }
        }

        if (PlayerPrefs.GetInt("coinsInEndless", 0) >= 90)
        {
            if (aHandler != null) { aHandler.unlockAchievement(6); }
        }

        if (PlayerPrefs.GetInt("coinsInEndless", 0) >= 150)
        {
            if (aHandler != null) { aHandler.unlockAchievement(7); }
        }

        if(aHandler != null) { aHandler.submitScore(PlayerPrefs.GetInt("coinsInEndless", 0)); }


        fold.canBeOpened = false;
        if (fold.openFolder.activeInHierarchy)
        {
            soundFx.PlayOneShot(Resources.Load<AudioClip>("Sounds/paper" + Random.Range(0, 3).ToString()));
            foreach (Draggable d in filesContainer.GetComponentsInChildren<Draggable>())
            {
                Mover m = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Mover")).GetComponent<Mover>();
                m.set(d.gameObject.GetComponent<RectTransform>(), new Vector2(0, 0), .6f);
            }
            yield return new WaitForSeconds(.6f);
            fold.closedFolder.SetActive(true);
            soundFx.PlayOneShot(Resources.Load<AudioClip>("Sounds/folder"));
            fold.openFolder.SetActive(false);
        }
        yield return new WaitForSeconds(.5f);
        Mover m2 = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Mover")).GetComponent<Mover>();
        m2.set(filesContainer, new Vector2(0, 900), 1f);
        soundFx.PlayOneShot(Resources.Load<AudioClip>("Sounds/paper" + Random.Range(0, 3).ToString()));
        yield return new WaitForSeconds(1f);
        Mover m3 = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Mover")).GetComponent<Mover>();
        m3.set(pinkSlip, new Vector2(0, 0), 1f);
        soundFx.PlayOneShot(Resources.Load<AudioClip>("Sounds/paper" + Random.Range(0, 3).ToString()));
        

    }

    public void getAudit()
    {
        StartCoroutine(getAuditCo());
    }

    IEnumerator getAuditCo()
    {
        resetAudit();
        folderMoving = true;
        soundFx.PlayOneShot(Resources.Load<AudioClip>("Sounds/paper" + Random.Range(0, 3).ToString()));
        Mover m = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Mover")).GetComponent<Mover>();
        m.set(filesContainer, new Vector2(0, 0), .6f);
        yield return new WaitForSeconds(.6f);
        folderMoving = false;
        fold.canBeOpened = true;
    }


    public void confirmAudit()
    {
        StartCoroutine(confirmAuditCo());
    }

    [SerializeField] AudioSource soundFx;
    [SerializeField] AudioSource dialogueAudio;

    bool folderMoving = false;

    IEnumerator confirmAuditCo()
    {
        folderMoving = true;
        Mover m4 = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Mover")).GetComponent<Mover>();
        m4.set(auditButton, new Vector2(900, -350), .6f);
        fold.canBeOpened = false;
        soundFx.PlayOneShot(Resources.Load<AudioClip>("Sounds/paper" + Random.Range(0, 3).ToString()));
        foreach (Draggable d in filesContainer.GetComponentsInChildren<Draggable>())
        {
            Mover m = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Mover")).GetComponent<Mover>();
            m.set(d.gameObject.GetComponent<RectTransform>(), new Vector2(0, 0), .6f);
        }
        yield return new WaitForSeconds(.6f);
        handlePoints();
        fold.closedFolder.SetActive(true);
        soundFx.PlayOneShot(Resources.Load<AudioClip>("Sounds/folder"));
        fold.openFolder.SetActive(false);
        yield return new WaitForSeconds(.5f);
        Mover m2 = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Mover")).GetComponent<Mover>();
        m2.set(filesContainer, new Vector2(0, 900), .6f);
        soundFx.PlayOneShot(Resources.Load<AudioClip>("Sounds/paper" + Random.Range(0, 3).ToString()));
        yield return new WaitForSeconds(.7f);
        folderMoving = false;

        if (storyMode)
        {
            music.Stop();
            music.clip = calmSong;
            music.time = 0;
            music.Play();

            beginDialoguePhase();
        }
        else
        {
            if (endlessStarted)
            {
                getAudit();
            } 
        }
    }

    public string vegetableToChar(string s)
    {
        switch (s)
        {
            case "Pumpkins":
                return "U";
            case "Peas":
                return "E";
            case "Potatoes":
                return "P";
            case "Beets":
                return "B";
            case "Carrots":
                return "C";
        }
        return "N";
    }

    [SerializeField] Image barFill;
    int totalCrops = 0;
    List<string> alphabet = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K" };


    public void resetAudit()
    {


        fileName.text = "File " + alphabet[Random.Range(0, alphabet.Count)] + "." + level.ToString();
        totalCrops = 0;
        timer = 0;

        foreach (TaxDetail t in filesContainer.GetComponentsInChildren<TaxDetail>())
        {
            t.isSelected = false;
            t.GetComponent<RawImage>().color = new Color(.92f, .92f, .92f, 1f);
        }

        plotText.text = plots[Random.Range(0, plots.Count)].Replace("\\n", "\n");
        List<string> crops = new List<string>() { "Potatoes", "Carrots", "Peas", "Beets", "Pumpkins" };

        int amountOfYield = Random.Range(2, 5);

        for (int i = 0; i < cropYields.Count; i++)
        {
            if (i < amountOfYield)
            {
                cropYields[i].gameObject.SetActive(true);
            }
            else
            {
                cropYields[i].gameObject.SetActive(false);

            }
        }


        foreach (TaxDetail t in cropYields)
        {
            if (t.isActiveAndEnabled)
            {
                int ind = Random.Range(0, crops.Count);
                t.detail1 = crops[ind];
                crops.RemoveAt(ind);
                t.detail2 = Random.Range(50, 500).ToString();
                totalCrops += Convert.ToInt32(t.detail2, format);
                t.GetComponentInChildren<TextMeshProUGUI>().text = t.detail1 + " - " + t.detail2 + " lbs";
            }
        }

        

        int yearDOB = Random.Range(1970, 2024);
        DOB.detail1 = yearDOB.ToString();
        DOB.GetComponentInChildren<TextMeshProUGUI>().text = "DOB: " + Random.Range(1, 13).ToString() + "/" + Random.Range(1, 29).ToString() + "/" + (yearDOB).ToString("D2");

        int yearExp = Random.Range(2013, 2030);
        expiry.detail1 = yearExp.ToString();
        expiry.GetComponentInChildren<TextMeshProUGUI>().text = "EXP: " + Random.Range(1, 13).ToString() + "/" + Random.Range(1, 29).ToString() + "/" + (yearExp).ToString("D2");


        List<string> crops2 = new List<string>() { "Potatoes", "Carrots", "Peas", "Beets", "Pumpkins" };

        int amountOfSub = Random.Range(1, 4);

        for (int i = 0; i < cropYields.Count; i++)
        {
            if (i < amountOfSub)
            {
                subsidies[i].gameObject.SetActive(true);
            }
            else
            {
                subsidies[i].gameObject.SetActive(false);
            }
        }

        foreach (TaxDetail t in subsidies)
        {
            if (t.isActiveAndEnabled)
            {
                int ind = Random.Range(0, crops2.Count);
                t.detail1 = crops2[ind];
                crops2.RemoveAt(ind);
                t.GetComponentInChildren<TextMeshProUGUI>().text = subsidiesNames[t.detail1][Random.Range(0, subsidiesNames[t.detail1].Count)];
            }
        }

        if (!storyMode)
        {
            nameString = potentialNames[Random.Range(0, potentialNames.Count)];
            name.text = "Name: " + nameString;
            dialogueNameText.text = nameString;
            pictureOnID.texture = Resources.Load<Texture>("Sprites/Photos/photo" + Random.Range(0,5).ToString());
        }
    }

    public void randomizePositions()
    {
        Mover m4 = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Mover")).GetComponent<Mover>();
        m4.set(auditButton, new Vector2(680, -350), .6f);

        foreach (Draggable d in filesContainer.GetComponentsInChildren<Draggable>())
        {
            d.transform.localPosition = new Vector2(Random.Range(-250, 250), Random.Range(-50, 50));
        }
    }

    IFormatProvider format = new CultureInfo("en-US");
    [SerializeField] TextMeshProUGUI pointTotalText;

    public void handlePoints()
    {
        int amountTotal = 0;
        int amountWrong = 0;
        int previousPoints = points;
        float oldHealth = health;

        foreach (TaxDetail t in cropYields)
        {
            if (t.isActiveAndEnabled)
            {
                amountTotal++;
                if (t.isSelected && (plotText.text.Contains(vegetableToChar(t.detail1))))
                {
                    amountWrong++;
                }
                else if (!t.isSelected && !(plotText.text.Contains(vegetableToChar(t.detail1))))
                {
                    amountWrong++;
                }
            }
        }

        if (DOB.isActiveAndEnabled)
        {
            amountTotal++;
            if (DOB.isSelected && Convert.ToInt32(DOB.detail1, format) <= 2004)
            {
                Debug.Log("Something wrong 1");
                amountWrong++;
            }
            else if (!DOB.isSelected && Convert.ToInt32(DOB.detail1, format) > 2004)
            {
                Debug.Log("Something wrong 2");
                amountWrong++;
            }
        }

        if (expiry.isActiveAndEnabled)
        {
            amountTotal++;
            if (expiry.isSelected && Convert.ToInt32(expiry.detail1, format) >= 2023)
            {
                Debug.Log("Something wrong 3");
                amountWrong++;
            }
            else if (!expiry.isSelected && Convert.ToInt32(expiry.detail1, format) < 2023)
            {
                Debug.Log("Something wrong 4");
                amountWrong++;
            }
        }

        if (existsInRegistry.isActiveAndEnabled)
        {
            amountTotal++;
            if(existsInRegistry.isSelected && countyRegistry.ContainsKey(name.text))
            {
                Debug.Log("Something wrong 5");
                amountWrong++;
            }
            else if(!existsInRegistry.isSelected && !countyRegistry.ContainsKey(nameString))
            {
                Debug.Log("Something wrong 6");
                Debug.Log(nameString);
                amountWrong++;
            }
        }

        if (subsidiesPage.activeSelf)
        {
            foreach (TaxDetail t in subsidies)
            {
                if (t.isActiveAndEnabled)
                {
                    amountTotal++;


                    if (t.isSelected && (checkIfSubsidyValid(t.detail1)))
                    {
                        Debug.Log("wrong 7 " + t.detail1);
                        amountWrong++;
                    }
                    else if (!t.isSelected && !(checkIfSubsidyValid(t.detail1)))
                    {
                        Debug.Log("wrong 8 " + t.detail1);
                        amountWrong++;
                    }
                }
            }
        }


        float ratio = (amountTotal - amountWrong) / ((float)(amountTotal));
        Debug.Log(amountWrong);

        statusText.text = "";

        if (ratio >= .66f)
        {
            soundFx.PlayOneShot(Resources.Load<AudioClip>("Sounds/correct"));
            points++;
            statusText.text = "Good Enough! (+1)";
        }
        else
        {
            points -= 2;
            soundFx.PlayOneShot(Resources.Load<AudioClip>("Sounds/wrong"));
            statusText.text = "Inaccurate!!! (-2)";
        }

        if(ratio >= .8f)
        {
            points++;
            statusText.text = "Great Eye!! (+2)";
        }

        if (ratio >= .99f)
        {
            points += 2;
            statusText.text = "Perfect Accuracy!!! (+4)";
        }

        if(timer < 30 && ratio >= .66f)
        {
            points++;
            statusText.text += "\nSuper Fast!! (+2)";
        }

        if(timer < 60 && ratio >= .66f)
        {
            soundFx.PlayOneShot(Resources.Load<AudioClip>("Sounds/timerDing"));
            points++;
            if(timer >= 30)
            {
                statusText.text += "\nFast! (+1)";
            }    
        }

        if (!storyMode)
        {
            if ((points - previousPoints) * 4 * ((points - previousPoints) > 0 ? damageRate : 1) < 0)
            {
                Debug.Log("pee");
            }
            health += (points - previousPoints) * 4 * ((points - previousPoints) > 0 ? damageRate : 1);
            updateBarEndless(oldHealth);
        }


        points = Mathf.Max(0, points);

        if (storyMode)
        {
            points = Mathf.Min(30, points);
        }
        else
        {
            pointTotalText.text = "Coins: " + points.ToString();
        }


        damageRate *= 1.03f;

        if (storyMode)
        {
            if (previousPoints > points && points / 8 != previousPoints / 8)
            {
                statusText.text += "\nStar Lost :(";
                starsSpun[points / 8] = false;
                StartCoroutine(unspinStar(points / 8));
            }

            if (points >= 8 && !starsSpun[points / 8 - 1])
            {
                statusText.text += "\nStar Got!!!";
                starsSpun[points / 8 - 1] = true;
                StartCoroutine(spinStar(points / 8 - 1));
            }
        }
        

        StartCoroutine(showStatus());

        level++;
        handleLevel();

        if (storyMode)
        {
            barFill.fillAmount = (points / 24f) * .9f + .1f;
        }
        

    }

    public void backToMenu()
    {
        StartCoroutine(backToMenuCo());
        initializeMenuStats();
    }

    [SerializeField] List<RawImage> mainMenuStars;
    [SerializeField] TextMeshProUGUI mainMenuCoins;

    public void initializeMenuStats()
    {
        foreach(RawImage r in mainMenuStars)
        {
            r.color = new Color(0, 0, 0, .2f);
        }

        if(PlayerPrefs.GetInt("starsInStory", 0) >= 1)
        {
            mainMenuStars[0].color = Color.yellow;
        }

        if (PlayerPrefs.GetInt("starsInStory", 0) >= 2)
        {
            mainMenuStars[1].color = Color.yellow;
        }

        if (PlayerPrefs.GetInt("starsInStory", 0) >= 3)
        {
            mainMenuStars[2].color = Color.yellow;
        }

        mainMenuCoins.text = "Best: " + PlayerPrefs.GetInt("coinsInEndless", 0).ToString();
        mainMenuCoins.color = new Color(0, 0, 0, .2f);
    }

    [SerializeField] RawImage pictureCloseUp;
    [SerializeField] RawImage pictureOnID;

    public void showPicture()
    {
        pictureCloseUp.transform.parent.gameObject.SetActive(true);
        pictureCloseUp.texture = pictureOnID.texture;
        soundFx.PlayOneShot(Resources.Load<AudioClip>("Sounds/folder"), .6f);
    }

    public void leavePicture()
    {
        pictureCloseUp.transform.parent.gameObject.SetActive(false);
        soundFx.PlayOneShot(Resources.Load<AudioClip>("Sounds/folder"), .6f);
    }

    [SerializeField] TextMeshProUGUI fileName;

    IEnumerator backToMenuCo()
    {
        music.Stop();
        music.clip = mainMenuSong;
        music.time = 0;
        music.Play();

        foreach (RawImage r in storyPaper.GetComponentsInChildren<RawImage>())
        {
            r.color = new Color(r.color.r, r.color.g, r.color.b, .2f);
        }

        foreach (RawImage r in endlessPaper.GetComponentsInChildren<RawImage>())
        {
            r.color = new Color(r.color.r, r.color.g, r.color.b, .2f);
        }
        storyPaper.GetComponentInChildren<TextMeshProUGUI>().color = Color.black;
        storyPaper.color = new Color(storyPaper.color.r, storyPaper.color.g, storyPaper.color.b, 1);
        endlessPaper.GetComponentInChildren<TextMeshProUGUI>().color = Color.black;
        endlessPaper.color = new Color(endlessPaper.color.r, endlessPaper.color.g, endlessPaper.color.b, 1);

        storyPaper.gameObject.GetComponent<Draggable>().enabled = true;
        endlessPaper.gameObject.GetComponent<Draggable>().enabled = true;
        storyPaper.rectTransform.localPosition = new Vector2(-480, -60);
        endlessPaper.rectTransform.localPosition = new Vector2(-80, -60);
        Mover m = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Mover")).GetComponent<Mover>();
        m.set(everything, new Vector2(0, 0), 1f);
        yield return new WaitForSeconds(1);
    }

    [SerializeField] TaxDetail DOB;
    [SerializeField] TaxDetail expiry;
    [SerializeField] GameObject countyRegistryPage;
    [SerializeField] GameObject subsidiesPage;
    [SerializeField] TaxDetail existsInRegistry;
    

    [SerializeField] TextMeshProUGUI statusText;
    [SerializeField] List<RawImage> stars;
    [SerializeField] List<RawImage> starsNumbers;
    List<bool> starsSpun = new List<bool> { false, false, false };


    public void handleLevel()
    {
        int newLevel = level;
        if (!storyMode)
        {
            newLevel /= 3;
            if(level % 3 != 0)
            {
                return;
            }
        }

        switch (newLevel)
        {
            case 1:
                DOB.gameObject.SetActive(true);
                expiry.gameObject.SetActive(true);
                guidelines.text += "\n\n2) Highlight DOB in Doc C if born <u>after</u> 2004\n\n3) Highlight EXP in Doc C if <u>before</u> 2023";
                break;
            case 2:
                countyRegistryPage.SetActive(true);
                existsInRegistry.gameObject.SetActive(true);
                break;
            case 3:
                subsidiesPage.SetActive(true);
                guidelines.text += "\n\n\n\n5) Subsidies given if harvested <u>>= 150lbs</u> for a crop on Doc A. Highlight <u>ineligible</u> subsidies on Doc E";
                guidelines.text += "\n\n6) If the crop does <u>not</u> appear on Doc B.1, mark subsidy ineligible on Doc E";
                break;
        }
    }

    public bool checkIfSubsidyValid(string crop)
    {
        foreach (TaxDetail t in cropYields)
        {
            if (t.isActiveAndEnabled && t.detail1 == crop && plotText.text.Contains(vegetableToChar(t.detail1)))
            {
                if(Convert.ToInt32(t.detail2, format) >= 150)
                {
                    return true;
                }
            }
        }


        return false;
    }

    IEnumerator showStatus()
    {
        foreach(AlphaFader i in FindObjectsOfType<AlphaFader>())
        {
            i.restart();
        }
        Debug.Log("status text");
        statusText.rectTransform.localPosition = new Vector2(0, 500);
        statusText.color = new Color(statusText.color.r, statusText.color.g, statusText.color.b, 1);
        Mover m = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Mover")).GetComponent<Mover>();
        m.set(statusText.rectTransform, new Vector2(0, 300), 1.5f);
        yield return new WaitForSeconds(1f);
        AlphaFader a = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/AlphaFader")).GetComponent<AlphaFader>();
        a.set(statusText, 0, 4f);
        yield return new WaitForSeconds(2f);
    }
    
    IEnumerator spinStar(int i)
    {
        Rotator r = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Rotator")).GetComponent<Rotator>();
        r.set(stars[i].rectTransform, 360, 2f);
        ColorFader c = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/ColorFader")).GetComponent<ColorFader>();
        c.set(stars[i], Color.yellow, 2f);
        ColorFader c2 = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/ColorFader")).GetComponent<ColorFader>();
        c2.set(starsNumbers[i], Color.black, 2f);
        yield return new WaitForSeconds(2f);
    }

    IEnumerator unspinStar(int i)
    {
        Rotator r = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Rotator")).GetComponent<Rotator>();
        r.set(stars[i].rectTransform, -360, 2f);
        ColorFader c = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/ColorFader")).GetComponent<ColorFader>();
        c.set(stars[i], Color.black, 2f);
        ColorFader c2 = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/ColorFader")).GetComponent<ColorFader>();
        c2.set(starsNumbers[i], Color.white, 2f);
        yield return new WaitForSeconds(2f);
    }

    bool isMoving = false;
    [SerializeField] RawImage dimmer;
    [SerializeField] RectTransform dialogueBoxes;
    [SerializeField] RawImage creature;

    

    public void showDialogueScreen()
    {
        isMoving = true;
        StartCoroutine(showDialogueCo());
    }

    public void leaveDialogueScreen()
    {
        isMoving = true;
        StartCoroutine(leaveDialogueCo());
    }

    IEnumerator showDialogueCo()
    {
        dimmer.gameObject.SetActive(true);
        ColorFader cf = Instantiate(Resources.Load<GameObject>("Prefabs/ColorFader")).GetComponent<ColorFader>();
        cf.set(dimmer, new Color(0, 0, 0, .5f), .4f);
        Mover m = Instantiate(Resources.Load<GameObject>("Prefabs/Mover")).GetComponent<Mover>();
        m.set(dialogueBoxes, new Vector2(0, -187f), .4f);
        Mover m2 = Instantiate(Resources.Load<GameObject>("Prefabs/Mover")).GetComponent<Mover>();
        m2.set(creature.rectTransform, new Vector2(400f, -60f), .4f);
        yield return new WaitForSeconds(.4f);
        isMoving = false;
    }

    IEnumerator leaveDialogueCo()
    {
        ColorFader cf = Instantiate(Resources.Load<GameObject>("Prefabs/ColorFader")).GetComponent<ColorFader>();
        cf.set(dimmer, new Color(0, 0, 0, 0f), .4f);
        Mover m = Instantiate(Resources.Load<GameObject>("Prefabs/Mover")).GetComponent<Mover>();
        m.set(dialogueBoxes, new Vector2(0, -500f), .4f);
        Mover m2 = Instantiate(Resources.Load<GameObject>("Prefabs/Mover")).GetComponent<Mover>();
        m2.set(creature.rectTransform, new Vector2(1200f, -60f), .4f);
        yield return new WaitForSeconds(.4f);
        dimmer.gameObject.SetActive(false);
        isMoving = false;
    }

    IEnumerator changeCharacterPortrait(string filePath)
    {
        isMoving = true;
        Mover m2 = Instantiate(Resources.Load<GameObject>("Prefabs/Mover")).GetComponent<Mover>();
        m2.set(creature.rectTransform, new Vector2(1200f, -60f), .4f);
        yield return new WaitForSeconds(.4f);
        creature.texture = Resources.Load<Texture>(filePath);
        Mover m3 = Instantiate(Resources.Load<GameObject>("Prefabs/Mover")).GetComponent<Mover>();
        m3.set(creature.rectTransform, new Vector2(400f, -60f), .4f);
        yield return new WaitForSeconds(.4f);
        isMoving = false;
    }



}

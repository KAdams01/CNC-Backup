using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Logs : MonoBehaviour
{
    // Quest List
	public List<Log> LogsList;

    // Text Fields
    public GameObject questField1;
    public GameObject questField2;
    public GameObject questField3;
    public GameObject questField4;
    public GameObject questField5;
    public GameObject extendedDescription;

    // Textures
    public GameObject eDImage;
    public Texture arrowKeys;
    public Texture axisKeys;
    public Texture defaultPosition;
    public Texture handJog;
    public Texture handleJog;
    public Texture keypad;
    public Texture numberKeys;
    public Texture partZeroSet;
    public Texture powerOn;
    public Texture speedKeys;
    public Texture tool;
    public Texture toolArrow;

    public bool isTipBroken;

    // Quest Number Counter
    private int questNumber;
    private bool questComplete;
    private int lastQuest;

    public AudioSource source;
    public AudioClip completed;

    // Language
    public string lang;

    private bool areHighlightersOn;

    private HighlightCreator highlightCreator;

    void Awake () {
        isTipBroken = false;
		LogsList = new List<Log>();
        

        LogsList.Add(
            new Log(
                new LogContent("", ""),
                new LogContent("", ""),
                0
            )
        );

        LogsList.Add(
            new Log(
                new LogContent("", ""),
                new LogContent("", ""),
                1
            )
        );

        // Log 0 - Quest 1
        LogsList.Add(
			new Log(
				new LogContent("Press the green [POWER ON] button to turn the machine on.", "The button can be found in the top left of the control panel."),
				new LogContent("Tryk på den grønne [POWER ON] knap for at starte maskinen.", "Knappen kan findes i det øverste venstre hjørne af kontrolpanelet."),
                2
			)
		);
		
		// Log 1 - Quest 2
		LogsList.Add(
			new Log(
				new LogContent("Test the [EMERGENCY STOP] button by pressing it in and pulling out.", "The emergency button is tested in the beginning to make sure machine can be stopped, if something goes wrong."),
				new LogContent("Test, at [NØDSTOP] knappen virker ved at trykke den ind og trække den ud igen.", "Man tester at nødstop knappen virker, inden maskinen startes, for at sikre at man kan stoppe maskinen, hvis noget går galt."),
                3
			)
		);
		
		// Log 2 - Quest 3
		LogsList.Add(
			new Log(
				new LogContent("Test the door sensors by opening and closing the doors.", "The sensors on the doors are also tested to make sure that if they are open while the machine is working, the machine stops to prevent injury."),
				new LogContent("Test at dør sensorene virker ved at åbne og lukke dørene.", "Man tester også at sensorene på dørene virker, så hvis dørene åbnes mens maskinen kører, stopper maskinen for at undgå personskade."),
                4
			)
		);
		
		// Log 3 - Quest 4
		LogsList.Add(
			new Log(
				new LogContent("Press the [POWER UP] button and let the machine return to its reference point.", "Before the machine can used, the workbench needs to return to its reference point. This means returning to the point where everything is at zero. On the TM-1 this is all the way to the left, all the way towards the doors and all the way up."),
				new LogContent("Tryk på [POWER UP] og lad maskinen køre til dens referencepunkt.", "Inden man kan bruge maskinen, skal slæden kører til referencepunkt. Det vil sige, at de kører tilbage til et punkt, hvor den ved at alting står i deres nulpunkter. På TM-1 er referencepunktet helt til venstre, helt frem mod dørene og helt op."),
                5
			)
		);
		
		// Log 4 - Quest 5
		LogsList.Add(
			new Log(
				new LogContent("Press the [HANDLE JOG] button to open the manual control menu on the control panel.", "The button can be found among the arrow-shaped buttons on the right side of the control panel."),
				new LogContent("Tryk på [HANDLE JOG] for at åbne menuen for manuel kontrol på kontrolpanelet.", "Knappen kan findes blandt de spidse knapper på den højre del af kontrolpanelet."),
                6
			)
		);
		
		// Log 5 - Quest 6
		LogsList.Add(
			new Log(
				new LogContent("Open the doors to the machine.", ""),
				new LogContent("Åbn dørene til maskinen.", ""),
                7
			)
		);
		
		// Log 6 - Quest 7
		LogsList.Add(
			new Log(
				new LogContent("Find the measuring tool on the tool table and wipe off the tip of the tool with a cloth.", "It is very important that the tip (the top part of the tool that is inserted into the machine) is clean before inserting to avoid damaging both the machine and tool."),
				new LogContent("Find måleværktøjet på væktøjsbordet og tør konus af med en klud.", "Konusen er den øverste del, som går ind i maskinen. Det er vigtigt at den er helt ren, inden den bliver sat fast i maskinen, for at undgå at ødelægge både maskine og konus."),
                8
			)
		);
		
		// Log 7 - Quest 8
		LogsList.Add(
			new Log(
				new LogContent("Press and hold the black button with one hand while inserting the tool into the clamp with the other.", "When the button is held down, the claw expands, allowing to insert the tool. It is important the tool is placed correctly. The holes on the side of the tool should sit in the claws on the machine or else the tool won't be properly attached and the machine won't work properly and might get damaged."),
				new LogContent("Tryk og hold den sorte knap inde, med den ene hånd, mens du sætter værktøjet på plads med den anden.", "Når man holder knappen inde, udvider de to kløer sig, så man kan sætte værktøjet i. Det er vigtigt at væktøjet sidder rigtigt, så kløerne i maskinen (feder) sidder i hullerne på værktøjet (not). Ellers sidder værktøjet ikke rigtig fast og maskinen kan ikke bruges."),
                9
			)
		);
		
		// Log 8 - Quest 9
		LogsList.Add(
			new Log(
				new LogContent("Press [ARROW UP] until the cursor is in the menu selection field.", "The arrow keys can be found in the middle of the control panel. The menu field is at the top of the display."),
				new LogContent("Tryk på [PIL OP] indtil curseren står oppe i menu feltet.", "Piletasterne kan findes i midten af kontrolpanelet. Menuen feltet er øverst på displayet."),
                10
			)
		);
		
		// Log 9 - Quest 10
		LogsList.Add(
			new Log(
				new LogContent("Press [ARROW RIGHT] to change from the Tool menu to the Work menu.", ""),
				new LogContent("Tryk på [PIL TIL HØJRE] for at skifte fra Tool menuen til Work menuen.", ""),
                11
			)
		);
		
		// Log 10 - Quest 11
		LogsList.Add(
			new Log(
				new LogContent("Press [ARROW DOWN] until the cursor is in G54 field.", "The field G54 is the most used field for single zero point targets. If more zero points are required, the fields G56, G58 etc. are used as well."),
				new LogContent("Tryk på [PIL NED] indtil curseren står i feltet G54.", "G54 er feltet der oftest bruges til emner med kun et nulpunkt. Hvis flere nulpunkter skal bruges, bruges G56, G58 osv. også."),
                12
			)
		);
		
		// Log 11 - Quest 12
		LogsList.Add(
			new Log(
				new LogContent("Press one of the axis buttons to choose which direction the tool should move.", "The axis buttons can be found on the left side of the control panel."),
				new LogContent("Tryk på en af akse knapperne for at vælge hvilken retning væktøjet skal køre.", "Akse knapperne kan findes på den venstre del af kontrolpanelet."),
                13
			)
		);
		
		// Log 12 - Quest 13
		LogsList.Add(
			new Log(
				new LogContent("Press one of the speed keys to choose how fast the tool should move.", "The speed buttons can be found to the right of the [HANDLE JOG] button."),
				new LogContent("Tryk på en af hastigheds knapperne for at vælge hvor hurtigt væktøjet skal køre.", "Hastigheds knapperne kan findes til højre for [HANDLE JOG] knappen."),
                14
			)
		);
		
		// Log 13 - Quest 14
		LogsList.Add(
			new Log(
				new LogContent("Rotate the [HAND JOG] wheel with the axis and the speed chosen to move the tool to the target.", "After choosing the axis and the speed, Hand Jog wheel can be turned to move the machine head or the workbench in the chosen axis. The fastest speed setting might be disabled on the real machine, due to the fact that if it's moved too fast, it doesn't stop immediately. Pay attention while operating the machine because it assumes only the tool is moving. Meaning the positive and negative directions are swapped while moving the workbench."),
				new LogContent("Brug en kombination af det store [HAND JOG] hjul, akse- og hastigheds- knapperne, til at flytte væktøjet hen til emnet.", "Når man har valgt en akse og en hastighed, kan man dreje på Hand Jog hjulet for at flytte slæden og maskinhovedet i den akse du har valgt. Den hurtigste indstilling kan være deaktivetet, fordi den har et for stort efterløb. Vær opmærksom på, at maskinen antager, at det er værktøjet der bevæger sig, så når man flytter slæden, kører den den modsatte vej, af hvad man ville tro."),
                15
			)
		);
		
		// Log 14 - Quest 15
		LogsList.Add(
			new Log(
				new LogContent("When you get closer to the target, reduce the speed and make the tip of the tool touch one of the surfaces of the target.", "It's important to use the speed keys to change speeds while moving the tool to get more control over the movement of the tool, because the tip of the tool can easily break."),
				new LogContent("Når du kommer tæt på emnet, skal du sænke farten og få spidsen af væktøjet til at røre en af emnets overflader.", "Det er vigtigt at bruge hastigheds knapperne til at styre hvor hurtigt værktøjet bevæger sig, da spidsen på måleværktøjet kan knække."),
                16
			)
		);
		
		// Log 15 - Quest 16
		LogsList.Add(
			new Log(
				new LogContent("The measuring tools arrow moves as the tool is getting closer to the target. It should turn one round.", "The ball on the tip of the tool is 4 mm in diameter. To find the surface within an axis, it is needed to find the center of the ball. It is needed to move 2mm to get to the center of the ball, corresponding to one rotation of the arrow on the tool. When the arrow turns one round, the tip is exactly on the surface of the axis measured."),
				new LogContent("Pilen på måleværktøjet bevæger sig i takt med man bevæger værktøjet. Pilen skal køre en omgang.", "Kuglen på spidsen af målevæktøjet er 4 mm i diameter, så for at komme ind i midten af kuglen og stå på den præcise overflade, skal mas 2 mm tættere på emnet. En runde for pilen på værktøjet svare til 2 mm. Så efter at have kørt en runde står værktøjet præcis på emnets overflade."),
                17
			)
		);
        
		
		// Log 17 - Quest 18
		LogsList.Add(
			new Log(
				new LogContent("In the work menu on the control panel, move the cursor to the axis you have chosen to measure while staying in G54. Press [ARROW RIGHT] or [ARROW LEFT] to choose a proper field.", "It is important that the cursor stays in the G54 line, and only moves to the sides, to get to the right axis' field."),
				new LogContent("I Work menuen på kontrolpanelet, flyt curseren over på den akse du er igang med at måle, imens du stadig står i G54. Tryk på [PIL TIL HØJRE] eller [PIL TIL VENSTRE] for at vælge et korrekt felt.", "Det er vigtigt at man bliver i G54 feltet og kun flytter curseren til siderne, for at nå til den rigtige akse felt."),
                18
			)
		);
		
		// Log 18 - Quest 19
		LogsList.Add(
			new Log(
				new LogContent("Press [PART ZERO SET] to set the machine's new zero point for the chosen axis.", "Important note! When [PART ZERO SET] is pressed, the cursor moves one step to the right right after. This is a nice feature when only zero points are measured, but the cursor is needed to be moved back when the new zero point is needed to be edited."),
				new LogContent("Tryk på [PART ZERO SET] for at sætte maskinens nye nulpunkt i den akse.", "Vigtigt! Når man trykker [PART ZERO SET], flytter curseren sig et trin til højre, dette er rart når man bare skal måle, men vær opmærksom på at flytte curseren tilbage til det tidligere akse felt, hvis man vil lave ændringer til den akse."),
                19
			)
		);
		
		// Log 19 - Quest 20
		LogsList.Add(
			new Log(
				new LogContent("Usually it's more beneficial to have the zero point lowered into the target. Press [-] to subtract from the current value. REMEMBER THAT THE CURSOR IS MOVED TO THE RIGHT!", "The subtraction (minus) button can be found on the lower right corner of the control panel. Right now the zero point is set on the surface of the target, meaning that if the machine was told to mill down to zero, nothing would actually be milled. This is why it's beneficial to move the zero point down into the target."),
				new LogContent("Oftest vil man have nulpunktet længere nede i emnet, tryk på [-] for at trække fra. HUSK, AT CURSEREN ER FLYTTET TIL HØJRE!", "Minus knappen kan findes i det nederste højre hjørne af kontrolpanelet. Lige nu ligger nulpunktet lige på overfladen, så hvis man startede maskinen, ville programmet skære ned til nul og stoppe, men nul er på overfladen, så der er ikke blevet skåret noget af. Det er derfor vigtigt at kunne flytte nulpunktet længere ned i emnet, hvor man præcis ved hvor overfladen er nu."),
                20
			)
		);
		
		// Log 20 - Quest 21
		LogsList.Add(
			new Log(
				new LogContent("Press [3] to move the zero point 3 units. Press [.] to change the unit from Mu to Millimeters.", ""),
				new LogContent("Tryk på [3] for at flytte nulpunktet 3 enheder. Tryk derefter på [.] for at ændre enhed fra My til Millimeter.", ""),
                21
			)
		);
		
		// Log 21 - Quest 22
		LogsList.Add(
			new Log(
				new LogContent("Press [ENTER] to subtract 3 millimeters from the current set zero point.", ""),
				new LogContent("Tryk [ENTER] for at trække de 3 millimeter fra det tidligere nulpunkt.", ""),
                22
			)
		);
		
		// Log 22 - Quest 23
		LogsList.Add(
			new Log(
				new LogContent("NEXT: Repeat measuring for the two other axes. Afterward you're done with the measuring.", "IMPORTANT! BEFORE moving the measuring tool away from the target, think about what way you want it to move. Again. Be advised while operating the machine, as it assumes only the tool is moving. Meaning the positive and negative directions are swapped while moving the workbench."),
				new LogContent("NÆSTE: Gentag for at måle de to andre akser. Bagefter er du færdig med at måle.", "VIGTIGT! INDEN du kører måleværktøjet væk fra emnet, tænk over hvad vej du skal køre.. Igen, vær opmærksom på, at maskinen antager, at det er kun værktøjet der bevæger sig, så når man flytter slæden, kører den den modsatte vej, af hvad man ville tro."),
                23
			)
		);
        

        LogsList.Add(
            new Log(
                new LogContent("Congratulations on completing this tutorial", ""),
                new LogContent("Tillykke! Du har nu gennemført vejledningen", ""),
                24
            )
        );

        LogsList.Add(
            new Log(
                new LogContent("", ""),
                new LogContent("", ""),
                25
            )
        );
        
        LogsList.Add(
            new Log(
                new LogContent("THE TOOL IS BROKEN. TAKE IT OUT FROM THE MACHINE, THROW IT TO THE TRASH BIN AND REPLACE WITH A NEW ONE!", ""),
                new LogContent("VÆRKTØJET GIK I STYKKER. TAG DET UD AF MASKINEN, SMID DET I SKRALDESPANDEN OG SÆT ET NYT VÆRKTØJ I!", ""),
                26
            )
        );

        LogsList.Add(
            new Log(
                new LogContent("", ""),
                new LogContent("", ""),
                27
            )
        );

        LogsList.Add(
            new Log(
                new LogContent("", ""),
                new LogContent("", ""),
                28
            )
        );

        // Testing and reference
        //Debug.Log(LogsList[5].danish.description);
        //Debug.Log(LogsList[20].english.description);
        //Debug.Log(LogsList[15].danish.extendedDescription);
        //Debug.Log(LogsList[0].isCompleted());
        //Debug.Log(LogsList[1].isCompleted());
        //LogsList[0].complete();
        //LogsList[1].complete();
        //LogsList[2].complete();
        //LogsList[3].complete();
        //Debug.Log(LogsList[1].isCompleted());
        //Debug.Log(LogsList[0].isCompleted());

        // Set Questlog Initial Values


        questNumber = 2;
        lastQuest = 2;
        lang = "danish";
        areHighlightersOn = false;
        highlightCreator = GameObject.FindObjectOfType<HighlightCreator>();
        ChangeDisplayedQuests(questNumber);
    }

    public void CompleteQuest(int securityCheck)
    {
        if (!isTipBroken)
        {
            if (securityCheck == questNumber)
            {
                LogsList[questNumber].complete();
                if (questNumber < 24)
                {
                    questNumber++;
                    lastQuest++;
                }
                source.PlayOneShot(completed);
                ChangeDisplayedQuests(questNumber);
                highlightCreator.SetAllHighlight(false, questNumber);
                highlightCreator.SetAllHighlight(areHighlightersOn, questNumber);
            }
        }
    }

    public void ChangeLanguage(string language)
    {
        if (language == "english")
        {
            for (int i = 0; i < LogsList.Count; i++)
            {
                LogsList[questNumber].ChangeLanguageToEnglish();
            }

            lang = "english";
            ChangeDisplayedQuests(questNumber);
        }
        if(language == "danish")
        {
            for (int i = 0; i < LogsList.Count; i++)
            {
                LogsList[questNumber].ChangeLanguageToDanish();
            }

            lang = "danish";
            ChangeDisplayedQuests(questNumber);
        }
    }

    void ChangeDisplayedQuests(int number)
    {
        
        if (lang == "english")
        {
            questField1.GetComponent<Text>().text = LogsList[questNumber - 2].english.description;
            questField2.GetComponent<Text>().text = LogsList[questNumber - 1].english.description;
            questField3.GetComponent<Text>().text = LogsList[questNumber].english.description;
            questField4.GetComponent<Text>().text = LogsList[questNumber + 1].english.description;
            questField5.GetComponent<Text>().text = LogsList[questNumber + 2].english.description;
            extendedDescription.GetComponent<Text>().text = LogsList[questNumber].english.extendedDescription;
        }
        if(lang == "danish")
        {
            questField1.GetComponent<Text>().text = LogsList[questNumber - 2].danish.description;
            questField2.GetComponent<Text>().text = LogsList[questNumber - 1].danish.description;
            questField3.GetComponent<Text>().text = LogsList[questNumber].danish.description;
            questField4.GetComponent<Text>().text = LogsList[questNumber + 1].danish.description;
            questField5.GetComponent<Text>().text = LogsList[questNumber + 2].danish.description;
            extendedDescription.GetComponent<Text>().text = LogsList[questNumber].danish.extendedDescription;
        }


        eDImage.gameObject.SetActive(true);

        switch (number)
        {
            case 2:
                eDImage.GetComponent<RawImage>().texture = powerOn;
                break;
            case 5:
                eDImage.GetComponent<RawImage>().texture = defaultPosition;
                break;
            case 6:
                eDImage.GetComponent<RawImage>().texture = handleJog;
                break;
            case 8:
                eDImage.GetComponent<RawImage>().texture = tool;
                break;
            case 9:
                eDImage.GetComponent<RawImage>().texture = keypad;
                break;
            case 10:
                eDImage.GetComponent<RawImage>().texture = arrowKeys;
                break;
            case 12:
                eDImage.GetComponent<RawImage>().texture = keypad;
                break;
            case 13:
                eDImage.GetComponent<RawImage>().texture = axisKeys;
                break;
            case 14:
                eDImage.GetComponent<RawImage>().texture = speedKeys;
                break;
            case 15:
                eDImage.GetComponent<RawImage>().texture = handJog;
                break;
            case 16:
                eDImage.GetComponent<RawImage>().texture = tool;
                break;
            case 17:
                eDImage.GetComponent<RawImage>().texture = toolArrow;
                break;
            case 19:
                eDImage.GetComponent<RawImage>().texture = partZeroSet;
                break;
            case 20:
                eDImage.GetComponent<RawImage>().texture = numberKeys;
                break;
            default:
                eDImage.gameObject.SetActive(false);
                break;
        }

    }

    public void RestartQuestLog()
    {
        questNumber = 2;
        lastQuest = 2;
        ChangeDisplayedQuests(questNumber);
        areHighlightersOn = false;
        highlightCreator.SetAllHighlight(areHighlightersOn, questNumber);
    }

    public void SwitchHighlighters()
    {
        areHighlightersOn = !areHighlightersOn;
        highlightCreator.SetAllHighlight(areHighlightersOn, questNumber);
    }

    public void OpenBrokenTipQuest()
    {
        questNumber = 26;
        ChangeDisplayedQuests(questNumber);
    }

    public void CloseBrokenTipQuest()
    {
        questNumber = lastQuest;
        ChangeDisplayedQuests(questNumber);
    }

}

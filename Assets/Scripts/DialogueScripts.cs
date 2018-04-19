using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScripts : MonoBehaviour
{
    public static List<string[]> TutorialCS1;
    public static List<string[]> TutorialCS1OptionalQ;
    public static string[] TutorialCS1Optional1;
    public static string[] TutorialCS1Optional2;
    public static string[] TutorialCS2;
    public static string[] TutorialCS2Name;
    public static string[] TutorialCS3P1;
    public static string[] TutorialCS3P2;
    public static string[] TutorialCS3NameP1;
    public static string[] TutorialCS3NameP2;
    public static string[] HubCS1P1;
    public static string[] HubCS1P2;
    public static string[] HubCS1NameP1;
    public static string[] HubCS1NameP2;

    // Use this for initialization
    void Awake()
    {
        TutorialCS1 = new List<string[]> { new string[] { "....oo" }, new string[] { "...ear me?" }, new string[] { "Helllooooo" } };
        TutorialCS1OptionalQ = new List<string[]> { new string[] { "I know you're alive. Get up. We have places to be." }, new string[] { "Hilarious. Now hurry up, we need to go." },
            new string[]{"Uh, no. This is kind of important. You NEED to get up." } };
        TutorialCS1Optional1 = new string[] { "(1) No, I'm good.", "(1) Just five more minutes?", "(1) [Refuse to get up ever]" };
        TutorialCS1Optional2 = new string[] { "(2) [Get up]", "(2) Okay, okay.", "(2) Alright, fine." };
        TutorialCS2 = new string[] { "Morning, Grant. Enjoy your nap?", "I did, thanks for asking!", "Great, let's go.", "Hm? Go where?", "Somewhere.", "That certainly sounds exciting. To Somewhere, it is!" };
        TutorialCS2Name = new string[] { "???", "Grant", "???", "Grant", "???", "Grant" };
        TutorialCS3P1 = new string[] { "A floating puzzle piece! How magnificent! I think I'll be taking this with me.", "...really?" };
        TutorialCS3P2 = new string[] { "Shall we go?", "Hold on. I can think of at least ten important questions you could be asking right now, SHOULD be asking right now, and THAT'S what you're gonna ask?", "Didn't you say we had places to be?", "I did, but how do you know I'm not tricking you?"
        , "Then I suppose when we get there, I'll have quite the lesson to learn!", "You're blindly following a stranger to some place you don't know and taking mysterious floating objects without considering what might happen. How're you still alive?", "It's good to have a little faith sometimes, don't you agree? I'd rather that than being a negative Nancy about everything. That must be awfully tiresome!",
            "That doesn't mean you shouldn't ask questions. It might save you some trouble.", "Noted! Then let me ask: couldn't this door possibly lead us somewhere dangerous?", "No, this leads to the exit.", "How can you be so sure?", "I just am. Now let's go.", "See, I could've possibly saved myself the trouble of asking!", "Or maybe you're just asking the wrong questions. C'mon."};
        TutorialCS3NameP1 = new string[] { "Grant", "Eden"};
        TutorialCS3NameP2 = new string[] { "Grant", "Eden", "Grant", "Eden", "Grant", "Eden", "Grant", "Eden", "Grant", "Eden", "Grant", "Eden", "Grant", "Eden" };
        HubCS1P1 = new string[] { "A thought occurs.", "And what's that?", "\"Exit\" is more of a relative term than I'd first considered. Are not all doors exits? A door that leads you further into a labryinth is still allowing you to leave another section of it, but do you consider it an \"exit\"?", "And if all doors are exits, then you could not have possibly been wrong about the door! How clever!", "Thanks?", "And oh, how that forest takes me back! When I was in college, I met my wonderful wife at a park near my building and...", "Pause the story for a second. I need to check something."};
        HubCS1NameP1 = new string[] { "Grant", "Eden", "Grant", "Grant", "Eden", "Grant", "Eden"};
        HubCS1P2 = new string[] { "Damn, it won't open.", "Is this Somewhere?", "What? Uh, yeah, sure. There's a lock on the door. We probably need three more of those puzzle pieces to get in.", "Then we should find them!", "Thanks, I would've never considered doing that.", "You're welcome! May I continue my story now?", "Tell me later. We have puzzle pieces to find." };
        HubCS1NameP2 = new string[] {"Eden", "Grant", "Eden", "Grant", "Eden", "Grant", "Eden"};


    }

    // Update is called once per frame
    void Update()
    {

    }
}

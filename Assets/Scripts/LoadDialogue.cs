using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class LoadDialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    // List of all dialogue used in the game
    public List<string> lines = new List<string>();
    public static bool display = false;
    public float textSpeed;
    private int index = 0;
    bool done = false;
    // Start is called before the first frame update
    public void Start()
    {
        // Add the dialogue lines into list
        lines.Add("Welcome to Ionic Escape! Use WASD to move, press space to jump! Good luck! (Click to close(");
        lines.Add("Be careful not to fall into the pit! Press space to jump, press space again to perform a double jump! (Click to close(");
        lines.Add("This platform is a North Magnet. Change your polarity by pressing the E key. North platforms will repel you if you are red but will attract you if you are blue. (Click to close(");
        lines.Add("This platform is a South Magnet. South platforms will repel you if you are blue but will attract you if you are red. (Click to close(");
        lines.Add("This is the last of the tutorial messages! Good luck with the rest of the level! (Click to close(");
    }

    // Update is called once per frame
    public void Update()
    {
        // bool to tell if we need to display the text
        if (display && !done)
        {
            Debug.Log("DIALOGUE BOX STUFF");
            gameObject.GetComponent<Renderer>().enabled = true;
            NextLine();
            display = false;
            done = false;
            StopAllCoroutines();
        }
        else if(!display)
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            done = false;
        }
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            textComponent.text = string.Empty;
            display = false;
            done = false;
        }
    }

    // gets the next line in lines() list
    public void NextLine()
    {
            textComponent.text = string.Empty;
            textComponent.text += lines[index];
            index++;
            done = true;
    }
}

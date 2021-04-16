using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryLine : MonoBehaviour
{
	int currentLine;
	public List<string> story_lines = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        currentLine = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // show the next line in the story
    public void ShowNextLine()
    {
    	if(currentLine < story_lines.Count)
    	{
    		// call transition first
    		//Fade();
    		this.transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = story_lines[currentLine++];
    	}else{
    		// if there is no next line, close the panel
    		this.transform.parent.gameObject.SetActive(false);
    	}
    }

    private IEnumerator Fade()
    {
    	yield return new WaitForSeconds(1f);
    	this.transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f);
    	yield return new WaitForSeconds(1f);
    	//this.transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(0f, 0f, 0f, 1f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tutorial : MonoBehaviour
{
	public bool FirstTime = true;
	public Dialog dialog;
	public int Page=1;
	public bool Complete = false;
	public bool showing = false;
	public bool[] Done = {false,false,false,false,false,false,false};
	public int[] Emotion = {1,1,1,1,1};
	public GameObject Dialog;
	
	public void SkipTutorial(){
		
	 	dialog.New(new Vector2(0f,0f),StringManager.TutorialEndHeader[1],StringManager.TutorialEnd[1],null,2);
		
		
		
	}

	

    // Start is called before the first frame update
    void Start()
    {
       if(!PlayerPrefs.HasKey("first_time")){
		   PlayerPrefs.SetString("first_time","true");		   
	   }
	   else {
		   if(PlayerPrefs.GetString("first_time")=="false"){
			   FirstTime = false;
		   }
		   else {
			   FirstTime = true;
		   }
		   
	   }
	   
	   if(FirstTime){
		   Dialog.SetActive(true);
	   }
	   
	  
	   
    }
	
	void Display(){
			dialog.New(new Vector2(0f,0f),StringManager.TutorialHeaderStrings[Page],StringManager.TutorialStrings[Page],null,Emotion[Page]);
	}

    // Update is called once per frame
    void Update()
    {
		Complete = true;
		foreach(bool b in Done){
			if(!b){
				Complete = false;
			}
			
		}
		
		if(!Complete){
		Display();
        }
		
		dialog.New(new Vector2(0f,0f),StringManager.TutorialEndHeader[1],StringManager.TutorialEnd[1],null,1);
    }
}

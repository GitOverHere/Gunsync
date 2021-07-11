using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Screenshot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("screenshot_index")){
			PlayerPrefs.SetInt("screenshot_index",0);
		}
    }

    // Update is called once per frame
	public void Update(){
      if(Input.GetButtonDown(Keybinds.Screenshot)){
		  Take();
	  }		
		
	}

	public void Take(){
		ScreenCapture.CaptureScreenshot("screenshot_"+PlayerPrefs.GetInt("screenshot_index"));
		PlayerPrefs.SetInt("screenshot_index",PlayerPrefs.GetInt("screenshot_index")+1);
		
	}
	
	
}

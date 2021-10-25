using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using UnityEngine.UI;

public class StringManager : MonoBehaviour
{
    // Start is called before the first frame update
	public GameObject tooltip;
	public string tooltip_s;
	public static List<string> TutorialHeaderStrings;
	public static List<string> TutorialStrings;
	public static List<string> SettingsStrings;
	public static List<string> TutorialEnd;
	public static List<string> TutorialEndHeader;
	
	public TextAsset english,espanol,portugese,hindi,odia,arabic,chinese,japanese,korean;
	
	
	public void UpdateLanguage(){
		//PlayerPrefs.SetString("language",)
		
	}
	
	
	
	
	
	public void Open(){
		switch(PlayerPrefs.GetString("language")){
			case "english":
			
			
			break;
			
			case "espanol":
			
			break;
			
			case "hindi":
			
			break;
			
			case "odia":
			
			break;
			
			case "arabic":
			
			break;
			
			case "chinese":
			
			break;
			
			case "japanese":
			
			
			break;
			
			
			case "korean":
			
			break;
			
			default:
			
			break;
			
		}
		
		
	}
	
    void Start()
    {
        if(!PlayerPrefs.HasKey("language")){
		  PlayerPrefs.SetString("language","english");	
		}
		
		
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keybinds : MonoBehaviour
{
    // Start is called before the first frame update
	public static string Screenshot,Easy,NoFail,Half,HardRock,SuddenDeath,Perfect,DoubleTime,Nightcore,Hidden,Flashlight,Relax,Auto,Spinner;
	public static string Mods,BeatmapSettings,Filters,Random;
	
	
    void Start()
    {
		
	 //Your typical key binds.
	 
	 if(!PlayerPrefs.HasKey("mods")){
		
		PlayerPrefs.SetString("mods","f1");
		}	
       Mods = PlayerPrefs.GetString("mods");

	 if(!PlayerPrefs.HasKey("beatmap_settings")){
		
		PlayerPrefs.SetString("beatmap_settings","f2");
		}	
       BeatmapSettings = PlayerPrefs.GetString("beatmap_settings");

if(!PlayerPrefs.HasKey("mods")){
		
		PlayerPrefs.SetString("filters","f3");
		}	
       Filters = PlayerPrefs.GetString("filters");
	   
	   if(!PlayerPrefs.HasKey("random")){
		
		PlayerPrefs.SetString("random","f4");
		}	
       Random = PlayerPrefs.GetString("random");
	 
		
	// Take screenshots with this key.
		if(!PlayerPrefs.HasKey("screenshot")){
			PlayerPrefs.SetString("screenshot","f4");
		}	
       Screenshot = PlayerPrefs.GetString("screenshot");
	   // Mod Keybinds	
		if(!PlayerPrefs.HasKey("easy")){
			PlayerPrefs.SetString("easy","q");
		}
		
		Easy = PlayerPrefs.GetString("easy");
		
		if(!PlayerPrefs.HasKey("nofail")){
			PlayerPrefs.SetString("nofail","w");
		}
		
		NoFail = PlayerPrefs.GetString("nofail");
		
		if(!PlayerPrefs.HasKey("half")){
		  PlayerPrefs.SetString("half","e");
		}
		
		Half = PlayerPrefs.GetString("half");
		
		if(!PlayerPrefs.HasKey("hardrock")){
			PlayerPrefs.SetString("hardrock","a");
			
		}
		
		HardRock = PlayerPrefs.GetString("hardrock");
		
		if(!PlayerPrefs.HasKey("nofail")){
			PlayerPrefs.SetString("bofail","e");
			
		}
		
		NoFail = PlayerPrefs.GetString("nofail");
		
		if(!PlayerPrefs.HasKey("suddendeath")){
			PlayerPrefs.SetString("suddendeath","d");
		}
		
		SuddenDeath = PlayerPrefs.GetString("suddendeath");
		
		if(!PlayerPrefs.HasKey("doubletime")){
			PlayerPrefs.SetString("doubletime","f");
			
		}
		DoubleTime = PlayerPrefs.GetString("doubletime");
		
		if(!PlayerPrefs.HasKey("nightcore")){
			PlayerPrefs.SetString("nightcore","g");
			
		}
		
		Nightcore = PlayerPrefs.GetString("nightcore");
		
		if(!PlayerPrefs.HasKey("hidden")){
			PlayerPrefs.SetString("hidden","h");
		}
		
		Hidden = PlayerPrefs.GetString("hidden");
		
		if(!PlayerPrefs.HasKey("flashlight")){
			PlayerPrefs.SetString("flashlight","j");
			
		}
		
		Flashlight = PlayerPrefs.GetString("flashlight");
		
		if(!PlayerPrefs.HasKey("relax")){
			PlayerPrefs.SetString("relax","z");
			
		}
		
		Relax = PlayerPrefs.GetString("relax");
		
		if(!PlayerPrefs.HasKey("auto")){
			PlayerPrefs.SetString("auto","x");
			
		}
		
		Auto = PlayerPrefs.GetString("auto");
		
		if(!PlayerPrefs.HasKey("spinner")){
			PlayerPrefs.SetString("spinner","c");
			
		}
		
		Spinner = PlayerPrefs.GetString("spinner");
		
		
		
		
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

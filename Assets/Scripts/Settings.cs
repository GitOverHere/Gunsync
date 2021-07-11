using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public static float Sensitivity=0.3f;
    public Slider s;




    // Start is called before the first frame update
    void Start()
    {
		if(!PlayerPrefs.HasKey("default_music")){
		
		PlayerPrefs.SetString("default_music","true");
		}	
       
    }

    // Update is called once per frame
    void Update()
    {

    }




}

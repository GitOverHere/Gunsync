using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;




public class Mods : MonoBehaviour
{
	public GameObject mod_screen;
	public GameObject easy,nofail,half;
public GameObject hardrock,suddendeath,doubletime,hidden,flashlight;
public GameObject relax, auto, spinner;
public GameObject cancel;
public Sprite perfect_sprite,nightcore_sprite,sd_sprite,dt_sprite;
public bool easy_on,nofail_on,half_on,hardrock_on,suddendeath_on,perfect_on,doubletime_on,nightcore_on,hidden_on,flashlight_on;
public bool relax_on,auto_on,spinner_on;
public float multiplier=1.0f;
public Text multiplier_text;
    // Start is called before the first frame update
    void Start()
    {
        EventTrigger.Entry easy_click = new EventTrigger.Entry();
		easy_click.eventID = EventTriggerType.PointerClick;
		easy_click.callback.AddListener((data) => {if(!easy_on){
			multiplier -= 0.5f;
			easy_on =true;
		}
		else {
			multiplier += 0.5f;
			easy_on =false;
		}
		

		});
		easy.GetComponent<EventTrigger>().triggers.Add(easy_click);
		
        EventTrigger.Entry nofail_click = new EventTrigger.Entry();
		nofail_click.eventID = EventTriggerType.PointerClick;
        nofail_click.callback.AddListener((data) => {
		if(!nofail_on){
			multiplier -= 0.5f;
			nofail_on =true;
		}
		else {
			multiplier += 0.5f;
			nofail_on =false;
		}
		});
		nofail.GetComponent<EventTrigger>().triggers.Add(nofail_click);
		
		
        EventTrigger.Entry half_click = new EventTrigger.Entry();
		half_click.eventID = EventTriggerType.PointerClick;
		half_click.callback.AddListener((data) => {
			if(!half_on){
			multiplier += 0.5f;
			half_on =true;
		}
		else {
			multiplier -= 0.5f;
			half_on =false;
		}
		});
		half.GetComponent<EventTrigger>().triggers.Add(half_click);
		
        EventTrigger.Entry hardrock_click = new EventTrigger.Entry();
		hardrock_click.eventID = EventTriggerType.PointerClick;
        hardrock_click.callback.AddListener((data) => {
			if(!hardrock_on){
				multiplier += 0.3f;
			hardrock_on =true;
		}
		else {
			multiplier -= 0.3f;
			hardrock_on =false;
		}
		});
		hardrock.GetComponent<EventTrigger>().triggers.Add(hardrock_click);
		
		EventTrigger.Entry suddendeath_click = new EventTrigger.Entry();
		suddendeath_click.eventID = EventTriggerType.PointerClick;
        suddendeath_click.callback.AddListener((data) => {
			if(!suddendeath_on){
				multiplier += 0.3f;
			suddendeath_on =true;
		}
		else {
			if(!perfect_on){
				multiplier += 0.3f;
				perfect_on = true;
				suddendeath.GetComponent<Image>().sprite = perfect_sprite;
			}
			else {
			multiplier -= 0.6f;
			suddendeath_on =false;
			perfect_on = false;
			suddendeath.GetComponent<Image>().sprite = sd_sprite;
			}
		}
		});
		suddendeath.GetComponent<EventTrigger>().triggers.Add(suddendeath_click);


EventTrigger.Entry doubletime_click = new EventTrigger.Entry();
		doubletime_click.eventID = EventTriggerType.PointerClick;
        doubletime_click.callback.AddListener((data) => {
			if(!doubletime_on){
				multiplier += 0.3f;
			doubletime_on =true;
		}
		else {
			if(!nightcore_on){
				multiplier += 0.3f;
				nightcore_on = true;
				doubletime.GetComponent<Image>().sprite = nightcore_sprite;
			}
			else {
			multiplier -= 0.6f;
			doubletime_on =false;
			nightcore_on = false;
			Debug.Log("bruh");
			doubletime.GetComponent<Image>().sprite = dt_sprite;
			}
		}
		});
		doubletime.GetComponent<EventTrigger>().triggers.Add(doubletime_click);

		
		
		
		
		
		EventTrigger.Entry hidden_click = new EventTrigger.Entry();
		hidden_click.eventID = EventTriggerType.PointerClick;
        hidden_click.callback.AddListener((data) => {
			if(!hidden_on){
				multiplier += 0.3f;
			hidden_on =true;
		}
		else {
			multiplier -= 0.3f;
			hidden_on =false;
		}
		});
		hidden.GetComponent<EventTrigger>().triggers.Add(hidden_click);
		
		
		EventTrigger.Entry flashlight_click = new EventTrigger.Entry();
		flashlight_click.eventID = EventTriggerType.PointerClick;
        flashlight_click.callback.AddListener((data) => {
			if(!flashlight_on){
				multiplier += 0.3f;
			flashlight_on =true;
		}
		else {
			multiplier += 0.3f;
			flashlight_on =false;
		}
		});
		flashlight.GetComponent<EventTrigger>().triggers.Add(flashlight_click);
		
		
		
		EventTrigger.Entry relax_click = new EventTrigger.Entry();
		relax_click.eventID = EventTriggerType.PointerClick;
        relax_click.callback.AddListener((data) => {
			if(!relax_on){
			multiplier = 0f;
			relax_on =true;
		}
		else {
			multiplier = 1f;
			relax_on =false;
		}
		});
		relax.GetComponent<EventTrigger>().triggers.Add(relax_click);
		
		
		EventTrigger.Entry auto_click = new EventTrigger.Entry();
		auto_click.eventID = EventTriggerType.PointerClick;
        auto_click.callback.AddListener((data) => {
			if(!auto_on){
				multiplier = 0f;
			auto_on =true;
		}
		else {
			multiplier = 1f;
			auto_on =false;
		}
		});
		auto.GetComponent<EventTrigger>().triggers.Add(auto_click);
		
		
		EventTrigger.Entry spinner_click = new EventTrigger.Entry();
		spinner_click.eventID = EventTriggerType.PointerClick;
        spinner_click.callback.AddListener((data) => {
			if(!spinner_on){
				multiplier = 0f;
			spinner_on =true;
		}
		else {
			multiplier = 1f;
			spinner_on =false;
		}
		});
		spinner.GetComponent<EventTrigger>().triggers.Add(spinner_click);
				
    }
	
	public void Hide(){
		
		mod_screen.SetActive(false);
	}

    // Update is called once per frame
    void Update()
    {
        multiplier_text.text = multiplier.ToString();
    }
	
	
}






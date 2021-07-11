using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatmapSettings : MonoBehaviour
{
    // Start is called before the first frame update
	public GameObject menu;
	public GameObject collections_screen,reset_screen,remove_unranked_screen,delete_screen;
	public GameObject settings_menu;
	
    void Start()
    {
        
		
		
		
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void collections(){
		menu.SetActive(false);
		collections_screen.SetActive(true);
		
		
	}
	
	public void collections_close(){
		menu.SetActive(true);
		collections_screen.SetActive(false);
		
	}
	
	
	public void edit_beatmap(){
		menu.SetActive(false);
		
	}
	
	public void reset() {
		menu.SetActive(false);
		reset_screen.SetActive(true);
	}
	
	public void reset_close() {
		menu.SetActive(true);
		reset_screen.SetActive(false);
	}
	
	public void remove_unranked(){
		menu.SetActive(false);
		remove_unranked_screen.SetActive(true);

	}
	
	public void delete(){
		menu.SetActive(false);
		delete_screen.SetActive(true);
		
	}
	
	public void delete_close() {
		menu.SetActive(true);
		delete_screen.SetActive(false);
	}
	
	public void close() {
		settings_menu.SetActive(false);
	}

}

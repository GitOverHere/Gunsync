using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unranked : MonoBehaviour
{
    // Start is called before the first frame update
	public GameObject RemoveButton,CancelButton,MainMenu;
	
	
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void RemoveUnrankedBeatmaps(){

		Delete.DeleteUnranked();

		this.gameObject.SetActive(false);
		MainMenu.SetActive(true);
	}
	
	
	public void Cancel(){
		 this.gameObject.SetActive(false);
		MainMenu.SetActive(true);
	}
	
	public void Submit(){
		
		
		
	}

}

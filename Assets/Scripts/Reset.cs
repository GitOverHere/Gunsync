using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    // Start is called before the first frame update
	public GameObject ResetButton,CancelButton,MainMenu;
    
	public void ResetScores(){
		
		
		
	}
	
	
	public void Cancel(){
		this.gameObject.SetActive(false);
		MainMenu.SetActive(false);
	}
	
	
  
}

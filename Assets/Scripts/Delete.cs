using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour
{
	
	public GameObject DeleteBeatmap,DeleteDifficulties,DeleteAllButton,MainMenu;
	

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void delete(){
		
		
	}
	
	public static void DeleteUnranked(){
		
		
		
	}
	
	public void DeleteAllDifficulties(){
		
		this.gameObject.SetActive(false);
	    MainMenu.SetActive(true);
		
	}
	
	public void DeleteAll(){

		this.gameObject.SetActive(false);
	    MainMenu.SetActive(true);
		
	}
	
	public void Cancel(){
		this.gameObject.SetActive(false);
	    MainMenu.SetActive(true);
		
	}
	
}

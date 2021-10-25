using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogControl : MonoBehaviour
{
    // Start is called before the first frame update
	public GameObject close;
	public GameObject dialog;
	
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void Close(){
		dialog.SetActive(false);
		
	}
	
	void OK(){
		
		
	}
	
	void Cancel(){
		
		
	}
	
}

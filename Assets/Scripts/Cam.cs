using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
	public Camera Third, First;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if(Input.GetKeyDown("f1")){
			First.enabled = true;
		}
		if(Input.GetKeyDown("f2")){
			Third.enabled = true;
			
		}
		
		
		
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Start is called before the first frame update
	public bool rotating=false;
	public bool selected= false;
	public float time = 0.3f;
	public float deg = 45f;
	public float yvel =0.0f;

    

    // Update is called once per frame
    void Update(){
        if(selected){

			if(gameObject.transform.eulerAngles.z >= deg){
				rotating = false;
			}
			if(rotating){
				float zpos = Mathf.SmoothDamp(gameObject.transform.eulerAngles.z, deg, ref yvel, time);
		gameObject.transform.eulerAngles = new Vector3(0f,0f,zpos);
			}
    }
	else {
	
		
		
		gameObject.transform.eulerAngles = new Vector3(0f,0f,0f);	

	
	}
	}
	
public void OnMouseDown(){
		if(!selected){
			Debug.Log("selected");
			selected = true;
			rotating = true;
		}
		else {
			Debug.Log("unselected");
			selected = false;
			rotating = false;
		}
		
	}
	
	
	
}

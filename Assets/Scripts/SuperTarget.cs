using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperTarget : MonoBehaviour
{
	public GameObject RightArm,LeftArm,RightLeg,LeftLeg;
	
	
	
	
       // Start is called before the first frame update
    void Start()
    {
      Invoke("Destroy",30f);    
    }

    // Update is called once per frame
	//Dream: Was playing a  game where peopel would walk around you would rub choco on face, then get chased by a wave of water. If it touched you, you were dead.
    void Update()
    {
		gameObject.transform.Translate(0f,0f,0.1f);
		if(RightArm.transform.rotation.x > 45f){
			RightArm.transform.Rotate(-1f);
		}
		else if(RightArm.transform.rotation.x  < -45f){
		    RightArm.transform.Rotate(1f);
		}
		

		RightArm.transform.Rotate(1f);
		LeftArm.transform.Rotate(1f);
		if(RightArm)
		
    }
	
	void OnCollisionEnter(){
		
		Destroy(gameObject);
	}
	
	void Destroy(){
		Debug.Log("Bullet destroyed");
		Destroy(gameObject);
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	
	
	
    // Start is called before the first frame update
    void Start()
    {
      Invoke("Destroy",10f);    
    }

    // Update is called once per frame
    void Update()
    {
		gameObject.transform.Translate(0f,0f,0.1f);
		
		
    }
	
	void OnCollisionEnter(){
		
		Destroy(gameObject);
	}
	
	void Destroy(){
		Debug.Log("Bullet destroyed");
		Destroy(gameObject);
		
	}
	
	
	
	
	
}

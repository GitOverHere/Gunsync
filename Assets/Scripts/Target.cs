using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         Invoke("Destroy",30f); 
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(0f,1f,0f);
    }
	
	void OnCollisionEnter(){
		
		Destroy(gameObject);
	}
	
	void Destroy(){
		Debug.Log("Bullet destroyed");
		Destroy(gameObject);
		
	}
	
}

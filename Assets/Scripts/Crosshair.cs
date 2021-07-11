using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    // Start is called before the first frame update

	public GameObject crosshair,Gun,Bullet;
	public static bool dualWield;
	Audio a;
	public bool moving = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetMouseButtonDown(0)){
				moving = true;
		  	a.Fire();
	  }
		if(moving){
			Bullet.transform.Translate(new Vector3(0,0,1)*Time.deltaTime,Space.World);
		}

    }
}

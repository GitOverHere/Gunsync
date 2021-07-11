using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBody : MonoBehaviour
{
	public GameObject RightShoulder,RightWrist,RightArm,RightElbow,LeftArm,LeftElbow,LeftShoulder,LeftWrist,Character,Head;
	public GameObject LeftThumb,LeftRing,LeftMiddle,LeftIndex,LeftPinky;
	public GameObject RightThumb, RightRing, RightMiddle, RightIndex, RightPinky;
	public Vector3 previousPos;
	public float p;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

		if(Input.GetAxis("Horizontal") < 0) {
			Head.transform.Rotate(0f,-2f,0f,Space.World);
				LeftArm.transform.Rotate(0f,-2f,0f,Space.World);
				
		}

		if(Input.GetAxis("Horizontal") > 0){
			Head.transform.Rotate(0f,2f,0f,Space.World);
				LeftArm.transform.Rotate(0f,2f,0f,Space.World);
		}

		if(Input.GetAxis("Vertical") < 0 ){
	Head.transform.Rotate(-2f,0f,0f,Space.World);
	LeftArm.transform.Rotate(-2f,0f,0f,Space.World);
}
if(Input.GetAxis("Vertical") > 0){
	Head.transform.Rotate(2f,0f,0f,Space.World);
	LeftArm.transform.Rotate(2f,0f,0f,Space.World);
}


		if(Head.transform.eulerAngles.z != 0){
				Head.transform.eulerAngles = new Vector3(Head.transform.eulerAngles.x,Head.transform.eulerAngles.y,0f);
			}



	}


    }

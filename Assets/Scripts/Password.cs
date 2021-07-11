using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Password: MonoBehaviour
{
    // Start is called before the first frame update
	public Text Pwd;
	private string RealText;
	
    void Start()
    {
      Pwd = gameObject.GetComponent<InputField>().textComponent;
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.anyKeyDown){
		   if(!Input.GetKeyDown("Backspace")){
		   Pwd.text += "*";
		   RealText += Input.inputString;
		   }
		   else {
		   RealText.Remove(RealText.Length-1);
		   Pwd.text.Remove(Pwd.text.Length-1);
		   }
	   }
	  
    }
}

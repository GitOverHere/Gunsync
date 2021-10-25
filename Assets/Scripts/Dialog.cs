using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    // Start is called before the first frame update
	public GameObject Window,Close,Button;
	public Sprite normal,happy,angry,error,info;

	
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void New(Vector2 t,string header, string content,string[] buttons=null,int code=5){
		Window.transform.position = t;
		Window.transform.GetChild(0).GetComponent<Text>().text = header;
		Window.transform.GetChild(1).GetComponent<Text>().text = content;
		
		switch(code){
	    case 1:
		Window.transform.GetChild(2).gameObject.GetComponent<Image>().sprite= normal; 
		break;
		case 2:
		Window.transform.GetChild(2).gameObject.GetComponent<Image>().sprite=  happy;
		break;
		case 3: 
		Window.transform.GetChild(2).gameObject.GetComponent<Image>().sprite= angry;
		break;
		case 4:
		Window.transform.GetChild(2).gameObject.GetComponent<Image>().sprite = error;
        break;
        case 5:
         Window.transform.GetChild(2).gameObject.GetComponent<Image>().sprite= info;
        break;
        default:
         Window.transform.GetChild(2).gameObject.GetComponent<Image>().sprite= info;
		 break;
		}
		
		foreach(string s in buttons){
			GameObject button = Instantiate(Button);
			button.transform.SetParent(Window.transform,false);
			button.transform.Translate(Vector3.right*30);
			button.transform.GetChild(0).gameObject.GetComponent<Text>().text = s;
		}

       
 
 
 
	}
	
	void OK(){
		
		
	}
	
	void Cancel(){
		
		
	}
	
}

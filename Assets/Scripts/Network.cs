using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class Network : MonoBehaviour
{
	
	public InputField username,password;
	public Toggle Remember;
    
	  IEnumerator Post(string uri,List<string> keys, List<string> values)
    {
        WWWForm form = new WWWForm();
		
		for(int keyCount=0; keyCount < keys.Count; keyCount++){
        form.AddField(keys[keyCount],values[keyCount]);
		}

        using (UnityWebRequest www = UnityWebRequest.Post(uri, form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
	
	IEnumerator Get(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
            }
        }
    }
	
	
	
	
	
    void Start()
    {
		if(!PlayerPrefs.HasKey("remember")){
		  PlayerPrefs.SetInt("remember",0);
		}
      StartCoroutine(Get("https://www.google.com"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void Login(){		
	StartCoroutine(Post("https://gunsync.sahu.me/login/login.php",new List<string>(){"username","password","remember"},new List<string>() {username.text,password.text,PlayerPrefs.GetInt("remember").ToString()}));
	}
	
	
    public void Register(){
		
	}
	
	public void ForgotPassword(){
		 using(UnityWebRequest Web = UnityWebRequest.Get("https://gunsync.sahu.me/login/forgot.php")){
		Web.Send();
		if(Web.isNetworkError || Web.isHttpError){
			Debug.Log(Web.error);
			
		}
		Debug.Log(Web.downloadHandler.text);
		 }	
	}
	
	public void RememberMe() {
		if(PlayerPrefs.GetInt("remember")==0){
		  PlayerPrefs.SetInt("remember",1);
	    }
		else {
		   PlayerPrefs.SetInt("remember",0);	
		}
}
}

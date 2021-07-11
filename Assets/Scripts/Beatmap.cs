using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System.IO;
using UnityEngine.SceneManagement;

public class Beatmap : MonoBehaviour
{
    // Start is called before the first frame update
	public bool hovering = false;
	public Vector2 new_pos;
	public Vector2 old_pos;
	public Vector2 currentVelocity = Vector2.zero;
	public Music music;
	
	//needs ref when using in function call
	public float smoothTime = 0.3f;

	public void OnMouseOver(){
		hovering = true;
		
		
	}
	
	public void Select() {
		//Directory.GetDirectories(beatmap_dir, "*", SearchOption.TopDirectoryOnly)[0];
		//gameObject.GetComponent<RectTransform>().gameObjecgameObject.GetComponent<RectTransform>().name
		music.LoadSong(gameObject.transform.GetSiblingIndex());
		
	}
	
    void OnEnable()
    {
        old_pos = gameObject.GetComponent<RectTransform>().anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
		/*
		if(hovering){
			gameObject.GetComponent<RectTransform>().anchoredPosition = Vector2.SmoothDamp(gameObject.GetComponent<RectTransform>().anchoredPosition,new_pos,ref currentVelocity,smoothTime,Time.deltaTime);
		}
		else {
			gameObject.GetComponent<RectTransform>().anchoredPosition = Vector2.SmoothDamp(gameObject.GetComponent<RectTransform>().anchoredPosition,old_pos,ref currentVelocity,smoothTime,Time.deltaTime);
		}
		*/
    }
	

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Object= UnityEngine.Object;
	using Random = UnityEngine.Random;
	
	
public class Collections : MonoBehaviour
{
	public static List<string> collections;
	public static List<string> songs;
	public InputField name;
	public GameObject s_list, c_list;
	public GameObject text,c_text;
	public GameObject screen;
	public BeatmapParse bp;
	public int song_index=0,collection_index=0;
	public GameObject back;
	
	
	
	// Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("collections")){
			PlayerPrefs.SetString("collections","My Favorite Songs,");
		}
		
		if(!PlayerPrefs.HasKey("songs")){
			PlayerPrefs.SetString("songs","");
		}
		
		collections = PlayerPrefs.GetString("collections").Split(',').ToList();
		songs = PlayerPrefs.GetString("songs").Split(';').ToList();
		update_collection_list();
		
    }

    // Update is called once per frame
    void Update()
    {
		
    }
	
	public void go_back(){
		back.SetActive(false);
		s_list.SetActive(false);
		c_list.SetActive(true);
	}
	
	
	
	public void select_collection(GameObject g){
		collection_index = g.transform.GetSiblingIndex();
		update_songlist();
		
	}
	
	
	public void select_song(GameObject g){
		song_index = g.transform.GetSiblingIndex();	
		bp.active_song  = g.transform.name;
	}
	
	
	

	public void update_collection_list(){
		for(int h=0; h>c_list.transform.childCount; h++){
			Object.Destroy(c_list.transform.GetChild(h));
		}
	
		List<string> songlist = songs[collection_index].Split(',').ToList();
		 int i =0;
		foreach(string s in songlist){
			GameObject obj = Instantiate(c_text,c_text.transform.position,Quaternion.identity);
			obj.GetComponent<InputField>().text = songlist[i];
			i++;
		}
		
	}
	
	public void update_songlist(){
		List<string> songlist = songs[collection_index].Split(',').ToList();
		 int i =0;
		foreach(string s in songlist){
			GameObject obj = Instantiate(text,text.transform.position,Quaternion.identity);
			obj.GetComponent<InputField>().text = songlist[i];
			i++;
		}
		
	}
	
	public void create_collection(){
		PlayerPrefs.SetString("collections",PlayerPrefs.GetString("collections")+name.text+",");
		PlayerPrefs.SetString("songs",PlayerPrefs.GetString("songs")+";");
		collections = PlayerPrefs.GetString("collections").Split(',').ToList();
		songs = PlayerPrefs.GetString("songs").Split(';').ToList();
		name.text = "";
	}
	
	public void remove_collection(){
		 
		
	}
	
	public void rename_collection(){
		string[] cols = PlayerPrefs.GetString("collections").Split(',');
		cols[collection_index] = name.text;
		PlayerPrefs.SetString("collections",String.Join("",cols));
	}
		
	public void export_collection(){
		
		
	}
	
	public void import_collection(){
		
		
	}
	
	public void add_song(){
		string s = bp.active_song;		
				songs[collection_index] += s+',';
	
		string new_songs = songs.ToString();
		
		PlayerPrefs.SetString("songs",new_songs);
		Debug.Log(PlayerPrefs.GetString("songs"));
	
	}
	
	public void remove_song(){
		string s = bp.active_song;
		List<string> list = songs[collection_index].Split(',').ToList();
		list[song_index] = "";
		for(int i=0; i< list.Count; i++){
			if(list[i]==""){
				list.RemoveAt(i);
			}
		}
		songs[collection_index] = list.ToString(); 
		update_songlist();
		
	}
	
	public void close(){
		screen.SetActive(false);
	}
	
}

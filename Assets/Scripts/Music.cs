using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Diagnostics;
using System.Threading;
using Debug = UnityEngine.Debug;
using UnityEngine.Audio;
using System.Threading.Tasks;
using UnityEngine.Networking;
using Random = System.Random;
using System.Web;


public class Music : MonoBehaviour
{
    // Start is called before the first frame update
	// uwr = Unity Web Request
	public AudioSource music;
	public static int index;
	
async Task<AudioClip> LoadClip(string path){
     AudioClip clip = null;
	 //path.Replace("\\", "/");
	 //string abs =  new Uri(path).AbsoluteUri;
	 Debug.Log("Attempting to load: "+ path);
     using (UnityWebRequest uwr = UnityWebRequestMultimedia.GetAudioClip(path, AudioType.WAV))
     {
         uwr.SendWebRequest();
 
         // wrap tasks in try/catch, otherwise it'll fail silently
         try
         {
             while (!uwr.isDone) await Task.Delay(5);
 
             if (uwr.isNetworkError || uwr.isHttpError) {
				 Debug.Log($"{uwr.error}");
				 Debug.Log(path);
				 uwr.Dispose();
			 }
             else
             {
                 clip = DownloadHandlerAudioClip.GetContent(uwr);
				 uwr.Dispose();
             }
         }
         catch (Exception err)
         {
             Debug.Log($"{err.Message}, {err.StackTrace}");
			 uwr.Dispose();
			 Play();
         }
     }
 
     return clip;
 }
	

	
		public void Play(){
		music.Play();
	}
	
	public void Pause(){
		music.Pause();
		
	}
	
	public void Stop(){
		music.Stop();
	}
	
	async public void Random(){
		Stop();
		Random r = new Random();
		index = r.Next(0,SongSelect.beatmap_count);
			PlayerPrefs.SetString("beatmap",SongSelect.dir[index]);
			music.clip = await LoadClip(PlayerPrefs.GetString("beatmap")+"/song.wav");
		Play();
	}
	
	async public void NextSong(){
		Stop();
		index += 1;
		PlayerPrefs.SetString("beatmap",SongSelect.dir[index]);
			music.clip = await LoadClip(PlayerPrefs.GetString("beatmap")+"/song.wav");
			Play();
	}
	
	async public void PreviousSong(){
		Stop();
		index -= 1;
		if(index < 0){
			index = 0;
		}
		PlayerPrefs.SetString("beatmap",SongSelect.dir[index]);
			music.clip = await LoadClip(PlayerPrefs.GetString("beatmap")+"/song.wav");
			Play();
	}
	
	
	
	async public void Load(){
		if(PlayerPrefs.GetString("default_music") == "true"){
		if(Application.isEditor){
		Debug.Log("Attempting to access: "+Application.dataPath+"/Audio/song.wav");
		music.clip = await LoadClip(Application.dataPath+"/Audio/song.wav");
		Play();
		}
		else {
			Debug.Log("Attempting to access: song.wav"); 
			music.clip = await LoadClip("song.wav");
		}
		
		}
		
		else {
			Random();
			Play();
		}
		
	}
	
	async public void LoadSong(int i){
		Stop();
		index = i;
		if(Application.isEditor){
		PlayerPrefs.SetString("beatmap",Application.dataPath+"/"+SongSelect.dir[index]);
		}
		else{
			PlayerPrefs.SetString("beatmap",SongSelect.dir[index]);
		}
		//Find the absolute url from a relative url 7-25-2021:7:59PM
			music.clip = await LoadClip(PlayerPrefs.GetString("beatmap")+"/song.wav");
			Play();
			
	}
	
	public void CheckForBeatmaps(){
		
		
	}
	
   async void Start()
    {
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

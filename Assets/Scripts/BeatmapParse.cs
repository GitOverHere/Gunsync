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

public class BeatmapParse : MonoBehaviour
{

    // Start is called before the first frame update
    public string beatmap;
    public string[] content;
    public GameObject Target,SuperTarget,Warning;
	public GameObject Perfect,Good,Okay,Miss;
	public List<float[]> tgt_list = new List<float[]>();
	public List<float[]> supertarget_list = new List<float[]>();
	public float[] timings;
	public bool[] sent;
	public Stopwatch stopwatch;
	public string active_song;
	public AudioSource music,sfx;
	public AudioClip hit,miss;

	
	 async Task<AudioClip> LoadClip(string path){
     AudioClip clip = null;
     using (UnityWebRequest uwr = UnityWebRequestMultimedia.GetAudioClip(path, AudioType.WAV))
     {
         uwr.SendWebRequest();
 
         // wrap tasks in try/catch, otherwise it'll fail silently
         try
         {
             while (!uwr.isDone) await Task.Delay(5);
 
             if (uwr.isNetworkError || uwr.isHttpError) Debug.Log($"{uwr.error}");
             else
             {
                 clip = DownloadHandlerAudioClip.GetContent(uwr);
             }
         }
         catch (Exception err)
         {
             Debug.Log($"{err.Message}, {err.StackTrace}");
         }
     }
 
     return clip;
 }
	
public void Pause(){
	music.Pause();
	
	
	
}

IEnumerator Launch(GameObject g,float x,float y,float delay)
{
	yield return new WaitForSeconds(delay);
	Instantiate(g, new Vector3(x,y,200f), Quaternion.identity);
	
}
	
	
    async void Start()
    {
		
		active_song = PlayerPrefs.GetString("beatmap")+"/song.wav";
	    if(!File.Exists(active_song)){
			active_song = "";
			SceneManager.LoadScene("Menu");	
		}
			 
		else {
			
			music.clip = await LoadClip(active_song) as AudioClip;
			music.Play();
		}
	 
	
	
      beatmap = PlayerPrefs.GetString("beatmap");
      XmlDocument xml = new XmlDocument();
      xml.PreserveWhitespace= true;
        xml.Load(beatmap);
		XmlNodeList targets;
		XmlNodeList supertargets;
		 XmlNode doc =   xml.DocumentElement;  
      targets = doc.SelectNodes("file/targets/t");
	  supertargets = doc.SelectNodes("file/targets/s");
		foreach(XmlNode target in targets){
			string text = target.InnerText;
			Debug.Log(text);
			string[] str = text.Split(',');
			float[] numbers={float.Parse(str[0]),float.Parse(str[1]),float.Parse(str[2])};
			tgt_list.Add(numbers);
            StartCoroutine(Launch(Target, float.Parse(str[0]),float.Parse(str[1]),float.Parse(str[2])));		
			}
		foreach(XmlNode supertarget in supertargets){
			string text = supertarget.InnerText;
			Debug.Log(text);
			string[] str = text.Split(',');
			float[] numbers={float.Parse(str[0]),float.Parse(str[1]),float.Parse(str[2])};
			supertarget_list.Add(numbers);
			StartCoroutine(Launch(SuperTarget, float.Parse(str[0]),float.Parse(str[1]),float.Parse(str[2])));
		}
	stopwatch = new Stopwatch();
    }
	
	
    // Update is called once per frame
    void Update()
    {
		/*
		for(int i=0; i<timings.Length; i++){
			if(stopwatch.ElapsedMilliseconds>timings[i] && !sent[i]){
				sent[i]=true;
				Instantiate(Target);
			}
			
		}
		
		*/
    }
}

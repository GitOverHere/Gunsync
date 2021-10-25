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
using UnityEngine.UI;
using Microsoft.VisualBasic;

public class Editor : MonoBehaviour
{
	public RectTransform Timeline;
	public Text Timestamp;
	public GameObject Interval;
	public Music music;
	public GameObject PlayButton,PauseButton,StopButton,SkipButton;
	public string active_song;
    public AudioSource Music; 
	public Slider progress;
	public GameObject dialog,SkipTo;
	public float song_position=0;
	public GameObject cursor;
	public float WidthInterval = 100f;
	public float Duration=0f;
	public float TimelineWidth= 1000f;
    public List<float[]> tgt_list = new List<float[]>();
	public List<float[]> supertarget_list = new List<float[]>();
	public List<float> HeadsUp = new List<float>();
	public float[] timings;
	public bool[] sent;
	public Stopwatch stopwatch;
	public string beatmap;
	public float SuperTargetHeadsUp=1f;
	
	
	
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
	
	
	public void ResizeTimeline(){
		
		
		
		
		
    }
	
	public void CreateTimestamps(){
		
		
		
	}
	

    // Start is called before the first frame update
    async void Start()
    {
        active_song = PlayerPrefs.GetString("beatmap")+"/song.wav";
	    if(!System.IO.File.Exists(active_song)){
			active_song = "";
			SceneManager.LoadScene("Menu");	
		}
		else {
			
			Music.clip = await LoadClip(active_song) as AudioClip;
		}
		Duration = Music.clip.length;
		TimelineWidth = Duration*WidthInterval;
		Timeline.sizeDelta = new Vector2(TimelineWidth,Timeline.sizeDelta.y);
		float Width=0;
		int IntervalCount=0;
		while(Width < Duration*WidthInterval){
			Transform pos = Interval.transform;
			pos.position = Vector2.right * (WidthInterval*IntervalCount);
			Instantiate(Interval,pos);
			Text stamp = Instantiate(Timestamp,pos);
			TimeSpan time = TimeSpan.FromSeconds(Duration*(Width/TimelineWidth));
			stamp.text = time.ToString(@"hh\:mm\:ss\:ff");
			Width += WidthInterval;
			IntervalCount += 1;
		}
		
		beatmap = PlayerPrefs.GetString("beatmap")+"/beatmap.xml";
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
			}
		foreach(XmlNode supertarget in supertargets){
			string text = supertarget.InnerText;
			Debug.Log(text);
			string[] str = text.Split(',');
			float[] numbers={float.Parse(str[0]),float.Parse(str[1]),float.Parse(str[2])};
			supertarget_list.Add(numbers);
			HeadsUp.Add(float.Parse(str[2])-SuperTargetHeadsUp);
		}
		Debug.Log("Target count: "+tgt_list.Count());
	  Debug.Log("Supertarget count: "+supertarget_list.Count());
		
		
    }
	
	void Update(){
		
		Debug.Log(Music.time);
		cursor.transform.Translate(Vector3.right*WidthInterval*Time.deltaTime);
	}
	
	
	public void Play(){
		Music.Play();
		
	}
	
	public void Pause(){
		Music.Pause();
	}
	
	public void Stop(){
		Music.Stop();
		
	}
	
	public void Skip(){
	 Music.Stop();	
	}

   public void JumpTo(){
	   
   }
	
	public void File(){
		
		
	}
	
	public void Open(){
		
	}
	
	public void ExitToMenu(){
		SceneManager.LoadScene("Menu");
		
	}
	
	public void Exit(){
		Application.Quit();
		
	}
	
	public void AddTarget(){
		
		
	}
	
	public void AddSuperTarget(){
		
		
	}
	
	public void Remove(){
		
		
	}
	
	public void DarkMode(){
		
		
	}
	
	public void ZoomIn(){
		
		
		
	}
	
	public void ZoomOut(){
		
		
	}
	
	
	
	
}

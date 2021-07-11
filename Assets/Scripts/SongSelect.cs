using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System.IO;
using System.Collections;
using System.Xml;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class SongSelect : MonoBehaviour
{
    // Start is called before the first frame update
	public GameObject beatmap;
	public GameObject scroller,scroll_rect;
	  public GameObject mods_button,beatmap_settings_button,filter_button,random_button,play_button;
  public GameObject mods_screen,beatmap_settings_screen,filter_screen,random_screen;
	public static int beatmap_count;
	public float beatmap_space = 5f;
	public static string beatmap_dir = "Beatmaps/";
	public RectTransform b;
	public GameObject back;
	public bool back_hovering=false;
	public float smoothTime = 0.3f;
    public float yVelocity = 0.0f;
	public float scale = 1.2f;
	public static List<string> dir;
	
	public void AddBeatmaps(){
		b = beatmap.GetComponent<RectTransform>();
		dir = new List<string>(Directory.GetDirectories(beatmap_dir, "*", SearchOption.TopDirectoryOnly));
		float offset =0;
		
		beatmap_count = dir.Count;
		Debug.Log(beatmap_count.ToString());
		
		beatmap.transform.GetChild(0).GetComponent<Text>().text = "Gunsync Tutorial";
		beatmap.transform.GetChild(1).GetComponent<Text>().text = "Gamesational // Sahu Games";
		beatmap.transform.GetChild(2).GetComponent<Text>().text = "Easy";
		beatmap.transform.GetChild(3).GetComponent<Text>().text = "0.5";
		beatmap.name = dir[0];
		
		
		for(int i =1; i<beatmap_count; i++){
			offset += beatmap_space;
			Vector2 pos = new Vector2(b.anchoredPosition.x,b.anchoredPosition.y-offset);
			GameObject g = Instantiate(beatmap,scroller.GetComponent<RectTransform>(),false);
			g.GetComponent<RectTransform>().anchoredPosition = pos;
			string name = dir[i];
			Debug.Log(name);
			try {
			XmlDocument doc = new XmlDocument();
			doc.PreserveWhitespace = true;
				doc.Load(name+"/beatmap.xml"); 
				string title = doc.GetElementsByTagName("title")[0].InnerText;
				string artist = doc.GetElementsByTagName("artist")[0].InnerText;
				string creator = doc.GetElementsByTagName("creator")[0].InnerText;
				string difficulty = doc.GetElementsByTagName("difficulty")[0].InnerText;
				string stars =  doc.GetElementsByTagName("stars")[0].InnerText;
				
				g.transform.GetChild(0).GetComponent<Text>().text = title;
				g.transform.GetChild(1).GetComponent<Text>().text = creator+"//"+artist;
				g.transform.GetChild(2).GetComponent<Text>().text = difficulty;
				g.transform.GetChild(3).GetComponent<Text>().text = stars;
			
			g.name = name;
			}
			catch (System.IO.FileNotFoundException error)
				{
				
			Debug.Log("Could not fetch some information.");
			Debug.Log(error.FileName);
			Debug.Log(error.Message);
			g.transform.GetChild(0).GetComponent<Text>().text = "Unknown";
			g.transform.GetChild(1).GetComponent<Text>().text = "Unknown"+"//"+"Unknown";
				}
	}
		
	}
	
    void Start(){
	AddBeatmaps();
	back.AddComponent<EventTrigger>();
	EventTrigger.Entry back_hover = new EventTrigger.Entry();
	back_hover.eventID = EventTriggerType.PointerEnter;
	back_hover.callback.AddListener((data) => {back_hovering=true;});
	EventTrigger.Entry back_hover_exit = new EventTrigger.Entry();
	back_hover_exit.eventID = EventTriggerType.PointerExit;
	back_hover_exit.callback.AddListener((data) => {back_hovering=false;});
	back.GetComponent<EventTrigger>().triggers.Add(back_hover_exit);
	back.GetComponent<EventTrigger>().triggers.Add(back_hover);
	EventTrigger.Entry mods = new EventTrigger.Entry();
         EventTrigger.Entry beatmap_settings = new EventTrigger.Entry();
         EventTrigger.Entry filter = new EventTrigger.Entry();
         EventTrigger.Entry random = new EventTrigger.Entry();
		  mods.eventID = EventTriggerType.PointerClick;
        beatmap_settings.eventID = EventTriggerType.PointerClick;
        filter.eventID = EventTriggerType.PointerClick;
        random.eventID = EventTriggerType.PointerClick;
		mods.callback.AddListener((data) => {mods_screen.SetActive(true);});
		beatmap_settings.callback.AddListener((data) => {
			beatmap_settings_screen.SetActive(true);
			Debug.Log("bruh");
		});
		filter.callback.AddListener((data) => {filter_screen.SetActive(true);});
		random.callback.AddListener((data) => {
				
			
			
			
		});
		
		mods_button.AddComponent<EventTrigger>();
		mods_button.GetComponent<EventTrigger>().triggers.Add(mods);
		beatmap_settings_button.AddComponent<EventTrigger>();
		beatmap_settings_button.GetComponent<EventTrigger>().triggers.Add(beatmap_settings);
		filter_button.AddComponent<EventTrigger>();
		filter_button.GetComponent<EventTrigger>().triggers.Add(filter);
		random_button.AddComponent<EventTrigger>();
		random_button.GetComponent<EventTrigger>().triggers.Add(random);
		
		
		EventTrigger.Entry play_click = new EventTrigger.Entry();
		play_click.eventID = EventTriggerType.PointerClick;
		play_click.callback.AddListener((data) => {SceneManager.LoadScene("GunRange");});
		play_button.AddComponent<EventTrigger>();
		play_button.GetComponent<EventTrigger>().triggers.Add(play_click);
	}	
	
	public void random(){
		scroll_rect.transform.position = scroller.transform.GetChild(Random.Range(0,scroller.transform.childCount)).transform.position;
		
	}
	
	
	
	

    // Update is called once per frame
    void Update()
    {
        if(back_hovering){
			float old_pos = back.GetComponent<RectTransform>().sizeDelta.x;
			  float newPosition = Mathf.SmoothDamp(old_pos, scale, ref yVelocity, smoothTime);
        back.GetComponent<RectTransform>().sizeDelta = new Vector2(newPosition, back.GetComponent<RectTransform>().sizeDelta.y);
		}
		else {
			float old_pos = back.GetComponent<RectTransform>().sizeDelta.x;
			  float newPosition = Mathf.SmoothDamp(old_pos, 1f, ref yVelocity, smoothTime);
        back.GetComponent<RectTransform>().sizeDelta = new Vector2(newPosition, back.GetComponent<RectTransform>().sizeDelta.y);
		}
		
		
    }
	
}

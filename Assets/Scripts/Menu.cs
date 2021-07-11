using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Audio;
using System.IO;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    public Text beatmaps,song;
	public GameObject play,edit,settings,exit_game,logo;
	public GameObject cover;
  public GameObject play_music,pause_music,stop_music,prev_track,next_track,menu,info,Login;
  public AudioSource audio;
  public GameObject main_menu,song_select,edit_select,results;
	public RectTransform settings_menu;
  public int button;
  public Vector2 x;
  public float timeScale = 0.04f;
  public Vector2 init;
 public AudioClip sfx;
 public AudioSource source;
 private LineRenderer[] lines;
 public int BarCount=300;
 public float SoundLevel=0.5f;
 public int radius = 30;
 public LineRenderer lr;
 public string beatmap_dir = "Beatmaps";
public float x_init,y_init;
public bool switchMenu = false;
public Color clear,black;
//ori-spos: Original settings menu position;
//spos: New settings menu position.
public Vector2 ori_spos= new Vector2(-550f,0f);
public Vector2 spos = new Vector2(-285,0f);
public float s_time=11f;
private Vector2 v2 = Vector3.zero;
public bool settings_menu_active=false;
public float delay = 0.3f;

    void Start()
    {
		clear = new Color(0,0,0,0);
		black = new Color(0,0,0,100f);
		
		play.AddComponent<EventTrigger>();
		edit.AddComponent<EventTrigger>();
		settings.AddComponent<EventTrigger>();
		exit_game.AddComponent<EventTrigger>();
		
		
		
		
    
	cover.SetActive(false);
        EventTrigger.Entry hover1 = new EventTrigger.Entry();
		hover1.eventID = EventTriggerType.PointerEnter;
		hover1.callback.AddListener((data) => {button=1;});
		play.GetComponent<EventTrigger>().triggers.Add(hover1);
		
        EventTrigger.Entry hover2 = new EventTrigger.Entry();
		hover2.eventID = EventTriggerType.PointerEnter;
        hover2.callback.AddListener((data) => {button=2;});
		edit.GetComponent<EventTrigger>().triggers.Add(hover2);
		
		
        EventTrigger.Entry hover3 = new EventTrigger.Entry();
		hover3.eventID = EventTriggerType.PointerEnter;
		hover3.callback.AddListener((data) => {button=3;});
		settings.GetComponent<EventTrigger>().triggers.Add(hover3);
		
        EventTrigger.Entry hover4 = new EventTrigger.Entry();
		hover4.eventID = EventTriggerType.PointerEnter;
        hover4.callback.AddListener((data) => {button=4;});
		exit_game.GetComponent<EventTrigger>().triggers.Add(hover4);

		EventTrigger.Entry click1 = new EventTrigger.Entry();
		click1.eventID = EventTriggerType.PointerClick;
		click1.callback.AddListener((data) => {
          Debug.Log("Playing Game");
		switchMenu = true;
		StartCoroutine(SongSelect());
		});
		play.GetComponent<EventTrigger>().triggers.Add(click1);
		 
		 EventTrigger.Entry click2 = new EventTrigger.Entry();
		click2.eventID = EventTriggerType.PointerClick;
		click2.callback.AddListener((data) => {Debug.Log("Editing Beatmap");
		switchMenu = true;
		StartCoroutine(EditSelect());
		});
		edit.GetComponent<EventTrigger>().triggers.Add(click2);
		
		 EventTrigger.Entry click3 = new EventTrigger.Entry();
		 click3.eventID = EventTriggerType.PointerClick;
		 click3.callback.AddListener((data) => {
			Debug.Log("Modifying Settings");
			if(!settings_menu_active){
			settings_menu_active=true;
			}
			else {
				settings_menu_active = false;
			}
		});
		settings.GetComponent<EventTrigger>().triggers.Add(click3);
		
		EventTrigger.Entry click4 = new EventTrigger.Entry();
		 click4.eventID = EventTriggerType.PointerClick;
		 click4.callback.AddListener((data) => {Debug.Log("Exiting Game");
		Application.Quit();
		});
		 exit_game.GetComponent<EventTrigger>().triggers.Add(click4);
		 
		 
		 
		 
		 EventTrigger.Entry login_click = new EventTrigger.Entry();
		 
		login_click.eventID = EventTriggerType.PointerClick;
		login_click.callback.AddListener((data) => {
			Login.SetActive(false);
		});
		 
		 
		 
		 
		 
		
        EventTrigger.Entry exit = new EventTrigger.Entry();
		EventTrigger.Entry hover_exit = new EventTrigger.Entry();
       
        
        
         
         EventTrigger.Entry play_hover = new EventTrigger.Entry();
         EventTrigger.Entry pause_hover = new EventTrigger.Entry();
         EventTrigger.Entry stop_hover = new EventTrigger.Entry();
         EventTrigger.Entry prev_hover = new EventTrigger.Entry();
         EventTrigger.Entry next_hover = new EventTrigger.Entry();
         EventTrigger.Entry menu_hover = new EventTrigger.Entry();
         EventTrigger.Entry info_hover = new EventTrigger.Entry();
         EventTrigger.Entry play_click = new EventTrigger.Entry();
         EventTrigger.Entry pause_click = new EventTrigger.Entry();
         EventTrigger.Entry stop_click = new EventTrigger.Entry();
         EventTrigger.Entry prev_click = new EventTrigger.Entry();
         EventTrigger.Entry next_click = new EventTrigger.Entry();
         EventTrigger.Entry menu_click = new EventTrigger.Entry();
         EventTrigger.Entry info_click = new EventTrigger.Entry();
		 
		 
        exit.eventID = EventTriggerType.PointerExit;
        play_hover.eventID = EventTriggerType.PointerEnter;
        pause_hover.eventID = EventTriggerType.PointerEnter;
        stop_hover.eventID = EventTriggerType.PointerEnter;
        prev_hover.eventID = EventTriggerType.PointerEnter;
        next_hover.eventID = EventTriggerType.PointerEnter;
        menu_hover.eventID = EventTriggerType.PointerEnter;
        info_hover.eventID = EventTriggerType.PointerEnter;
        play_click.eventID = EventTriggerType.PointerClick;
        pause_click.eventID = EventTriggerType.PointerClick;
        stop_click.eventID = EventTriggerType.PointerClick;
        prev_click.eventID = EventTriggerType.PointerClick;
        next_click.eventID = EventTriggerType.PointerClick;
        menu_click.eventID = EventTriggerType.PointerClick;
        info_click.eventID = EventTriggerType.PointerClick;
        exit.callback.AddListener((data) => {button=0;});
        
        
        
        
		play_hover.callback.AddListener((data) => {



		});
		pause_hover.callback.AddListener((data) => {



		});
		stop_hover.callback.AddListener((data) => {



		});
		prev_hover.callback.AddListener((data) => {


		});
		next_hover.callback.AddListener((data) => {


		});
		menu_hover.callback.AddListener((data) => {


		});
		info_hover.callback.AddListener((data) => {


		});
		play_click.callback.AddListener((data) => {

			Debug.Log("Playing music.");
			audio.Play();
		});
		pause_click.callback.AddListener((data) => {
			audio.Pause();

		});
		stop_click.callback.AddListener((data) => {
			audio.Stop();

		});
		prev_click.callback.AddListener((data) => {

		});
		next_click.callback.AddListener((data) => {


		});
		menu_click.callback.AddListener((data) => {


		});
		info_click.callback.AddListener((data) => {


		});
		
		
		
		
		
	
		
    
      play.GetComponent<EventTrigger>().triggers.Add(exit);
      edit.GetComponent<EventTrigger>().triggers.Add(exit);
        settings.GetComponent<EventTrigger>().triggers.Add(exit);
        exit_game.GetComponent<EventTrigger>().triggers.Add(exit);


play_music.AddComponent<EventTrigger>();
play_music.GetComponent<EventTrigger>().triggers.Add(play_hover);
play_music.GetComponent<EventTrigger>().triggers.Add(play_click);
play_music.GetComponent<EventTrigger>().triggers.Add(hover_exit);

pause_music.AddComponent<EventTrigger>();
pause_music.GetComponent<EventTrigger>().triggers.Add(pause_click);
pause_music.GetComponent<EventTrigger>().triggers.Add(pause_hover);
pause_music.GetComponent<EventTrigger>().triggers.Add(hover_exit);

stop_music.AddComponent<EventTrigger>();
stop_music.GetComponent<EventTrigger>().triggers.Add(stop_click);
stop_music.GetComponent<EventTrigger>().triggers.Add(stop_hover);
stop_music.GetComponent<EventTrigger>().triggers.Add(hover_exit);

prev_track.AddComponent<EventTrigger>();
prev_track.GetComponent<EventTrigger>().triggers.Add(next_click);
prev_track.GetComponent<EventTrigger>().triggers.Add(next_hover);
prev_track.GetComponent<EventTrigger>().triggers.Add(hover_exit);

next_track.AddComponent<EventTrigger>();
next_track.GetComponent<EventTrigger>().triggers.Add(next_click);
next_track.GetComponent<EventTrigger>().triggers.Add(next_hover);
next_track.GetComponent<EventTrigger>().triggers.Add(hover_exit);

menu.AddComponent<EventTrigger>();
next_track.GetComponent<EventTrigger>().triggers.Add(next_click);
next_track.GetComponent<EventTrigger>().triggers.Add(next_hover);
next_track.GetComponent<EventTrigger>().triggers.Add(hover_exit);

info.AddComponent<EventTrigger>();
next_track.GetComponent<EventTrigger>().triggers.Add(info_click);
next_track.GetComponent<EventTrigger>().triggers.Add(info_hover);
next_track.GetComponent<EventTrigger>().triggers.Add(hover_exit);





      init = new Vector2(play.GetComponent<RectTransform>().sizeDelta.x,play.GetComponent<RectTransform>().sizeDelta.y);
      x_init = init.x;
      y_init = init.y;
      InvokeRepeating("CountBeatmaps",0f,1f);
	  //settings_menu.transform.localPosition = Vector2.SmoothDamp(transform.position,spos,ref this.v2,s_time);
    }

    void Update()
    {
		if(settings_menu_active==true){
			settings_menu.localPosition = Vector2.SmoothDamp(ori_spos,spos,ref v2,delay);
			
		}
		else {
			settings_menu.localPosition = Vector2.SmoothDamp(spos,ori_spos,ref v2,delay);
		}
		
      switch(button){
        case 1:
          if(play.GetComponent<RectTransform>().sizeDelta.x < x_init*1.2f){
            play.GetComponent<RectTransform>().sizeDelta = new Vector2(play.GetComponent<RectTransform>().sizeDelta.x+(play.GetComponent<RectTransform>().sizeDelta.x*1.05f-play.GetComponent<RectTransform>().sizeDelta.x),play.GetComponent<RectTransform>().sizeDelta.y+(play.GetComponent<RectTransform>().sizeDelta.y*1.05f-play.GetComponent<RectTransform>().sizeDelta.y));
        }
        break;
        case 2:
        if(edit.GetComponent<RectTransform>().sizeDelta.x < x_init*1.2f){
          edit.GetComponent<RectTransform>().sizeDelta = new Vector2(edit.GetComponent<RectTransform>().sizeDelta.x+(edit.GetComponent<RectTransform>().sizeDelta.x*1.05f-edit.GetComponent<RectTransform>().sizeDelta.x),edit.GetComponent<RectTransform>().sizeDelta.y+(edit.GetComponent<RectTransform>().sizeDelta.y*1.05f-edit.GetComponent<RectTransform>().sizeDelta.y));
      }
        break;

        case 3:
        if(settings.GetComponent<RectTransform>().sizeDelta.x < x_init*1.2f){
          settings.GetComponent<RectTransform>().sizeDelta = new Vector2(settings.GetComponent<RectTransform>().sizeDelta.x+(settings.GetComponent<RectTransform>().sizeDelta.x*1.05f-settings.GetComponent<RectTransform>().sizeDelta.x),settings.GetComponent<RectTransform>().sizeDelta.y+(settings.GetComponent<RectTransform>().sizeDelta.y*1.05f-settings.GetComponent<RectTransform>().sizeDelta.y));
      }
        break;
        case 4:
        if(exit_game.GetComponent<RectTransform>().sizeDelta.x < x_init*1.2f){
          exit_game.GetComponent<RectTransform>().sizeDelta = new Vector2(exit_game.GetComponent<RectTransform>().sizeDelta.x+(exit_game.GetComponent<RectTransform>().sizeDelta.x*1.05f-exit_game.GetComponent<RectTransform>().sizeDelta.x),exit_game.GetComponent<RectTransform>().sizeDelta.y+(exit_game.GetComponent<RectTransform>().sizeDelta.y*1.05f-exit_game.GetComponent<RectTransform>().sizeDelta.y));
      }
        break;
        default:
          play.GetComponent<RectTransform>().sizeDelta = init;
          edit.GetComponent<RectTransform>().sizeDelta= init;
          settings.GetComponent<RectTransform>().sizeDelta = init;
          exit_game.GetComponent<RectTransform>().sizeDelta = init;
        break;
      }
    }

IEnumerator SongSelect(){
	cover.SetActive(true);
	yield return new WaitForSeconds(2);
	Time.timeScale = 0f;
	main_menu.SetActive(false);
	song_select.SetActive(true);
	Time.timeScale = 1.0f;
	cover.SetActive(false);
	
}

IEnumerator EditSelect() {
	cover.SetActive(true);
	yield return new WaitForSeconds(2);
	Time.timeScale = 0f;
	main_menu.SetActive(false);
	edit_select.SetActive(false);
	Time.timeScale = 1.0f;
	cover.SetActive(false);
}



public void CountBeatmaps() {
string s =   Directory.GetDirectories(beatmap_dir, "*", SearchOption.TopDirectoryOnly).Length.ToString();
if(s=="1"){
beatmaps.text = "1 beatmap loaded";
}

if(s=="0"){
beatmaps.text = "No Beatmaps Loaded!";

}
else {
beatmaps.text = s +" beatmaps loaded";

}

}


}






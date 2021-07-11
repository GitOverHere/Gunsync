using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
  public float delay=1f;
    // Start is called before the first frame update
    IEnumerator Delay(float time)
     {
         yield return new WaitForSeconds(time);
         this.gameObject.SetActive(false);
         // Code to execute after the delay
     }

public void OnEnable(){
this.gameObject.SetActive(true);
this.GetComponent<Image>().canvasRenderer.SetAlpha(0.0f);
FadeIn();
}

public void OnDisable(){
this.GetComponent<Image>().canvasRenderer.SetAlpha(1.0f);
FadeOut();
StartCoroutine(Delay(1.1f));
}

  public void FadeIn(){
      this.GetComponent<Image>().CrossFadeAlpha(1f,delay,true);
    }

  public void FadeOut(){
      this.GetComponent<Image>().CrossFadeAlpha(0f,delay,true);
  }

}

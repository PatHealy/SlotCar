using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class EndDirector : MonoBehaviour {

    public GameObject FadePanel;
    public float fadeSpeed = 0.1f;
    public Text cred;
    public Text bo;
    public Text thnk;
    public GameObject vpObject;
    public VideoPlayer vp;

    int wT = 300;

	void Start () {
        StartCoroutine(sequence());
	}
	
	IEnumerator sequence() {
        yield return new WaitForSeconds(1f);
        int k = 0;
        while (k < wT)
        {
            k++;
            FadePanel.GetComponent<Image>().color = Color.Lerp(FadePanel.GetComponent<Image>().color, Color.clear, fadeSpeed * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }

        k = 0;
        while (k < wT)
        {
            k++;
            cred.color = Color.Lerp(cred.color, Color.white, fadeSpeed * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }

        k = 0;
        while (k < wT)
        {
            k++;
            cred.color = Color.Lerp(cred.color, Color.clear, fadeSpeed * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }

        k = 0;
        while (k < wT)
        {
            k++;
            bo.color = Color.Lerp(bo.color, Color.white, fadeSpeed * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }

        k = 0;
        while (k < wT)
        {
            k++;
            bo.color = Color.Lerp(bo.color, Color.clear, fadeSpeed * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }

        vpObject.SetActive(true);
        vp.Play();
        yield return new WaitForSeconds(10f);

        k = 0;
        while (k < wT)
        {
            k++;
            FadePanel.GetComponent<Image>().color = Color.Lerp(FadePanel.GetComponent<Image>().color, Color.black, fadeSpeed * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }

        k = 0;
        while (k < wT)
        {
            k++;
            thnk.color = Color.Lerp(thnk.color, Color.white, fadeSpeed * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
        Application.Quit();
    }
}

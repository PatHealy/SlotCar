using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleBehavior : MonoBehaviour {
    Rigidbody rb;
    public Transform dg;
    public GameObject FadePanel;

    public float fadeSpeed;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        StartCoroutine(introSequence());
	}
	
	IEnumerator introSequence() {
        rb.angularVelocity = new Vector3(0, 0, 1000f);
        rb.velocity = new Vector3(0, 0, -30f);
        while (transform.position.z > -9)
        {
            yield return new WaitForFixedUpdate();
        }
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        yield return new WaitForSeconds(1.5f);

        while (dg.position.y < 0.4f)
        {
            dg.Translate(new Vector3(0, 0.01f, 0), Space.World);
            yield return new WaitForFixedUpdate();
        }

        rb.angularVelocity = new Vector3(0, 0, 1f);

        while (dg.position.y < 0.62f) {
            dg.Translate(new Vector3(0, 0.01f, 0), Space.World);
            yield return new WaitForFixedUpdate();
        }
        rb.angularVelocity = Vector3.zero;

        yield return new WaitForSeconds(5f);

        int k = 0;
        while (k < 500)
        {
            k++;
            FadePanel.GetComponent<Image>().color = Color.Lerp(FadePanel.GetComponent<Image>().color, Color.black, fadeSpeed * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }

        SceneManager.LoadScene("MainScene");
    }
}

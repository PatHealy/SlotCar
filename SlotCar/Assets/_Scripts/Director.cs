using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Director : MonoBehaviour {
    public static Director instance;
    public Image fd;
    public Image controls;
    public Text esc;

	void Awake () {
        instance = this;
	}

    private void Start()
    {
        StartCoroutine(startSequence());
    }

    IEnumerator startSequence() {
        yield return new WaitForSeconds(4f);
        int k = 0;
        while (k < 200)
        {
            k++;
            controls.color = Color.Lerp(controls.color, Color.white, 0.2f * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }

        k = 0;
        while (k < 100)
        {
            k++;
            controls.color = Color.Lerp(controls.color, Color.clear, 10f * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }

        yield return new WaitForSeconds(5f);

        k = 0;
        while (k < 200)
        {
            k++;
            esc.color = Color.Lerp(esc.color, Color.white, 0.2f * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }

        k = 0;
        while (k < 100)
        {
            k++;
            esc.color = Color.Lerp(esc.color, Color.clear, 10f * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            StartCoroutine(sequence());
        }
    }

    IEnumerator sequence() {
        int k = 0;
        while (k < 400)
        {
            k++;
            fd.color = Color.Lerp(fd.color, Color.black, 0.3f * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }

        SceneManager.LoadScene("EndScene");
    }
}

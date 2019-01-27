using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Director : MonoBehaviour {
    public static Director instance;
    public Image fd;

	void Awake () {
        instance = this;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SliderLoading : MonoBehaviour
{
    public Slider mainSlider;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waiter());
        
    }

    IEnumerator waiter()
    {
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.06f);
            mainSlider.value += 0.02f;
        }
    }
    public void Jugar()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //Cargar nivel1
            SceneManager.LoadScene("Nivel1");
        }
    }
}

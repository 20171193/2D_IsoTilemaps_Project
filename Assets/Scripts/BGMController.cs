using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BGMController : MonoBehaviour
{
    Slider slider;
    [SerializeField]
    AudioSource audioSource;

    bool isMuted = false;    
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponentInChildren<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMuted)
        {
            audioSource.volume = slider.value;
            Debug.Log(audioSource.volume);
        }
        else
            audioSource.volume = 0.0f;
    }
    public void OnSoundImageClick()
    {
        isMuted = !isMuted;

    }
}

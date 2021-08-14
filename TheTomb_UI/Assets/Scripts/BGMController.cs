using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BGMController : MonoBehaviour
{
    public Slider slider;
    [SerializeField]
    AudioSource audioSource;

    //bool isMuted = false;
    // Start is called before the first frame update
    private void Awake()
    {
        slider = GameObject.Find("BGMSlider").GetComponent<Slider>();
    }
    void Start()
    {
        //slider.value = audioSource.volume;
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = slider.value;
    }
    public void OnSoundImageClick()
    {
        Debug.Log("click onsoundimage");
        slider.value = 0;
    }
}

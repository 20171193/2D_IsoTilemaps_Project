//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class SoundManager : MonoBehaviour
//{
//    private static SoundManager instance = null;
//    public static SoundManager Instance
//    {
//        get
//        {
//            if(null == instance)
//            {
//                return null;
//            }
//            return instance;
//        }
//    }
//    public AudioSource curBgmAudio;
//    public AudioSource mainEmAudio;
//    public float bgmValue = 1;
//    public float emValue;
//    private void Awake()
//    {
//        curBgmAudio = GameObject.Find("MainCamera").GetComponent<AudioSource>();
//        DontDestroyOnLoad(this.gameObject);
//    }
//    private void Update()
//    {
//    }
//    private void OnEnable()
//    {
//        SceneManager.sceneLoaded += OnSceneLoaded;
//    }
//    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
//    {
//        Debug.Log("OnSceneLoaded: " + scene.name);
//        curBgmAudio = GameObject.Find("MainCamera").GetComponent<AudioSource>();
//        curBgmAudio.volume = bgmValue;
//    }
//    private void OnDisable()
//    {
//        SceneManager.sceneLoaded -= OnSceneLoaded;
//    }
//    public void UpdateSound()
//    {
//        bgmValue = curBgmAudio.volume;
//    }
//}

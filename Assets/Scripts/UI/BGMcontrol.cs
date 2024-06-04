using UnityEngine;
using UnityEngine.UI;

public class BGMcontrol : MonoBehaviour
{
    static BGMcontrol Music; //is used to store the unique instance of background music
    public AudioSource bgMusic;
    public Slider volumeSlider;

    void Start()
    {
        //these are for keeping background music playing even if we are testing other scences
        //and assuring there is always only one background music throughout the play
        if (Music == null) //checks whether there is already an existing music instance
        {
            Music = this; //if not existing (like in the 1st scene), it assigns the current instance to Music
        }
        else
        {
            Destroy(gameObject); //if so (like in the 2nd scene), then destroy the current music instance
        }

        DontDestroyOnLoad(gameObject); //keep the only one music playing 

        // 设置音量滑块的初始值为背景音乐的当前音量
        if (bgMusic != null && volumeSlider != null)
        {
            volumeSlider.value = bgMusic.volume;
        }
        else
        {
            Debug.Log("No BGM or Slider!");
        }

    }


    public void SetVolume(float volume)
    {
        // 当用户调整音量滑块时调用此方法来设置背景音乐的音量
        Debug.Log("Set Volume!");
        if (bgMusic != null)
        {
            bgMusic.volume = volume;
        }
    }
}

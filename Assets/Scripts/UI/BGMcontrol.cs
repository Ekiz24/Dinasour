using UnityEngine;
using UnityEngine.UI;

public class BGMcontrol : MonoBehaviour
{
    public AudioSource bgMusic;
    public Slider volumeSlider;

    void Start()
    {
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

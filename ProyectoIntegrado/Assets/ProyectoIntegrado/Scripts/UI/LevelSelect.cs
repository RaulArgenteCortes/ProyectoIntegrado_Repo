using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    [Header("Botones de MainMenu")]
    public Button loadLevel01;
    public Button loadLevel02;
    public Button loadLevel03;
    public Button loadLevel04;
    public Button loadLevel05;
    public Button loadLevel06;
    public Button loadLevel07;
    public Button loadLevel08;
    public Button loadLevel09;
    public Button loadLevel10;
    public Button loadLevel11;
    public Button loadLevel12;
    public Button loadLevel13;
    public Button loadLevel14;
    public Button loadLevel15;
    public Button loadLevel16;
    public Button loadLevel17;
    public Button loadLevel18;
    public Button loadLevel19;
    public Button loadLevel20;

    [Header("External Scripts")]
    [SerializeField] AudioManager Script_AudioManager;

    // Start is called before the first frame update
    void Start()
    {
        loadLevel01.onClick.AddListener(LoadLevel01);
        loadLevel02.onClick.AddListener(LoadLevel02);
        loadLevel03.onClick.AddListener(LoadLevel03);
        loadLevel04.onClick.AddListener(LoadLevel04);
        loadLevel05.onClick.AddListener(LoadLevel05);
        loadLevel06.onClick.AddListener(LoadLevel06);
        loadLevel07.onClick.AddListener(LoadLevel07);
        loadLevel08.onClick.AddListener(LoadLevel08);
        loadLevel09.onClick.AddListener(LoadLevel09);
        loadLevel10.onClick.AddListener(LoadLevel10);
        loadLevel11.onClick.AddListener(LoadLevel11);
        loadLevel12.onClick.AddListener(LoadLevel12);
        loadLevel13.onClick.AddListener(LoadLevel13);
        loadLevel14.onClick.AddListener(LoadLevel14);
        loadLevel15.onClick.AddListener(LoadLevel15);
        loadLevel16.onClick.AddListener(LoadLevel16);
        loadLevel17.onClick.AddListener(LoadLevel17);
        loadLevel18.onClick.AddListener(LoadLevel18);
        loadLevel19.onClick.AddListener(LoadLevel19);
        loadLevel20.onClick.AddListener(LoadLevel20);

        // Referencias a otros scripts
        Script_AudioManager = GameObject.FindWithTag("Audio").GetComponent<AudioManager>();
    }

    void LoadLevel01() { SceneManager.LoadScene("Level_01"); Script_AudioManager.PlaySfx(Script_AudioManager.buttonPress); }
    void LoadLevel02() { SceneManager.LoadScene("Level_02"); Script_AudioManager.PlaySfx(Script_AudioManager.buttonPress); }
    void LoadLevel03() { SceneManager.LoadScene("Level_03"); Script_AudioManager.PlaySfx(Script_AudioManager.buttonPress); }
    void LoadLevel04() { SceneManager.LoadScene("Level_04"); Script_AudioManager.PlaySfx(Script_AudioManager.buttonPress); }
    void LoadLevel05() { SceneManager.LoadScene("Level_05"); Script_AudioManager.PlaySfx(Script_AudioManager.buttonPress); }
    void LoadLevel06() { SceneManager.LoadScene("Level_06"); Script_AudioManager.PlaySfx(Script_AudioManager.buttonPress); }
    void LoadLevel07() { SceneManager.LoadScene("Level_07"); Script_AudioManager.PlaySfx(Script_AudioManager.buttonPress); }
    void LoadLevel08() { SceneManager.LoadScene("Level_08"); Script_AudioManager.PlaySfx(Script_AudioManager.buttonPress); }
    void LoadLevel09() { SceneManager.LoadScene("Level_09"); Script_AudioManager.PlaySfx(Script_AudioManager.buttonPress); }
    void LoadLevel10() { SceneManager.LoadScene("Level_10"); Script_AudioManager.PlaySfx(Script_AudioManager.buttonPress); }
    void LoadLevel11() { SceneManager.LoadScene("Level_11"); Script_AudioManager.PlaySfx(Script_AudioManager.buttonPress); }
    void LoadLevel12() { SceneManager.LoadScene("Level_12"); Script_AudioManager.PlaySfx(Script_AudioManager.buttonPress); }
    void LoadLevel13() { SceneManager.LoadScene("Level_13"); Script_AudioManager.PlaySfx(Script_AudioManager.buttonPress); }
    void LoadLevel14() { SceneManager.LoadScene("Level_14"); Script_AudioManager.PlaySfx(Script_AudioManager.buttonPress); }
    void LoadLevel15() { SceneManager.LoadScene("Level_15"); Script_AudioManager.PlaySfx(Script_AudioManager.buttonPress); }
    void LoadLevel16() { SceneManager.LoadScene("Level_16"); Script_AudioManager.PlaySfx(Script_AudioManager.buttonPress); }
    void LoadLevel17() { SceneManager.LoadScene("Level_17"); Script_AudioManager.PlaySfx(Script_AudioManager.buttonPress); }
    void LoadLevel18() { SceneManager.LoadScene("Level_18"); Script_AudioManager.PlaySfx(Script_AudioManager.buttonPress); }
    void LoadLevel19() { SceneManager.LoadScene("Level_19"); Script_AudioManager.PlaySfx(Script_AudioManager.buttonPress); }
    void LoadLevel20() { SceneManager.LoadScene("Level_20"); Script_AudioManager.PlaySfx(Script_AudioManager.buttonPress); }
}

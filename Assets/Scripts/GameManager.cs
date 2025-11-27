using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float timer;
    public float talkDelay;
    public static bool myTurn;
    public static int numOfAttack;
    public TextMeshProUGUI textInBox;
    string txt;
    public AudioSource audioSource;
    public AudioClip txtsnd;
    int k = 0;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        myTurn = true;
        numOfAttack = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (myTurn && numOfAttack == 0)
        {
            textInBox.color = Color.red;
            txt = "Time for a free xp =)";
            StartCoroutine(Talk(txt));
        }
    }
    IEnumerator Talk(string txt)
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 100 && k <= txt.Length - 1; i++)
        {
            if (timer <= 0)
            {
                textInBox.text += txt[k].ToString();
                k++;
                audioSource.PlayOneShot(txtsnd);
                timer = talkDelay;
            }
            else
                timer -= Time.deltaTime;
        }
    }
}

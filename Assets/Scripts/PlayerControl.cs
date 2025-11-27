using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    int btn = 0;
    int maxBtn = 3;
    int[] x = new int[2] {1, 0};
    public GameObject Fight; public GameObject Act; public GameObject Item; public GameObject Mercy;
    public Sprite inactiveFight;
    public Sprite activeFight;
    public Sprite inactiveAct;
    public Sprite activeAct;
    public Sprite inactiveItem;
    public Sprite activeItem;
    public Sprite inactiveMercy;
    public Sprite activeMercy;
    private SpriteRenderer SpriteRenderer;
    public AudioClip switchsound;
    public AudioSource audios;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        if (SpriteRenderer != null )
        {
            SpriteRenderer.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.myTurn)
        {
            switch (btn)
            {
                case 0:
                    this.transform.position = new Vector2(-6.95f, -4.2f);
                    SwitchBtn(Fight, Act, Mercy, Item, activeFight, inactiveAct, inactiveMercy, inactiveItem);
                    break;
                case 1:
                    this.transform.position = new Vector2(-2.9f, -4.2f);
                    SwitchBtn(Act, Fight, Item, Mercy, activeAct, inactiveFight, inactiveItem, inactiveMercy);
                    break;
                case 2:
                    this.transform.position = new Vector2(1.04f, -4.2f);
                    SwitchBtn(Item, Act, Mercy, Fight, activeItem, inactiveAct, inactiveMercy, inactiveFight);
                    break;
                case 3:
                    this.transform.position = new Vector2(5.05f, -4.2f);
                    SwitchBtn(Mercy, Fight, Item, Act, activeMercy, inactiveFight, inactiveItem, inactiveAct);
                    break;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (btn == maxBtn)
                    btn = 0;
                else
                    this.btn += 1;
                audios.PlayOneShot(switchsound);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (btn == 0)
                    btn = maxBtn;
                else
                    this.btn -= 1;
                audios.PlayOneShot(switchsound);
            }
            if ((Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.KeypadEnter)) && btn == 3)
            {
                Mercy.SetActive(false);
                
                maxBtn = 2;
                btn = 0;
            }
        }
    }
    void SwitchBtn(GameObject on, GameObject off1, GameObject off2, GameObject off3, Sprite onS, Sprite offS1, Sprite offS2, Sprite offS3)
    {
        on.GetComponent<SpriteRenderer>().sprite = onS;
        off1.GetComponent<SpriteRenderer>().sprite = offS1;
        off2.GetComponent<SpriteRenderer>().sprite = offS2;
        off3.GetComponent<SpriteRenderer>().sprite = offS3;
    }
    
}

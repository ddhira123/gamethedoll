using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Girl G;
    public Image barImg;
    private float MANA_MAX;
    private float manaAmt;
    private float manaRegenAmt;
    private float manaOverTime;
    private float prevScore;

    void Awake()
    {
        G = GameObject.FindObjectOfType(typeof(Girl)) as Girl;
        barImg = GetComponent<Image> ();
        barImg.fillAmount = 1f;
        MANA_MAX = 100f;
        manaAmt = MANA_MAX;
        manaRegenAmt = 15f;
        manaOverTime = 5f;
        prevScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameControl.instance.gameOver == false)
        {
            if(manaAmt >= 0){
                manaAmt -= Time.deltaTime * manaOverTime;
                barImg.fillAmount = manaAmt/MANA_MAX;

                if(GameControl.instance.score > prevScore){
                    manaAmt += manaRegenAmt;
                    prevScore = GameControl.instance.score;
                }
            }
            else
            {
                G.GirlDie();
            }
        }
    }
}

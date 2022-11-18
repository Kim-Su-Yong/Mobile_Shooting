using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RocketDamage : MonoBehaviour
{
    public float hp = 0f;
    public float hpInit = 100f;
    [SerializeField]
    private Image hpBar;
    private readonly Color initColor = new Vector4(0.1f, 1.0f, 0.0f, 1.0f);
    private readonly string asteroidtag = "ASTEROID";
    void Start()
    {
        hp = hpInit;
        hpBar = GameObject.Find("Canvas-UI").transform.GetChild(0).transform.GetChild(1).GetComponent<Image>();
        hpBar.color = initColor;
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(asteroidtag))
        {
            col.gameObject.SetActive(false);
            hp -= 25f;
            hp = Mathf.Clamp(hp, 0, 100);
            DisPlayHpBar();

            if (hp <= 0)
                PlayerDie();
        }
    }
    void PlayerDie()
    {
        SceneManager.LoadScene("End");
        //GameManager.gameManager.isGameOver = false;  
    }
    void DisPlayHpBar()
    {
        hpBar.fillAmount = (float)hp / (float)hpInit;
        if (hpBar.fillAmount <= 0.3f)
            hpBar.color = Color.red;
        else if (hpBar.fillAmount <= 0.5f)
            hpBar.color = Color.yellow;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TopHareketi : MonoBehaviour
{   

    public AudioSource alkis, skor;
    public TextMeshProUGUI oyuncu1PuaniText, oyuncu2PuaniText, kazananText;
    public GameObject obj, obj2;
    Rigidbody2D top;
    //[SerializeField]
    //float speed = 5f;
    float xHizi, yHizi;
    int xSecim, ySecim;
    private void Start()
    {
        /*xSecim = Random.Range(1, 3);
        ySecim = Random.Range(1, 3);
        if(xSecim == 1)
        {
            xHizi = Random.Range(3f, 6f);
        }
        else
        {
            xHizi = -(Random.Range(3f, 6f));
        }
        if(ySecim == 1)
        {
            yHizi = Random.Range(3f, 6f);
        }
        else
        {
            yHizi = -(Random.Range(3f, 6f));
        }*/
        Time.timeScale = 0;
        xHizi = 5f;
        yHizi = 5f;
        top = gameObject.GetComponent<Rigidbody2D>();
        top.velocity = new Vector2(xHizi, yHizi);
    }
    public void Button()
    {
        obj2.SetActive(false);
        Time.timeScale = 1;
    }

    private void Update()
    {
        oyuncu2PuaniText.text = YenidenBaslatma.oyuncu2Puani.ToString();
        oyuncu1PuaniText.text = YenidenBaslatma.oyuncu1Puani.ToString();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "1.Oyuncu")
        {
            xHizi += 0.1f;
            top.velocity = new Vector2(-xHizi, Random.Range(-yHizi, yHizi));            
        }
        if(collision.gameObject.name == "2.Oyuncu")
        {
            xHizi += 0.1f;
            top.velocity = new Vector2(xHizi, Random.Range(-yHizi, yHizi));            
        }
        if(collision.gameObject.name == "Yukari")
        {
            yHizi += 0.1f;
            top.velocity = new Vector2(top.velocity.x, -yHizi);            
        }
        if(collision.gameObject.name == "Asagi")
        {
            yHizi += 0.1f;
            top.velocity = new Vector2(top.velocity.x, yHizi);            
        }
        if(collision.gameObject.name == "Sag")
        {
            skor.Play();
            YenidenBaslatma.oyuncu2Puani++;            
            if(YenidenBaslatma.oyuncu2Puani == 5)
            {
                alkis.Play();
                kazananText.text = "TEBRİKLER \n 2.OYUNCU KAZANDI";
                Time.timeScale = 0;
                obj.SetActive(true);
            }
            StartCoroutine(Tekrar());
        }
        if(collision.gameObject.name == "Sol")
        {
            skor.Play();
            YenidenBaslatma.oyuncu1Puani++;            
            if (YenidenBaslatma.oyuncu1Puani == 5)
            {
                alkis.Play();
                kazananText.text = "TEBRİKLER \n 1.OYUNCU KAZANDI";
                Time.timeScale = 0;
                obj.SetActive(true);
            }
            StartCoroutine(Tekrar());
        }
    }
    IEnumerator Tekrar()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("SampleScene");
    }
}

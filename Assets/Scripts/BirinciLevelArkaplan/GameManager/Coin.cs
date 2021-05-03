using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public ParticleSystem efekt;
    public AudioSource pses;

    // Start is called before the first frame update
    void Start()
    {
        pses = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
          }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Karakter")
        //Coin ekler
        {
            GameDataManager.AddCoins(24);
            GameSharedUI.Instance.UpdateCoinsUIText();
            pses.Play();
            StartCoroutine(WaitBefore());
      

        }

    }
    IEnumerator WaitBefore()    
    {
        Instantiate(efekt, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        Destroy(this.gameObject);

    }
}

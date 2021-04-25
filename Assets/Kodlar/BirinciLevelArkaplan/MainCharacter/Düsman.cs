using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Düsman : MonoBehaviour
{
    public GameObject efekt;
    public Animator ani;
    private RipplePostProccessor CamRipple;
    public AudioSource cses;
    // Start is called before the first frame update
    void Start()
    {
        cses = GetComponent<AudioSource>();
        ani.enabled = false;
        CamRipple = Camera.main.GetComponent<RipplePostProccessor>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {


    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Zemin")
        {
            Destroy(this.gameObject);

        }
        if (other.gameObject.tag == "Karakter")

        {
            other.gameObject.transform.GetComponent<Animator>().SetInteger("Damage", 1);
            other.gameObject.transform.GetComponent<Animator>().SetInteger("WhichCharacter", int.Parse(other.gameObject.name));
           
            cses.Play();
            CamRipple.RippleEffect();
            StartCoroutine(WaitBefore());

            Hak.kalanCan -= 1;
            
            
        }
     

    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Karakter")

        {

            
                other.gameObject.transform.GetComponent<Animator>().SetInteger("Damage", 0);
                other.gameObject.transform.GetComponent<Animator>().SetInteger("WhichCharacter", 0);

            
        }

    }
  
    IEnumerator WaitBefore()
    {
        ani.enabled = true;
        Instantiate(efekt, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);

    }
}

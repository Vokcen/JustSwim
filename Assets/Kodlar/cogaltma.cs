using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cogaltma : MonoBehaviour
{ 
    [Header("Objeler")]
    public GameObject slot;
    public List<itemler> items;
    public Image ortadakiresim;

    [Header("Para")]
    public int Para;

    void Start()
    {
        MarketCagir();
        ortadakiresim.sprite = items[0].Resim;
    }
    void MarketCagir()
    {
        for (int i = 0; i < items.Count; i++)
        {
            GameObject cogalanslot = Instantiate(slot, transform);
            cogalanslot.GetComponent < Image>().sprite = items[i].Resim;
            int gececi = i;
           cogalanslot.transform.Find("Týklanacak").GetComponent<Button>().onClick.AddListener(()=> satýnal(gececi,cogalanslot)); 

        }
    }
    public void satýnal(int id, GameObject obje)
    {
        if (Para >= items[id].Fiyat)
        {
            ortadakiresim.sprite = items[id].Resim;
            obje.transform.Find("Týklanacak").transform.Find("Text").GetComponent<Text>().text = "Satýn alýndý";
            Para -= items[id].Fiyat;
            items[id].Alýnmadurum = true;

        }
        else
        {
            Debug.Log("Yetersiz miktar");
        }
        if (items[id].Alýnmadurum)
        {
         
            ortadakiresim.sprite = items[id].Resim;
        }    
          
        // oyun içi karakteri spawnlama
    }
    [System.Serializable]
    public class itemler    {
        public string Ýsim;
        public Sprite Resim;
        public int Fiyat;
        public bool Alýnmadurum;

        public itemler(string isim, Sprite resim, int fiyat,bool alýnmadurum)
        {
            Ýsim = isim;
            Resim = resim;
            Fiyat = fiyat;
            Alýnmadurum = alýnmadurum;
        }
    }

   
}

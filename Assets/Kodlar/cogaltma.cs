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
           cogalanslot.transform.Find("T�klanacak").GetComponent<Button>().onClick.AddListener(()=> sat�nal(gececi,cogalanslot)); 

        }
    }
    public void sat�nal(int id, GameObject obje)
    {
        if (Para >= items[id].Fiyat)
        {
            ortadakiresim.sprite = items[id].Resim;
            obje.transform.Find("T�klanacak").transform.Find("Text").GetComponent<Text>().text = "Sat�n al�nd�";
            Para -= items[id].Fiyat;
            items[id].Al�nmadurum = true;

        }
        else
        {
            Debug.Log("Yetersiz miktar");
        }
        if (items[id].Al�nmadurum)
        {
         
            ortadakiresim.sprite = items[id].Resim;
        }    
          
        // oyun i�i karakteri spawnlama
    }
    [System.Serializable]
    public class itemler    {
        public string �sim;
        public Sprite Resim;
        public int Fiyat;
        public bool Al�nmadurum;

        public itemler(string isim, Sprite resim, int fiyat,bool al�nmadurum)
        {
            �sim = isim;
            Resim = resim;
            Fiyat = fiyat;
            Al�nmadurum = al�nmadurum;
        }
    }

   
}

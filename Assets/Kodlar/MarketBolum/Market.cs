using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Market : MonoBehaviour
{    [System.Serializable] class shopitem
    {
        public Sprite image;
        public int Price;
        public bool IsPurchased = false;
    }

    [SerializeField] List<shopitem> ShopitemsList;
    [SerializeField] Animator noCoinsAnim;
    [SerializeField] Text CoinsText;
  
      GameObject itemTemplate;
    [SerializeField] Transform shopScroollView;
    GameObject g;
    Button buyBtn;
    void Start()
    {
        
        itemTemplate = shopScroollView.GetChild(0).gameObject;

        int len = ShopitemsList.Count; 
        for (int i = 0; i < len; i++)
        {
            g = Instantiate(itemTemplate, shopScroollView);
            g.transform.GetChild(0).GetComponent<Image>().sprite=ShopitemsList[i].image;
            g.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = ShopitemsList[i].Price.ToString();
            buyBtn = g.transform.GetChild(2).GetComponent<Button>();
            buyBtn.interactable = !ShopitemsList[i].IsPurchased;
            buyBtn.AddEventListener(i,OnShopItemBtnClicked);

        }
        Destroy(itemTemplate);
        // Para metni
        SetCoinsU�();
    }
   
    void    OnShopItemBtnClicked(int itemIndex)
    {
        if (Game.Instance.HasEnoughCoins(ShopitemsList[itemIndex].Price))
        {
            Game.Instance.UseCoins(ShopitemsList [itemIndex].Price);
            //Sat�n alma
            ShopitemsList[itemIndex].IsPurchased = true;
            // pasif b�rakma
            buyBtn = shopScroollView.GetChild(itemIndex).GetChild(2).GetComponent<Button>();
            buyBtn.interactable = false;
            buyBtn.transform.GetChild(0).GetComponent<Text>().text = "SATIN ALINDI";
            // Para metni
            SetCoinsU�();
        }
        else
        {
            noCoinsAnim.SetTrigger("NoCoins");
            Debug.Log("Yetersiz Para");
        }
       
    }
   // Market    Para U�
   void SetCoinsU�()
    {
        CoinsText.text = Game.Instance.coins.ToString();

    }
    /*-----------------MarketiA��pKapatma------------------*/
    public void Openshop()
    {
        gameObject.SetActive (true);
        Debug.Log("�al��t�");
    }
    public void CloseShop()
    {
        gameObject.SetActive(false); Debug.Log("�al��t�");
    }
     
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class ChacterShopUI : MonoBehaviour
{
    [Header("Layout Settings")]
    [SerializeField] float itemSpacing = .5f;
    float itemHeight;


    [Header("UI Elements")]
    [SerializeField] Image selectedChacterIcon;
    [SerializeField] Transform shopMenu;
    [SerializeField] Transform shopItemsContainer;
    [SerializeField] GameObject itemPrefab;
    [Space(20)]
    [SerializeField] ChacterShopDataBase ChacterDB;
    
    [Space(20)]
    [Header("Shop Events")]
    [SerializeField] GameObject shopUI;
    [SerializeField] Button openShopButton;
    [SerializeField] Button closeShopButton;
    [SerializeField] Button scrollUpButton;

    [Space(20)]
    [Header("Main Menu")]
    [SerializeField] Image mainMenuChacterImage;
    [SerializeField] TMP_Text mainMenuChacterName;

    [Space(20)]
    [Header("Scroll Wiew")]
    [SerializeField] ScrollRect scroolRect;
    [SerializeField] GameObject topScrollFade;
    [SerializeField] GameObject bottomScrollFade;


    [Space(20)]
    [Header("SatýnAlmaFx& Hata Mesajý")]
    [SerializeField] ParticleSystem purchaseFx;
    [SerializeField] Transform purchaseFxpos;
    [SerializeField] TMP_Text noEnoughCoinsText;



    int newSelectedItemIndex = 0;
    int previousSelectedItemIndex = 0;


    void Start()
    {
        purchaseFx.transform.position = purchaseFxpos.position;
        AddShopEvents();
        GenerateShopItemsUI();
        //seçilmiþ karakter
        SetSelectedChacter();

        //ui itemleri
        SelectItemUI(GameDataManager.GetSelectedChacterIndex());
        //Karakter görünüþ deðiþtirme
        ChangePlayerSkin();
        //auto scrool shoptaki seçilmiþ karaktere
        AutoScrollShopList(GameDataManager.GetSelectedChacterIndex());


    }
    void AutoScrollShopList(int itemIndex)
    {
        scroolRect.verticalNormalizedPosition = Mathf.Clamp01(1f-(itemIndex/(float)(ChacterDB.ChacterCounts-1)));

    }
    void SetSelectedChacter()
    {
        //Get saved index
        int index = GameDataManager.GetSelectedChacterIndex();

        //set selected chacter
        GameDataManager.SetSelectedChacter(ChacterDB.GetChacter(index), index);
        //Select UI Item
        SelectItemUI(GameDataManager.GetSelectedChacterIndex());
        //update Player Skin(Karakter Görünüþ güncelleme)
        ChangePlayerSkin();
    }
    void GenerateShopItemsUI()
    {
        //Loop throw save purchased items and make them as purchased in the database array
        for (int i = 0; i < GameDataManager.GetAllPurchasedchacter().Count; i++)
        {
            int purchasedChacterIndex = GameDataManager.GetPurchChacter(i);
            ChacterDB.PurchaseChacter(purchasedChacterIndex);
        }


        //delete items template after caulcate
        itemHeight = shopItemsContainer.GetChild(0).GetComponent<RectTransform>().sizeDelta.y;
        Destroy(shopItemsContainer.GetChild(0).gameObject);
        shopItemsContainer.DetachChildren();
        //Generate items
        for (int i = 0; i < ChacterDB.ChacterCounts; i++)
        {
            Chacter chacter = ChacterDB.GetChacter(i);
            ChacterItemUI uiItem = Instantiate(itemPrefab, shopItemsContainer).GetComponent<ChacterItemUI>();
            //move item pos
            uiItem.SetItemPosition(Vector2.down * i * (itemHeight+itemSpacing));
            //set hierarcy name
            uiItem.gameObject.name = "item" + i + "-" + chacter.name;


            //add info uý (one item)
            uiItem.SetChacterName(chacter.name);
            uiItem.SetChacterImage(chacter.image);
            uiItem.SetChacterSpeed(chacter.speed);
            uiItem.SetChacterPower(chacter.power);
            uiItem.SetChacterPrice(chacter.price);
            if (chacter.isPurchased)
                //karakter satýn aldýysa
            {
                uiItem.SetChacterasPurchased();
                uiItem.OnItemSelect(i, OnItemSelected);
            }
            else
            {
                //karakter satýn alýnmadýysa
                uiItem.SetChacterPrice(chacter.price);
                uiItem.OnItemPurchase(i, OnItemPurchased);
            }
            // item container size
            shopItemsContainer.GetComponent<RectTransform>().sizeDelta =
                Vector2.up * ((itemHeight + itemSpacing) * ChacterDB.ChacterCounts+itemSpacing);
        }
    }
   void  ChangePlayerSkin()
    {
        Chacter chacter = GameDataManager.GetSelectedChacter();
        if(chacter.image != null)
        {
            mainMenuChacterImage.sprite = chacter.image;
            mainMenuChacterName.text = chacter.name;
            // Seçilen karakter ve karakter resmi

            selectedChacterIcon.sprite = GameDataManager.GetSelectedChacter().image;
        }
    }
    void OnItemSelected(int index)
    {
        //Seçilen item
        SelectItemUI(index);
       
        //Save Data(Kaydetme)
        GameDataManager.SetSelectedChacter(ChacterDB.GetChacter(index), index);
        //Change Player Skin(Karakter görünüþ deðiþtirme)
        ChangePlayerSkin();
    }
    void SelectItemUI(int itemIndex)
    {
        previousSelectedItemIndex = newSelectedItemIndex;
        newSelectedItemIndex = itemIndex;

        ChacterItemUI prevUiItem = GetItemUI(previousSelectedItemIndex);
        ChacterItemUI newUiItem = GetItemUI(newSelectedItemIndex);

        prevUiItem.DeSelectItem();
        newUiItem.SelectItem();
    }
    ChacterItemUI GetItemUI(int Index)
    {
        return shopItemsContainer.GetChild(Index).GetComponent<ChacterItemUI>();
    }
    void OnItemPurchased(int index)
    {
        Chacter chacter = ChacterDB.GetChacter(index);
        ChacterItemUI uiItem = GetItemUI(index);

        if (GameDataManager.CanSpendCoins(chacter.price))
        {
            //Procced with the purchase operation
            GameDataManager.SpendCoins(chacter.price);
            //Purchase.fx
            purchaseFx.Play();
            //update coins   uý text
            GameSharedUI.Instance.UpdateCoinsUIText();

            ChacterDB.PurchaseChacter(index);

            uiItem.SetChacterasPurchased();
            uiItem.OnItemSelect(index,OnItemSelected);

            //add Purchased item to shop data
            GameDataManager.AddPurchasedChacter(index);

        }
        else
        {
            //no enough coins
            AnimateNoMoreCoinsText();
            uiItem.AnimateShakeItem();
                }
    }
    void AnimateNoMoreCoinsText()
    {
        //complete animation(if its running)
        noEnoughCoinsText.transform.DOComplete();
        noEnoughCoinsText.DOComplete();

        noEnoughCoinsText.transform.DOShakePosition(3f, new Vector3(5f, 0f, 0f), 10, 0);
        noEnoughCoinsText.DOFade(1f, 3f).From(0f).OnComplete(() =>
        {
            noEnoughCoinsText.DOFade(0f, 1f);
        });
    
    }

        void AddShopEvents()
    {
        openShopButton.onClick.RemoveAllListeners();
        openShopButton.onClick.AddListener(OpenShop);
        
        closeShopButton.onClick.RemoveAllListeners();
        closeShopButton.onClick.AddListener(CloseShop);

        scroolRect.onValueChanged.RemoveAllListeners();
        scroolRect.onValueChanged.AddListener(OnShopListScroll);

        scrollUpButton.onClick.RemoveAllListeners();
        scrollUpButton.onClick.AddListener(OnScrollUpClicked);

    }
    
    void OnScrollUpClicked()
    {
        scroolRect.DOVerticalNormalizedPos(1f, .5f).SetEase(Ease.OutBack);

    }
    void OnShopListScroll(Vector2 value)
    {
        float scroolY = value.y;
        //Top fade
        if (scroolY<1f)
        
            topScrollFade.SetActive(true); 
        
        else
        
            topScrollFade.SetActive(false);

        
        //bottom Fade
        if (scroolY > 0f)
        
            bottomScrollFade.SetActive(true);
        
        else
       
            bottomScrollFade.SetActive(false);
        //yukarý kaydýrma butonu
        if (scroolY < .7f)
            scrollUpButton.gameObject.SetActive(true);
        else
            scrollUpButton.gameObject.SetActive(false);




    }
    void OpenShop()
    {
        shopUI.SetActive(true);
    }
    void CloseShop()
    {
        shopUI.SetActive(false);
    }
}

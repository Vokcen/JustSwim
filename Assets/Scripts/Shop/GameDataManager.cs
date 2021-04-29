using System.Collections.Generic;


//Shop Data Tutucu
[System.Serializable]public class ChactersShopData
{
	public List<int> purchasedChacterIndex = new List<int>();
}
//player data tutucu
[System.Serializable] public class PlayerData
{
	public int coins = 0;
	public int selectedChacterIndex = 0;
}

public static class GameDataManager
{
	static PlayerData playerData = new PlayerData();
	static ChactersShopData chactersShopData = new ChactersShopData();

	static Chacter selectedChacter;

	static GameDataManager(){
		LoadPlayerData();
		LoadChactersShopData();
	}

	//Player Data Methods -----------------------------------------------------------------------------
	public static Chacter GetSelectedChacter()
	{
		return selectedChacter;
	}
	public static void SetSelectedChacter(Chacter chacter, int index)
    {
		selectedChacter = chacter;
		playerData.selectedChacterIndex = index;
		SavePlayerData();
    }
	public static int GetSelectedChacterIndex()
    {
		return playerData.selectedChacterIndex;
    }
	
	public static int GetCoins ()
	{
		return playerData.coins;
	}

	public static void AddCoins (int amount)
	{
		playerData.coins += amount;
		SavePlayerData ();
	}

	public static bool CanSpendCoins (int amount)
	{
		return (playerData.coins >= amount);
	}

	public static void SpendCoins (int amount)
	{
		playerData.coins -= amount;
		SavePlayerData ();
	}

	static void LoadPlayerData ()
	{
		playerData = BinarySerializer.Load<PlayerData> ("player-data.txt");
		UnityEngine.Debug.Log ("<color=green>[PlayerData] Loaded.</color>");
	}

	static void SavePlayerData ()
	{
		BinarySerializer.Save (playerData, "player-data.txt");
		UnityEngine.Debug.Log ("<color=magenta>[PlayerData] Saved.</color>");
	}
	//Chacter ShopData Metodu---------------------
	public static void AddPurchasedChacter(int chacterIndex)
    {
		chactersShopData.purchasedChacterIndex.Add(chacterIndex);
		SaveChactersShopData();
    }
	public static List<int>GetAllPurchasedchacter ()
	{
		return chactersShopData.purchasedChacterIndex;
	}
	public static int GetPurchChacter(int index)
	{
		return chactersShopData.purchasedChacterIndex[index];
	}
	static void LoadChactersShopData()
	{
		chactersShopData = BinarySerializer.Load<ChactersShopData>("chacters-Shop-Data-data.txt");
		UnityEngine.Debug.Log("<color=green>[ChactersShopData] Loaded.</color>");
	}

	static void SaveChactersShopData()
	{
		BinarySerializer.Save(chactersShopData, "chacters-Shop-Data-data.txt");
		UnityEngine.Debug.Log("<color=magenta>[ChactersShopDataData] Saved.</color>");
	}
}

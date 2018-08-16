using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Gacha : MonoBehaviour
{
    //各個稀有度各要放幾個到陣列中 {稀有度, 數量}
    public int[,] Probability = new int[,]
    {
        { 3, 80 },
        { 4, 15 },
        { 5, 5 }
    };

    //放抽抽物品的List
    List<int> GachaList = new List<int>();

    // Use this for initialization
    void Start ()
    {
        InitializeGachaList();

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    //初始化抽抽list
    public void InitializeGachaList()
    {
        //放進list
        for(int i = 0; i < Probability.Length; i++)
        {
            int rare = Probability[i, 0];
            int count = Probability[i, 1];

            for(int j = 0; j < count; j++)
            {
                GachaList.Add(rare);
            }
        }

        //打亂順序
        for (int i = 0; i < GachaList.Count; i++)
        {

            int n = GetRandomInt(0, GachaList.Count);

            int temp = GachaList[i];
            GachaList[i] = GachaList[n];
            GachaList[n] = temp;


        }
    }

    //單抽
    public int GachaOne()
    {
        int GetItem = 0;

        int n = GetRandomInt(0, GachaList.Count);

        GetItem = GachaList[n];

        return GetItem;
    }

    //10連抽
    public int[] GachaTen()
    {
        int[] GetItem = new int[10];

        for(int i = 0; i < 10; i++)
        {
            int n = GetRandomInt(0, GachaList.Count);
            GetItem[i] = GachaList[n];
        }

        return GetItem;
    }

    //隨機一個數字
    public int GetRandomInt(int min, int max)
    {
        System.Random rnd = new System.Random(Guid.NewGuid().GetHashCode());
        int n = rnd.Next(min, max);

        return n;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostIdentity : MonoBehaviour
{
    //Di sini semua hitungan (dr upgrade upgrade) bakal ada di sini sebelum ntr dimasukkin ke behavio (jalan + total makanan yg dibeli)
    [SerializeField] private  string nama;
    [SerializeField] private  int levelUpgrade;
    [SerializeField] private  int totalKerakTelorawal;
    [SerializeField] private  float waktuDatangawal;
    [SerializeField] private  float hitunganwaktuDatang; //INI CEK RUMUS DI EXCEL

    private int totalHantuDatangawal = 1;

    //jgn lupa minta data-data dr class lain

    

    //Variable buat hitungan
    private int totalKerakTelorAkhir;
    private float waktuDatangAkhir;
    private int totalHantuDatangAkhir;

    bool adaUpgrade;//notif dr code lain jg

    GhostBehavio GhostB;



    void Awake() { //THIS IS ONLY UTK KASIHTAU KE YG LAIN ADA UPGRADE GA AAPLAGI BUAT YG GA ADA HUBUNGANNYA AMA SHOP
        GhostB = GetComponentInParent<GhostBehavio>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        count();
        adaUpgrade = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(adaUpgrade){
            GhostB.adaUpgrade1 = true;
            count();
            adaUpgrade = false;
        }
    }

    public int getKerakTelor(){
        return totalKerakTelorAkhir;
    }
    public int getTotalHantu(){
        return totalHantuDatangAkhir;
    }
    public float getWaktuDatang(){
        return waktuDatangAkhir;
    }
    public int getLevel(){
        return levelUpgrade;
    }


    void upgrade_Level(){
        levelUpgrade++;
        adaUpgrade = true;
    }

    void count(){
        //TotalKerakTelor
        int totalKerakTelor1 = (totalKerakTelorawal*levelUpgrade);
        totalKerakTelorAkhir = totalKerakTelor1;//Cek Upg Toko 1. Outlet 2. Papan Reklame 3.Item msg msg hantu kalo ada

        //WaktuDatang
        waktuDatangAkhir = waktuDatangawal - (hitunganwaktuDatang*(levelUpgrade-1));

        //totalHantu
        totalHantuDatangAkhir = totalHantuDatangawal;//Cek Upg Toko 1. Terompet Tanduk
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostIdentity : MonoBehaviour
{
    // Masih byk yg blm di sini yaaa
    
    //Di sini semua hitungan (dr upgrade upgrade) bakal ada di sini sebelum ntr dimasukkin ke behavio (jalan + total makanan yg dibeli)
    [SerializeField] private  string nama;
    [SerializeField] private  int levelUpgrade;
    [SerializeField] private  int totalKerakTelorawal;
    [SerializeField] private  float waktuDatangawal;
    [SerializeField] private  float hitunganwaktuDatang; //INI CEK RUMUS DI EXCEL

    // Harga Upgrade
    [SerializeField] private int hargaKoinUpgradeawal;
    [SerializeField] private int hargaFPUpgradeawal;

    private int totalHantuDatangawal = 1;

    //jgn lupa minta data-data dr class lain
    public GameObject player;
    Player Players;
    

    //Variable buat hitungan
    private int totalKerakTelorAkhir;
    private float waktuDatangAkhir;
    private int totalHantuDatangAkhir;
    private int hargaKoinUpgradeAkhir;
    private int hargaFPUpgradeAkhir;

    bool adaUpgrade;//notif dr code lain jg

    GhostBehavio GhostB;



    void Awake() { //THIS IS ONLY UTK KASIHTAU KE YG LAIN ADA UPGRADE GA AAPLAGI BUAT YG GA ADA HUBUNGANNYA AMA SHOP
        GhostB = GetComponentInParent<GhostBehavio>();
        Players = player.GetComponent<Player>();
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


    public void upgrade_Level(){ //INI buat button Upgrade
        if(levelUpgrade == 20){
            Players.sudahMaxUpgrade();
        }
        else{
            if(Players.getKoin() >= hargaKoinUpgradeAkhir && Players.getFP() >= hargaFPUpgradeAkhir){
                levelUpgrade++;
                Players.changeKoin(-hargaKoinUpgradeAkhir);
                Players.changeFP(-hargaFPUpgradeAkhir);
                // jgn lupa ganti hargaupgradenya, eh tp gausa ya?
                adaUpgrade = true;
            }
            else{
                Players.notEnough();
            }
        }
        
        
    }

    public void beli(){
        int sempanHarga = Players.getHarga();
        int totalHarga = totalKerakTelorAkhir * sempanHarga;
        int total = totalHarga; //Ntr ditambahin bonus : Kompor, Wajan Kecil, 
        Players.changeKoin(total*totalHantuDatangAkhir);
        Debug.Log(Players.getKoin());
    }

    void count(){
        //TotalKerakTelor
        int totalKerakTelor1 = (totalKerakTelorawal*levelUpgrade);
        totalKerakTelorAkhir = totalKerakTelor1;//Cek Upg Toko 1. Outlet 2. Papan Reklame 3.Item msg msg hantu kalo ada 4. Efek negative dari miniBoss //mungkin nanti kita vikin syarat aja buat bedain ghost bioasa ama yg ada item tmbhn.

        //WaktuDatang
        waktuDatangAkhir = waktuDatangawal - (hitunganwaktuDatang*(levelUpgrade-1));//

        //totalHantu
        totalHantuDatangAkhir = totalHantuDatangawal;//Cek Upg Toko 1. Terompet Tanduk
        hargaKoinUpgradeAkhir = hargaKoinUpgradeawal*levelUpgrade;//Masih blm dpt rumus pasnya...
        hargaFPUpgradeAkhir = hargaFPUpgradeawal*levelUpgrade;//Masih blm dpt rumus pasnya...
        totalHantuDatangAkhir = totalHantuDatangawal;// Dikali ama Terompet Tanduk Nanti jgn lupa
    }

}

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
    Toko tokoupgrade;
    

    //Variable buat hitungan
    private int totalKerakTelorAkhir;
    private float waktuDatangAkhir;
    private int totalHantuDatangAkhir;
    private int hargaKoinUpgradeAkhir;
    private int hargaFPUpgradeAkhir;

    bool adaUpgrade;//notif dr code lain jg
    public bool adaUpgradetoko;//Ini biar ngitung di sini aja ga di ghostbehavio

    GhostBehavio GhostB;


    // buat tau ini ghost yg mana (8,9,10,11 --> ini buat ghost yg ada efek d toko, sisanya 0)
    [SerializeField] private int ghost;

    void Awake() { //THIS IS ONLY UTK KASIHTAU KE YG LAIN ADA UPGRADE GA AAPLAGI BUAT YG GA ADA HUBUNGANNYA AMA SHOP
        GhostB = GetComponentInParent<GhostBehavio>();
        Players = player.GetComponent<Player>();
        tokoupgrade = player.GetComponent<Toko>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        count();
        adaUpgrade = false;
        adaUpgradetoko = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(adaUpgrade){
            GhostB.adaUpgrade1 = true;
            count();
            adaUpgrade = false;
        }
        if(adaUpgradetoko){
            count();
            adaUpgradetoko = false;
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
        // Data toko
        int Kompor = tokoupgrade.getDataInt(2);//persenan dr total awal
        int wajanK = tokoupgrade.getDataInt(3);// sama

        int total = totalHarga + Kompor/100*totalHarga + wajanK/100*totalHarga; //Ntr ditambahin bonus : Kompor, Wajan Kecil, 
        Players.changeKoin(total*totalHantuDatangAkhir);
        Debug.Log(Players.getKoin());
    }

    void count(){
        // Data toko
        int TerompetData = tokoupgrade.getDataInt(0);//ditambah
        int Outlet = tokoupgrade.getDataInt(1);//dikali ke total awal
        int papan = tokoupgrade.getDataInt(4);//persenan dr total awal

        // efek miniboss
        
        
        
        
        //TotalKerakTelor
        int totalKerakTelor1 = (totalKerakTelorawal*levelUpgrade);
        
        
        //Cek Upg Toko 1. Outlet 2. Papan Reklame 3.Item msg msg hantu kalo ada 4. Efek negative dari miniBoss //mungkin nanti kita vikin syarat aja buat bedain ghost bioasa ama yg ada item tmbhn.

        if(ghost != 0){
            int tambahan = tokoupgrade.getDataInt(ghost);
            totalKerakTelor1 += tambahan;
        }
        totalKerakTelorAkhir = totalKerakTelor1*Outlet + totalKerakTelor1*papan/100;

        //WaktuDatang
        waktuDatangAkhir = waktuDatangawal - (hitunganwaktuDatang*(levelUpgrade-1));//negatif miniboss jgn lupa dimasukkin ~ stlh ditotalin

        //totalHantu
        totalHantuDatangAkhir = totalHantuDatangawal + TerompetData;//Cek Upg Toko 1. Terompet Tanduk
        hargaKoinUpgradeAkhir = hargaKoinUpgradeawal*levelUpgrade;//Masih blm dpt rumus pasnya...
        hargaFPUpgradeAkhir = hargaFPUpgradeawal*levelUpgrade;//Masih blm dpt rumus pasnya...
        
    }

}

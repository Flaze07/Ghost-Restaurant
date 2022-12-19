using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BahanMakanan : MonoBehaviour
{
    // List bahan makananan~~~~~ urutan makanan ikutin tabel content stats~~
    [SerializeField] private string[] nama;
    [SerializeField] private int[] hargaawal;

    // uh.. ya
    private int[] hargaAkhir = {0,0,0,0,0,0,0,0,0,0,0,0};
    private int[] level = {0,0,0,0,0,0,0,0,0,0,0,0};
    private int[] Rank = {1,1,1,1,1,1,1,1,1,1,1,1};
    [SerializeField] private int[] upgrade_awal;
    private int[] upgrade_Akhir = {0,0,0,0,0,0,0,0,0,0,0,0};
    [SerializeField] private int[] hitunganx;
    
    private int totalKoinUpgrade = 0;

    Player player;

    private bool adaUpdateBahan;

    private void Awake() {
        player = GetComponentInParent<Player>();
        
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        setName();
        count();
        adaUpdateBahan = false;
    }

    /**
     * menginitialize variable name dengan nama yang benar
     */
    void setName()
    {
        nama = new string[12];
        nama[0] = "Telur Ayam";
        nama[1] = "Ebi";
        nama[2] = "Kelapa Parut";
        nama[3] = "Beras Ketan Putih";
        nama[4] = "Gula, Garam, & Merica";
        nama[5] = "Bawang Goreng";
        nama[6] = "Jahe";
        nama[7] = "Kencur";
        nama[8] = "Telur Bebek";
        nama[9] = "Cabai Merah";
        nama[10] = "Abon";
        nama[11] = "Mie";
    }

    // Update is called once per frame
    void Update()
    {
        if(adaUpdateBahan){
            count();
            adaUpdateBahan = false;
        }
    }

    void count(){
        totalKoinUpgrade = 0;
        for(int i=0;i<12;i++){
            hargaAkhir[i] = hargaawal[i] + hargaawal[i]*(level[i]);
            if(Rank[i]==1){
                upgrade_Akhir[i] = upgrade_awal[i]*level[i];
            }
            else{
                upgrade_Akhir[i] = upgrade_awal[i]*level[i] + hitunganx[i];
            }
        }
        for(int i=0;i<12;i++){
            totalKoinUpgrade += upgrade_Akhir[i];
        }
        player.changeHarga(totalKoinUpgrade);
    }


    /**
     * mendapatkan data berdasarkan index
     */
    public int getUpgrade(int x){
        return upgrade_Akhir[x];
    }
    public int getUpgradeawal(int x){
        return upgrade_awal[x];
    }
    public int gethitunganx(int x){
        return hitunganx[x];
    }
    public int getRankBM(int x){
        return Rank[x];
    }
    public int getLevelBM(int x){
        if(Rank[x]==1){
            return level[x];
        }
        else{
            return level[x]-25;
        }
    }
    public int getHargaBM(int x){
        return hargaAkhir[x];
    }
    public string getName(int x){
        return nama[x];
    }

    /**
     * mencari index dari sebuah nama
     */
    public int findName(string name)
    {
        int namaIdx = -1;
        for(int i = 0; i < nama.Length; ++i)
        {
            if(nama[i] == name)
            {
                namaIdx = i;
                break;
            }
        }

        return namaIdx;
    }

    /**
     * setter untuk menginitialize value dari saved data
     */
    public void setRank(int idx, int newRank)
    {
        Rank[idx] = newRank;
    }

    public void setLevel(int idx, int newLevel)
    {
        level[idx] = newLevel;
    }


    // BUAT AKTIFIN UPGRADE PERLU BUTTON , NTR BUTTONNYA DIISI X OKE OKE OKE, YG DIBWH INI NTR DI BUTTON NGEL
    // trus d code baru ini nanti jg bakal jd tmpt isi sprite
    // public void upgrade1(){
    //     upgrade_levBahan(0);
    // }
    // public void upgrade1(){
    //     upgrade_levBahan(0);
    // }
    public void upgrade_levBahan(int x){
        if(level[x]==50){
            player.sudahMaxUpgrade();
        }
        else{
            if(player.getKoin()>=hargaAkhir[x]){
                level[x]++;
                if(level[x] == 26){
                    Rank[x] = 2;
                }
                player.changeKoin(-hargaAkhir[x]);
                adaUpdateBahan = true;
            }
            else{
                player.notEnough();
            }
        }
    }


// aa
    // cek unlock ato tidak - eh tp gatau deh, keknya bs di unlock d canvas biar gabisa diteken..
    // private bool upgrade_cek(int x){
    //     if(x == 8){
    //         // cek level Ghostnya, kalo level msh 0, bool false, kalo ga ya true
    //     }
    //     if(x == 9){
    //         // cek level Ghostnya, kalo level msh 0, bool false, kalo ga ya true
    //     }
    //     if(x == 10){
    //         // cek level Ghostnya, kalo level msh 0, bool false, kalo ga ya true
    //     }
    //     if(x == 11){
    //         // cek level Ghostnya, kalo level msh 0, bool false, kalo ga ya true
    //     }
    // }




}

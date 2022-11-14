using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private string nama;
    private int koinDarah = 0;
    private int famePoint = 0;
    private int hargaKerakTelorAwal = 1;
    private int hargaKerakTelorAkhir;

    // Cek tempat di mana(?)

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Hargakeraktelor " + hargaKerakTelorAkhir);
        // Debug.Log(koinDarah);
    }


    public int getKoin(){ //kalo org mo upgrade cek ini
        return koinDarah;
    }
    public void changeKoin(int koin){ //masukkin + - kalo mo pake
        koinDarah += koin;
    }
    



    public int getFP(){ //kalo org mo upgrade cek ini
        return famePoint;
    }
    public void changeFP(int poin){ //masukkin + - kalo mo pake
        famePoint += poin;
    }

    //Kalo player ga punya uang cukup utk upgrade
    public void notEnough(){
        //Ntr ada Canvas d sini yg blg not enough begitu.
    }
    public void sudahMaxUpgrade(){
        //Ntr ada Canvas d sini yg blg not enough begitu.
    }





    public int getHarga(){ //Kalo org mo beli kan cek ini
        return hargaKerakTelorAkhir;
    }
    public void changeHarga(int hargaKT){ //masukkin + - kalo mo pake
        hargaKerakTelorAkhir = hargaKerakTelorAwal + hargaKT;
    }
}

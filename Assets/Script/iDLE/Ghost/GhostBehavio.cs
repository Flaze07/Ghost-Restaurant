using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBehavio : MonoBehaviour
{
    [SerializeField] private Transform pos1, tengah, pos2;
    GhostIdentity GhostID;
    // private int KerakTelor;//Mikir dl..
    private float waktuDatang;

    private Vector3 tujuan;
    private float simpanWaktu1,simpanWaktu2,simpanWaktu3,timer;//bagi jam jd 3, jd 1 buat awal ke tengah, 2 nunggu tengah bntr,3 tengah ke akhir

    public bool adaUpgrade1; //gabisa minta dr sebelah, soalnya lsg ke false, eh tp gatau de...


    private int numberRandom;
    private float kecepatan, jarak1, jarak2;
    private void Awake() {
        GhostID = GetComponentInParent<GhostIdentity>();
    }
    // Start is called before the first frame update
    void Start()
    {
        jarak1 = pos1.position.x - tengah.position.x;
        jarak2 = tengah.position.x - pos2.position.x;
        hitung();
        tujuan = pos1.position;
        adaUpgrade1 = false;
        // kecepatan = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(KerakTelor);
        // Debug.Log(waktuDatang);
        
        if(GhostID.getLevel() >= 1){
            if(adaUpgrade1 && (transform.position == pos1.position ||transform.position == pos2.position)) {
                hitung(); // kalo ada upgrade hrs hitung ulang dl tp kalo si target dh nyampe posisi
                adaUpgrade1 = false;
                Debug.Log("1");
            }
            else if(transform.position == pos1.position ||transform.position == pos2.position){
                numberRandom = Random.Range(1,3);
                // Debug.Log("2");
                Debug.Log(numberRandom);
                if(numberRandom == 1){
                    transform.position = pos1.position;
                    kecepatan = jarak1/simpanWaktu1;
                    //INI NTR ROTASI JGN LUPA 
                }
                else{
                    transform.position = pos2.position;
                    kecepatan = jarak2/simpanWaktu1;
                    //INI NTR ROTASI JGN LUPA 
                }
                    
                tujuan = tengah.position;
            }
            else if(transform.position == tengah.position){
                //WAIT
                timer -= Time.deltaTime;
                if(timer <=0){
                    timer = simpanWaktu2;
                        
                    if(numberRandom == 1){
                        kecepatan = jarak2/simpanWaktu3;
                        tujuan = pos2.position;
                            
                    }
                    else if(numberRandom == 2){
                        kecepatan = jarak1/simpanWaktu3;
                        tujuan = pos1.position;
                    }
                        
                }

                    
            }
            move();
        }
        // else{
        //     kecepatan = 0;
        // }
        


    }

    void move(){
        transform.position = Vector3.MoveTowards(transform.position, tujuan, kecepatan * Time.deltaTime);
    }


    void hitung(){
        // KerakTelor = GhostID.getKerakTelor();
        waktuDatang = GhostID.getWaktuDatang();


        simpanWaktu1 = waktuDatang/2;
        simpanWaktu3 = waktuDatang - simpanWaktu1;
        simpanWaktu2 = simpanWaktu3/2;
        timer = simpanWaktu2;
        simpanWaktu3 = simpanWaktu3-simpanWaktu2;
    }
}

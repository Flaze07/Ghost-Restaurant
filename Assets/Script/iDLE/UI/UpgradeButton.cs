using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;
    BahanMakanan bahanmakanan;
    [SerializeField]private int bahanmakananx;
    private void Awake() {
        bahanmakanan = player.GetComponent<BahanMakanan>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void upgradeBahanMakanan(){
        bahanmakanan.upgrade_levBahan(bahanmakananx);
    }



}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DataToSave
{
    public class RankData: Dictionary<string, int> {}
    public class LevelData: Dictionary<string, int> {}

    public RankData rankData = new RankData();
    public LevelData levelData = new LevelData();
}

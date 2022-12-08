using System;
using System.Collections.Generic;

namespace SaveSystem
{
    public enum GameProgressAttributes { developmentProgress}
    //This object encompasses one save file. Each day is saved seperatly in a list Days
    [Serializable]
    public class GameProgress
    {
        public int currentDay;
        public int developmentProgress;
        public DaySaveObject[] Days;

        public PlayerData playerData = new PlayerData();
    }
}
using System;

using UnityEngine;

namespace Assets.Scripts
{
    public class GameState : GameFrame.Core.GameState
    {
        public GameState() : base()
        {
        }

        [SerializeField]
        private String currentLevel;
        public String CurrentLevel
        {
            get
            {
                return currentLevel;
            }
            set
            {
                if (currentLevel != value)
                {
                    currentLevel = value;
                }
            }
        }

        [SerializeField]
        private BasicShip ship;
        public BasicShip Ship
        {
            get
            {
                return ship;
            }
            set
            {
                if (ship != value)
                {
                    ship = value;
                }
            }
        }

        [SerializeField]
        private String currentBackground;
        public String CurrentBackground
        {
            get
            {
                return this.currentBackground;
            }
            set
            {
                if (this.currentBackground != value)
                {
                    this.currentBackground = value;
                }
            }
        }
    }
}

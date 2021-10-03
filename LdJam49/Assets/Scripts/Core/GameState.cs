using System;

using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public class GameState
    {
        public GameState()
        {
            id = Guid.NewGuid();
        }

        [SerializeField]
        private Guid id;
        public Guid ID
        {
            get
            {
                return this.id;
            }
        }

        [SerializeField]
        private String currentScene;
        public String CurrentScene
        {
            get
            {
                return currentScene;
            }
            set
            {
                if (currentScene != value)
                {
                    currentScene = value;
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
        private Int64 savedOnTicks;
        private DateTime? savedOn;
        public DateTime SavedOn
        {
            get
            {
                if ((!savedOn.HasValue) && (savedOnTicks > 0))
                {
                    savedOn = new DateTime(savedOnTicks);
                }

                return savedOn.GetValueOrDefault();
            }
            set
            {
                if (savedOn != value)
                {
                    savedOn = value;
                    savedOnTicks = value.Ticks;
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

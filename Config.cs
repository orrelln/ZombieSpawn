using System.ComponentModel;
using Exiled.API.Interfaces;

namespace ZombieSpawn
{
    public class Config : IConfig
    {
        [Description("Determines whether or not the plugin is enabled.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Whether or not to show debug logs.")]
        public bool Debug { get; set; } = true;

        [Description("Which respawn round to start respawning zombies on.")]
        public int RespawnOn { get; set; } = 2;

        [Description("Number of SCPs left that you start respawning a zombie.")]
        public int SCPCount { get; set; } = 1;
    }
}
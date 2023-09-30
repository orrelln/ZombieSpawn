using System;

using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Loader;
using Handlers = Exiled.Events.Handlers;

namespace ZombieSpawn
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Singleton;
        private EventHandlers handler;
        public static bool ScanInProgress = false;
        public static bool Force = false;
        public override void OnEnabled()
        {
            Singleton = this;
            handler = new EventHandlers(this);

            Handlers.Server.RoundStarted += handler.OnRoundStarted;
            Handlers.Server.RespawningTeam += handler.OnRespawned;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Handlers.Server.RoundStarted -= handler.OnRoundStarted;
            Handlers.Server.RespawningTeam -= handler.OnRespawned;

            handler = null;
            Singleton = null;

            base.OnDisabled();
        }

        public override string Name => "Zombie Spawn";
        public override string Author => "Nick";
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredExiledVersion => new Version(8, 2, 1);
        public override PluginPriority Priority => PluginPriority.High;
    }
}
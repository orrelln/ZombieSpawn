using System.Collections.Generic;

using Exiled.API.Features;
using PlayerRoles;
using Exiled.Events.EventArgs.Server;
using Exiled.API.Extensions;
using MEC;

namespace ZombieSpawn
{
    public class EventHandlers
    {
        private static Plugin plugin;
        private static int RespawnCount = 0;
        public EventHandlers(Plugin P) => plugin = P;

        private static List<Player> GetAliveScps()
        {
            List<Player> aliveScps = new List<Player> { };
            foreach (Player curPlayer in Player.List)
            {
                if (curPlayer.IsAlive && curPlayer.Role.Team == Team.SCPs)
                {
                    aliveScps.Add(curPlayer);
                }
            }
            return aliveScps;
        }

        public void OnRoundStarted()
        {
            RespawnCount = 0;
        }

        public void OnRespawned(RespawningTeamEventArgs ev)
        {
            RespawnCount++;

            if (RespawnCount >= plugin.Config.RespawnOn && GetAliveScps().Count <= plugin.Config.SCPCount)
            {
                Player randPlayer = Helper.GetRandomFromList(ev.Players);
                ev.Players.Remove(randPlayer);

                randPlayer.Role.Set(RoleTypeId.Scp0492);
                randPlayer.Position = RoleExtensions.GetRandomSpawnLocation(RoleTypeId.Scp049).Position;

                Timing.CallDelayed(30f, () =>
                {
                    Cassie.MessageTranslated(
                         "WARNING SCP 0 4 9 2 HAS BREACHED CONTAINMENT. PROCEED WITH CAUTION.",
                         "Warning, SCP-049-2 has breached containment. Proceed with caution.",
                         isNoisy: false);
                });
            }
        }
    }
}
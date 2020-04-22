using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smod2;
using Smod2.API;
using Smod2.EventHandlers;
using Smod2.Events;

namespace YYYIlike
{

    internal class CheckRun : IEventHandler, IEventHandler079LevelUp, IEventHandlerSpawn, IEventHandler079Lockdown, IEventHandlerPlayerDie, IEventHandlerRoundEnd, IEventHandlerGeneratorEjectTablet, IEventHandlerGeneratorUnlock, IEventHandlerCheckRoundEnd, IEventHandlerCallCommand, IEventHandlerRoundRestart ,IEventHandlerUpdate,IEventHandlerRoundStart ,IEventHandlerPlayerHurt 
    {
        // Fields
        private Plugin plugin;
        private int scp079id = -1;
        private int count = 0;
        private int num;
        private bool scp;
        private bool h;
        private bool choise;
        private DateTime updatatimersteal;
        private bool roundstart;
        private int time1;


        // Methods
        public CheckRun(Plugin plugin)
        {
            this.plugin = plugin;
        }

        public void On079LevelUp(Player079LevelUpEvent ev)
        {
            if(h == true)
            {
                ev.Player.Scp079Data.MaxAP = 130;
                ev.Player.Scp079Data.APPerSecond = 4;
                ev.Player.PersonalBroadcast(10, "<color=#FFC0CB>[消息]</color>\n你升级了,但是你的回复速度被限制到了4AP\n" + "你的电量被限制到了130点QAQ", false);
            }

        }

        public void On079Lockdown(Player079LockdownEvent ev)
        {
            if(h == true)
            {
                if (this.count > 4)
                {
                    if (new Random().Next(1, 100) > 50)
                    {
                        ev.Player.Kill(DamageType.TESLA);
                        ev.Player.PersonalBroadcast(10, "<color=#FFC0CB>[消息]</color>\n你因为关灯没关好把自己电源关了", false);
                    }
                }
                else
                {
                    this.count++;
                }
            }
                 

        }
        public void OnCallCommand(PlayerCallCommandEvent ev)
        {
            if (ev.Player.TeamRole.Role == Smod2.API.Role.SCP_079)
            {
                if (choise == false)
                {
                    if (ev.Command.Contains("scp"))
                    {
                        scp = true;
                        choise = true;
                        foreach(Player player in plugin.Server.GetPlayers())
                        {
                            if(player.TeamRole.Role == Smod2.API.Role.SCP_079)
                            {
                                player.SetRank("aqua", "SCP079 - 帮助SCP", null);
                            }
                        }
                        
                        plugin.Server.Map.Broadcast(10, "<color=#FFC0CB>---[SCP079]---</color>\n<color=aqua>人类感受恐惧吧 本局SCP079选择帮助SCP</color>\n<color=aqua>SCP不会受到电网伤害(人形scp除外)</color>", false);
                    }
                    if (ev.Command.Contains("h"))
                    {
                        foreach (Player player in plugin.Server.GetPlayers())
                        {
                            if (player.TeamRole.Role == Smod2.API.Role.SCP_079)
                            {
                                player.SetRank("aqua", "SCP079 - 最大电力:130 | 电力恢复:3AP/s   帮助人类", null);
                            }
                        }
                        h = true;
                        ev.Player.SetRank("aqua", "SCP079 - 最大电力:130 | 电力恢复:3AP/s   帮助人类", null);
                        choise = true;
                        plugin.Server.Map.Broadcast(10, "<color=#FFC0CB>---[SCP079]---</color>\n<color=aqua>SCP没想到吧我是25仔 本局SCP079选择帮助人类</color>\n<color=aqua>人类不会受到电网伤害</color>", false);
                        foreach (Player p in plugin.Server.GetPlayers())
                        {
                            if (p.TeamRole.Team == Smod2.API.Team.SCP)
                            {
                                if (p.TeamRole.Role != Smod2.API.Role.SCP_106)
                                {
                                    p.SetHealth(p.GetHealth() + 3000);
                                }
                            }
                        }
                    }
                }
            }

        }
        public void OnCheckRoundEnd(CheckRoundEndEvent ev)
        {
            if (this.scp079id != -1)
            {
                num = 0;
                int num2 = 0;
                int num3 = 0;
                int num4 = 0;
                int num5 = 0;
                foreach (Player player in this.plugin.PluginManager.Server.GetPlayers(""))
                {
                    if (player.TeamRole.Team == Smod2.API.Team.SCP)
                    {
                        num++;
                    }
                    if (player.TeamRole.Team == Smod2.API.Team.CHAOS_INSURGENCY)
                    {
                        num2++;
                    }
                    if (player.TeamRole.Team == Smod2.API.Team.SCIENTIST)
                    {
                        num3++;
                    }
                    if (player.TeamRole.Team == Smod2.API.Team.CLASSD)
                    {
                        num4++;
                    }
                    if (player.TeamRole.Team == Smod2.API.Team.NINETAILFOX)
                    {
                        num5++;
                    }
                }
                if ((num2 == 0) && (num4 == 0) && (num == 1))
                {
                    ev.Status = ROUND_END_STATUS.MTF_VICTORY;
                    this.plugin.PluginManager.Server.Round.EndRound();
                }
                else if ((num3 == 0) && (num5 == 0) && (num == 1) && (num2 == 0))
                {
                    ev.Status = ROUND_END_STATUS.CI_VICTORY;
                    this.plugin.PluginManager.Server.Round.EndRound();
                }
            }
        }
        public void OnGeneratorEjectTablet(PlayerGeneratorEjectTabletEvent ev)
        {
            if(h == true)
            {
                ev.Allow = false;
            }
        }

        public void OnGeneratorUnlock(PlayerGeneratorUnlockEvent ev)
        {
            if (h == true)
            {
                ev.Allow = false;
            }

        }

        public void OnPlayerDie(PlayerDeathEvent ev)
        {
            if (ev.Player.PlayerId == this.scp079id)
            {
                this.scp079id = -1;
            }
        }

        public void OnPlayerHurt(PlayerHurtEvent ev)
        {
            if(ev.DamageType == DamageType.TESLA)
            {
                if(ev.Attacker.PlayerId == ev.Player.PlayerId)
                {
                    if(ev.Player.TeamRole.Team == Smod2.API.Team.SCP)
                    {
                        if(scp == true)
                        {
                            ev.Damage = 0;
                        }
                    }
                    else
                    {
                        if(h == true)
                        {
                            ev.Damage = 0;
                        }
                    }
                }
                
            }
        }

        public void OnRoundEnd(RoundEndEvent ev)
        {

        }

        public void OnRoundRestart(RoundRestartEvent ev)
        {
            this.scp079id = -1;
            this.count = 0;
            scp = false;
            h = false;
            roundstart = false;
            time1 = 0;
            choise = false;
        }

        public void OnRoundStart(RoundStartEvent ev)
        {
            roundstart = true;
        }

        public void OnSpawn(PlayerSpawnEvent ev)
        {
            if (ev.Player.TeamRole.Role == Smod2.API.Role.SCP_079)
            {
                this.scp079id = ev.Player.PlayerId;
                if(choise == false)
                {
                    ev.Player.SendConsoleMessage("==========SCP079============");
                    ev.Player.SendConsoleMessage(".scp         选择本局帮助SCP");
                    ev.Player.SendConsoleMessage(".h           选择本局帮助人类");
                    ev.Player.SetRank("aqua", "SCP079 - 最大电力:130 | 电力恢复:3AP/s   未选择帮助倾向", null);
                    ev.Player.PersonalBroadcast(15, "<color=#FFC0CB>---[SCP079]---</color>\n<color=#00FFFF>HP:无限  </color><color=aqua>你可以耗费电量开门和锁门 \n 清点键盘数字键1左边的~键选择本局所属阵营，如果看不到提示则向上翻</color>", false);
                }
                if(choise == true)
                {
                    if(scp==true)
                    {
                        ev.Player.SetRank("aqua", "SCP079 -  帮助SCP", null);
                        ev.Player.PersonalBroadcast(15, "<color=#FFC0CB>---[SCP079]---</color>\n<color=#00FFFF>HP:无限  </color><color=aqua>你可以耗费电量开门和锁门 \n 本局079选择帮助SCP</color>", false);
                    }
                    if(h == true)
                    {
                        ev.Player.SetRank("aqua", "SCP079 - 最大电力:130 | 电力恢复:3AP/s   帮助人类", null);
                        ev.Player.PersonalBroadcast(15, "<color=#FFC0CB>---[SCP079]---</color>\n<color=#00FFFF>HP:无限  </color><color=aqua>你可以耗费电量开门和锁门 \n 本局079选择帮助人类</color>", false);
                    }
                   
                }
            }
        }

        public void OnUpdate(UpdateEvent ev)
        {
            if ((this.updatatimersteal < DateTime.Now)&&(choise ==false)&&(roundstart==true))
            {
                this.updatatimersteal = DateTime.Now.AddSeconds(100.0);
                time1++;
                if(time1==2)
                {
                    choise = true;
                    scp = true;
                    foreach(Player p in plugin.Server.GetPlayers())
                    {
                        if(p.TeamRole.Role == Smod2.API.Role.SCP_079)
                        {
                            p.SetRank("aqua", "SCP079 - 帮助SCP", null);
                        }
                    }
                    plugin.Server.Map.Broadcast(10, "<color=#FFC0CB>---[SCP079]---</color>\n<color=aqua>人类感受恐惧吧 本局SCP079选择帮助SCP</color>\n<color=aqua>SCP不会受到电网的伤害</color>", false);
                }

            }
        }

    }
}

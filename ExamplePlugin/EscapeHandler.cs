using Smod2;
using Smod2.API;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.EventSystem.Events;
using System;
using System.Collections.Generic;
using System.Threading;

namespace YYYIlike
{
    class EscapeHandler
    {
        public EscapeHandler(Start ev, Plugin plugin)
        {
            while (ev.roundstart)
            {
                foreach (Player player in plugin.PluginManager.Server.GetPlayers())
                {

                    if (player.TeamRole.Role == Smod2.API.Role.FACILITY_GUARD)
                    {
                        Vector position = player.GetPosition();
                        if (((position.x >= 171f) && (position.x <= 187f)) && ((position.y >= 980f) && (position.y <= 1000f)) && ((position.z >= 12f) && (position.z <= 47f)))
                        {
                            ev.GuardType[ev.Guardnum] = player.PlayerId;
                            ev.Guardnum++;
                            foreach (int num2 in ev.GuardType)
                            {
                                if (num2 == player.PlayerId)
                                {
                                    ev.count++;
                                }
                            }
                            if (ev.count == 1)
                            {
                                plugin.Info("保安:" + player.Name + "|正在领取物资");
                                string name = player.Name;
                                int num3 = new Random().Next(1, 100);
                                int num4 = new Random().Next(1, 10);
                                if (((num3 >= 50) && (num3 <= 100)) && (num4 <= 5))
                                {
                                    int num5 = new Random().Next(1, 5);
                                    if (num5 == 1)
                                    {
                                        player.PersonalBroadcast(10, "<color=#FF1493>[你收刮了一下发现了一张纸条]</color>\n上面写着\n<color=#87CEFA>服主的原味胖次统统20块!</color>", false);
                                        plugin.Info("服主的原味胖次统统20块");
                                    }
                                    else if (num5 == 2)
                                    {
                                        player.PersonalBroadcast(10, "<color=#FF1493>[你收刮了一下发现了一张纸条]</color>\n上面写着\n<color=#87CEFA>服主欠下3.5个亿,卷钱跑路了!</color>", false);
                                        plugin.Info("服主欠下3.5个亿,卷钱跑路了!");
                                    }
                                    else if (num5 == 3)
                                    {
                                        player.PersonalBroadcast(10, "<color=#FF1493>[你收刮了一下发现了一张纸条]</color>\n啥都没有:\n<color=#87CEFA>qwq</color>", false);
                                        plugin.Info("神秘代码");
                                    }
                                    else if (num5 == 4)
                                    {
                                        player.Damage(5, DamageType.CONTAIN);
                                        plugin.PluginManager.Server.Map.Broadcast(10, "<color=#FF1493>[消息]</color>\n<color=#87CEFA>保安 " + name + " 因为下班被基金会阉了</color>", false);
                                        plugin.Info("被阉了");
                                    }
                                    else
                                    {
                                        player.PersonalBroadcast(10, "<color=#FF1493>[你收刮了一下发现了一张纸条]</color>\n上面写着\n<color=#87CEFA>惊喜</color>", false);
                                        plugin.Info("没有惊喜的惊喜");
                                    }
                                }
                                else if (((num3 >= 50) && (num3 <= 100)) && ((num4 >= 6) && (num4 <= 10)))
                                {
                                    player.SetAmmo(AmmoType.DROPPED_5, player.GetAmmo(AmmoType.DROPPED_5) + 100);
                                    player.SetAmmo(AmmoType.DROPPED_7, player.GetAmmo(AmmoType.DROPPED_7) + 100);
                                    player.SetAmmo(AmmoType.DROPPED_9, player.GetAmmo(AmmoType.DROPPED_9) + 100);
                                    player.PersonalBroadcast(10, "<color=#FF1493>[你收刮了一下]</color>\n发现了\n<color=#87CEFA>弹药补给各100发子弹</color>", false);
                                    plugin.Info("100发子弹");
                                }
                                else if ((num3 >= 30) && (num3 <= 0x27))
                                {
                                    player.GiveItem(Smod2.API.ItemType.MEDKIT);
                                    player.PersonalBroadcast(10, "<color=#FF1493>[你收刮了一下]</color>\n发现了\n<color=#87CEFA>一个血包</color>", false);
                                    plugin.Info("一个血包");
                                }
                                else if ((num3 >= 20) && (num3 <= 0x1d))
                                {
                                    player.GiveItem(Smod2.API.ItemType.GRENADEFRAG);
                                    player.PersonalBroadcast(10, "<color=#FF1493>[你收刮了一下]</color>\n发现了\n<color=#87CEFA>一个手雷</color>", false);
                                    plugin.Info("一个手雷");
                                }
                                else if ((num3 >= 10) && (num3 <= 0x13))
                                {
                                    player.Kill();
                                    plugin.PluginManager.Server.Map.Broadcast(10, "<color=#FF1493>[消息]</color>\n<color=#00FFFF>" + name + "</color>\n<color=#87CEFA>搜刮物资的时候搬东西手滑砸死了自己</color>", false);
                                    plugin.Info("砸死自己");
                                }
                                else if ((num3 >= 1) && (num3 <= 9))
                                {
                                    player.GiveItem(Smod2.API.ItemType.COIN);
                                    player.PersonalBroadcast(10, "<color=#FF1493>[你收刮了一下]</color>\n发现了\n<color=#87CEFA>一枚硬币</color>", false);
                                    plugin.Info("一枚硬币");
                                }
                                else
                                {
                                    player.PersonalBroadcast(10, "<color=#FF1493>[你收刮了一下发现了一张纸条]</color>\n上面写着\n<color=#87CEFA>惊喜</color>", false);
                                    plugin.Info("没有惊喜的惊喜");
                                }
                            }
                            ev.count = 0;
                        }
                    }
                    if (player.TeamRole.Role == Smod2.API.Role.SCP_049)
                    {
                        Vector position = player.GetPosition();
                        if ((position.y <= -588f) && (position.y >= -605f))
                        {
                            ev.waring = true;
                            player.Damage(15, DamageType.CONTAIN);
                            player.PersonalBroadcast(1, "<color=#FF4500>本服禁止049长蹲核弹室</color>\n你正在以每秒15血速度扣除HP", false);
                            player.PersonalBroadcast(1, "<color=#87CEEB>本服禁止049长蹲核弹室</color>\n你正在以每秒15血速度扣除HP", false);
                        }
                        Thread.Sleep(0x5dc);
                    }
                }

            }
        }
        internal class Start : IEventHandler, IEventHandlerRoundStart, IEventHandlerSpawn, IEventHandlerRoundEnd, IEventHandlerPlayerDie, IEventHandlerSetRole, IEventHandlerPlayerJoin, IEventHandlerCallCommand, IEventHandlerDoorAccess, IEventHandlerPlayerHurt, IEventHandlerPocketDimensionExit, IEventHandlerPlayerDropItem, IEventHandlerUpdate, IEventHandlerRoundRestart, IEventHandlerCheckEscape, IEventHandlerTeamRespawn, IEventHandlerSetNTFUnitName, IEventHandlerWaitingForPlayers, IEventHandlerPlayerPickupItem, IEventHandlerContain106, IEventHandlerPocketDimensionDie, IEventHandlerCheckRoundEnd, IEventHandlerMedkitUse ,IEventHandlerShoot
        {


            // Fields
            private Plugin plugin;
            private string SCP173;
            private string SCP049;
            private string SCP079;
            private string SCP096;
            private string SCP939_89;
            private string SCP939_53;
            private string SCP106;
            private int s173;
            public int s049;
            private int s096;
            private int s939_53;
            private int s939_89;
            private int s106;
            private int KillerID;
            private int PlayerID;
            private int RoleSet = 0;
            public bool roundstart = false;
            public int[] GuardType = new int[200];
            public int Guardnum = 0;
            public int count = 0;
            public DateTime updatatimer = DateTime.Now;
            public int deadtimer = 0;
            public bool starttimer = false;
            private bool firstscp;
            public bool deadtime = false;
            public int count2 = 0;
            private int waring1;
            private int playernum = 0;
            public Vector LCZ;
            public bool waring = false;
            public int[] touxiang = new int[0x65];
            private int round = 0;
            public int chaos = 0;
            public int mtf = 0;
            public int mtfchange = 0;
            public int chaoschange = 0;
            private int 同意;
            private int 拒绝;
            private bool 投票是否发起;
            private Player ban;
            private Dictionary<int, bool> players = new Dictionary<int, bool>();
            private int 理由;
            private string 理由文本;
            private bool 当前是否在投票;
            private DateTime maxtime;
            private int Count = 0;
            private int issuperTrue = 0;
            private int issuperFalse = 0;
            private int coldtime = 0;
            private int coldtime2 = 2;
            private bool coldbc = false;
            private bool coldtb = false;
            public static List<string> HDZHG2 = new List<string>();
            private int ini10;
            public static List<Smod2.API.Player> player233 = new List<Smod2.API.Player>();
            public static List<int> LLBS233 = new List<int>();
            private int xp;
            private int lv;
            private bool coldwait233;
            private List<Player> player2;
            private bool Dio1;
            private Player Dio;
            public static List<string> Dio2 = new List<string>();
            public static List<Smod2.API.Player> scpd79 = new List<Smod2.API.Player>();
            private bool sjtz1;
            private bool sjtz2;
            private Thread cd;
            List<Smod2.API.Vector> pos1 = new List<Smod2.API.Vector>();
            private List<Smod2.API.Player> player22;
            public static List<string> player4 = new List<string>();
            private List<Smod2.API.Player> player5;
            private Thread pmd;
            private Player ylb;
            private bool ylb1;
            private List<Player> player10;
            public static List<string> ylb2 = new List<string>();
            private DateTime updatatimer2 = DateTime.Now;
            private DateTime updatatimer5 = DateTime.Now;
            private DateTime updatatimer6 = DateTime.Now;
            private DateTime updatatimer7 = DateTime.Now;
            private int tiems;
            private Player scp073;
            private int scp073id;
            private bool mrfishzb = true;
            private bool scp076yes;
            private Player scp076;
            private Player mrfish;
            public static List<int> jw = new List<int>();
            public static List<string> hd = new List<string>();
            private int scp076id;
            private List<Smod2.API.Player> player3 = new List<Smod2.API.Player>();
            private bool xhsnb;
            private DateTime updatatimer9;
            private int xhsnb2;
            private Player scp106a;
            private Player scp2818;
            private int scp2818id;
            private bool scp2818pick;
            private bool hhzhgzb = true;
            private int times2;
            private Player scp1143;
            private bool scp1143a;
            private int scp1143id;
            private int times;
            private List<Player> player6;
            private Player HDZHG;
            private bool gd;
            private DateTime updatatimer3 = DateTime.Now;
            private DateTime time233;
            private bool bpb;
            public static List<int> bpb2 = new List<int>();
            private bool jljy1;
            private Player jljy;
            private bool jljyzb;
            public static List<string> jljy2 = new List<string>();
            public static List<Smod2.API.Door> door2 = new List<Smod2.API.Door>();
            private int scp181id;


            //181的变量测试
            public int cxkid;
            public List<Smod2.API.Door> doord = new List<Smod2.API.Door>();
            public Smod2.API.Player scp817;
            public Smod2.API.Player D9341;
            public bool jntm;
            public Smod2.API.Player cxk;
            public bool cxkyes;
            public List<Smod2.API.Door> Doors = new List<Smod2.API.Door>();
            public Smod2.API.Door Door;
            public int scp817id;
            public bool scp817yes;
            private Smod2.API.Vector pos3;
            public List<Smod2.API.Item> Items = new List<Smod2.API.Item>();
            public int D9341id;
            public bool D9341yes;
            public List<Smod2.API.Item> D9341Item = new List<Smod2.API.Item>();
            public Smod2.API.Vector D9341zb;
            public Smod2.API.Role D9341js;
            public int times1 = 0;
            public bool jntmlq;
            //public DateTime updatatimer4 = DateTime.Now;
            public int times3 = 0;
            private Player scp181;
            private Player scp2006;
            private int scp2006id;
            private List<string> scp2006a = new List<string>();
            private int times4;
            //private DateTime updatatimer8 = DateTime.Now;
            private Player scp035;
            public int scp035id;
            //private DateTime updatatimer10 = DateTime.Now;
            private int times5 = 1;
            private int scpqblid2;
            private Player scpqbl3;
            private Player scpqbl;
            private string scpqblid;
            private Player scp914m;
            private int scp914mid;
            private DateTime updatatimer181 = DateTime.Now;
            private DateTime updatatimer182 = DateTime.Now;
            private DateTime updatatimer183 = DateTime.Now;
            private DateTime updatatimer184 = DateTime.Now;
            private DateTime updatatimer185 = DateTime.Now;
            private DateTime updatatimer186 = DateTime.Now;
            public static List<string> scp682 = new List<string>();
            private int scp939id;
            private bool jkl;
            private string jklid;
            private Player qblcq;
            private bool qblcq2;
            private Player xywj;
            private int xywjid;
            private bool bscp79;
            private Player jwhhk;
            private int jwhhkid;
            private bool hrss;
            private Vector hkzb;
            private DateTime updatatimerhk;
            private int hktime;
            private bool csm;
            private DateTime updatatimercsm;
            private int csmtime;
            private bool a127;
            private bool a127c;
            private int a127b;
            private Vector pos2;
            private Player xtd;
            private int xtdid;
            private bool stealcd;
            private DateTime updatatimersteal;
            private int t96a35;
            private bool scp457a;
            private bool scp457die;
            private Player scp457;
            private int scp457id;
            private DateTime updatatimerscp457;
            private Vector scp457b;
            private int t96a457;
            private int time2;
            private Player lb;
            private int lbid;
            private bool lbyes;
            private int time3;
            private Vector pos4;
            private bool scp005;
            private int scp005aid;
            private DateTime updatatimerscp076;
            private bool scp073a;
            private bool scp073zb;
            private Vector pos100;
            private Vector pos101;
            private Player dsjsc;
            private int dsjscid;
            private bool a127d;
            private bool scp650yes;
            private Player scp650;
            private int scp650id;
            private DateTime updatatimerscp650;
            private List<Player> playerqwq;
            private bool scp3108pick;

            private int scp3108playerid;

            private List<Smod2.API.Item> scp3108shotatplayeritems = new List<Smod2.API.Item>();

            private Vector scp3108shotatplayerpos;
            private bool scp3108shotyes;
            private List<int> scp1577id = new List<int>();
            private Vector scp1577pos;
            private bool scp1577bj;
            private DateTime updatatimerscp1577;
            private int scp1577times;
            private bool scp1577pick;
            private int gjtr;
            private bool bhsx;
            private int njsxtimes;

            // Methods
            public Start(Plugin plugin)
            {
                this.plugin = plugin;
                同意 = 0;
                拒绝 = 0;
                投票是否发起 = false;
                理由 = 0;
                理由文本 = null;
                当前是否在投票 = false;
                players = new Dictionary<int, bool>();
                Count = 0;
                issuperTrue = 0;
                issuperFalse = 0;

            }

            public void OnSetNTFUnitName(SetNTFUnitNameEvent ev)
            {
                ini10++;

                if (ini10 == 1)
                {
                    ev.Unit = "白给小分队";
                }
                if (ini10 == 2)
                {
                    ev.Unit = "蔡徐坤";
                    plugin.Server.Map.Broadcast(7, "<color=#66FF00>机动特遣队</color><color=#3333FF>九尾狐</color><color=#FF0000>蔡徐坤</color><color=#66FF00>小队已经进入设施</color>\n<color=#66FF00>请所有人员乖乖站好♂投入九尾狐怀抱</color>", false);
                }
                if (ini10 == 3)
                {
                    ev.Unit = "九尾大军";
                    plugin.Server.Map.Broadcast(7, "<color=#66FF00>机动特遣队</color><color=#3333FF>九尾狐</color><color=#FF0000>九尾大军</color><color=#66FF00>小队已经进入设施</color>\n<color=#66FF00>请所有人员乖乖站好♂投入九尾狐怀抱</color>", false);
                }
                if (ini10 == 4)
                {
                    ev.Unit = "最差的一届九尾";
                    plugin.Server.Map.Broadcast(7, "<color=#66FF00>机动特遣队</color><color=#3333FF>九尾狐</color><color=#FF0000>最差的一届九尾</color><color=#66FF00>小队已经进入设施</color>\n<color=#66FF00>请所有人员乖乖站好♂投入九尾狐怀抱</color>", false);
                }
                if (ini10 == 5)
                {
                    ev.Unit = "炮灰";
                    plugin.Server.Map.Broadcast(7, "<color=#66FF00>机动特遣队</color><color=#3333FF>九尾狐</color><color=#FF0000>炮灰</color><color=#66FF00>小队已经进入设施</color>\n<color=#66FF00>请所有人员乖乖站好♂投入九尾狐怀抱</color>", false);
                }
                if (ini10 == 6)
                {
                    ev.Unit = "顺丰快递";
                    plugin.Server.Map.Broadcast(7, "<color=#66FF00>机动特遣队</color><color=#3333FF>九尾狐</color><color=#FF0000>顺丰快递</color><color=#66FF00>小队已经进入设施</color>\n<color=#66FF00>您的快递已到请签收</color>", false);
                }
                if (ini10 == 7)
                {
                    ev.Unit = "圆通快递";
                    plugin.Server.Map.Broadcast(7, "<color=#66FF00>机动特遣队</color><color=#3333FF>九尾狐</color><color=#FF0000>圆通快递</color><color=#66FF00>小队已经进入设施</color>\n<color=#66FF00>您的快递已到请签收</color>", false);
                }
                if (ini10 == 8)
                {
                    ev.Unit = "宅急送";
                    plugin.Server.Map.Broadcast(7, "<color=#66FF00>机动特遣队</color><color=#3333FF>九尾狐</color><color=#FF0000>宅急送</color><color=#66FF00>小队已经进入设施</color>\n<color=#66FF00>您的快递已到请签收</color>", false);
                }
                if (ini10 == 9)
                {
                    ev.Unit = "SCP106迫害小分队";
                    plugin.Server.Map.Broadcast(7, "<color=#66FF00>机动特遣队</color><color=#3333FF>九尾狐</color><color=#FF0000>SCP106迫害小分队</color><color=#66FF00>小队已经进入设施</color>\n<color=#66FF00>您的快递已到请签收</color>", false);
                }
            }
            public void OnTeamRespawn(TeamRespawnEvent ev)
            {
                if (ev.SpawnChaos)
                {
                    player22 = ev.PlayerList;
                    times2 = 1;
                    foreach (Player p in player22)
                    {
                        hd.Add(p.UserId);
                    }
                }
                if (ev.SpawnChaos == false)
                {
                    player22 = ev.PlayerList;
                    tiems = 1;
                    foreach (Player p in player22)
                    {
                        jw.Add(p.PlayerId);
                    }
                }
            }
            public void OnCallCommand(PlayerCallCommandEvent ev)
            {
                string name = ev.Player.Name;
                int num = 0;
                int num2 = 0;
                char[] separator = new char[] { ' ' };
                string[] strArray = ev.Command.ToLower().Split(separator);
                foreach (Player player in plugin.PluginManager.Server.GetPlayers(""))
                {
                    if (player.TeamRole.Role == Smod2.API.Role.CHAOS_INSURGENCY)
                    {
                        num++;
                    }
                    if (player.TeamRole.Team == Smod2.API.Team.NINETAILFOX)
                    {
                        num2++;
                    }
                }
                if(ev.Command.Contains("cs"))
                {
                    pos100 = ev.Player.GetPosition();
                    plugin.Server.Map.SpawnItem(Smod2.API.ItemType.SCP018, new Vector(pos100.x + (float)0.5, pos100.y + (float)0.5, pos100.z + (float)0.5), null);
                    plugin.Server.Map.SpawnItem(Smod2.API.ItemType.SCP018, new Vector(pos100.x + (float)0.5, pos2.y + (float)0.5, pos100.z), null);
                    plugin.Server.Map.SpawnItem(Smod2.API.ItemType.SCP018, new Vector(pos100.x, pos100.y + (float)0.5, pos100.z + (float)0.5), null);
                    plugin.Server.Map.SpawnItem(Smod2.API.ItemType.SCP018, new Vector(pos100.x - (float)0.5, pos100.y + (float)0.5, pos100.z), null);
                    plugin.Server.Map.SpawnItem(Smod2.API.ItemType.SCP018, new Vector(pos100.x, pos100.y + (float)0.5, pos100.z - (float)0.5), null);
                    plugin.Server.Map.SpawnItem(Smod2.API.ItemType.SCP018, new Vector(pos100.x + (float)0.5, pos100.y + (float)0.5, pos100.z + (float)0.5), null);
                    plugin.Server.Map.SpawnItem(Smod2.API.ItemType.SCP018, new Vector(pos100.x + (float)0.5, pos100.y + (float)0.5, pos100.z - (float)0.5), null);
                    plugin.Server.Map.SpawnItem(Smod2.API.ItemType.SCP018, new Vector(pos100.x - (float)0.5, pos100.y + (float)0.5, pos100.z + (float)0.5), null);
                }
                if (ev.Command.Contains("steal") && (ev.Player.PlayerId == xtd.PlayerId) && (stealcd == false))
                {
                    stealcd = true;
                    foreach (Player p in plugin.Server.GetPlayers())
                    {
                        int num4 = new Random().Next(1, 10);
                        if (num4 == 1)
                        {
                            ev.Player.GiveItem(Smod2.API.ItemType.COIN);
                        }
                        if (num4 == 2)
                        {
                            ev.Player.GiveItem(Smod2.API.ItemType.KEYCARDNTFCOMMANDER);
                        }
                        if (num4 == 3)
                        {
                            ev.Player.GiveItem(Smod2.API.ItemType.GUNE11SR); ;
                        }
                        if (num4 == 4)
                        {
                            ev.Player.GiveItem(Smod2.API.ItemType.GUNUSP);
                        }
                        if (num4 == 5)
                        {
                            ev.Player.GiveItem(Smod2.API.ItemType.SCP500);
                        }
                        if (num4 == 6)
                        {
                            ev.Player.GiveItem(Smod2.API.ItemType.KEYCARDO5);
                        }
                        if (num4 > 6)
                        {
                            ev.Player.SendConsoleMessage("什么都没偷到");
                        }

                    }
                    ev.Player.SendConsoleMessage("你的能力没有找到人");
                }
                if (ev.Command.Contains("gdyes"))
                {
                    plugin.Server.Map.Broadcast(10, "管理员启用了关灯模式！！！", false);
                    gd = true;
                }
                if (ev.Command.Contains("gdno"))
                {
                    plugin.Server.Map.Broadcast(10, "管理员关闭了关灯模式！！！", false);
                    gd = false;
                }
                if (ev.Command.Contains("s173"))
                {
                    if (ev.Player.PlayerId == xywjid)
                    {
                        xywj.ChangeRole(Smod2.API.Role.SCP_173, true, true, false, true);
                        xywj = null;
                        xywjid = 0;
                    }
                }
                if (ev.Command.Contains("s106"))
                {
                    if (ev.Player.PlayerId == xywjid)
                    {
                        xywj.ChangeRole(Smod2.API.Role.SCP_106, true, true, false, true);
                        xywj = null;
                        xywjid = 0;
                    }
                }
                if (ev.Command.Contains("sD"))
                {
                    if (ev.Player.PlayerId == xywjid)
                    {
                        xywj.ChangeRole(Smod2.API.Role.CLASSD, true, true, false, true);
                        xywj = null;
                        xywjid = 0;
                    }
                }
                if (ev.Command.Contains("sS"))
                {
                    if (ev.Player.PlayerId == xywjid)
                    {
                        xywj.ChangeRole(Smod2.API.Role.SCIENTIST, true, true, false, true);
                        xywj = null;
                        xywjid = 0;
                    }
                }
                if (ev.Command.Contains("sG"))
                {
                    if (ev.Player.PlayerId == xywjid)
                    {
                        xywj = null;
                        xywjid = 0;
                        xywj.Kill();
                        xywj.ChangeRole(Smod2.API.Role.FACILITY_GUARD, true, true, false, true);
                    }
                }
                if (ev.Command.Contains("dk"))
                {
                    if (hrss == true)
                    {
                        jwhhk.ChangeRole(Smod2.API.Role.NTF_SCIENTIST, true, false, false, false);
                        jwhhk.Teleport(hkzb, true);
                        hktime = 0;
                        hrss = false;
                    }
                }
                if (ev.Command.Contains("hk"))
                {
                    if ((jwhhkid == ev.Player.PlayerId) && (hrss == false))
                    {
                        hrss = true;
                        hkzb = ev.Player.GetPosition();
                        ev.Player.ChangeRole(Smod2.API.Role.SCP_079, true, false, false, false);

                    }
                }

                if (ev.Command.Contains("tx") && ((ev.Player.TeamRole.Role == Smod2.API.Role.CLASSD) && (Dio2.Contains(ev.Player.UserId) == false) || (ev.Player.TeamRole.Role == Smod2.API.Role.SCIENTIST)))
                {
                    int playerId = ev.Player.PlayerId;
                    if ((ev.Player.TeamRole.Role == Smod2.API.Role.CLASSD) && (num == 0))
                    {
                        touxiang[round] = playerId;
                        ev.Player.PersonalBroadcast(10, "<color=#FF00FF>你已经进入投降模式</color>无法取消\n当你逃出的时候<color=#00FF7F>自动变为相反阵营</color>", false);
                        ev.Player.SetRank("default", "(" + ev.Player.PlayerId + ") 投降人员", null);
                        round++;
                    }
                    else if ((ev.Player.TeamRole.Role == Smod2.API.Role.CLASSD) && (num > 0))
                    {
                        ev.Player.PersonalBroadcast(10, "<color=#FF00FF>你无法进入投降模式</color>\n因为场上有<color=#00FF7F>混沌</color>", false);
                    }
                    if ((ev.Player.TeamRole.Role == Smod2.API.Role.SCIENTIST) && (num2 == 0))
                    {
                        touxiang[round] = playerId;
                        ev.Player.PersonalBroadcast(10, "<color=#FF00FF>你已经进入投降模式</color>无法取消\n当你逃出的时候<color=#00FF7F>自动变为相反阵营</color>", false);
                        ev.Player.SetRank("default", "投降人员", null);
                        round++;
                    }
                    else if ((ev.Player.TeamRole.Role == Smod2.API.Role.SCIENTIST) && (num2 > 0))
                    {
                        ev.Player.PersonalBroadcast(10, "<color=#FF00FF>你无法进入投降模式</color>\n因为场上有<color=#00FF7F>MTF</color>", false);
                    }
                }
                if (ev.Command.Contains("pos"))
                {
                    Vector position = ev.Player.GetPosition();
                    object[] objArray1 = new object[] { position.x, "|", position.y, "|", position.z };
                    ev.ReturnMessage = string.Concat(objArray1) ?? "";
                }
                if (strArray[0] == "c")
                {
                    if (strArray.Length == 1)
                    {
                        ev.Player.SendConsoleMessage("请输入内容", "yellow");
                    }
                    if (strArray.Length == 2)
                    {
                        ev.Player.SendConsoleMessage("发送成功", "yellow");
                        if (ev.Player.TeamRole.Role == Smod2.API.Role.SPECTATOR)
                        {
                            foreach (Player player in plugin.Server.GetPlayers())
                            {
                                if (player.TeamRole.Role == Smod2.API.Role.SPECTATOR)
                                {
                                    player.PersonalBroadcast(5, "[玩家]" + ev.Player.Name + strArray[1], false);
                                }
                            }
                        }
                        if (ev.Player.TeamRole.Team == Smod2.API.Team.SCP)
                        {
                            foreach (Player player in plugin.Server.GetPlayers())
                            {
                                if (player.TeamRole.Team == Smod2.API.Team.SCP)
                                {
                                    player.PersonalBroadcast(5, "[玩家]" + ev.Player.Name + strArray[1], false);
                                }
                            }
                        }
                        if (ev.Player.TeamRole.Team == Smod2.API.Team.NINETAILFOX)
                        {
                            foreach (Player player in plugin.Server.GetPlayers())
                            {
                                if (player.TeamRole.Team == Smod2.API.Team.NINETAILFOX)
                                {
                                    player.PersonalBroadcast(5, "[玩家]" + ev.Player.Name + strArray[1], false);
                                }
                            }
                        }
                    }
                }
                if (strArray[0] == "x")
                {
                    Vector vector = new Vector(ev.Player.GetPosition().x + 3, ev.Player.GetPosition().y, ev.Player.GetPosition().z);

                    ev.Player.Teleport(vector);
                }
                if (strArray[0] == "y")
                {
                    Vector vector = new Vector(ev.Player.GetPosition().x, ev.Player.GetPosition().y + 3, ev.Player.GetPosition().z);

                    ev.Player.Teleport(vector);
                }
                if (strArray[0] == "z")
                {
                    Vector vector = new Vector(ev.Player.GetPosition().x, ev.Player.GetPosition().y, ev.Player.GetPosition().z + 3);

                    ev.Player.Teleport(vector);
                }
                if (strArray[0] == "qwqqwqwqwq")
                {
                    if (strArray.Length == 1)
                    {
                        ev.Player.SendConsoleMessage("\n投票踢人方法：\n.ban 玩家编号 理由编号\n踢出理由及编号：\n1：作弊行为\n2：违反<玩家守则>\n\n\n参与投票方法：\n同意：.ban true\n反对：.ban false\n\n\n请勿恶意使用投票否则将追究责任", "yellow");
                    }
                    else if (strArray.Length == 2)
                    {
                        if (((strArray[1] == "istrue") && !players[ev.Player.PlayerId]) && 投票是否发起)
                        {
                            ev.Player.SendConsoleMessage("投票成功！", "green");
                            同意 += 10;
                            issuperTrue++;
                            players[ev.Player.PlayerId] = true;
                            plugin.Server.Map.ClearBroadcasts();
                            object[] objArray2 = new object[] { "玩家<color=red>[", ev.Player.Name, "]</color>参与踢出:<color=red>", ban.Name, "</color>的投票\n理由:<color=#FF8C00>", 理由文本, "</color>   (<color=red>按~输入.ban使用投票</color>)\n同意:<color=red>", 同意, "</color>\t拒绝:<color=red>", 拒绝, "</color>" };
                            plugin.Server.Map.Broadcast(90, string.Concat(objArray2), false);
                            plugin.Info(string.Concat(new object[] { "当前票数:同意:", 同意, "拒绝:", 拒绝 }));
                            plugin.Info("!!!!!!!!!!玩家: [" + ev.Player.Name + "] 投超级赞成票!!!!!!!!!!");
                            if (issuperTrue == 2)
                            {
                                plugin.Server.Map.ClearBroadcasts();
                                plugin.Server.Map.Broadcast(10, "[<color=red>投票</color>]\n系统已成功踢出玩家:<color=red>" + ban.Name + "</color>", false);
                                ban.Ban(90);
                                TheReset();
                            }
                        }
                        else if (((strArray[1] == "isfalse") && !players[ev.Player.PlayerId]) && 投票是否发起)
                        {
                            ev.Player.SendConsoleMessage("投票成功！", "green");
                            players[ev.Player.PlayerId] = true;
                            拒绝 += 10;
                            issuperFalse++;
                            plugin.Server.Map.ClearBroadcasts();
                            object[] objArray4 = new object[] { "玩家<color=red>[", ev.Player.Name, "]</color>参与踢出:<color=red>", ban.Name, "</color>的投票\n理由:<color=#FF8C00>", 理由文本, "</color>   (<color=red>按~输入.ban使用投票</color>)\n同意:<color=red>", 同意, "</color>\t拒绝:<color=red>", 拒绝, "</color>" };
                            plugin.Server.Map.Broadcast(90, string.Concat(objArray4), false);
                            plugin.Info(string.Concat(new object[] { "当前票数:同意:", 同意, "拒绝:", 拒绝 }));
                            plugin.Info("!!!!!!!!!!玩家: [" + ev.Player.Name + "] 投超级赞成票!!!!!!!!!!");
                            if (issuperFalse == 2)
                            {
                                plugin.Server.Map.ClearBroadcasts();
                                plugin.Server.Map.Broadcast(10, "[<color=red>投票</color>]踢出玩家失败,理由<color=red>投票玩家不足</color>\n注:投票玩家需要大于当前一半玩家", false);
                                TheReset();
                            }
                        }
                        if (((strArray[1] == "true") && !players[ev.Player.PlayerId]) && 投票是否发起)
                        {
                            ev.Player.SendConsoleMessage("投票成功！", "green");
                            同意++;
                            players[ev.Player.PlayerId] = true;
                            plugin.Server.Map.ClearBroadcasts();
                            object[] objArray6 = new object[] { "玩家<color=red>[", ev.Player.Name, "]</color>参与踢出:<color=red>", ban.Name, "</color>的投票\n理由:<color=#FF8C00>", 理由文本, "</color>   (<color=red>按~输入.ban使用投票</color>)\n同意:<color=red>", 同意, "</color>\t拒绝:<color=red>", 拒绝, "</color>" };
                            plugin.Server.Map.Broadcast(90, string.Concat(objArray6), false);
                            plugin.Info(string.Concat(new object[] { "当前票数:同意:", 同意, "拒绝:", 拒绝 }));
                            plugin.Info("玩家: [" + ev.Player.Name + "] 投赞成票");
                        }
                        else if (((strArray[1] == "false") && !players[ev.Player.PlayerId]) && 投票是否发起)
                        {
                            ev.Player.SendConsoleMessage("投票成功！", "green");
                            players[ev.Player.PlayerId] = true;
                            拒绝++;
                            plugin.Server.Map.ClearBroadcasts();
                            object[] objArray8 = new object[] { "玩家<color=red>[", ev.Player.Name, "]</color>参与踢出:<color=red>", ban.Name, "</color>的投票\n理由:<color=#FF8C00>", 理由文本, "</color>   (<color=red>按~输入.ban使用投票</color>)\n同意:<color=red>", 同意, "</color>\t拒绝:<color=red>", 拒绝, "</color>" };
                            plugin.Server.Map.Broadcast(90, string.Concat(objArray8), false);
                            plugin.Info(string.Concat(new object[] { "当前票数:同意:", 同意, "拒绝:", 拒绝 }));
                            plugin.Info("玩家: [" + ev.Player.Name + "] 投反对票");
                        }
                        else if (((strArray[1] == "true") && players[ev.Player.PlayerId]) && 投票是否发起)
                        {
                            ev.Player.SendConsoleMessage("你已经投过票了哦！", "green");
                        }
                        else if (((strArray[1] == "false") && players[ev.Player.PlayerId]) && 投票是否发起)
                        {
                            ev.Player.SendConsoleMessage("你已经投过票了哦！", "green");
                        }
                        else if ((strArray[1] == "true") && !投票是否发起)
                        {
                            ev.Player.SendConsoleMessage("当前没有投票哦", "green");
                        }
                        else if ((strArray[1] == "false") && !投票是否发起)
                        {
                            ev.Player.SendConsoleMessage("当前没有投票哦", "green");
                        }
                    }
                    else if (strArray.Length == 3)
                    {
                        if (当前是否在投票)
                        {
                            ev.Player.SendConsoleMessage("当前正在投票哦", "yellow");
                        }
                        else
                        {
                            int num4 = int.Parse(strArray[1]);
                            理由 = int.Parse(strArray[2]);
                            if (理由 == 1)
                            {
                                理由文本 = "作弊";
                            }
                            else if (理由 == 2)
                            {
                                理由文本 = "违反<玩家守则>";
                            }
                            foreach (Player player2 in plugin.Server.GetPlayers(""))
                            {
                                if (player2.PlayerId == num4)
                                {
                                    投票是否发起 = true;
                                    当前是否在投票 = true;
                                    maxtime = DateTime.Now.AddSeconds(90.0);
                                    break;
                                }
                            }
                            if (投票是否发起)
                            {
                                foreach (Player player3 in plugin.Server.GetPlayers(""))
                                {
                                    players[player3.PlayerId] = false;
                                    Count++;
                                }
                                foreach (Player player4 in plugin.Server.GetPlayers(""))
                                {
                                    if (player4.PlayerId == num4)
                                    {
                                        plugin.Server.Map.ClearBroadcasts();
                                        object[] objArray10 = new object[] { "玩家<color=red>[", ev.Player.Name, "]</color>发起踢出:<color=#00BFFF>", player4.Name, "</color>的投票\n理由:<color=#FF8C00>", 理由文本, "</color>   (<color=red>按~输入.ban使用投票</color>)\n同意:<color=red>", 同意, "</color>\t拒绝:<color=red>", 拒绝, "</color>" };
                                        plugin.Server.Map.Broadcast(90, string.Concat(objArray10), false);
                                        ban = player4;
                                        plugin.Info("玩家:" + ev.Player.Name + ",发起踢出:" + ban.Name + "的投票，理由:" + 理由文本);
                                    }
                                }
                                players[ev.Player.PlayerId] = true;
                                players[ban.PlayerId] = true;
                                同意++;
                                拒绝++;
                                plugin.Server.Map.ClearBroadcasts();
                                object[] objArray11 = new object[] { "玩家<color=red>[", ev.Player.Name, "]</color>发起踢出: <color=#00BFFF>[", ban.Name, "]</color> 的投票\n理由:<color=#FF8C00>", 理由文本, "</color>   (<color=red>按~输入.ban使用投票</color>)\n同意:<color=red>", 同意, "</color>\t拒绝:<color=red>", 拒绝, "</color>" };
                                plugin.Server.Map.Broadcast(90, string.Concat(objArray11), false);
                            }
                        }
                    }
                }
                if ((ev.Player.TeamRole.Role == Smod2.API.Role.NTF_COMMANDER) && (strArray[0] == "bc"))
                {
                    if (strArray.Length == 1)
                    {
                        ev.Player.SendConsoleMessage("\n指挥鱼命令使用教程:\n\n.bc [内容]\n\n内容会全图发送给予所有九尾鱼阵营玩家", "yellow");
                    }
                    else if ((strArray.Length == 2) && !coldbc)
                    {
                        coldbc = true;
                        foreach (Player player5 in plugin.PluginManager.Server.GetPlayers(""))
                        {
                            if (player5.TeamRole.Team == Smod2.API.Team.NINETAILFOX)
                            {
                                player5.PersonalClearBroadcasts();
                                player5.PersonalBroadcast(6, "<color=#4682B4>[来自指挥鱼的信息]</color>\n" + strArray[1], false);
                            }
                        }

                    }
                }
                if (strArray[0] == "f")
                {
                    Vector pos = scpqbl3.GetPosition();
                    float pos2 = pos.x + 3;
                    float pos3 = pos.y + 3;
                    float pos4 = pos.z + 3;
                    float pos5 = pos.x - 3;
                    float pos6 = pos.y - 3;
                    float pos7 = pos.z - 3;
                    Player player = ev.Player;
                    if (qblcq2 == true)
                    {
                        qblcq2 = false;
                    }
                    else if ((player.GetPosition().x <= pos2) && (player.GetPosition().x >= pos5) && (player.GetPosition().y <= pos3) && (player.GetPosition().y >= pos6) && ((player.GetPosition().z <= pos4) && (player.GetPosition().z >= pos7)))
                    {
                        plugin.Server.Map.Broadcast(5, ev.Player.Name + "已经登上坦克", false);
                        qblcq = ev.Player;
                        qblcq2 = true;
                    }



                }
                if ((ev.Player.TeamRole.Role == Smod2.API.Role.NTF_COMMANDER) && (strArray[0] == "tb"))
                {
                    if (strArray.Length == 1)
                    {
                        ev.Player.SendConsoleMessage("\n提拔使用教程:\n\n.tb [编号]\n\n可以将九尾狐新兵提拔为 九尾狐士官 300秒1个人", "yellow");
                    }
                    else if ((strArray.Length == 2) && !coldtb)
                    {
                        coldtb = true;

                        int num4 = int.Parse(strArray[1]);
                        foreach (Player player2 in plugin.Server.GetPlayers(""))
                        {
                            if ((player2.PlayerId == num4) && (player2.TeamRole.Role == Smod2.API.Role.NTF_CADET))
                            {
                                ev.Player.SendConsoleMessage("提拔成功", "yellow");
                                player2.ChangeRole(Smod2.API.Role.NTF_LIEUTENANT, true, true, true, true);
                                player2.PersonalBroadcast(5, "你表现得超级nice被指挥官提拔了", false);
                            }
                        }

                    }
                }
                if ((HDZHG2.Contains(ev.Player.UserId)) && (strArray[0] == "bc"))
                {
                    if (strArray.Length == 1)
                    {
                        ev.Player.SendConsoleMessage("\n混沌指挥鱼命令使用教程:\n\n.bc [内容]\n\n内容会全图发送给予所有九尾鱼阵营玩家", "yellow");
                    }
                    else if ((strArray.Length == 2))
                    {
                        foreach (Player player5 in plugin.PluginManager.Server.GetPlayers(""))
                        {
                            if (player5.TeamRole.Team == Smod2.API.Team.CHAOS_INSURGENCY)
                            {
                                player5.PersonalClearBroadcasts();
                                player5.PersonalBroadcast(6, "<color=#4682B4>[来自混沌指挥鱼的信息]</color>\n" + strArray[1], false);
                            }
                        }

                    }
                }
                if ((strArray[0] == "list"))
                {
                    if (strArray.Length == 1)
                    {
                        ev.Player.SendConsoleMessage("全部id", "yellow");
                        foreach (Player player5 in plugin.PluginManager.Server.GetPlayers(""))
                        {

                            ev.Player.SendConsoleMessage("玩家名字:" + player5.Name + "     玩家编号:" + player5.PlayerId, "yellow");
                        }
                        ev.Player.SendConsoleMessage("获取完毕", "yellow");
                    }
                }
                if ((strArray[0] == "cz"))
                {
                    if (strArray.Length == 1)
                    {
                        ev.Player.SendConsoleMessage("重新做人指令帮助 可以让指定的混沌变成DD重新来过", "yellow");

                    }
                    if (strArray.Length == 2)
                    {
                        int num4 = int.Parse(strArray[1]);
                        foreach (Player player2 in plugin.Server.GetPlayers(""))
                        {
                            if ((player2.PlayerId == num4) && (player2.TeamRole.Team == Smod2.API.Team.CHAOS_INSURGENCY) && (!HDZHG2.Contains(player2.UserId)))
                            {
                                ev.Player.SendConsoleMessage("执行完成", "yellow");
                                player2.ChangeRole(Smod2.API.Role.CLASSD, true, true, true, true);
                                player2.PersonalBroadcast(5, "你因为惹怒了混沌指挥官被开除成DD", false);
                            }
                        }
                    }
                }
                if ((strArray[0] == "help"))
                {
                    if (strArray.Length == 1)
                    {
                        if (HDZHG2.Contains(ev.Player.UserId))
                        {
                            ev.Player.SendConsoleMessage("混沌指挥官使用教程\n.bc + [内容]把内容广播给全体混沌\n.cz +[玩家编号]把玩家开除成D级");
                        }
                        if (ev.Player.TeamRole.Role == Smod2.API.Role.NTF_COMMANDER)
                        {
                            ev.Player.SendConsoleMessage("九尾狐指挥官使用教程\n.bc + [内容]把内容广播给全体九尾狐\n.tb +[玩家编号]把玩家升级");
                        }

                    }
                }
                num = 0;
                num2 = 0;
            }
            public void OnPocketDimensionDie(PlayerPocketDimensionDieEvent ev)
            {
                if (ev.Player.PlayerId == scp457id)
                {
                    ev.Die = false;
                }
                if (ev.Player.PlayerId == scp181id)
                {
                    ev.Die = false;
                }
                if (ev.Player.PlayerId == scp035id)
                {
                    ev.Die = false;
                }
            }
            public void OnCheckEscape(PlayerCheckEscapeEvent ev)
            {

                if (LLBS233.Contains(ev.Player.PlayerId))
                {
                    ev.AllowEscape = false;
                }
                foreach (Player player in plugin.PluginManager.Server.GetPlayers(""))
                {
                    if (player.TeamRole.Role == Smod2.API.Role.CHAOS_INSURGENCY)
                    {
                        chaos++;
                    }
                    if (player.TeamRole.Team == Smod2.API.Team.NINETAILFOX)
                    {
                        mtf++;
                    }
                }
                plugin.Info("混沌人数:" + chaos);
                plugin.Info("MTF人数:" + mtf);
                foreach (int num2 in touxiang)
                {
                    if (num2 == ev.Player.PlayerId)
                    {
                        plugin.Info("投降玩家是:" + ev.Player.Name);
                    }
                    if (((num2 == ev.Player.PlayerId) && (ev.Player.TeamRole.Role == Smod2.API.Role.CLASSD)) && (chaos == 0))
                    {
                        plugin.Info("玩家即将变为NTF学员");
                        plugin.Info("玩家名:" + ev.Player.Name);
                        ev.ChangeRole = Smod2.API.Role.NTF_CADET;
                        for (int i = 0; i <= 100; i++)
                        {
                            if (touxiang[i] == ev.Player.PlayerId)
                            {
                                touxiang[i] = 0;
                            }
                        }
                        chaos = 0;
                        mtf = 0;
                        return;
                    }
                    if (((num2 == ev.Player.PlayerId) && (ev.Player.TeamRole.Role == Smod2.API.Role.SCIENTIST)) && (mtf == 0))
                    {
                        plugin.Info("玩家即将变为混沌");
                        plugin.Info("玩家名:" + ev.Player.Name);
                        ev.ChangeRole = Smod2.API.Role.CHAOS_INSURGENCY;
                        for (int i = 0; i <= 100; i++)
                        {
                            if (touxiang[i] == ev.Player.PlayerId)
                            {
                                touxiang[i] = 0;
                            }
                        }
                        chaos = 0;
                        mtf = 0;
                        return;
                    }
                }
                ev.Player.GiveItem(Smod2.API.ItemType.MICROHID);
                chaos = 0;
                mtf = 0;
            }

            public void OnDoorAccess(PlayerDoorAccessEvent ev)
            {
                if(ev.Player.PlayerId == dsjscid)
                {
                    if (new Random().Next(0, 100) >= 95)
                    {
                        ev.Allow = true;
                    }
                }
                if(bhsx == true)
                {
                    if (new Random().Next(0, 100) >= 97)
                    {
                        ev.Allow = false;
                    }
                }
                if (csm == true)
                {
                    Doors = plugin.Server.Map.GetDoors();
                    Random random = new Random();
                    Door = Doors[random.Next(Doors.Count)];
                    ev.Player.Teleport(new Vector(Door.Position.x, Door.Position.y + (float)1.5, Door.Position.z));
                    ev.Player.PersonalClearBroadcasts();
                    ev.Player.PersonalBroadcast(5, "----[<color=#32CD32>SCP247</color>]----\n<color=#FF0000>你碰到了随机门以被传送</color>", false);

                }
                if (scp005 == true)
                {
                    if (ev.Player.PlayerId == scp005aid)
                    {
                        ev.Allow = true;
                    }
                }
                if (bscp79 == true)
                {
                    if (ev.Player.TeamRole.Team == Smod2.API.Team.SCP)
                    {
                        if (new Random().Next(0, 100) >= 95)
                        {
                            ev.Allow = true;
                        }
                    }
                }
                if (scp682.Contains(ev.Player.UserId) && (ev.Player.TeamRole.Role == Smod2.API.Role.SCP_939_89))
                {
                    if (new Random().Next(0, 100) >= 90)
                    {
                        ev.Destroy = true;
                        ev.Allow = true;
                    }
                }
                if (ev.Player.TeamRole.Role == Smod2.API.Role.SCIENTIST)
                {
                    ev.Destroy = false;
                }

                if (ev.Player.PlayerId == scp181id)
                {
                    Random random = new Random();
                    if (random.Next(1, 0x1f) == 0x18)
                    {
                        ev.Allow = true;
                    }
                }

                if (ev.Player.PlayerId == cxkid)
                {
                    Random random = new Random();
                    if (random.Next(1, 5) == 2)
                    {
                        ev.Allow = false;
                        ev.Player.PersonalBroadcast(3, "你太菜了导致门没打开", false);
                    }
                    if (jntm == true)
                    {
                        ev.Allow = true;
                        ev.Destroy = true;
                        ev.Player.PersonalClearBroadcasts();
                        ev.Player.PersonalBroadcast(4, "你发动鸡你太美门都看不下去了", false);

                    }
                }

                if ((ev.Player.TeamRole.Role == Smod2.API.Role.FACILITY_GUARD) && (ev.Door.Name == "INTERCOM"))
                {
                    ev.Destroy = true;
                    plugin.Server.Map.Broadcast(5, "暴躁老哥" + ev.Player.Name + "一jio踹开了广播室", false);
                }
                if ((ev.Player.TeamRole.Team == Smod2.API.Team.NINETAILFOX) && (ev.Door.Name == "INTERCOM"))
                {
                    ev.Destroy = true;
                    plugin.Server.Map.Broadcast(5, "暴躁老哥" + ev.Player.Name + "一jio踹开了广播室", false);
                }
                Random num111 = new Random();
                if ((num111.Next(1, 200) >= 199) && (deadtimer <= 1800))
                {
                    Doors = plugin.Server.Map.GetDoors();
                    Random random = new Random();
                    Door = Doors[random.Next(Doors.Count)];
                    ev.Player.Teleport(new Vector(Door.Position.x, Door.Position.y + (float)1.5, Door.Position.z));
                    ev.Player.PersonalClearBroadcasts();
                    ev.Player.PersonalBroadcast(5, "----[<color=#32CD32>SCP247</color>]----\n<color=#FF0000>你碰到了随机门以被传送</color>", false);

                }

                if ((door2.Contains(ev.Door) && (jljy2.Contains(ev.Player.UserId) == false)))
                {
                    ev.Player.Damage(50);
                    ev.Player.PersonalBroadcast(5, "吉良吉影为你点赞", false);
                    door2.Remove(ev.Door);
                }
                if ((ev.Player.TeamRole.Role == Smod2.API.Role.SCP_096) && (new Random().Next(1, 100) <= 3))
                {
                    ev.Allow = true;
                }
                if (ev.Door.Name.Equals("NUKE_SURFACE") && (ev.Player.HasItem(Smod2.API.ItemType.KEYCARDNTFCOMMANDER) || ev.Player.HasItem(Smod2.API.ItemType.KEYCARDCHAOSINSURGENCY)))
                {
                    ev.Allow = true;
                }
                if ((Dio2.Contains(ev.Player.UserId)) && (sjtz1 == true))
                {
                    ev.Destroy = true;
                    ev.Allow = true;
                }
                if ((Dio2.Contains(ev.Player.UserId) == false) && (sjtz1 == true))
                {
                    ev.Allow = false;
                }
                if (jljy2.Contains(ev.Player.UserId))
                {
                    int num3 = new Random().Next(1, 100);
                    if (num3 >= 99)
                    {
                        door2.Add(ev.Door);
                        ev.Player.PersonalBroadcast(5, "已经安放炸弹", false);
                    }
                }
            }

            public void OnPlayerDie(PlayerDeathEvent ev)
            {
                if((scp650yes == true)&&(ev.Player.PlayerId == scp650id))
                {

                    scp650 = null;
                    scp650id = 0;
                    scp650yes = false;
                    ev.Killer.SetGodmode(false);
                    ev.Killer.Kill();
                }
                if(ev.Player.PlayerId == dsjscid)
                {
                    dsjscid = 0;
                    dsjsc = null;
                    plugin.PluginManager.Server.Map.Broadcast(6, "----[<color=#32CD32>D[未知]</color>]----\n<color=#FF0000>[收容成功]</color>\n收容者: <color=#40E0D0>" + ev.Killer.Name + "</color>", false);
                    ev.Player.SetRank("white", "", null);
                }
                if(ev.Player.PlayerId == jwhhkid)
                {
                    jwhhkid = 0;
                    jwhhk = null;
                    ev.Player.SetRank("white", "", null);
                }
                if(ev.Player.PlayerId == scp073id)
                {
                    scp073 = null;
                    scp073id = 0;
                    ev.Player.SetRank("white", "", null);
                    PluginManager.Manager.Server.Map.AnnounceCustomMessage("SCP 0 7 3 CONTAINEDSUCCESSFULLY", false);
                    plugin.PluginManager.Server.Map.Broadcast(6, "----[<color=#32CD32>SCP073</color>]----\n<color=#FF0000>[收容成功]</color>\n收容者: <color=#40E0D0>" + ev.Killer.Name + "</color>", false);
                }
                if (ev.Player.PlayerId == scp076id)
                {
                    scp076 = null;
                    scp076id = 0;
                    scp076yes = false;

                    ev.Player.SetRank("white", "", null);
                    PluginManager.Manager.Server.Map.AnnounceCustomMessage("SCP 0 7 6 CONTAINEDSUCCESSFULLY", false);
                    plugin.PluginManager.Server.Map.Broadcast(6, "----[<color=#32CD32>SCP076</color>]----\n<color=#FF0000>[收容成功]</color>\n收容者: <color=#40E0D0>" + ev.Killer.Name + "</color>", false);
                }
                if (ev.Player.PlayerId == scp005aid)
                {
                    scp005aid = 0;
                }
                if (ev.Player.PlayerId == lbid)
                {
                    lb = null;
                    lbid = 0;
                    lbyes = false;
                }
                if (ev.Player.PlayerId == scp457id)
                {
                    scp457 = null;
                    scp457a = false;
                    scp457die = true;
                    scp457b = null;
                    ev.Player.SetRank("white", "", null);
                    scp457id = 0;
                    plugin.PluginManager.Server.Map.Broadcast(6, "----[<color=#32CD32>SCP457</color>]----\n<color=#FF0000>[收容成功]</color>\n收容者: <color=#40E0D0>" + ev.Killer.Name + "</color>", false);
                    PluginManager.Manager.Server.Map.AnnounceCustomMessage("SCP 4 5 7 CONTAINEDSUCCESSFULLY", false);
                }
                if (ev.Player.PlayerId == xtdid)
                {
                    xtd = null;
                    xtdid = 0;
                    xtd.SetRank("white", "", null);
                }
                if (qblcq2 == true)
                {
                    if (qblcq.PlayerId == ev.Player.PlayerId)
                    {
                        qblcq2 = false;
                        qblcq = null;
                    }
                }
                if (scp682.Contains(ev.Player.UserId))
                {
                    scp682.Remove(ev.Player.UserId);
                    ev.Player.SetRank("white", " ", null);
                    plugin.Info("scp682 " + ev.Player.Name + " 死了");
                    PluginManager.Manager.Server.Map.AnnounceScpKill("682", null);
                }
                if (scp939id == ev.Player.PlayerId)
                {
                    ev.Player.SetRank("white", " ", "");
                    scp939id = 0;
                }
                ev.Player.PersonalBroadcast(7, "欢迎回家qwq", false);
                if (ev.Player.PlayerId == scp914mid)
                {
                    scp914m = null;
                    scp914mid = 0;
                    plugin.PluginManager.Server.Map.Broadcast(6, "----[<color=#32CD32>SCP914-M</color>]----\n<color=#FF0000>[收容成功]</color>\n收容者: <color=#40E0D0>" + ev.Killer.Name + "</color>", false);
                    PluginManager.Manager.Server.Map.AnnounceCustomMessage("SCP 9 1 4 M CONTAINEDSUCCESSFULLY", false);
                }
                if (ev.Player.PlayerId == scpqblid2)
                {
                    scpqblid2 = 0;
                    plugin.PluginManager.Server.Map.Broadcast(6, "----[<color=#32CD32>SCP乔碧萝</color>]----\n<color=#FF0000>[收容成功]</color>\n收容者: <color=#40E0D0>" + ev.Killer.Name + "</color>", false);
                }
                if (ev.Player.PlayerId == scp181id)
                {
                    scp181id = 0;
                    PluginManager.Manager.Server.Map.AnnounceScpKill("181", null);
                    plugin.PluginManager.Server.Map.Broadcast(6, "----[<color=#32CD32>SCP181</color>]----\n<color=#FF0000>[收容成功]</color>\n收容者: <color=#40E0D0>" + ev.Killer.Name + "</color>", false);
                    ev.Player.SetRank("white", "", null);

                }
                if (ev.Player.PlayerId == scp035id)
                {
                    PluginManager.Manager.Server.Map.AnnounceScpKill("035", null);
                    plugin.PluginManager.Server.Map.Broadcast(6, "----[<color=#32CD32>SCP035</color>]----\n<color=#FF0000>[收容成功]</color>\n收容者: <color=#40E0D0>" + ev.Killer.Name + "</color>", false);
                    scp035 = null;
                    scp035id = 0;
                }
                if (scp2006a.Contains(ev.Player.UserId))
                {
                    scp2006a.Clear();
                    scp2006 = null;
                    plugin.PluginManager.Server.Map.Broadcast(6, "----[<color=#32CD32>SCP2006</color>]----\n<color=#FF0000>[收容成功]</color>\n收容者: <color=#40E0D0>" + ev.Killer.Name + "</color>", false);
                    PluginManager.Manager.Server.Map.AnnounceScpKill("2006", null);
                    ev.Player.SetRank("white", "", null);
                }
                if (ev.Player.PlayerId == cxkid)
                {
                    cxkid = 0;
                    cxk = null;
                    cxkyes = false;
                    string Killercxk = ev.Killer.Name;
                    plugin.PluginManager.Server.Map.Broadcast(6, "----[<color=#32CD32>SCP蔡徐坤</color>]----\n<color=#FF0000>[收容成功]</color>\n收容者: <color=#40E0D0>" + Killercxk + "</color>", false);
                    Killercxk = null;
                    PluginManager.Manager.Server.Map.AnnounceCustomMessage("SCP C X K CONTAINEDSUCCESSFULLY", false);
                    ev.Player.SetRank("white", "", null);
                }
                if (ev.Player.PlayerId == scp817id)
                {
                    scp817id = 0;
                    scp817 = null;
                    scp817yes = false;
                    string Killer817 = ev.Killer.Name;
                    plugin.PluginManager.Server.Map.Broadcast(6, "----[<color=#32CD32>SCP817</color>]----\n<color=#FF0000>[收容成功]</color>\n收容者: <color=#40E0D0>" + Killer817 + "</color>", false);
                    Killer817 = null;
                    PluginManager.Manager.Server.Map.AnnounceScpKill("817", null);
                    ev.Player.SetRank("white", "", null);
                }
                if (ev.Player.PlayerId == D9341id)
                {
                    if (times >= 5)
                    {
                        D9341 = null;
                        D9341id = 0;
                        D9341Item = null;
                        D9341yes = false;
                        D9341zb = null;
                        PluginManager.Manager.Server.Map.AnnounceCustomMessage("D 9 3 4 1 CONTAINEDSUCCESSFULLY", false);
                        ev.Player.SetRank("white", "", null);
                        plugin.PluginManager.Server.Map.Broadcast(6, "----[<color=#32CD32>D-9341</color>]----\n<color=#FF0000>[收容成功]</color>\n收容者: <color=#40E0D0>" + ev.Killer.Name + "</color>", false);
                    }
                }
                if (bpb2.Contains(ev.Player.PlayerId))
                {
                    bpb = false;
                    bpb2.Clear();
                    ev.Player.SetRank("white", "", null);
                }
                if (LLBS233.Contains(ev.Player.PlayerId))
                {
                    plugin.Server.Map.Broadcast(5, "<color=#FFFF33>Mr.fish:</color>\n装逼失败", false);
                    LLBS233.Remove(ev.Player.PlayerId);
                    ev.Player.SetRank("white", "", null);
                }
                if (Dio2.Contains(ev.Player.UserId))
                {
                    plugin.Server.Map.Broadcast(5, "<color=#FFFF33>Dio:</color>\n装逼失败", false);
                    Dio2.Remove(ev.Player.UserId);
                    Dio = null;
                    ev.Player.SetRank("white", "", null);
                }
                if (scp1143id == ev.Player.PlayerId)
                {
                    scp1143 = null;
                    scp1143id = 0;
                    scp1143a = false;
                    plugin.PluginManager.Server.Map.Broadcast(6, "----[<color=#32CD32>SCP1143</color>]----\n<color=#FF0000>[收容成功]</color>\n收容者: <color=#40E0D0>" + ev.Killer.Name + "</color>", false);
                }
                if (ylb2.Contains(ev.Player.UserId))
                {
                    ev.Player.SetRank("white", "", null);
                    ylb = null;
                    ylb1 = false;
                    ylb2.Clear();
                }
                if (HDZHG2.Contains(ev.Player.UserId))
                {
                    HDZHG2.Remove(ev.Player.UserId);
                }

                KillerID = ev.Killer.PlayerId;
                PlayerID = ev.Player.PlayerId;
                for (int i = 0; i <= 0x27; i++)
                {
                    if (touxiang[i] == ev.Player.PlayerId)
                    {
                        plugin.Info(string.Concat(new object[] { "死亡投降玩家:", ev.Player.Name, " 死于:", ev.Killer.Name, " 作为:", ev.Killer.TeamRole.Role }));
                        touxiang[i] = 0;
                    }
                }
                if (ev.Player.TeamRole.Role == Smod2.API.Role.SCP_173)
                {

                    s173 = 2;
                    if (KillerID == PlayerID)
                    {
                        plugin.Server.Map.Broadcast(6, "----[<color=#32CD32>SCP173</color>]----\n<color=#FF0000>[收容成功]</color>\n原因: <color=#40E0D0>自杀或者被服务器日了</color>", false);
                    }
                    else
                    {
                        if (ev.Killer.UserId == "76561198366416373@steam")
                        {
                            plugin.Server.Map.Broadcast(6, "----[<color=#32CD32>SCP173</color>]----\n<color=#FF0000>[收容成功]</color>\n花生你好弱啊 <color=#40E0D0>" + ev.Killer.Name + "</color>", false);
                        }
                        else
                        {
                            plugin.Server.Map.Broadcast(6, "----[<color=#32CD32>SCP173</color>]----\n<color=#FF0000>[收容成功]</color>\n收容者: <color=#40E0D0>" + ev.Killer.Name + "</color>", false);
                        }

                    }
                }
                if (ev.Player.TeamRole.Role == Smod2.API.Role.SCP_049)
                {
                    s049 = 2;
                    if (KillerID == PlayerID)
                    {
                        plugin.Server.Map.Broadcast(6, "----[<color=#32CD32>SCP049</color>]----\n<color=#FF0000>[收容成功]</color>\n原因: <color=#40E0D0>自杀或者被服务器日了</color>", false);
                    }
                    else
                    {
                        plugin.Server.Map.Broadcast(6, "----[<color=#32CD32>SCP049</color>]----\n<color=#FF0000>[收容成功]</color>\n收容者: <color=#40E0D0>" + ev.Killer.Name + "</color>", false);
                    }
                }
                if (ev.Player.TeamRole.Role == Smod2.API.Role.SCP_079)
                {
                    plugin.Server.Map.Broadcast(6, "----[<color=#32CD32>SCP079</color>]----\n<color=#FF0000>[收容成功]</color>\n原因: <color=#40E0D0>与核爆了</color>", false);
                    ev.Player.SetRank("red", "SCP079 - 核爆了", null);
                }
                if (ev.Player.TeamRole.Role == Smod2.API.Role.SCP_096)
                {
                    s096 = 2;
                    if (KillerID == PlayerID)
                    {
                        plugin.Server.Map.Broadcast(6, "----[<color=#32CD32>SCP096</color>]----\n<color=#FF0000>[收容成功]</color>\n原因: <color=#40E0D0>自杀或者被服务器日了</color>", false);
                    }
                    else
                    {
                        plugin.Server.Map.Broadcast(6, "----[<color=#32CD32>SCP096</color>]----\n<color=#FF0000>[收容成功]</color>\n收容者: <color=#40E0D0>" + ev.Killer.Name + "</color>", false);
                    }
                }
                if (ev.Player.TeamRole.Role == Smod2.API.Role.SCP_939_53)
                {
                    s939_53 = 2;
                    if (KillerID == PlayerID)
                    {
                        plugin.Server.Map.Broadcast(6, "----[<color=#32CD32>SCP939_53</color>]----\n<color=#FF0000>[收容成功]</color>\n原因: <color=#40E0D0>自杀或者被服务器日了</color>", false);
                    }
                    else
                    {
                        plugin.Server.Map.Broadcast(6, "----[<color=#32CD32>SCP939_53</color>]----\n<color=#FF0000>[收容成功]</color>\n收容者: <color=#40E0D0>" + ev.Killer.Name + "</color>", false);
                    }
                }
                if (ev.Player.TeamRole.Role == Smod2.API.Role.SCP_939_89)
                {
                    s939_89 = 2;
                    if (KillerID == PlayerID)
                    {
                        plugin.Server.Map.Broadcast(6, "----[<color=#32CD32>SCP939_89</color>]----\n<color=#FF0000>[收容成功]</color>\n原因: <color=#40E0D0>自杀或者被服务器日了</color>", false);
                    }
                    else
                    {
                        plugin.Server.Map.Broadcast(6, "----[<color=#32CD32>SCP939_89</color>]----\n<color=#FF0000>[收容成功]</color>\n收容者: <color=#40E0D0>" + ev.Killer.Name + "</color>", false);
                    }
                }
                if (ev.Player.TeamRole.Role == Smod2.API.Role.SCP_106)
                {
                    s106 = 2;
                    if (KillerID == PlayerID)
                    {
                        plugin.Server.Map.Broadcast(6, "----[<color=#32CD32>SCP106</color>]----\n<color=#FF0000>[收容成功]</color>\n原因: <color=#40E0D0>自杀或者被服务器日了</color>", false);
                    }
                    else
                    {
                        plugin.Server.Map.Broadcast(6, "----[<color=#32CD32>SCP106</color>]----\n<color=#FF0000>[收容成功]</color>\n收容者: <color=#40E0D0>" + ev.Killer.Name + "</color>", false);
                    }
                }
            }
            public void OnContain106(PlayerContain106Event ev)
            {
                plugin.Server.Map.ClearBroadcasts();
                plugin.Server.Map.Broadcast(20, "<color=red>广播</color>:(因大腿骨粉碎机而痛苦大叫)\n为什么? 为什么!\n呜呜呜呜呜呜呜", false);
            }
            public void OnCheckRoundEnd(CheckRoundEndEvent ev)
            {
                int num = 0;
                int num2 = 0;
                int num3 = 0;
                int num4 = 0;
                int num5 = 0;
                foreach (Player player in plugin.PluginManager.Server.GetPlayers(""))
                {
                    if ((player.TeamRole.Team == Smod2.API.Team.SCP) && (player.PlayerId != scp650id))
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
                    if ((player.TeamRole.Team == Smod2.API.Team.CLASSD) && (player.PlayerId != scp035id))
                    {
                        num4++;
                    }
                    if (player.TeamRole.Team == Smod2.API.Team.NINETAILFOX)
                    {
                        num5++;
                    }

                }
                if ((num2 == 0) && (num4 == 0) && (num >= 1) && (num5 == 0) && (num3 == 0))
                {
                    ev.Status = ROUND_END_STATUS.SCP_VICTORY;
                    plugin.PluginManager.Server.Round.EndRound();
                }
                if ((num == 0) && (num4 == 0) && (num5 >= 1))
                {
                    ev.Status = ROUND_END_STATUS.MTF_VICTORY;
                    this.plugin.PluginManager.Server.Round.EndRound();
                }

            }
            public void OnPlayerDropItem(PlayerDropItemEvent ev)
            {
                Vector room = ev.Player.GetPosition();
                if (ylb2.Contains(ev.Player.UserId))
                {
                    if (ev.Item.ItemType == Smod2.API.ItemType.FLASHLIGHT)
                    {
                        ev.ChangeTo = Smod2.API.ItemType.MEDKIT;
                    }
                    if (ev.Item.ItemType == Smod2.API.ItemType.RADIO)
                    {
                        ev.ChangeTo = Smod2.API.ItemType.MEDKIT;
                    }


                }
                if (bpb2.Contains(ev.Player.PlayerId))
                {
                    if (ev.Item.ItemType == Smod2.API.ItemType.FLASHLIGHT)
                    {
                        ev.ChangeTo = Smod2.API.ItemType.GRENADEFRAG;
                    }
                    if (ev.Item.ItemType == Smod2.API.ItemType.RADIO)
                    {
                        ev.ChangeTo = Smod2.API.ItemType.GRENADEFRAG;
                    }
                }
            }
                if ((a127d == true) && (ev.Item.ItemType == Smod2.API.ItemType.GUNUSP))
                {
                    if (scp3108pick == false)
                    {
                        scp3108playerid = ev.Player.PlayerId;
                        scp3108pick = true;
                        plugin.Server.Map.Broadcast(5, "<color=red>SCP-3108已被捡起被打中的人会强行转换身份</color>", false);
                        ev.Player.PersonalBroadcast(5, "<color=lime>你捡起了</color>\n[<color=red>SCP-3108</color>]\n<color=lime>使用本手枪射中人会让他角色变化 你只能开一枪</color>", false);
                    }
                }
                if (ev.Player.PlayerId == scp914mid)
                {
                    int cardup = new Random().Next(1, 4);
                    if (cardup == 2)
                    {
                        if (ev.Item.ItemType == Smod2.API.ItemType.KEYCARDSCIENTIST)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.KEYCARDSCIENTISTMAJOR;
                        }
                        if (ev.Item.ItemType == Smod2.API.ItemType.KEYCARDJANITOR)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.KEYCARDSCIENTIST;
                        }
                        if (ev.Item.ItemType == Smod2.API.ItemType.KEYCARDNTFLIEUTENANT)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.KEYCARDNTFCOMMANDER;
                        }
                        if (ev.Item.ItemType == Smod2.API.ItemType.KEYCARDSCIENTISTMAJOR)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.KEYCARDCHAOSINSURGENCY;
                        }
                        if (ev.Item.ItemType == Smod2.API.ItemType.KEYCARDCHAOSINSURGENCY)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.KEYCARDNTFCOMMANDER;
                        }
                        if (ev.Item.ItemType == Smod2.API.ItemType.KEYCARDNTFCOMMANDER)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.KEYCARDO5;
                        }
                        if (ev.Item.ItemType == Smod2.API.ItemType.KEYCARDZONEMANAGER)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.KEYCARDCONTAINMENTENGINEER;
                        }

                        if (ev.Item.ItemType == Smod2.API.ItemType.KEYCARDCHAOSINSURGENCY)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.KEYCARDO5;
                        }
                        if (ev.Item.ItemType == Smod2.API.ItemType.GUNCOM15)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.GUNPROJECT90;
                        }
                        if (ev.Item.ItemType == Smod2.API.ItemType.GUNCOM15)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.GUNPROJECT90;
                        }
                        if (ev.Item.ItemType == Smod2.API.ItemType.GUNPROJECT90)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.GUNE11SR;
                        }
                        if (ev.Item.ItemType == Smod2.API.ItemType.GUNE11SR)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.GUNLOGICER;
                        }
                        if (ev.Item.ItemType == Smod2.API.ItemType.GUNLOGICER)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.MICROHID;
                        }
                        if (ev.Item.ItemType == Smod2.API.ItemType.GUNCOM15)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.GUNPROJECT90;
                        }
                        if (ev.Item.ItemType == Smod2.API.ItemType.FLASHLIGHT)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.GRENADEFRAG;
                        }

                    }
                    if (cardup == 3)
                    {
                        if (ev.Item.ItemType == Smod2.API.ItemType.KEYCARDSCIENTISTMAJOR)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.KEYCARDSCIENTIST;
                        }
                        if (ev.Item.ItemType == Smod2.API.ItemType.KEYCARDSCIENTIST)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.KEYCARDJANITOR;
                        }
                        if (ev.Item.ItemType == Smod2.API.ItemType.KEYCARDNTFCOMMANDER)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.KEYCARDNTFCOMMANDER;
                        }
                        if (ev.Item.ItemType == Smod2.API.ItemType.KEYCARDCHAOSINSURGENCY)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.KEYCARDSCIENTISTMAJOR;
                        }
                        if (ev.Item.ItemType == Smod2.API.ItemType.KEYCARDCHAOSINSURGENCY)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.KEYCARDCHAOSINSURGENCY;
                        }
                        if (ev.Item.ItemType == Smod2.API.ItemType.KEYCARDCONTAINMENTENGINEER)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.KEYCARDZONEMANAGER;

                        }
                        if (ev.Item.ItemType == Smod2.API.ItemType.GUNPROJECT90)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.GUNCOM15;

                        }
                        if (ev.Item.ItemType == Smod2.API.ItemType.GUNPROJECT90)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.GUNCOM15;
                        }
                        if (ev.Item.ItemType == Smod2.API.ItemType.GUNE11SR)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.GUNPROJECT90;
                        }
                        if (ev.Item.ItemType == Smod2.API.ItemType.GUNLOGICER)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.GUNE11SR;
                        }
                        if (ev.Item.ItemType == Smod2.API.ItemType.MICROHID)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.GUNLOGICER;
                        }
                        if (ev.Item.ItemType == Smod2.API.ItemType.GUNPROJECT90)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.GUNCOM15;
                        }
                        if (ev.Item.ItemType == Smod2.API.ItemType.GRENADEFRAG)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.FLASHLIGHT;
                        }
                    }
                }
                if (ev.Player.PlayerId == scp181id)
                {
                    if (ev.Item.ItemType == Smod2.API.ItemType.KEYCARDSCIENTIST)
                    {
                        int cardup = new Random().Next(1, 100);
                        if (cardup >= 80)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.KEYCARDSCIENTISTMAJOR;
                            ev.Player.PersonalBroadcast(5, "[<color=red>当当当当你的科学家变成了大科学家卡</color>]", false);
                        }

                    }
                    if (ev.Item.ItemType == Smod2.API.ItemType.KEYCARDJANITOR)
                    {
                        int cardup = new Random().Next(1, 100);
                        plugin.Info("测试" + cardup);
                        if (cardup >= 80)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.KEYCARDSCIENTIST;
                            ev.Player.PersonalBroadcast(5, "[<color=red>当当当当你的清洁工变成了科学家卡</color>]", false);
                        }
                    }
                    if (ev.Item.ItemType == Smod2.API.ItemType.KEYCARDNTFLIEUTENANT)
                    {
                        int cardup = new Random().Next(1, 100);
                        if (cardup >= 80)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.KEYCARDNTFCOMMANDER;
                            ev.Player.PersonalBroadcast(5, "[<color=red>当当当当你的士官卡变成了指挥官卡</color>]", false);
                        }
                    }

                    if (ev.Item.ItemType == Smod2.API.ItemType.KEYCARDSCIENTISTMAJOR)
                    {
                        int cardup = new Random().Next(1, 100);
                        if (cardup >= 80)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.KEYCARDCHAOSINSURGENCY;
                            ev.Player.PersonalBroadcast(5, "[<color=red>当当当当你的大科学家变成了收容工程师卡</color>]", false);
                        }

                    }
                    if (ev.Item.ItemType == Smod2.API.ItemType.KEYCARDCHAOSINSURGENCY)
                    {
                        int cardup = new Random().Next(1, 100);
                        if (cardup >= 80)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.KEYCARDNTFCOMMANDER;
                            ev.Player.PersonalBroadcast(5, "[<color=red>当当当当你的收容工程师卡变成了指挥官卡</color>]", false);
                        }
                    }
                    if (ev.Item.ItemType == Smod2.API.ItemType.KEYCARDNTFCOMMANDER)
                    {
                        int cardup = new Random().Next(1, 100);
                        if (cardup >= 80)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.KEYCARDO5;
                            ev.Player.PersonalBroadcast(5, "[<color=red>当当当当你的指挥官卡变成了黑卡</color>]", false);
                        }
                    }
                    if (ev.Item.ItemType == Smod2.API.ItemType.KEYCARDZONEMANAGER)
                    {
                        int cardup = new Random().Next(1, 100);
                        if (cardup >= 80)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.KEYCARDCONTAINMENTENGINEER;
                            ev.Player.PersonalBroadcast(5, "[<color=red>当当当当你的区域总监卡变成了设施总监卡</color>]", false);
                        }
                    }
                    if (ev.Item.ItemType == Smod2.API.ItemType.KEYCARDJANITOR)
                    {
                        int cardup = new Random().Next(1, 100);
                        if (cardup >= 80)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.KEYCARDNTFLIEUTENANT;
                            ev.Player.PersonalBroadcast(5, "[<color=red>当当当当你的九尾狐新兵卡变成了九尾狐士官卡</color>]", false);
                        }
                    }
                    if (ev.Item.ItemType == Smod2.API.ItemType.KEYCARDJANITOR)
                    {
                        int cardup = new Random().Next(1, 100);
                        if (cardup >= 80)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.KEYCARDJANITOR;
                            ev.Player.PersonalBroadcast(5, "[<color=red>当当当当你的保安卡变成了设施九尾狐新兵卡</color>]", false);
                        }
                    }
                    if (ev.Item.ItemType == Smod2.API.ItemType.KEYCARDCHAOSINSURGENCY)
                    {
                        int cardup = new Random().Next(1, 100);
                        if (cardup >= 80)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.KEYCARDO5;
                            ev.Player.PersonalBroadcast(5, "[<color=red>当当当当你的混沌卡变成了设施黑卡</color>]", false);
                        }
                    }
                    if (ev.Item.ItemType == Smod2.API.ItemType.GUNCOM15)
                    {
                        int cardup = new Random().Next(1, 100);
                        if (cardup >= 80)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.GUNPROJECT90;
                            ev.Player.PersonalBroadcast(5, "[<color=red>当当当当你的小手枪变成了P90</color>]", false);
                        }
                    }
                    if (ev.Item.ItemType == Smod2.API.ItemType.GUNCOM15)
                    {
                        int cardup = new Random().Next(1, 100);
                        if (cardup >= 80)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.GUNPROJECT90;
                            ev.Player.PersonalBroadcast(5, "[<color=red>当当当当你的小手枪变成了P90</color>]", false);
                        }
                    }
                    if (ev.Item.ItemType == Smod2.API.ItemType.GUNPROJECT90)
                    {
                        int cardup = new Random().Next(1, 100);
                        if (cardup >= 80)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.GUNE11SR;
                            ev.Player.PersonalBroadcast(5, "[<color=red>当当当当你的P90变成了九尾步枪</color>]", false);
                        }
                    }
                    if (ev.Item.ItemType == Smod2.API.ItemType.GUNE11SR)
                    {
                        int cardup = new Random().Next(1, 100);
                        if (cardup >= 80)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.GUNLOGICER;
                            ev.Player.PersonalBroadcast(5, "[<color=red>当当当当你的九尾步枪变成了大菠萝</color>]", false);
                        }
                    }
                    if (ev.Item.ItemType == Smod2.API.ItemType.GUNLOGICER)
                    {
                        int cardup = new Random().Next(1, 100);
                        if (cardup >= 80)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.MICROHID;
                            ev.Player.PersonalBroadcast(5, "[<color=red>当当当当你的大菠萝变成了电磁炮</color>]", false);
                        }
                    }
                    if (ev.Item.ItemType == Smod2.API.ItemType.GUNCOM15)
                    {
                        int cardup = new Random().Next(1, 100);
                        if (cardup >= 80)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.GUNPROJECT90;
                            ev.Player.PersonalBroadcast(5, "[<color=red>当当当当你的保安枪变成了P90</color>]", false);
                        }
                    }
                    if (ev.Item.ItemType == Smod2.API.ItemType.FLASHLIGHT)
                    {
                        int cardup = new Random().Next(1, 100);
                        if (cardup >= 80)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.GRENADEFRAG;
                            ev.Player.PersonalBroadcast(5, "[<color=red>当当当当你的闪光弹枪变成了手榴弹</color>]", false);
                        }
                    }
                }
                if ((scp1577pick == false) && (ev.Item.ItemType == Smod2.API.ItemType.GUNCOM15))
                {
                    Vector scp1577pos2 = plugin.Server.Map.GetRandomSpawnPoint(Smod2.API.Role.SCP_173);
                    float num2 = scp1577pos2.x + 10;
                    float num3 = scp1577pos2.y + 10;
                    float num4 = scp1577pos2.z + 10;
                    float num5 = scp1577pos2.x - 10;
                    float num6 = scp1577pos2.y - 10;
                    float num7 = scp1577pos2.z - 10;
                    if ((ev.Player.GetPosition().x <= num2) && (ev.Player.GetPosition().x >= num5) && (ev.Player.GetPosition().y <= num3) && (ev.Player.GetPosition().y >= num6) && ((ev.Player.GetPosition().z <= num4) && (ev.Player.GetPosition().z >= num7)))
                    {
                        scp1577pick = true;
                        scp1577id.Add(ev.Player.PlayerId);
                        ev.Player.PersonalBroadcast(5, "<color=lime>你捡起了 信号枪</color>\n[<color=red>SCP-1577</color>]\n<color=lime>使用本手枪射击可以呼叫空投</color>", false);

                    }
                }
                if (ev.Player.PlayerId == dsjscid)
                {
                    if(ev.Item.ItemType == Smod2.API.ItemType.FLASHLIGHT)
                    {
                        ev.ChangeTo = Smod2.API.ItemType.COIN;
                        Doors = plugin.Server.Map.GetDoors();
                        Vector pos2 = ev.Player.GetPosition();
                        float num2 = pos2.x + 150;
                        float num3 = pos2.y + 150;
                        float num4 = pos2.z + 150;
                        float num5 = pos2.x - 150;
                        float num6 = pos2.y - 150;
                        float num7 = pos2.z - 150;
                        foreach (Smod2.API.Door door in Doors)
                        {
                            if((door.Position.x <= num2) && (door.Position.x >= num5) && (door.Position.y <= num3) && (door.Position.y >= num6) && (door.Position.z <= num4) && (door.Position.z >= num7))
                            {
                                doord.Add(door);
                            }
                        }
                        foreach(Smod2.API.Door door1 in doord)
                        {
                            door1.Open = true;
                            door1.Locked = true;
                        }
                    }
                }
                if (ev.Player.PlayerId == scp005aid)
                {
                    if (ev.Item.ItemType == Smod2.API.ItemType.KEYCARDJANITOR)
                    {
                        scp005aid = 0;

                    }
                }
                if (ev.Item.ItemType == Smod2.API.ItemType.KEYCARDJANITOR)
                {
                    if (scp005 == false)
                    {
                        scp005aid = ev.Player.PlayerId;
                        ev.Player.PersonalBroadcast(5, "<color=lime>你捡起了</color>[<color=red>SCP-005</color>]", false);
                    }
                }

                if (ev.Item.ItemType == Smod2.API.ItemType.GUNUSP)
                {
                    a127 = false;

                }
                if (ev.Player.PlayerId == D9341id)
                {
                    if (ev.Item.ItemType == Smod2.API.ItemType.GRENADEFLASH)
                    {
                        D9341.PersonalBroadcast(6, "存档成功", false);
                        ev.Item.Remove();
                        D9341.GiveItem(Smod2.API.ItemType.GRENADEFLASH);
                        D9341Item = D9341.GetInventory();
                        D9341zb = D9341.GetPosition();
                       
                        D9341js = D9341.TeamRole.Role;
                    }
                    if (ev.Item.ItemType == Smod2.API.ItemType.FLASHLIGHT)
                    {
                        if (times <= 5)
                        {
                            D9341.ChangeRole(D9341js, true, true, true, true);
                            foreach (Smod2.API.Item item2 in D9341Item)
                            {
                                D9341.GiveItem(item2.ItemType);
                            }
                            D9341.Teleport(D9341zb, false);
                            times++;
                        }

                    }
                }
                if (scp2006id == ev.Player.PlayerId)
                {
                    if (ev.Item.ItemType == Smod2.API.ItemType.COIN)
                    {
                        Doors = plugin.Server.Map.GetDoors();
                        Random random = new Random();
                        Door = Doors[random.Next(Doors.Count)];
                        ev.Player.Teleport(new Vector(Door.Position.x, Door.Position.y + (float)1.5, Door.Position.z));
                    }
                }
                if (ev.Player.PlayerId == cxkid)
                {
                    if (ev.Item.ItemType == Smod2.API.ItemType.FLASHLIGHT)
                    {
                        jntm = true;
                        ev.Player.PersonalClearBroadcasts();
                        ev.ChangeTo = Smod2.API.ItemType.COIN;
                        ev.Player.PersonalBroadcast(10, "成功发动鸡你太美时长10秒", false);
                        PluginManager.Manager.Server.Map.AnnounceCustomMessage("SCP C X K START J N T M", false);

                    }
                }
                if ((room.y <= -1f) && (room.y >= -7f))
                {
                    if (coldwait233 == false)
                    {
                        ev.Player.GiveItem(ev.Item.ItemType);
                        ev.Player.GiveItem(ev.Item.ItemType);
                        ev.Player.PersonalBroadcast(5, "复制成功", false);
                        coldwait233 = true;
                    }
                    if (coldwait233 == true)
                    {
                        ev.Player.PersonalBroadcast(5, "038:累死我了一会再来呗QAQ", false);
                    }
                }
                if (scp2818pick == true)
                {
                    if ((ev.Item.ItemType == Smod2.API.ItemType.GUNCOM15) && (scp2818.PlayerId == ev.Player.PlayerId))
                    {
                        ev.Player.PersonalBroadcast(5, "SCP2818已经被扔下", false);
                        scp2818pick = false;
                        scp2818id = 0;
                        scp2818 = null;
                    }
                }
                if ((ev.Item.ItemType == Smod2.API.ItemType.GUNCOM15) && (scp2818pick == false))
                {
                    plugin.Server.Map.Broadcast(5, "SCP-2818已经被" + ev.Player.Name + "捡起", false);
                    ev.Player.PersonalBroadcast(5, "你捡起了2818 开枪后瞬间死亡伤害1000点", false);
                    PluginManager.Manager.Server.Map.AnnounceCustomMessage("SCP 2 8 1 8 TAKEN", false);
                    scp2818 = ev.Player;
                    scp2818id = ev.Player.PlayerId;
                    scp2818pick = true;
                }
                if ((Dio2.Contains(ev.Player.UserId)) && (ev.Item.ItemType == Smod2.API.ItemType.FLASHLIGHT) && (sjtz2 == false))
                {
                    ev.ChangeTo = Smod2.API.ItemType.COIN;
                    plugin.Server.Map.ClearBroadcasts();
                    plugin.Server.Map.Broadcast(12, "<color=#99FF00>Dio发动了时间停止</color>", false);
                    sjtz1 = true;
                    sjtz2 = true;
                    cd = new Thread(CD);
                    cd.Start();

                    player5 = plugin.Server.GetPlayers();
                    for (int i = 0; i < player5.Count; i++)
                    {
                        pos1.Add(player5[i].GetPosition());
                    }
                }
                if (ev.Item.ItemType == Smod2.API.ItemType.COIN)
                {
                    int num = new Random().Next(1, 12);
                    switch (num)
                    {
                        case 1:
                            ev.ChangeTo = Smod2.API.ItemType.COIN;
                            ev.Player.PersonalBroadcast(5, "<color=#FF1493>你的硬币变成了</color>\n[硬币]", false);
                            plugin.Info("硬币变为了硬币| 玩家:" + ev.Player.Name);
                            goto Label_01E9;

                        case 2:
                            ev.ChangeTo = Smod2.API.ItemType.MICROHID;
                            ev.Player.PersonalBroadcast(5, "<color=#FF1493>你的硬币变成了</color>\n[电磁炮·没电]", false);
                            plugin.Info("硬币变为了电磁炮| 玩家:" + ev.Player.Name);
                            goto Label_01E9;

                        case 3:
                            ev.ChangeTo = Smod2.API.ItemType.GUNE11SR;
                            ev.Player.PersonalBroadcast(5, "<color=#FF1493>你的硬币变成了</color>\n[九尾步枪]", false);
                            plugin.Info("硬币变为了九尾步枪| 玩家:" + ev.Player.Name);
                            goto Label_01E9;

                        case 4:
                            ev.ChangeTo = Smod2.API.ItemType.KEYCARDCHAOSINSURGENCY;
                            ev.Player.PersonalBroadcast(5, "<color=#FF1493>你的硬币变成了</color>\n[收容工程师卡]", false);
                            plugin.Info("硬币变为了收容工程师卡| 玩家:" + ev.Player.Name);
                            goto Label_01E9;
                    }
                    if (num == 5)
                    {
                        ev.ChangeTo = Smod2.API.ItemType.GRENADEFRAG;
                        ev.Player.PersonalBroadcast(5, "<color=#FF1493>你的硬币变成了</color>\n[手雷]", false);
                        plugin.Info("硬币变为了手雷| 玩家:" + ev.Player.Name);
                    }
                    if (num == 6)
                    {
                        ev.ChangeTo = Smod2.API.ItemType.AMMO556;
                        ev.Player.PersonalBroadcast(5, "<color=#FF1493>你的硬币变成了</color>\n[5.56子弹]", false);
                    }
                    if (num == 7)
                    {
                        ev.ChangeTo = Smod2.API.ItemType.GUNLOGICER;
                        ev.Player.PersonalBroadcast(5, "<color=#FF1493>你的硬币变成了</color>\n[大菠萝]", false);
                    }
                    if (num == 8)
                    {
                        ev.ChangeTo = Smod2.API.ItemType.KEYCARDGUARD;
                        ev.Player.PersonalBroadcast(5, "<color=#FF1493>你的硬币变成了</color>\n[保安卡]", false);
                    }
                    if (num == 9)
                    {
                        ev.ChangeTo = Smod2.API.ItemType.RADIO;
                        ev.Player.PersonalBroadcast(5, "<color=#FF1493>你的硬币变成了</color>\n[对讲机·没电]", false);
                    }
                    if (num == 10)
                    {
                        ev.ChangeTo = Smod2.API.ItemType.KEYCARDSCIENTIST;
                        ev.Player.PersonalBroadcast(5, "<color=#FF1493>你的硬币变成了</color>\n[科学家卡]", false);
                    }
                    else
                    {
                        ev.ChangeTo = Smod2.API.ItemType.FLASHLIGHT;
                        ev.Player.PersonalBroadcast(5, "<color=#FF1493>你的硬币变成了</color>\n[手电筒]", false);
                        plugin.Info("硬币变为了手电筒| 玩家:" + ev.Player.Name);
                    }
                }
                Label_01E9:
                if ((((((s173 == 0) || (s173 == 2)) && ((s096 == 0) || (s096 == 2))) && (((s939_53 == 0) || (s939_53 == 2)) && ((s939_89 == 0) || (s939_89 == 2)))) && ((s049 == 0) || (s049 == 2))) && ((s106 == 1) && (RoleSet != 1)))
                {
                    plugin.Info("当前场上只剩余一个SCP了");
                    if (ev.Player.TeamRole.Role == Smod2.API.Role.NTF_COMMANDER)
                    {
                        ev.Player.PersonalClearBroadcasts();
                        ev.Player.PersonalBroadcast(5, "当前场上只剩下一个SCP了\n<color=#FF1493>你可以把你的指挥官卡丢出来</color>\n变为收容工程师卡", false);
                        if (ev.Item.ItemType == Smod2.API.ItemType.KEYCARDNTFCOMMANDER)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.KEYCARDCHAOSINSURGENCY;
                            RoleSet = 1;
                        }
                    }
                }
                else if ((((((s106 == 0) || (s106 == 2)) && ((s096 == 0) || (s096 == 2))) && (((s939_53 == 0) || (s939_53 == 2)) && ((s939_89 == 0) || (s939_89 == 2)))) && ((s049 == 0) || (s049 == 2))) && ((s173 == 1) && (RoleSet != 1)))
                {
                    plugin.Info("当前场上只剩余一个SCP了");
                    if (ev.Player.TeamRole.Role == Smod2.API.Role.NTF_COMMANDER)
                    {
                        ev.Player.PersonalClearBroadcasts();
                        ev.Player.PersonalBroadcast(5, "当前场上只剩下一个SCP了\n<color=#FF1493>你可以把你的指挥官卡丢出来</color>\n变为收容工程师卡", false);
                        if (ev.Item.ItemType == Smod2.API.ItemType.KEYCARDNTFCOMMANDER)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.KEYCARDCHAOSINSURGENCY;
                            RoleSet = 1;
                        }
                    }
                }
                else if ((((((s106 == 0) || (s106 == 2)) && ((s173 == 0) || (s173 == 2))) && (((s939_53 == 0) || (s939_53 == 2)) && ((s939_89 == 0) || (s939_89 == 2)))) && ((s049 == 0) || (s049 == 2))) && ((s096 == 1) && (RoleSet != 1)))
                {
                    plugin.Info("当前场上只剩余一个SCP了");
                    if (ev.Player.TeamRole.Role == Smod2.API.Role.NTF_COMMANDER)
                    {
                        ev.Player.PersonalClearBroadcasts();
                        ev.Player.PersonalBroadcast(5, "当前场上只剩下一个SCP了\n<color=#FF1493>你可以把你的指挥官卡丢出来</color>\n变为收容工程师卡", false);
                        if (ev.Item.ItemType == Smod2.API.ItemType.KEYCARDNTFCOMMANDER)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.KEYCARDCHAOSINSURGENCY;
                            RoleSet = 1;
                        }
                    }
                }
                else if ((((((s106 == 0) || (s106 == 2)) && ((s173 == 0) || (s173 == 2))) && (((s096 == 0) || (s096 == 2)) && ((s939_89 == 0) || (s939_89 == 2)))) && ((s049 == 0) || (s049 == 2))) && ((s939_53 == 1) && (RoleSet != 1)))
                {
                    plugin.Info("当前场上只剩余一个SCP了");
                    if (ev.Player.TeamRole.Role == Smod2.API.Role.NTF_COMMANDER)
                    {
                        ev.Player.PersonalClearBroadcasts();
                        ev.Player.PersonalBroadcast(5, "当前场上只剩下一个SCP了\n<color=#FF1493>你可以把你的指挥官卡丢出来</color>\n变为收容工程师卡", false);
                        if (ev.Item.ItemType == Smod2.API.ItemType.KEYCARDNTFCOMMANDER)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.KEYCARDCHAOSINSURGENCY;
                            RoleSet = 1;
                        }
                    }
                }
                else if ((((((s106 == 0) || (s106 == 2)) && ((s173 == 0) || (s173 == 2))) && (((s096 == 0) || (s096 == 2)) && ((s939_53 == 0) || (s939_53 == 2)))) && ((s049 == 0) || (s049 == 2))) && ((s939_89 == 1) && (RoleSet != 1)))
                {
                    plugin.Info("当前场上只剩余一个SCP了");
                    if (ev.Player.TeamRole.Role == Smod2.API.Role.NTF_COMMANDER)
                    {
                        ev.Player.PersonalClearBroadcasts();
                        ev.Player.PersonalBroadcast(5, "当前场上只剩下一个SCP了\n<color=#FF1493>你可以把你的指挥官卡丢出来</color>\n变为收容工程师卡", false);
                        if (ev.Item.ItemType == Smod2.API.ItemType.KEYCARDNTFCOMMANDER)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.KEYCARDCHAOSINSURGENCY;
                            RoleSet = 1;
                        }
                    }
                }
                else if ((((((s106 == 0) || (s106 == 2)) && ((s173 == 0) || (s173 == 2))) && (((s096 == 0) || (s096 == 2)) && ((s939_53 == 0) || (s939_53 == 2)))) && ((s939_89 == 0) || (s939_89 == 2))) && ((s049 == 1) && (RoleSet != 1)))
                {
                    plugin.Info("当前场上只剩余一个SCP了");
                    if (ev.Player.TeamRole.Role == Smod2.API.Role.NTF_COMMANDER)
                    {
                        ev.Player.PersonalClearBroadcasts();
                        ev.Player.PersonalBroadcast(5, "当前场上只剩下一个SCP了\n<color=#FF1493>你可以把你的指挥官卡丢出来</color>\n变为收容工程师卡", false);
                        if (ev.Item.ItemType == Smod2.API.ItemType.KEYCARDNTFCOMMANDER)
                        {
                            ev.ChangeTo = Smod2.API.ItemType.KEYCARDCHAOSINSURGENCY;
                            RoleSet = 1;
                        }
                    }
                }
            }

            public void OnPlayerHurt(PlayerHurtEvent ev)
            {
                LCZ = ev.Player.GetPosition();
                int num = 0;
                int num2 = 0;
                if(ev.Attacker.PlayerId == scp650id)
                {
                    gjtr++;
                    ev.Attacker.PersonalBroadcast(4, "<color=red>停止多次攻击刷血否则您将会被请出服务器</color>", false);
                    if (gjtr == 50)
                    {
                        ev.Attacker.Ban(0, "你触发650刷血限制");

                    }
                }
                if((ev.DamageType == DamageType.USP)&&(ev.Player.PlayerId != scp650id)&&(ev.Player.PlayerId != scp457id))
                {
                    if(ev.Attacker.PlayerId == scp3108playerid)
                    {
                        scp3108playerid = 0;
                        scp3108shotatplayeritems = ev.Player.GetInventory();
                        scp3108shotatplayerpos = ev.Player.GetPosition();
                        ev.Damage = 0;
                        int Rolenum = new Random().Next(1, 17);
                        if (Rolenum == 1)
                        {
                            ev.Player.ChangeRole(Smod2.API.Role.SCIENTIST, true, false, false, false);
                        }
                        if (Rolenum == 2)
                        {
                            ev.Player.ChangeRole(Smod2.API.Role.CHAOS_INSURGENCY, true, false, false, false);
                        }
                        if (Rolenum == 3)
                        {
                            ev.Player.ChangeRole(Smod2.API.Role.FACILITY_GUARD, true, false, false, false);
                        }
                        if (Rolenum == 4)
                        {
                            ev.Player.ChangeRole(Smod2.API.Role.NTF_CADET, true, false, false, false);
                        }
                        if (Rolenum == 5)
                        {
                            ev.Player.ChangeRole(Smod2.API.Role.NTF_COMMANDER, true, false, false, false);
                        }
                        if (Rolenum == 6)
                        {
                            ev.Player.ChangeRole(Smod2.API.Role.NTF_LIEUTENANT, true, false, false, false);
                        }
                        if (Rolenum == 7)
                        {
                            ev.Player.ChangeRole(Smod2.API.Role.NTF_SCIENTIST, true, false, false, false);
                        }
                        if (Rolenum == 8)
                        {
                            ev.Player.ChangeRole(Smod2.API.Role.SCP_049_2, true, false, false, false);
                        }
                        if (Rolenum == 9)
                        {
                            ev.Player.ChangeRole(Smod2.API.Role.SCP_079, true, false, false, false);
                        }
                        if (Rolenum == 10)
                        {
                            ev.Player.ChangeRole(Smod2.API.Role.SCP_106, true, false, false, false);
                        }
                        if (Rolenum == 11)
                        {
                            ev.Player.ChangeRole(Smod2.API.Role.SCP_173, true, false, false, false);
                        }
                        if (Rolenum == 12)
                        {
                            ev.Player.ChangeRole(Smod2.API.Role.SCP_939_53, true, false, false, false);
                        }
                        if (Rolenum == 13)
                        {
                            ev.Player.ChangeRole(Smod2.API.Role.SCP_939_89, true, false, false, false);
                        }
                        if (Rolenum == 14)
                        {
                            ev.Player.ChangeRole(Smod2.API.Role.TUTORIAL, true, false, false, false);
                        }
                        if (Rolenum == 15)
                        {
                            ev.Player.ChangeRole(Smod2.API.Role.UNASSIGNED, true, false, false, false);
                        }
                        if (Rolenum == 16)
                        {
                            ev.Player.ChangeRole(Smod2.API.Role.ZOMBIE, true, false, false, false);
                        }

                        ev.Player.PersonalBroadcast(5, "<color=red>你被SCP-3108射击已经转变身份</color>", false);

                        foreach (Smod2.API.Item item2 in scp3108shotatplayeritems)
                        {
                            ev.Player.GiveItem(item2.ItemType);
                        }
                        ev.Player.Teleport(scp3108shotatplayerpos);
                    }
                }
                if ((ev.Attacker.PlayerId == scp650id) && (ev.DamageType != DamageType.TESLA) && (ev.DamageType != DamageType.DECONT) && (ev.DamageType != DamageType.FALLDOWN) && (ev.DamageType != DamageType.FLYING) && (ev.DamageType != DamageType.NUKE) && (ev.DamageType != DamageType.POCKET) && (ev.DamageType != DamageType.WALL) && (ev.DamageType != DamageType.LURE))
                {
                    ev.Damage = 0;
                }
                if ((ev.Attacker.TeamRole.Role == Smod2.API.Role.SCP_173)&&(Dio2.Contains(ev.Player.UserId)) && (ev.DamageType != DamageType.TESLA) && (ev.DamageType != DamageType.DECONT) && (ev.DamageType != DamageType.FALLDOWN) && (ev.DamageType != DamageType.FLYING) && (ev.DamageType != DamageType.NUKE) && (ev.DamageType != DamageType.POCKET) && (ev.DamageType != DamageType.WALL) && (ev.DamageType != DamageType.LURE))
                {
                    ev.Damage = 100;
                }
                
                if (ev.Attacker.TeamRole.Role == Smod2.API.Role.SCP_096)
                {
                    if (ev.Player.PlayerId == scp457id)
                    {
                        t96a457++;
                        ev.Attacker.PersonalBroadcast(4, "<color=red>停止攻击457否则您将会被请出服务器</color>", false);
                        if (t96a457 == 30)
                        {
                            ev.Attacker.Ban(0, "您已触发96多次攻击457检测");

                        }
                    }
                }
                if (ev.Attacker.TeamRole.Role == Smod2.API.Role.SCP_096)
                {
                    if (ev.Player.PlayerId == scp035id)
                    {
                        t96a35++;
                        ev.Attacker.PersonalBroadcast(4, "<color=red>停止攻击035否则您将会被请出服务器</color>", false);
                        if (t96a35 == 30)
                        {
                            ev.Attacker.Ban(0, "您已触发96多次攻击035检测");

                        }
                    }
                }
                if ((ev.Attacker.TeamRole.Team == Smod2.API.Team.SCP) && (ev.Player.PlayerId == scp457id))
                {
                    ev.Damage = 0;
                }
                if ((ev.Attacker.PlayerId == scp457id) && (ev.DamageType != DamageType.TESLA) && (ev.DamageType != DamageType.DECONT) && (ev.DamageType != DamageType.FALLDOWN) && (ev.DamageType != DamageType.FLYING) && (ev.DamageType != DamageType.NUKE) && (ev.DamageType != DamageType.POCKET) && (ev.DamageType != DamageType.WALL) && (ev.DamageType != DamageType.LURE) && (ev.Attacker.TeamRole.Role == Smod2.API.Role.TUTORIAL) && (ev.Player.PlayerId != scp457id))
                {
                    ev.Damage = 0;
                }
                if((ev.Player.PlayerId==dsjscid)&&(ev.Attacker.TeamRole.Team == Smod2.API.Team.SCP) && (ev.DamageType != DamageType.DECONT) && (ev.DamageType != DamageType.FALLDOWN) && (ev.DamageType != DamageType.FLYING) && (ev.DamageType != DamageType.NUKE) && (ev.DamageType != DamageType.POCKET) && (ev.DamageType != DamageType.WALL) && (ev.DamageType != DamageType.LURE) && (ev.Attacker.TeamRole.Role == Smod2.API.Role.SCP_939_53))
                {
                    ev.Damage = 35;
                }
                if ((ev.Attacker.PlayerId == scp939id) && (ev.DamageType != DamageType.DECONT) && (ev.DamageType != DamageType.FALLDOWN) && (ev.DamageType != DamageType.FLYING) && (ev.DamageType != DamageType.NUKE) && (ev.DamageType != DamageType.POCKET) && (ev.DamageType != DamageType.WALL) && (ev.DamageType != DamageType.LURE) && (ev.Attacker.TeamRole.Role == Smod2.API.Role.SCP_939_53) && (ev.Player.PlayerId != scp035id) && (LLBS233.Contains(ev.Player.PlayerId) == false))
                {
                    ev.Damage = 100f;
                }
                if (ev.Player.PlayerId == cxkid)
                {
                    if (jntm == true)
                    {
                        int num3 = new Random().Next(1, 100);
                        if (num3 >= 50)
                        {
                            ev.Damage = 0;
                        }
                    }
                }
                if((ev.Player.PlayerId != scp650id) && (ev.Attacker.TeamRole.Team == Smod2.API.Team.SCP) && (ev.DamageType != DamageType.DECONT) && (ev.DamageType != DamageType.FALLDOWN) && (ev.DamageType != DamageType.FLYING) && (ev.DamageType != DamageType.NUKE) && (ev.DamageType != DamageType.POCKET) && (ev.DamageType != DamageType.WALL) && (ev.DamageType != DamageType.LURE))
                {
                    if(ev.Player.PlayerId == scp073id)
                    {
                        ev.Damage = 10;
                        ev.Attacker.SetHealth(ev.Attacker.GetHealth() - 50);
                        
                    }
                }
                if((ev.Attacker.TeamRole.Team != Smod2.API.Team.NINETAILFOX)&&(ev.Attacker.TeamRole.Team != Smod2.API.Team.SCIENTIST)&&(ev.Attacker.TeamRole.Team != Smod2.API.Team.SCP) && (ev.DamageType != DamageType.DECONT) && (ev.DamageType != DamageType.FALLDOWN) && (ev.DamageType != DamageType.FLYING) && (ev.DamageType != DamageType.NUKE) && (ev.DamageType != DamageType.POCKET) && (ev.DamageType != DamageType.WALL) && (ev.DamageType != DamageType.LURE))
                {
                    if (ev.Player.PlayerId == scp073id)
                    {
                        ev.Damage = 1;
                        ev.Attacker.SetHealth(ev.Attacker.GetHealth() - 5);

                    }
                }
                if ((scp682.Contains(ev.Attacker.UserId)) && (ev.DamageType != DamageType.TESLA) && (ev.DamageType != DamageType.USP) && (ev.DamageType != DamageType.DECONT) && (ev.DamageType != DamageType.FALLDOWN) && (ev.DamageType != DamageType.FLYING) && (ev.DamageType != DamageType.NUKE) && (ev.DamageType != DamageType.POCKET) && (ev.DamageType != DamageType.WALL) && (ev.DamageType != DamageType.LURE) && (ev.Attacker.TeamRole.Role == Smod2.API.Role.SCP_939_89) && (ev.Player.PlayerId != scp035id) && (LLBS233.Contains(ev.Player.PlayerId) == false))
                {
                    ev.Damage = 300f;
                    ev.Attacker.AddHealth(100);
                }
                if ((ev.Attacker.PlayerId == scpqblid2) && (ev.DamageType != DamageType.DECONT) && (ev.DamageType != DamageType.FALLDOWN) && (ev.DamageType != DamageType.FLYING) && (ev.DamageType != DamageType.NUKE) && (ev.DamageType != DamageType.POCKET) && (ev.DamageType != DamageType.WALL) && (ev.DamageType != DamageType.LURE))
                {
                    ev.Damage = 0;
                }
                if ((ev.Player.UserId == scpqblid) && (ev.Damage >= scpqbl.GetHealth()))
                {
                    ev.Damage = 0;
                    scpqbl.ChangeRole(Smod2.API.Role.SCP_939_89, true, false, false, true);
                    scpqblid2 = scpqbl.PlayerId;
                    scpqbl3 = ev.Player;
                    scpqbl = null;
                    scpqblid = null;
                    ev.Player.SetRank("yellow", "SCP-乔碧萝", null);
                    plugin.Server.Map.Broadcast(7, "我是颜值主播qwq", false);
                }
                if ((ev.Player.PlayerId == scp035id) && (ev.Attacker.TeamRole.Team == Smod2.API.Team.SCP) && (ev.DamageType != DamageType.DECONT) && (ev.DamageType != DamageType.FALLDOWN) && (ev.DamageType != DamageType.FLYING) && (ev.DamageType != DamageType.NUKE) && (ev.DamageType != DamageType.POCKET) && (ev.DamageType != DamageType.TESLA) && (ev.DamageType != DamageType.WALL) && (ev.DamageType != DamageType.LURE) && (ev.Attacker != null))
                {
                    ev.Damage = 0;
                }
                if ((ev.Player.PlayerId == scp181id) && (ev.Attacker.TeamRole.Team == Smod2.API.Team.SCP))
                {
                    Random random = new Random();
                    if (random.Next(1, 3) == 2)
                    {
                        ev.Damage = 0;
                        ev.Attacker.SetHealth(ev.Attacker.GetHealth() - (int)ev.Damage);
                    }
                }

                if (scp2006a.Contains(ev.Player.UserId)&&(ev.Attacker.PlayerId!=scp650id))
                {
                    if (ev.Attacker.TeamRole.Team > Smod2.API.Team.SCP)
                    {
                        ev.Damage = 10;
                    }
                }
                if ((ev.Player.PlayerId == D9341id))
                {
                    if ((ev.Damage >= ev.Player.GetHealth()) && (times <= 5))
                    {
                        ev.Damage = 0;
                        D9341.ChangeRole(D9341js, true, true, true, true);
                        foreach (Smod2.API.Item item2 in D9341Item)
                        {
                            D9341.GiveItem(item2.ItemType);
                        }
                        D9341.Teleport(D9341zb, false);
                        times++;
                    }

                }
                if ((ev.Attacker.PlayerId == scp035id) && (ev.Player.TeamRole.Team > Smod2.API.Team.SCP) && (ev.DamageType != DamageType.DECONT) && (ev.DamageType != DamageType.FALLDOWN) && (ev.DamageType != DamageType.FLYING) && (ev.DamageType != DamageType.NUKE) && (ev.DamageType != DamageType.POCKET) && (ev.DamageType != DamageType.TESLA) && (ev.DamageType != DamageType.WALL) && (ev.DamageType != DamageType.LURE) && (ev.Attacker != null))
                {
                    ev.Damage = 20;
                }
                if ((scp2818pick == true))
                {
                    if ((scp2818id == ev.Attacker.PlayerId) && (ev.DamageType == DamageType.COM15))
                    {
                        if (ev.Player.TeamRole.Role == Smod2.API.Role.SCP_106)
                        {
                            ev.Damage = 300;
                            scp2818.Kill();
                            scp2818pick = false;
                            scp2818id = 0;
                            scp2818 = null;
                        }
                        else
                        {
                            ev.Damage = 1000;
                            scp2818.Kill();
                            scp2818pick = false;
                            scp2818 = null;
                            scp2818id = 0;
                        }
                    }
                }

                if (ev.Attacker.TeamRole.Role == Smod2.API.Role.SCP_049)
                {
                    if ((lv == 3) && (ev.Player.PlayerId != scp076id) && (LLBS233.Contains(ev.Player.PlayerId) == false) && (ev.Player.PlayerId != scp457id))
                    {
                        ev.Damage = 0;
                        pos2 = ev.Player.GetPosition();
                        ev.Player.ChangeRole(Smod2.API.Role.SCP_049_2, true, false, false, true);
                        ev.Player.Teleport(pos2);
                    }
                }
                if ((ev.Player.PlayerId != scp650id)&&(ev.Player.PlayerId == scp076id))
                {
                    if ((ev.Attacker.TeamRole.Role == Smod2.API.Role.SCP_173) && (ev.DamageType != DamageType.DECONT) && (ev.DamageType != DamageType.FALLDOWN) && (ev.DamageType != DamageType.FLYING) && (ev.DamageType != DamageType.NUKE) && (ev.DamageType != DamageType.POCKET) && (ev.DamageType != DamageType.TESLA) && (ev.DamageType != DamageType.WALL) && (ev.DamageType != DamageType.LURE))
                    {
                        ev.Damage = 20;
                    }
                    if ((ev.Attacker.TeamRole.Role == Smod2.API.Role.SCP_049) && (ev.DamageType != DamageType.DECONT) && (ev.DamageType != DamageType.FALLDOWN) && (ev.DamageType != DamageType.FLYING) && (ev.DamageType != DamageType.NUKE) && (ev.DamageType != DamageType.POCKET) && (ev.DamageType != DamageType.TESLA) && (ev.DamageType != DamageType.WALL) && (ev.DamageType != DamageType.LURE))
                    {
                        ev.Damage = 20;
                    }
                    if ((ev.Attacker.TeamRole.Role == Smod2.API.Role.SCP_049_2) && (ev.DamageType != DamageType.DECONT) && (ev.DamageType != DamageType.FALLDOWN) && (ev.DamageType != DamageType.FLYING) && (ev.DamageType != DamageType.NUKE) && (ev.DamageType != DamageType.POCKET) && (ev.DamageType != DamageType.TESLA) && (ev.DamageType != DamageType.WALL) && (ev.DamageType != DamageType.LURE))
                    {
                        ev.Damage = 10;
                    }
                    if ((ev.Attacker.TeamRole.Role == Smod2.API.Role.SCP_096) && (ev.DamageType != DamageType.DECONT) && (ev.DamageType != DamageType.FALLDOWN) && (ev.DamageType != DamageType.FLYING) && (ev.DamageType != DamageType.NUKE) && (ev.DamageType != DamageType.POCKET) && (ev.DamageType != DamageType.TESLA) && (ev.DamageType != DamageType.WALL) && (ev.DamageType != DamageType.LURE))
                    {
                        ev.Damage = 20;
                    }
                    if ((ev.Attacker.TeamRole.Role == Smod2.API.Role.SCP_939_53) || (ev.Attacker.TeamRole.Role == Smod2.API.Role.SCP_939_89))
                    {
                        ev.Damage = 15;
                    }
                    if ((ev.Attacker.TeamRole.Team != Smod2.API.Team.SCP) && (ev.DamageType != DamageType.DECONT) && (ev.DamageType != DamageType.FALLDOWN) && (ev.DamageType != DamageType.FLYING) && (ev.DamageType != DamageType.NUKE) && (ev.DamageType != DamageType.POCKET) && (ev.DamageType != DamageType.TESLA) && (ev.DamageType != DamageType.WALL) && (ev.DamageType != DamageType.LURE))
                    {
                        ev.Damage = 6;
                    }
                }
                if (roundstart == true)
                {
                    if ((ev.Attacker.TeamRole.Team == Smod2.API.Team.SCIENTIST) && (ev.DamageType != DamageType.DECONT) && (ev.DamageType != DamageType.FALLDOWN) && (ev.DamageType != DamageType.FLYING) && (ev.DamageType != DamageType.NUKE) && (ev.DamageType != DamageType.POCKET) && (ev.DamageType != DamageType.TESLA) && (ev.DamageType != DamageType.WALL) && (ev.DamageType != DamageType.LURE) && (ev.Attacker != null))
                    {
                        if (ev.Player.TeamRole.Role == Smod2.API.Role.SCIENTIST)
                        {
                            ev.Damage = 0;
                        }
                        if (ev.Player.TeamRole.Team == Smod2.API.Team.NINETAILFOX)
                        {
                            ev.Damage = 0;
                        }
                    }
                    else if (ev.DamageType == DamageType.TESLA)
                    {
                        if (ev.Attacker.PlayerId != ev.Player.PlayerId)
                        {
                            if (ev.Player.TeamRole.Role == Smod2.API.Role.SCIENTIST)
                            {
                                ev.Damage = 0;
                            }
                            if (ev.Player.TeamRole.Team == Smod2.API.Team.NINETAILFOX)
                            {
                                ev.Damage = 0;
                            }
                        }
                    }
                    if ((ev.Attacker.TeamRole.Team == Smod2.API.Team.CHAOS_INSURGENCY) && (ev.DamageType != DamageType.FRAG) && (ev.DamageType != DamageType.DECONT) && (ev.DamageType != DamageType.FALLDOWN) && (ev.DamageType != DamageType.FLYING) && (ev.DamageType != DamageType.NUKE) && (ev.DamageType != DamageType.POCKET) && (ev.DamageType != DamageType.TESLA) && (ev.DamageType != DamageType.WALL) && (ev.DamageType != DamageType.LURE) && (ev.Attacker != null)&&(ev.Player.PlayerId !=scp035id))
                    {
                        if (ev.Player.TeamRole.Role == Smod2.API.Role.CLASSD)
                        {
                            ev.Damage = 0;
                        }
                        if (ev.Player.TeamRole.Team == Smod2.API.Team.CHAOS_INSURGENCY)
                        {
                            ev.Damage = 0;
                        }
                    }
                    else if (ev.DamageType == DamageType.TESLA)
                    {
                        if (ev.Attacker.PlayerId != ev.Player.PlayerId)
                        {
                            if (ev.Player.TeamRole.Role == Smod2.API.Role.SCIENTIST)
                            {
                                ev.Damage = 0;
                            }
                            if (ev.Player.TeamRole.Team == Smod2.API.Team.NINETAILFOX)
                            {
                                ev.Damage = 0;
                            }
                        }
                    }
                    if ((ev.Attacker.TeamRole.Team == Smod2.API.Team.CLASSD) && (ev.DamageType != DamageType.DECONT) && (ev.DamageType != DamageType.FALLDOWN) && (ev.DamageType != DamageType.FLYING) && (ev.DamageType != DamageType.NUKE) && (ev.DamageType != DamageType.POCKET) && (ev.DamageType != DamageType.TESLA) && (ev.DamageType != DamageType.WALL) && (ev.DamageType != DamageType.LURE) && (ev.Attacker != null) && (ev.Player.PlayerId != scp035id))
                    {
                        if (ev.Player.TeamRole.Role == Smod2.API.Role.CLASSD)
                        {
                            ev.Damage = 0;
                        }
                        if (ev.Player.TeamRole.Team == Smod2.API.Team.CHAOS_INSURGENCY)
                        {
                            ev.Damage = 0;
                        }
                    }
                    else if (ev.DamageType == DamageType.TESLA)
                    {
                        if (ev.Attacker.PlayerId != ev.Player.PlayerId)
                        {
                            if (ev.Player.TeamRole.Role == Smod2.API.Role.SCIENTIST)
                            {
                                ev.Damage = 0;
                            }
                            if (ev.Player.TeamRole.Team == Smod2.API.Team.NINETAILFOX)
                            {
                                ev.Damage = 0;
                            }
                        }
                    }
                    if ((ev.Attacker.TeamRole.Team == Smod2.API.Team.NINETAILFOX) && (ev.DamageType != DamageType.DECONT) && (ev.DamageType != DamageType.FALLDOWN) && (ev.DamageType != DamageType.FLYING) && (ev.DamageType != DamageType.NUKE) && (ev.DamageType != DamageType.POCKET) && (ev.DamageType != DamageType.TESLA) && (ev.DamageType != DamageType.WALL) && (ev.DamageType != DamageType.LURE) && (ev.Attacker != null))
                    {
                        if (ev.Player.TeamRole.Role == Smod2.API.Role.SCIENTIST)
                        {
                            ev.Damage = 0;
                        }
                        if (ev.Player.TeamRole.Team == Smod2.API.Team.NINETAILFOX)
                        {
                            ev.Damage = 0;
                        }
                    }
                    else if (ev.DamageType == DamageType.TESLA)
                    {
                        if (ev.Attacker.PlayerId != ev.Player.PlayerId)
                        {
                            if (ev.Player.TeamRole.Role == Smod2.API.Role.SCIENTIST)
                            {
                                ev.Damage = 0;
                            }
                            if (ev.Player.TeamRole.Team == Smod2.API.Team.NINETAILFOX)
                            {
                                ev.Damage = 0;
                            }
                        }
                    }

                }

                if ((Dio2.Contains(ev.Player.UserId)) && (sjtz1 == true) && (ev.DamageType != DamageType.NUKE))
                {
                    ev.Damage = 0;
                }

                if (ev.Attacker.PlayerId == scp076id)
                {
                    if (ev.Player.TeamRole.Team == Smod2.API.Team.SCP)
                    {
                        ev.Damage = ev.Damage + 10;
                    }
                }
                foreach (Player player in plugin.PluginManager.Server.GetPlayers(""))
                {
                    if (player.TeamRole.Role == Smod2.API.Role.CHAOS_INSURGENCY)
                    {
                        num++;
                    }
                    if (player.TeamRole.Team == Smod2.API.Team.NINETAILFOX)
                    {
                        num2++;
                    }
                }
                foreach (int num4 in touxiang)
                {
                    if (((((num4 == ev.Player.PlayerId) && ((ev.Attacker.TeamRole.Team == Smod2.API.Team.NINETAILFOX) || (ev.Attacker.TeamRole.Team == Smod2.API.Team.SCIENTIST))) && (((ev.DamageType != DamageType.FRAG) && (ev.DamageType != DamageType.DECONT)) && ((ev.DamageType != DamageType.FALLDOWN) && (ev.DamageType != DamageType.FLYING)))) && ((((ev.DamageType != DamageType.NUKE) && (ev.DamageType != DamageType.POCKET)) && ((ev.DamageType != DamageType.TESLA) && (ev.DamageType != DamageType.WALL))) && (((ev.DamageType != DamageType.LURE) && (ev.Attacker != null)) && ((ev.Player.PlayerId != ev.Attacker.PlayerId) && (num == 0))))) && (ev.Player.TeamRole.Role == Smod2.API.Role.CLASSD))
                    {
                        plugin.Info("混沌人数:" + num);
                        plugin.Info("MTF人数:" + num2);
                        ev.Attacker.PersonalBroadcast(2, "该玩家处于投降状态，你只能对他造成1伤害\n<color=#00FF7F>你自身也受到了3伤害</color>", false);
                        ev.Damage = 1f;
                        ev.Attacker.Damage(3, DamageType.CONTAIN);
                        plugin.Info(string.Concat(new object[] { "玩家: ", ev.Attacker.Name, " 正在攻击: ", ev.Player.Name, " 当前场上混沌: ", num2 }));
                    }
                    if (((num4 == ev.Player.PlayerId) && ((ev.Attacker.TeamRole.Team == Smod2.API.Team.NINETAILFOX) || (ev.Attacker.TeamRole.Team == Smod2.API.Team.SCIENTIST))) && (num > 0))
                    {
                        plugin.Info("混沌人数:" + num);
                        plugin.Info("MTF人数:" + num2);
                        ev.Player.PersonalBroadcast(2, "由于场上存在混沌\n<color=#00FF7F>你的保护已失效</color>", false);
                        plugin.Info(string.Concat(new object[] { "玩家: ", ev.Player.Name, "受到攻击,但无保护 | 当前场上混沌个数:", num }));
                    }
                    if ((((((num4 == ev.Player.PlayerId) && (ev.Attacker.TeamRole.Role == Smod2.API.Role.CHAOS_INSURGENCY)) && ((ev.DamageType != DamageType.FRAG) && (ev.DamageType != DamageType.DECONT))) && (((ev.DamageType != DamageType.FALLDOWN) && (ev.DamageType != DamageType.FLYING)) && ((ev.DamageType != DamageType.NUKE) && (ev.DamageType != DamageType.POCKET)))) && ((((ev.DamageType != DamageType.TESLA) && (ev.DamageType != DamageType.WALL)) && ((ev.DamageType != DamageType.LURE) && (ev.Attacker != null))) && ((ev.Player.PlayerId != ev.Attacker.PlayerId) && (num2 == 0)))) && (ev.Player.TeamRole.Role == Smod2.API.Role.SCIENTIST))
                    {
                        plugin.Info("混沌人数:" + num);
                        plugin.Info("MTF人数:" + num2);
                        ev.Attacker.PersonalBroadcast(2, "该玩家处于投降状态，你只能对他造成1伤害\n<color=#00FF7F>你自身也受到了3伤害</color>", false);
                        ev.Damage = 1f;
                        ev.Attacker.Damage(3, DamageType.CONTAIN);
                        plugin.Info(string.Concat(new object[] { "玩家: ", ev.Attacker.Name, " 正在攻击: ", ev.Player.Name, " 当前场上MTF: ", num2 }));
                    }
                    if (((num4 == ev.Player.PlayerId) && (ev.Attacker.TeamRole.Role == Smod2.API.Role.CHAOS_INSURGENCY)) && (num2 > 0))
                    {
                        plugin.Info("混沌人数:" + num);
                        plugin.Info("MTF人数:" + num2);
                        ev.Player.PersonalBroadcast(2, "由于场上存在MTF阵营\n<color=#00FF7F>你的保护已失效</color>", false);
                        plugin.Info(string.Concat(new object[] { "玩家: ", ev.Player.Name, "受到攻击,但无保护 | 当前场上九尾个数:", num2 }));
                    }
                    if (((((num4 == ev.Attacker.PlayerId) && ((ev.Player.TeamRole.Team == Smod2.API.Team.NINETAILFOX) || (ev.Player.TeamRole.Role == Smod2.API.Role.SCIENTIST))) && (((ev.DamageType != DamageType.FRAG) && (ev.DamageType != DamageType.DECONT)) && ((ev.DamageType != DamageType.FALLDOWN) && (ev.DamageType != DamageType.FLYING)))) && ((((ev.DamageType != DamageType.NUKE) && (ev.DamageType != DamageType.POCKET)) && ((ev.DamageType != DamageType.TESLA) && (ev.DamageType != DamageType.WALL))) && (((ev.DamageType != DamageType.LURE) && (ev.Player != null)) && (ev.Player.PlayerId != ev.Attacker.PlayerId)))) && (num == 0))
                    {
                        ev.Attacker.PersonalBroadcast(2, "你处于投降状态，你无法伤害MTF阵营", false);
                        ev.Damage = 0f;
                    }
                    if ((((((num4 == ev.Attacker.PlayerId) && (ev.Player.TeamRole.Team == Smod2.API.Team.CHAOS_INSURGENCY)) && ((ev.DamageType != DamageType.FRAG) && (ev.DamageType != DamageType.DECONT))) && (((ev.DamageType != DamageType.FALLDOWN) && (ev.DamageType != DamageType.FLYING)) && ((ev.DamageType != DamageType.NUKE) && (ev.DamageType != DamageType.POCKET)))) && ((((ev.DamageType != DamageType.TESLA) && (ev.DamageType != DamageType.WALL)) && ((ev.DamageType != DamageType.LURE) && (ev.Player != null))) && (ev.Player.PlayerId != ev.Attacker.PlayerId))) && (num2 == 0))
                    {
                        ev.Attacker.PersonalBroadcast(2, "你处于投降状态，你无法伤害混沌阵营", false);
                        ev.Damage = 0f;
                    }
                }
                if (((ev.Player.TeamRole.Role == Smod2.API.Role.CLASSD) || (ev.Player.TeamRole.Role == Smod2.API.Role.SCIENTIST)) && (ev.DamageType == DamageType.SCP_049))
                {
                    for (int i = 0; i <= 100; i++)
                    {
                        if (touxiang[i] == ev.Player.PlayerId)
                        {
                            touxiang[i] = 0;
                        }
                    }
                }
                if (ev.Player.TeamRole.Role == Smod2.API.Role.SCP_173)
                {
                    if ((((ev.DamageType == DamageType.LOGICER) || (ev.DamageType == DamageType.E11_STANDARD_RIFLE)) || ((ev.DamageType == DamageType.P90) || (ev.DamageType == DamageType.MP7))) || (ev.DamageType == DamageType.COM15))
                    {
                        ev.Damage = 3f;
                    }
                    if (ev.DamageType == DamageType.USP)
                    {
                        ev.Damage += 50f;
                    }
                }
                if ((ev.Player.TeamRole.Role == Smod2.API.Role.SCP_106) && (((((ev.DamageType == DamageType.USP) || (ev.DamageType == DamageType.LOGICER)) || ((ev.DamageType == DamageType.E11_STANDARD_RIFLE) || (ev.DamageType == DamageType.P90))) || (ev.DamageType == DamageType.MP7)) || (ev.DamageType == DamageType.COM15) && (scp2818.PlayerId != ev.Attacker.PlayerId)))
                {
                    ev.Damage = 1f;
                }
                if (((LCZ.y >= -10f) && (LCZ.y <= 20f)) && (scp2818.PlayerId != ev.Attacker.PlayerId) && (ev.Attacker.PlayerId != scp035id) && (ev.Player.PlayerId != scp035id))
                {
                    if (((ev.Attacker.TeamRole.Team == Smod2.API.Team.NINETAILFOX) || (ev.Attacker.TeamRole.Team == Smod2.API.Team.SCIENTIST)) && (ev.Player.TeamRole.Role == Smod2.API.Role.CLASSD))
                    {
                        ev.Attacker.PersonalBroadcast(1, "<color=#00FF7F>轻收容无法进行屠杀</color>", false);
                        ev.Damage = 0f;
                    }
                    if ((ev.Attacker.TeamRole.Role == Smod2.API.Role.CLASSD) && ((ev.Player.TeamRole.Team == Smod2.API.Team.SCIENTIST) || (ev.Player.TeamRole.Team == Smod2.API.Team.NINETAILFOX)))
                    {
                        ev.Attacker.PersonalBroadcast(1, "<color=#00FF7F>轻收容无法进行屠杀</color>", false);
                        ev.Damage = 0f;
                    }
                }
                if (((((((ev.Player.IsHandcuffed() && (ev.DamageType != DamageType.FRAG)) && ((ev.DamageType != DamageType.DECONT) && (ev.DamageType != DamageType.FALLDOWN))) && (((ev.DamageType != DamageType.FLYING) && (ev.DamageType != DamageType.NUKE)) && ((ev.DamageType != DamageType.POCKET) && (ev.DamageType != DamageType.TESLA)))) && (((ev.DamageType != DamageType.WALL) && (ev.DamageType != DamageType.LURE)) && (ev.Attacker != null))) && (ev.Player.PlayerId != ev.Attacker.PlayerId)) && ((ev.Player.TeamRole.Role == Smod2.API.Role.CLASSD) || (ev.Player.TeamRole.Role == Smod2.API.Role.SCIENTIST))) && ((((ev.Attacker.TeamRole.Team == Smod2.API.Team.NINETAILFOX) || (ev.Attacker.TeamRole.Team == Smod2.API.Team.CHAOS_INSURGENCY)) || (ev.Attacker.TeamRole.Team == Smod2.API.Team.CLASSD)) || (ev.Attacker.TeamRole.Team == Smod2.API.Team.SCIENTIST)))
                {
                    if (ev.Damage < ev.Player.GetHealth())
                    {
                        ev.Attacker.SetHealth(ev.Attacker.GetHealth() - ((int)ev.Damage), DamageType.NUKE);
                    }
                    else
                    {
                        ev.Damage = 0;
                        ev.Attacker.PersonalBroadcast(1, "<color=#00FF7F>这个人已经被绑了</color>", false);
                    }
                }
                if ((LLBS233.Contains(ev.Player.PlayerId)) && (ev.Attacker.TeamRole.Team == Smod2.API.Team.SCP)&&(ev.Player.PlayerId != scp650id))
                {
                    ev.Damage = 20f;
                }
                if ((a127 == true) && (ev.DamageType == DamageType.USP))
                {
                    ev.Damage = 100;
                    a127b++;
                    if (a127b == 10)
                    {
                        a127 = false;
                        a127c = true;
                        a127d = true;
                        plugin.Server.Map.Broadcast(10, "SCP127力量已经消失", false);
                    }

                }
                if ((ev.Attacker.PlayerId == scp650id) && (ev.DamageType != DamageType.TESLA) && (ev.DamageType != DamageType.DECONT) && (ev.DamageType != DamageType.FALLDOWN) && (ev.DamageType != DamageType.FLYING) && (ev.DamageType != DamageType.NUKE) && (ev.DamageType != DamageType.POCKET) && (ev.DamageType != DamageType.WALL) && (ev.DamageType != DamageType.LURE))
                {
                    ev.Damage = 0;
                }
                if (ev.Attacker.PlayerId == scp035id)
                {
                    ev.Damage = 30;
                }
                num = 0;
                num2 = 0;
            }

            public void OnPlayerJoin(PlayerJoinEvent ev)
            {

                foreach (Player player in plugin.PluginManager.Server.GetPlayers(""))
                {
                    playernum++;
                    if ((playernum > 42) && (ev.Player.UserId != "76561198425823494@steam") && (ev.Player.UserId != "76561198149835838@steam") && (ev.Player.UserId != "76561198816705835@steam") && (ev.Player.UserId != "76561198441344563@steam") && (ev.Player.UserId != "76561198401019684@steam") && (ev.Player.UserId != "76561198145812844@steam") && (ev.Player.UserId != "76561198145812844@steam") && (ev.Player.UserId != "76561198284755079@steam") && (ev.Player.UserId != "76561198284320740@steam") && (ev.Player.UserId != "76561198149835838@steam") && (ev.Player.UserId != "76561198191585303@steam") && (ev.Player.UserId != "76561198369468432@steam"))
                    {

                        ev.Player.Ban(1, "服务器满人了qwq对不起呀一会再试试吧QAQ");
                    }
                }

                if (ev.Player.UserId == "76561198369468432@steam")
                {
                    plugin.Server.Map.Broadcast(2, "<color=#6699FF>发出高价回收的声音:50包邮!</color>", false);
                    plugin.Server.Map.Broadcast(2, "<color=#FF0033>发出高价回收的声音:50包邮!</color>", false);
                    plugin.Server.Map.Broadcast(2, "<color=#FFFF00>发出高价回收的声音:50包邮!</color>", false);

                }
                if (ev.Player.UserId == "76561198893112896@steam")
                {
                    plugin.Server.Map.Broadcast(8, "<color=yellow>砸哇路多，DIO用『世界』暂停了时间并且加入了服务器</color>", false);
                }


                if (ev.Player.UserId == "76561198997348090@steam")
                {
                    plugin.Server.Map.Broadcast(1, "<color=#FFFF66>顺顺大魔王骑着皮皮虾唱着歌谣进来了:皮皮虾我们走去找一个好朋友!</color>", false);
                    plugin.Server.Map.Broadcast(1, "<color=#CCFF00>顺顺大魔王骑着皮皮虾唱着歌谣进来了:皮皮虾我们走去找一个好朋友!</color>", false);
                    plugin.Server.Map.Broadcast(1, "<color=#99FF00>顺顺大魔王骑着皮皮虾唱着歌谣进来了:皮皮虾我们走去找一个好朋友!</color>", false);
                    plugin.Server.Map.Broadcast(1, "<color=#FF6633>顺顺大魔王骑着皮皮虾唱着歌谣进来了:皮皮虾我们走去找一个好朋友!</color>", false);
                    plugin.Server.Map.Broadcast(1, "<color=#FF3300>顺顺大魔王骑着皮皮虾唱着歌谣进来了:皮皮虾我们走去找一个好朋友!</color>", false);
                    plugin.Server.Map.Broadcast(1, "<color=#66FF00>顺顺大魔王骑着皮皮虾唱着歌谣进来了:皮皮虾我们走去找一个好朋友!</color>", false);
                    plugin.Server.Map.Broadcast(1, "<color=#6666FF>顺顺大魔王骑着皮皮虾唱着歌谣进来了:皮皮虾我们走去找一个好朋友!</color>", false);
                    plugin.Server.Map.Broadcast(1, "<color=#FF0033>顺顺大魔王骑着皮皮虾唱着歌谣进来了:皮皮虾我们走去找一个好朋友!</color>", false);
                    plugin.Server.Map.Broadcast(1, "<color=#66CCFF>顺顺大魔王骑着皮皮虾唱着歌谣进来了:皮皮虾我们走去找一个好朋友!</color>", false);
                }
                if (ev.Player.UserId == "76561198145812844@steam")
                {
                    plugin.Server.Map.Broadcast(8, "<color=#66FF00>[注意！老阴比]</color>" + ev.Player.Name + "<color=#FFFF00>进入游戏，各位注意自己的菊花</color>", false);
                }

                if (ev.Player.UserId == "76561198401019684@steam")
                {
                    plugin.Server.Map.Broadcast(8, "<color=#66FF00>[注意！49痴汉]</color>" + ev.Player.Name + "<color=#FFFF00>进入游戏</color>", false);
                }
                if (ev.Player.UserId == "76561198441344563@steam")
                {
                    plugin.Server.Map.Broadcast(8, "<color=#66FF00>[全服最帅的人到达战场]</color>" + ev.Player.Name + "<color=#FFFF00>进入游戏</color>", false);
                }
                if (ev.Player.UserId == "76561198816705835@steam")
                {
                    plugin.Server.Map.Broadcast(8, "<color=#66FF00>[全服最菜的大佬]</color>" + ev.Player.Name + "<color=#FFFF00>进入游戏</color>", false);
                }
                if (ev.Player.UserId == "76561198149835838@steam")
                {
                    plugin.Server.Map.Broadcast(8, "<color=red>[SCP079保护协会会长]</color>" + ev.Player.Name + "<color=#red>进入游戏</color>", false);
                }
                if (ev.Player.UserId == "76561198425823494@steam")
                {
                    plugin.Server.Map.Broadcast(8, "<color=#66FF00>[全服最帅的人到达战场]</color>" + ev.Player.Name + "<color=#FFFF00>进入游戏</color>", false);
                }

                string name = ev.Player.Name;
                if (!player233.Contains(ev.Player))
                {
                    player233.Add(ev.Player);
                }
                object[] objArray1 = new object[] { "<color=#FFD700>[", name, "]</color>，欢迎你加入本服务器\n当前人数:<color=#00FF00>[", playernum, "/35]</color>\n+本服插件:<color=#00FFFF>很多打不下</color>+" };
                ev.Player.PersonalBroadcast(5, string.Concat(objArray1), false);

                ev.Player.PersonalBroadcast(8, "按~开启控制台，在控制台输入.list获取玩家编号", false);
                ev.Player.PersonalBroadcast(10, "<color=#BB1444>如果你看到这条消息证明随机事件插件已经在运行</color>\n<color=#FFFF00>如有破坏游戏体验等问题请在群内支出qwq</color>", false);
                int num3 = new Random().Next(1, 4);
                if (num3 == 1)
                {
                    ev.Player.PersonalBroadcast(5, "<color=#FF3300>[SCP038]</color>\n<color=#FFFF00>万象树在012房间可以复制物品qwq</color>", false);
                }
                if (num3 == 2)
                {
                    ev.Player.PersonalBroadcast(5, "<color=#FF3300>[通知]</color>\n<color=#FFFF00>插件介绍还在咕咕咕</color>", false);
                }
                if (num3 == 3)
                {
                    ev.Player.PersonalBroadcast(5, "<color=#FF3300>[SCP817]</color>\n<color=#FFFF00>随意人\n150秒变换一次角色</color>", false);
                }
                int num = new Random().Next(1, 101);
                if (num <= 20)
                {
                    int num2 = new Random().Next(1, 7);
                    if (num2 == 1)
                    {
                        ev.Player.PersonalBroadcast(7, "=w= 经过本鱼的检测,你本回合人品指数为\n[<color=#FFC0CB>" + num + "</color>%]\n<color=#FF00FF>恩断义绝警告</color>", false);
                    }
                    else if (num2 == 2)
                    {
                        ev.Player.PersonalBroadcast(7, "=w= 经过本鱼的检测,你本回合人品指数为\n[<color=#FFC0CB>" + num + "</color>%]\n<color=#FF00FF>你妈的，为什么</color>", false);
                    }
                    else if (num2 == 3)
                    {
                        ev.Player.PersonalBroadcast(7, "=w= 经过本鱼的检测,你本回合人品指数为\n[<color=#FFC0CB>" + num + "</color>%]\n<color=#FF00FF>你打游戏像蔡徐坤</color>", false);
                    }
                    else if (num2 == 4)
                    {
                        ev.Player.PersonalBroadcast(7, "=w= 经过本鱼的检测,你本回合人品指数为\n[<color=#FFC0CB>" + num + "</color>%]\n<color=#FF00FF>你长得像乔碧萝</color>", false);
                    }
                    else if (num2 == 5)
                    {
                        ev.Player.PersonalBroadcast(7, "=w= 经过本鱼的检测,你本回合人品指数为\n[<color=#FFC0CB>" + num + "</color>%]\n<color=#FF00FF>哈哈哈弱爆了</color>", false);
                    }
                    else
                    {
                        ev.Player.PersonalBroadcast(7, "=w= 经过本鱼的检测,你本回合人品指数为\n[<color=#FFC0CB>" + num + "</color>%]\n<color=#FF00FF>噗太菜了</color>", false);
                    }
                }
                if ((num >= 0x15) && (num <= 40))
                {
                    int num2 = new Random().Next(1, 7);
                    if (num2 == 1)
                    {
                        ev.Player.PersonalBroadcast(7, "=w= 经过本鱼的检测,你本回合人品指数为\n[<color=#FFC0CB>" + num + "</color>%]\n<color=#FF00FF>两行泪两行泪</color>", false);
                    }
                    else if (num2 == 2)
                    {
                        object[] objArray2 = new object[] { "=w= 经过本鱼的检测,你本回合人品指数为\n[<color=#FFC0CB>", num, "</color>%]\n<color=#FF00FF>喵哈哈哈哈哈哈哈才", num, "%</color>" };
                        ev.Player.PersonalBroadcast(7, string.Concat(objArray2), false);
                    }
                    else if (num2 == 3)
                    {
                        ev.Player.PersonalBroadcast(7, "=w= 经过本鱼的检测,你本回合人品指数为\n[<color=#FFC0CB>" + num + "</color>%]\n<color=#FF00FF>LOL一般般啦别伤心美好的人生</color>", false);
                    }
                    else
                    {
                        ev.Player.PersonalBroadcast(7, "=w= 经过本鱼的检测,你本回合人品指数为\n[<color=#FFC0CB>" + num + "</color>%]\n<color=#FF00FF>=w= qwq qaq awa AWSL</color>", false);
                    }
                }
                if ((num >= 0x29) && (num <= 0x31))
                {
                    if (new Random().Next(1, 6) == 1)
                    {
                        ev.Player.PersonalBroadcast(15, "=w= 经过本鱼的检测,你本回合人品指数为\n[<color=#FFC0CB>" + num + "</color>%]\n<color=#FF00FF>告诉你一个秘密,下班的神秘代码复制到迅雷</color>", false);
                    }
                    else if (new Random().Next(1, 6) == 2)
                    {
                        ev.Player.PersonalBroadcast(15, "=w= 经过本鱼的检测,你本回合人品指数为\n[<color=#FFC0CB>" + num + "</color>%]\n<color=#FF00FF>神秘代码不可能给你的233</color>", false);
                    }
                    else
                    {
                        ev.Player.PersonalBroadcast(15, "=w= 经过本鱼的检测,你本回合人品指数为\n[<color=#FFC0CB>" + num + "</color>%]\n<color=#FF00FF>其实50%以下比50%还好相信我!</color>", false);
                    }
                }
                if (num == 50)
                {
                    int num5 = new Random().Next(1, 6);
                    switch (num5)
                    {
                        case 1:
                            ev.Player.PersonalBroadcast(15, "=w= 经过本鱼的检测,你本回合人品指数为\n[<color=#FFC0CB>" + num + "</color>%]\n<color=#FF00FF>也不差嘛~不过电磁炮可能合不出来哇咔咔</color>", false);
                            goto Label_037D;

                        case 2:
                            ev.Player.PersonalBroadcast(15, "=w= 经过本鱼的检测,你本回合人品指数为\n[<color=#FFC0CB>" + num + "</color>%]\n<color=#FF00FF>50%是好还是坏呢</color>", false);
                            goto Label_037D;

                        case 3:
                            ev.Player.PersonalBroadcast(15, "=w= 经过本鱼的检测,你本回合人品指数为\n[<color=#FFC0CB>" + num + "</color>%]\n<color=#FF00FF>改编不是乱编!戏说不是胡说!</color>", false);
                            break;
                    }
                    if (num5 == 3)
                    {
                        ev.Player.PersonalBroadcast(15, "=w= 经过本鱼的检测,你本回合人品指数为\n[<color=#FFC0CB>" + num + "</color>%]\n<color=#FF00FF>改编不是乱编!戏说不是胡说!</color>", false);
                    }
                    else
                    {
                        ev.Player.PersonalBroadcast(15, "=w= 经过本鱼的检测,你本回合人品指数为\n[<color=#FFC0CB>" + num + "</color>%]\n<color=#FF00FF>50%...如果加1%会不会变得更强呢?</color>", false);
                    }
                }
                Label_037D:
                if ((num >= 51) && (num <= 80))
                {
                    int num6 = new Random().Next(1, 6);
                    switch (num6)
                    {
                        case 1:
                            ev.Player.PersonalBroadcast(15, "=w= 经过本鱼的检测,你本回合人品指数为\n[<color=#FFC0CB>" + num + "</color>%]\n<color=#FF00FF>我觉得海星</color>", false);
                            goto Label_0468;

                        case 2:
                            ev.Player.PersonalBroadcast(15, "=w= 经过本鱼的检测,你本回合人品指数为\n[<color=#FFC0CB>" + num + "</color>%]\n<color=#FF00FF>快乐DD每一天</color>", false);
                            goto Label_0468;

                        case 3:
                            ev.Player.PersonalBroadcast(15, "=w= 经过本鱼的检测,你本回合人品指数为\n[<color=#FFC0CB>" + num + "</color>%]\n<color=#FF00FF>不行啊，太短了满足不了我</color>", false);
                            break;
                    }
                    if (num6 == 3)
                    {
                        ev.Player.PersonalBroadcast(15, "=w= 经过本鱼的检测,你本回合人品指数为\n[<color=#FFC0CB>" + num + "</color>%]\n<color=#FF00FF>不行啊，太短了满足不了我</color>", false);
                    }
                    else
                    {
                        ev.Player.PersonalBroadcast(15, "=w= 经过本鱼的检测,你本回合人品指数为\n[<color=#FFC0CB>" + num + "</color>%]\n<color=#FF00FF>你看你队友打游戏像蔡徐坤</color>", false);
                    }
                }
                Label_0468:
                if ((num >= 80) && (num <= 90))
                {
                    int num2 = new Random().Next(1, 6);

                    if (num2 == 1)
                    {
                        ev.Player.PersonalBroadcast(15, "=w= 经过本鱼的检测,你本回合人品指数为\n[<color=#FFC0CB>" + num + "</color>%]\n<color=#FF00FF>妈妈咪耶，欧皇？我先吸掉你欧气为敬!</color>", false);
                    }
                    if (num2 == 2)
                    {
                        ev.Player.PersonalBroadcast(15, "=w= 经过本鱼的检测,你本回合人品指数为\n[<color=#FFC0CB>" + num + "</color>%]\n<color=#FF00FF>wdnm你太强了</color>", false);
                    }
                    if (num2 == 3)
                    {
                        ev.Player.PersonalBroadcast(15, "=w= 经过本鱼的检测,你本回合人品指数为\n[<color=#FFC0CB>" + num + "</color>%]\n<color=#FF00FF>你的欧气已被后台转移到服主身上</color>", false);
                    }
                    if (num2 == 4)
                    {
                        ev.Player.PersonalBroadcast(15, "=w= 经过本鱼的检测,你本回合人品指数为\n[<color=#FFC0CB>" + num + "</color>%]\n<color=#FF00FF>你的人品今天已经花在本服了,切勿抽卡233!</color>", false);
                    }

                }

                if (num == 100)
                {
                    if (new Random().Next(1, 6) <= 3)
                    {
                        ev.Player.PersonalBroadcast(15, "=w= 经过本鱼的检测,你本回合人品指数为\n[<color=#FFC0CB>" + num + "</color>%]\n<color=#FF00FF>....不就是100%[才不是羡慕],你可以把这条信息截图给服主秀一波了</color>", false);
                    }
                    else
                    {
                        ev.Player.PersonalBroadcast(15, "=w= 经过本鱼的检测,你本回合人品指数为\n[<color=#FFC0CB>" + num + "</color>%]\n<color=#FF00FF>100%!恭喜你,但是这条信息截图也无效233333", false);
                    }
                }
                playernum = 0;
            }

            public void OnPocketDimensionExit(PlayerPocketDimensionExitEvent ev)
            {
                int num = new Random().Next(1, 8);
                if (num == 1)
                {
                    ev.Player.GiveItem(Smod2.API.ItemType.RADIO);
                    ev.Player.PersonalBroadcast(10, "<color=#FF1493>你在口袋里搜刮到了</color>\n对讲机", false);
                }
                else if (num == 2)
                {
                    ev.Player.GiveItem(Smod2.API.ItemType.MEDKIT);
                    ev.Player.PersonalBroadcast(10, "<color=#FF1493>你在口袋里搜刮到了</color>\n医疗包", false);
                }
                else if (num == 3)
                {
                    ev.Player.GiveItem(Smod2.API.ItemType.FLASHLIGHT);
                    ev.Player.PersonalBroadcast(10, "<color=#FF1493>你在口袋里搜刮到了</color>\n闪光弹", false);
                }
                else if (num == 4)
                {
                    ev.Player.SetAmmo(AmmoType.DROPPED_5, ev.Player.GetAmmo(AmmoType.DROPPED_5) + 20);
                    ev.Player.PersonalBroadcast(10, "<color=#FF1493>你在口袋里搜刮到了</color>\n20发 5mm子弹", false);
                }
                else if (num == 5)
                {
                    ev.Player.SetAmmo(AmmoType.DROPPED_7, ev.Player.GetAmmo(AmmoType.DROPPED_7) + 20);
                    ev.Player.PersonalBroadcast(10, "<color=#FF1493>你在口袋里搜刮到了</color>\n20发 7mm子弹", false);
                }
                else
                {
                    ev.Player.SetAmmo(AmmoType.DROPPED_9, ev.Player.GetAmmo(AmmoType.DROPPED_9) + 20);
                    ev.Player.PersonalBroadcast(10, "<color=#FF1493>你在口袋里搜刮到了</color>\n20发 9mm子弹", false);
                }
            }

            public void OnRoundEnd(RoundEndEvent ev)
            {

            }

            public void OnRoundRestart(RoundRestartEvent ev)
            {
                bhsx = false;
                gjtr = 0;
                scp1577pick = false;
                scp1577times = 0;
                scp1577bj = false;
                scp1577id = new List<int>();
                scp1577pos = null;
                scp3108shotyes = false;
                scp3108shotatplayeritems.Clear();
                scp3108shotatplayerpos = null;
                scp3108playerid = 0;
                scp3108pick = false;
                a127d = false;
                scp650yes = false;
                scp650 = null;
                scp650id = 0;
                dsjsc = null;
                dsjscid = 0;
                scp073 = null;
                scp073a = false;
                scp073zb = true;
                scp076id = 0;
                scp005 = false;
                scp005aid = 0;
                time2 = 0;
                t96a457 = 0;
                scp457die = false;
                scp457 = null;
                scp457a = false;
                scp457id = 0;
                t96a35 = 0;
                xtd = null;
                xtdid = 0;
                a127 = false;
                a127b = 0;
                a127c = false;
                scp914mid = 0;
                scp914m = null;
                scp1143 = null;
                scp1143id = 0;
                scp1143a = false;
                csm = false;
                jwhhk = null;
                jwhhkid = 0;
                qblcq2 = false;
                qblcq = null;
                scpqbl3 = null;
                scp682.Clear();
                scp939id = 0;
                jkl = false;
                jklid = null;
                //181end头
                times5 = 1;
                scp035 = null;
                scp035id = 0;
                scp181id = 0;
                cxkid = 0;
                scp817id = 0;
                scp817 = null;
                cxk = null;
                cxkyes = false;
                scp817yes = false;
                D9341 = null;
                D9341id = 0;
                D9341Item = null;
                D9341yes = false;
                D9341zb = null;
                jntm = false;
                starttimer = false;
                scp2006 = null;
                scp2006a.Clear();
                scp2006id = 0;
                times3 = 0;
                deadtimer = 0;
                scpqblid2 = 0;
                scpqbl = null;
                scpqblid = null;
                //181end尾部
                bpb = false;
                bpb2.Clear();
                xhsnb2 = 0;
                scp2818id = 0;
                xhsnb = false;
                mrfishzb = true;
                scp1143id = 0;
                xp = 0;
                lv = 0;
                coldbc = false;
                coldtb = false;
                HDZHG2.Clear();
                coldtime = 0;
                mtf = 0;
                chaos = 0;
                mtfchange = 0;
                chaoschange = 0;
                round = 0;
                Array.Clear(touxiang, 0, touxiang.Length);
                playernum = 0;
                roundstart = false;
                player233.Clear();
                starttimer = false;
                deadtime = false;
                SCP173 = "";
                SCP049 = "";
                SCP079 = "";
                SCP096 = "";
                SCP939_53 = "";
                SCP939_89 = "";
                SCP106 = "";
                KillerID = 0;
                PlayerID = 0;
                RoleSet = 0;
                s173 = 0;
                s049 = 0;
                s096 = 0;
                s939_53 = 0;
                s939_89 = 0;
                s106 = 0;
                Guardnum = 0;
                deadtimer = 0;
                waring1 = 0;
                ini10 = 0;
                coldwait233 = false;
                Dio = null;
                Dio1 = false;
                Dio2.Clear();
                tiems = 0;
                sjtz1 = false;
                scp076 = null;
                scp076yes = false;
                scp2818 = null;
                scp2818pick = false;
                scp1143a = false;
                scp1143 = null;
                times = 0;
                plugin.Server.Map.Broadcast(5, "回合结束友伤保护关闭", false);
                jljy = null;
                jljy1 = false;
                jljy2.Clear();
                jljyzb = false;
                sjtz2 = false;
                ylb1 = false;
                HDZHG2.Clear();
                coldwait233 = false;
                coldbc = false;
                coldtb = false;
                coldtime = 0;
                mtf = 0;
                chaos = 0;
                mtfchange = 0;
                chaoschange = 0;
                round = 0;
                Array.Clear(touxiang, 0, touxiang.Length);
                playernum = 0;
                roundstart = false;
                player233.Clear();
                starttimer = false;
                deadtime = false;
                KillerID = 0;
                PlayerID = 0;
                RoleSet = 0;
                Guardnum = 0;
                deadtimer = 0;
                waring1 = 0;
                ini10 = 0;
                Dio = null;
                Dio1 = false;
                Dio2.Clear();
                xywj = null;
                xywjid = 0;
            }

            public void OnRoundStart(RoundStartEvent ev)
            {
                plugin.Server.Map.SpawnItem(Smod2.API.ItemType.GUNCOM15,plugin.Server.Map.GetRandomSpawnPoint(Smod2.API.Role.SCP_173),null);
                List<Player> list = new List<Player>();
                List<Player> list2 = new List<Player>();
                starttimer = true;
                firstscp = true;
                plugin.Server.Map.Broadcast(5, "本次更新日期2020.3.25此日期让你们催更用", false);
                foreach (Smod2.API.Door door in plugin.Server.Map.GetDoors())
                {
                    if (new Random().Next(1, 10) == 5)
                    {
                        Vector pos = new Vector(door.Position.x, door.Position.y + (float)2.0, door.Position.z);
                        plugin.Server.Map.SpawnItem(Smod2.API.ItemType.COIN, pos, null);
                        time2++;
                    }
                }
                plugin.Server.Map.Broadcast(10, "<color=lime>本局已生成</color>" + time2 + "<color=lime>个幸运硬币</color>", false);
                plugin.Server.Map.Broadcast(3, "<color=red>开始抽取幸运玩家</color>", false);
                foreach (Player player in ev.Server.GetPlayers())
                {
                    xywj = player;
                    xywjid = xywj.PlayerId;
                }
                plugin.Server.Map.Broadcast(2, "<color=lime>↓↓↓↓本回合幸运玩家↓↓↓↓</color>\n" + "<color=lime>" + xywj.Name + "</color>\n<color=red>你可以按~自选人物了</color>", false);
                plugin.Server.Map.Broadcast(2, "<color=lime>↓↓↓↓本回合幸运玩家↓↓↓↓</color>\n" + "<color=red>" + xywj.Name + "</color>\n<color=red>你可以按~自选人物了</color>", false);
                plugin.Server.Map.Broadcast(2, "<color=lime>↓↓↓↓本回合幸运玩家↓↓↓↓</color>\n" + "<color=green>" + xywj.Name + "</color>\n<color=red>你可以按~自选人物了</color>", false);
                xywj.SendConsoleMessage(".s173 变为173\n.s106 变为106\n.sD 变为D级\n.sS 变为科学家\n.sG 变为保安\n注意这会清除你的特殊人物", "green");
                plugin.Server.Map.Broadcast(20, "由于最近DDOS严重服务器可能无法一直在列表 请务必加群：278704578", false);
                foreach (Player player2 in ev.Server.GetPlayers(""))
                {
                    if (player2.TeamRole.Team == Smod2.API.Team.CLASSD)
                    {
                        list.Add(player2);
                    }
                    if (player2.TeamRole.Role == Smod2.API.Role.SCIENTIST)
                    {
                        list2.Add(player2);
                    }
                }
                for (int i = 0; i < list.Count; i++)
                {
                    if (i == 0)
                    {
                        scp181 = list[i];
                        scp181id = scp181.PlayerId;
                        scp181.GiveItem(Smod2.API.ItemType.COIN);
                        int card = new Random().Next(1, 11);

                        if (card == 1)
                        {
                            scp181.GiveItem(Smod2.API.ItemType.KEYCARDCHAOSINSURGENCY);
                        }
                        if (card == 2)
                        {
                            scp181.GiveItem(Smod2.API.ItemType.KEYCARDCONTAINMENTENGINEER);
                        }
                        if (card == 4)
                        {
                            scp181.GiveItem(Smod2.API.ItemType.KEYCARDJANITOR);
                        }
                        if (card == 5)
                        {
                            scp181.GiveItem(Smod2.API.ItemType.KEYCARDSCIENTISTMAJOR);
                        }
                        if (card == 6)
                        {
                            scp181.GiveItem(Smod2.API.ItemType.KEYCARDNTFCOMMANDER);
                        }
                        if (card == 7)
                        {
                            scp181.GiveItem(Smod2.API.ItemType.KEYCARDNTFLIEUTENANT);
                        }
                        if (card == 8)
                        {
                            scp181.GiveItem(Smod2.API.ItemType.KEYCARDO5);
                        }
                        if (card == 9)
                        {
                            scp181.GiveItem(Smod2.API.ItemType.KEYCARDSCIENTIST);
                        }
                        if (card == 10)
                        {
                            scp181.GiveItem(Smod2.API.ItemType.KEYCARDZONEMANAGER);
                        }

                        scp181.SetRank("pink", "scp181", null);
                        scp181.PersonalBroadcast(10, "你是[<color=red>SCP-181</color>]\n正在为你分配一张初始卡片你有20%几率捡起卡升级 次数无限 你可以人肉开门2次加油哦", false);
                        scp181.PersonalBroadcast(10, "[<color=red>SCP-181</color>]\n你还可以合成枪 你也可以合成闪光弹", false);

                    }
                    if (i == 1)
                    {
                        cxk = list[i];
                        cxkid = cxk.PlayerId;
                        cxkyes = true;
                        cxk.GiveItem(Smod2.API.ItemType.FLASHLIGHT);
                        cxk.SetRank("red", "蔡徐坤", null);
                        cxk.PersonalBroadcast(10, "你是[<color=red>SCP-蔡徐坤</color>]\n<color=lime>丢下手电筒使用技能鸡你太美</color>", false);
                    }
                    if (i == 2)
                    {
                        scp817 = list[i];
                        scp817yes = true;
                        scp817id = scp817.PlayerId;
                        scp817.SetRank("red", "SCP817", null);
                        scp817.PersonalBroadcast(10, "你是[<color=red>SCP-817</color>]\n<color=lime>150秒变换一次身份</color>", false);
                    }
                    if (i == 3)
                    {
                        D9341 = list[i];
                        D9341js = Smod2.API.Role.SPECTATOR;
                        D9341id = D9341.PlayerId;
                        D9341.GiveItem(Smod2.API.ItemType.FLASHLIGHT);
                        D9341.GiveItem(Smod2.API.ItemType.GRENADEFLASH);
                        D9341.SetRank("red", "D-9341", null);
                        D9341.PersonalBroadcast(6, "你是[<color=red>D-9341</color>]<color=lime>你有存档能力 丢掉闪光弹</color><color=red>(打开背包右键不是左键扔出去)</color><color=lime>存档</color>\n<color=lime>死亡或丢手电会回档一共5次机会</color>", false);
                    }
                    if (i == 4)
                    {
                        scp2006 = list[i];
                        scp2006id = scp2006.PlayerId;
                        scp2006.PersonalBroadcast(10, "你是[<color=red>SCP-2006</color>]\n<color=lime>丢下一个硬币就会被随机传送到一个地方</color>", false);
                        scp2006.GiveItem(Smod2.API.ItemType.COIN);
                        scp2006.GiveItem(Smod2.API.ItemType.COIN);
                        scp2006.GiveItem(Smod2.API.ItemType.COIN);
                        scp2006.GiveItem(Smod2.API.ItemType.COIN);
                        scp2006.GiveItem(Smod2.API.ItemType.COIN);
                        scp2006.GiveItem(Smod2.API.ItemType.COIN);
                        scp2006.GiveItem(Smod2.API.ItemType.COIN);
                        scp2006.GiveItem(Smod2.API.ItemType.COIN);
                        scp2006a.Add(scp2006.UserId);
                    }
                    if (i == 5)
                    {
                        scp035 = list[i];
                        scp035.PersonalBroadcast(10, "你是[<color=red>SCP035</color>]\n<color=lime>和</color><color=red>SCP</color><color=lime>合作杀光</color><color=red>人类</color>", false);
                        scp035.SetHealth(500);
                        scp035id = scp035.PlayerId;
                        scp035.GiveItem(Smod2.API.ItemType.KEYCARDCHAOSINSURGENCY);
                    }
                    if (i == 6)
                    {
                        xtd = list[i];
                        xtdid = xtd.PlayerId;
                        xtd.PersonalBroadcast(10, "你是[<color=red>小偷</color>]\n<color=lime>输入.steal偷取物品300s一次</color>", false);
                        xtd.SetRank("lime", "小偷", null);
                    }
                    if (i == 7)
                    {
                        dsjsc = list[i];
                        dsjscid = xtd.PlayerId;
                        dsjsc.PersonalBroadcast(10, "你是[<color=red>D-未知</color>]\n<color=lime>你可以降低致命伤害，扔下手电筒后可以使周围的设备失灵,你有几率开全部的门</color>", false);
                        dsjsc.SetRank("lime", "D-未知", null);
                    }
                    if (i == 100)
                    {
                        lb = list[i];
                        lb.PersonalBroadcast(10, "你是[<color=red>老八</color>]\n<color=lime>根据提示完成你的小汉堡</color>", false);
                        lbid = lb.PlayerId;
                        lbyes = true;
                        plugin.Server.Map.Broadcast(5, "<color=lime>一日山掺没烦恼，今天就吃老八秘制小汉堡，既实惠，还管饱</color>", false);

                    }
                }
                for (int i = 0; i < list2.Count; i++)
                {
                    if (i == 0)
                    {
                        scpqbl = list2[i];
                        scpqblid = scpqbl.UserId;
                    }
                    if (i == 1)
                    {
                        int yes = new Random().Next(1, 100);
                        if (yes >= 60)
                        {
                            scp914m = list2[i];
                            scp914m.SetRank("pink", "SCP914-M");
                            scp914mid = scp914m.PlayerId;
                            scp914m.PersonalBroadcast(10, "你是[<color=red>SCP914-M</color>]\n你就是914的化身", false);
                        }
                    }
                    if (i == 2)
                    {
                        scp076 = list2[i];
                        scp076.ChangeRole(Smod2.API.Role.NTF_COMMANDER);
                        foreach (Smod2.API.Item item in scp076.GetInventory())
                        {
                            item.Remove();
                        }

                        scp076.GiveItem(Smod2.API.ItemType.GUNE11SR);
                        scp076.GiveItem(Smod2.API.ItemType.RADIO);
                        scp076.GiveItem(Smod2.API.ItemType.ADRENALINE);
                        scp076.GiveItem(Smod2.API.ItemType.GRENADEFRAG);
                        scp076.GiveItem(Smod2.API.ItemType.GRENADEFRAG);
                        scp076.GiveItem(Smod2.API.ItemType.MICROHID);
                        scp076id = scp076.PlayerId;
                        scp076.SetRank("red", "SCP-076", null);
                        scp076yes = true;
                        scp076.PersonalBroadcast(10, "[<color=red>SCP-076</color>]\n<color=lime>你有强大的SCP抗性以及子弹抗性，你没有卡请等待其他人为你开门</color>", false);

                    }
                    if(i == 3)
                    {
                        scp650yes = true;
                        scp650 = list2[i];
                        scp650.ChangeRole(Smod2.API.Role.SCP_173);
                        scp650.SetHealth(1);
                        scp650id = scp650.PlayerId;
                        scp650.SetGodmode(true);
                        scp650.SetRank("red", "SCP-650", null);
                        scp076.PersonalBroadcast(10, "[<color=red>SCP-650</color>]\n<color=lime>你是无敌的但是你没有伤害 你的责任就是吓人qwq</color>", false);
                    }
                }
                times = 0;




                coldwait233 = false;
                starttimer = true;
                roundstart = true;
                deadtime = true;
                new Thread(() => new EscapeHandler(this, plugin)).Start();
                plugin.Server.Map.Broadcast(7, "由于服务器插件问题每次玩完一回合可能就会炸服\n直接点击直线连接不用输入Ip即可重连", false);
                plugin.PluginManager.Server.Map.AnnounceCustomMessage("Attention all personnel The Side now in Containment Breach The alpha warhead will DESTROY The SIDE Please CONTAINMENT All SCPSUBJECTS in 30 MINUTE", true);
                plugin.PluginManager.Server.Map.Broadcast(10, "<color=#FF0000>警告:</color>站点发生收容失效,Alpha弹头协议将会摧毁此站点\n请在30分钟内遏制重新收容所有SCP项目", false);
                string[] textArray1 = new string[] { "[<color=#FFA500>", SCP173, "</color> <color=#008000>", SCP049, "</color> <color=#FF8C00>", SCP079, "</color> <color=#808080>", SCP096, "</color> <color=#800000>", SCP939_89, "</color> <color=#CD5C5C>", SCP939_53, "</color> <color=#D2691E>", SCP106, "</color>", "]\n<color=#FF0000>检测到以上SCP已突破收容</color>" };
                plugin.PluginManager.Server.Map.Broadcast(12, string.Concat(textArray1), false);
                plugin.PluginManager.Server.Map.Broadcast(10, "<color=#FFFF00>[进入投降模式]</color>\n---|<color=#FF0000>点击键盘上的 ~ 键[数字1左边]</color>|---\n输入<color=#9400D3>.tx</color>即可进入<color=#9400D3>投降模式</color>", false);
                plugin.PluginManager.Server.Map.Broadcast(10, "<color=#FFFF00>[投票系统]</color>\n---|<color=#FF0000>点击键盘上的 ~ 键[数字1左边]</color>|---\n输入<color=#9400D3>.ban</color><color=#9400D3>查看详细操作和指令</color>", false);
            }


            public void OnSetRole(PlayerSetRoleEvent ev)
            {
                if (ev.Role == Smod2.API.Role.NTF_COMMANDER)
                {
                    ev.Player.SetAmmo(AmmoType.DROPPED_5, 400);
                    ev.Player.SetAmmo(AmmoType.DROPPED_7, 400);
                    ev.Player.SetAmmo(AmmoType.DROPPED_9, 400);
                }
                if (ev.Role == Smod2.API.Role.NTF_LIEUTENANT)
                {
                    ev.Player.SetAmmo(AmmoType.DROPPED_5, 450);
                    ev.Player.SetAmmo(AmmoType.DROPPED_7, 400);
                    ev.Player.SetAmmo(AmmoType.DROPPED_9, 400);
                }
                if (ev.Role == Smod2.API.Role.NTF_SCIENTIST)
                {
                    ev.Player.SetAmmo(AmmoType.DROPPED_5, 450);
                    ev.Player.SetAmmo(AmmoType.DROPPED_7, 400);
                    ev.Player.SetAmmo(AmmoType.DROPPED_9, 450);
                }
                if (ev.Role == Smod2.API.Role.NTF_CADET)
                {
                    ev.Player.SetAmmo(AmmoType.DROPPED_5, 40);
                    ev.Player.SetAmmo(AmmoType.DROPPED_7, 0xa5);
                    ev.Player.SetAmmo(AmmoType.DROPPED_9, 450);
                }
                if (ev.Role == Smod2.API.Role.FACILITY_GUARD)
                {
                    ev.Player.SetAmmo(AmmoType.DROPPED_5, 400);
                    ev.Player.SetAmmo(AmmoType.DROPPED_7, 450);
                    ev.Player.SetAmmo(AmmoType.DROPPED_9, 400);
                }
                if (ev.Role == Smod2.API.Role.CHAOS_INSURGENCY)
                {
                    ev.Player.SetAmmo(AmmoType.DROPPED_5, 0);
                    ev.Player.SetAmmo(AmmoType.DROPPED_7, 400);
                    ev.Player.SetAmmo(AmmoType.DROPPED_9, 0);
                }
            }

            public void OnSpawn(PlayerSpawnEvent ev)
            {
                starttimer = true;
                roundstart = true;

                int playerId = ev.Player.PlayerId;
                if ((ev.Player.TeamRole.Role == Smod2.API.Role.SCP_939_89) && (new Random().Next(0, 100) <= 20))
                {
                    ev.Player.SetRank("red", "SCP-682", null);
                    ev.Player.PersonalBroadcast(10, "<color=#FF0000>你是SCP682大爷记住你的身份哦qwq</color>", false);
                    scp682.Add(ev.Player.UserId);
                    plugin.Info(ev.Player.Name + "成为SCP682");
                    ev.Player.SetHealth(5000);
                }
                if (ev.Player.TeamRole.Role == Smod2.API.Role.SCP_939_53)
                {
                    ev.Player.SetRank("red", "SCP-939-3", null);
                    ev.Player.PersonalBroadcast(10, "<color=#FF0000>你是SCP-939-3你攻击伤害为100点哦qwq</color>", false);
                    plugin.Info(ev.Player.Name + "939-3");
                    scp939id = ev.Player.PlayerId;
                    ev.Player.SetHealth(5000);
                }
                if (ev.Player.TeamRole.Role == Smod2.API.Role.CHAOS_INSURGENCY)
                {
                    ev.Player.PersonalBroadcast(10, "<color=#FFC0CB>[混沌分裂者]</color>\n<color=#00FFFF>你的任务是救出D级杀光九尾或与SCP合作</color>\n你对SCP造成的伤害<color=#FFD700>+5</color>", false);
                    if (times == 2)
                    {
                        plugin.PluginManager.Server.Map.Broadcast(6, "SCP1143突破收容", false);
                        scp1143 = ev.Player;
                        scp1143.SetRank("red", "SCP-1143", null);
                        scp1143.PersonalBroadcast(6, "你是SCP1143 30秒会刷一个雷或闪光弹", false);
                        scp1143a = true;
                        scp1143id = scp1143.PlayerId;
                        times2 = 3;
                        goto qwq3;
                    }
                    if ((times2 == 1))
                    {
                        HDZHG = ev.Player;
                        hhzhgzb = false;
                        times2 = 2;
                        goto qwq3;
                    }

                }
                qwq3:
                if ((ev.Player.TeamRole.Role == Smod2.API.Role.NTF_CADET) && (jw.Contains(ev.Player.PlayerId)))
                {
                    if ((times == 6) && (jw.Contains(ev.Player.PlayerId)))
                    {
                        jwhhk = ev.Player;
                        jwhhkid = jwhhk.PlayerId;
                        
                        jw.Remove(ev.Player.PlayerId);
                        jwhhk.SetRank("red", "九尾狐黑客", null);
                        jwhhk.PersonalBroadcast(5, "<color=lime>你是九尾狐黑客</color>:输入.hk可以黑入实验室", false);
                        times = 7;
                        goto qwq2;
                    }
                    if ((tiems == 5) && (jljy1 == false) && (jw.Contains(ev.Player.PlayerId)))
                    {
                        times = 6;
                        jljy1 = true;
                        jljy = ev.Player;
                        jw.Remove(ev.Player.PlayerId);
                        jljy.PersonalBroadcast(5, "你是吉良吉影请稍等您的装备马上派发", false);
                        jljy.ChangeRole(Smod2.API.Role.FACILITY_GUARD);
                        jljyzb = true;
                        goto qwq2;
                    }
                    if ((tiems == 4) && (bpb == false) && (jw.Contains(ev.Player.PlayerId)))
                    {
                        times = 5;
                        bpb = true;
                        jw.Remove(ev.Player.PlayerId);
                        bpb2.Add(ev.Player.PlayerId);
                        ev.Player.SetRank("red", "九尾狐爆破兵");
                        ev.Player.PersonalBroadcast(5, "<color=red>你是九尾狐爆破兵</color>:捡起板子和闪光弹可以变成手雷", false);
                        goto qwq2;
                    }
                    if((tiems == 3)&&(scp073a == false)&&(jw.Contains(ev.Player.PlayerId)))
                    {
                        tiems = 4;
                        scp073 = ev.Player;
                        scp073a = true;
                        scp073id = scp073.PlayerId;
                        jw.Remove(ev.Player.PlayerId);
                        ev.Player.SetRank("red", "SCP-073");
                        ev.Player.PersonalBroadcast(5, "<color=#FF0000>你是九尾狐SCP-073</color>\n<color=lime>如果SCP攻击你 只有10点伤害 且反伤50 枪械攻击伤害为1且反伤5</color>", false);
                        scp073zb = false;
                        goto qwq2;
                    }
                    if ((tiems == 2) && (ylb1 == false) && (ev.Player.TeamRole.Role == Smod2.API.Role.NTF_CADET) && (jw.Contains(ev.Player.PlayerId)))
                    {
                        ylb1 = true;
                        ev.Player.SetRank("yellow", "九尾医疗兵", null);
                        ev.Player.PersonalBroadcast(5, "<color=#FF0000>你是九尾狐医疗兵</color>:在你周围的人会回血，捡起板子和闪光弹可以变成血包", false);
                        ylb = ev.Player;
                        ylb2.Add(ylb.UserId);
                        tiems = 3;
                        jw.Remove(ev.Player.PlayerId);
                        goto qwq2;
                    }
                    if ((ev.Player.TeamRole.Role == Smod2.API.Role.NTF_CADET) && (tiems == 1) && (jw.Contains(ev.Player.PlayerId)))
                    {
                        jw.Remove(ev.Player.PlayerId);
                        mrfish = ev.Player;
                        mrfish.SetRank("yellow", "Mr.Fish", null);
                        plugin.PluginManager.Server.Map.Broadcast(10, "<color=#FF0000>Mr.Fish:</color>你们太菜了看我把SCP都收容了", false);
                        LLBS233.Add(mrfish.PlayerId);
                        tiems = 2;
                        mrfishzb = false;
                        goto qwq2;
                    }
                    ev.Player.SetAmmo(AmmoType.DROPPED_5, 400);
                    ev.Player.SetAmmo(AmmoType.DROPPED_7, 400);
                    ev.Player.SetAmmo(AmmoType.DROPPED_9, 400);
                }
                qwq2:
                if (ev.Player.TeamRole.Role == Smod2.API.Role.NTF_COMMANDER)
                {
                    ev.Player.SetAmmo(AmmoType.DROPPED_5, 400);
                    ev.Player.SetAmmo(AmmoType.DROPPED_7, 400);
                    ev.Player.SetAmmo(AmmoType.DROPPED_9, 400);
                    ev.Player.PersonalBroadcast(10, "<color=#FFC0CB>[九尾狐指挥官]</color>\n<color=#00FFFF>你可以给所有九尾狐阵营发送信息,冷却80秒</color>\n详细<color=#FFD700>按~键激活控制台输入.help查看帮助</color>", false);
                }
                if (ev.Player.TeamRole.Role == Smod2.API.Role.FACILITY_GUARD)
                {
                    ev.Player.SetAmmo(AmmoType.DROPPED_5, 400);
                    ev.Player.SetAmmo(AmmoType.DROPPED_7, 400);
                    ev.Player.SetAmmo(AmmoType.DROPPED_9, 400);
                    ev.Player.PersonalBroadcast(10, "<color=#FFC0CB>[设施保安]</color>\n<color=#00FFFF>你的任务是捆绑救出D级科学家杀光SCP与混沌</color>\n你可以前往<color=#FFD700>逃脱点</color>获得物资", false);
                }
                if (ev.Player.TeamRole.Role == Smod2.API.Role.NTF_LIEUTENANT)
                {
                    ev.Player.SetAmmo(AmmoType.DROPPED_5, 400);
                    ev.Player.SetAmmo(AmmoType.DROPPED_7, 400);
                    ev.Player.SetAmmo(AmmoType.DROPPED_9, 400);
                }
                if (ev.Player.TeamRole.Role == Smod2.API.Role.SCP_173)
                {
                    ev.Player.PersonalBroadcast(10, "<color=#FFC0CB>---[SCP173]---</color>\n<color=#00FFFF>HP:4200  </color>你拥有一种特殊能力\n受到除手炮以外的<color=#FFD700>枪械伤害只有3点</color>", false);
                    SCP173 = "SCP173";
                    s173 = 1;
                    ev.Player.SetHealth(4200);
                }
                if (ev.Player.TeamRole.Role == Smod2.API.Role.SCP_049)
                {
                    ev.Player.SetRank("pink", "当前等级:" + lv + "经验值:" + xp, null);
                    SCP049 = "SCP049";
                    ev.Player.SetHealth(3300);
                    s173 = 1;
                    ev.Player.PersonalBroadcast(10, "<color=#FFC0CB>---[SCP049]---</color>\n<color=#FFC0CB>你一共3级多复活小僵尸吧qwq</color>", false);
                }
                if (ev.Player.TeamRole.Role == Smod2.API.Role.SCP_079)
                {
                    SCP079 = "SCP079";
                }
                if (ev.Player.TeamRole.Role == Smod2.API.Role.SCP_096)
                {
                    ev.Player.PersonalBroadcast(15, "<color=#FFC0CB>---[SCP096]---</color>\n<color=#00FFFF>HP:5000  </color>你拥有一种特殊能力\n<color=#FFD700>按E 3%概率 打开所有门</color>", false);
                    SCP096 = "SCP096";
                    s096 = 1;
                    ev.Player.SetHealth(5000);
                }
                if (ev.Player.TeamRole.Role == Smod2.API.Role.SCP_939_89)
                {
                    ev.Player.PersonalBroadcast(10, "<color=#FFC0CB>---[SCP939_89]---</color>\n<color=#00FFFF>HP:6000  </color>你拥有一种特殊能力\n受到<color=#FFD700>攻击时</color>你会加速,你可以奔跑", false);
                    SCP939_89 = "SCP939_89";
                    ev.Player.SetHealth(5000);
                    s939_89 = 1;
                }
                if (ev.Player.TeamRole.Role == Smod2.API.Role.SCP_939_53)
                {
                    ev.Player.PersonalBroadcast(10, "<color=#FFC0CB>---[SCP939_53]---</color>\n<color=#00FFFF>HP:6000  </color>你拥有一种特殊能力\n受到<color=#FFD700>攻击时</color>你会加速,你可以奔跑", false);
                    SCP939_53 = "SCP939_53";
                    s939_53 = 1;
                    ev.Player.SetHealth(5000);
                }
                if (ev.Player.TeamRole.Role == Smod2.API.Role.SCP_106)
                {
                    ev.Player.PersonalBroadcast(10, "<color=#FFC0CB>---[SCP106]---</color>\n<color=#00FFFF>HP:650  </color>你拥有一种特殊能力\n受到<color=#FFD700>枪械伤害只有1点</color>", false);
                    SCP106 = "SCP106";
                    s106 = 1;
                }
                if (ev.Player.TeamRole.Role == Smod2.API.Role.SCP_049_2)
                {
                    ev.Player.PersonalBroadcast(10, "<color=#FFC0CB>---[SCP049_2]---</color>\n<color=#00FFFF>HP:1400</color>", false);
                    ev.Player.SetHealth(1400);
                    xp = xp + 50;
                    if (xp == 100)
                    {
                        lv = 1;
                    }
                    if (xp == 400)
                    {
                        lv = 2;
                    }
                    if (xp == 800)
                    {
                        lv = 3;
                    }
                    foreach (Player player in plugin.Server.GetPlayers())
                    {
                        if (player.TeamRole.Role == Smod2.API.Role.SCP_049)
                        {
                            player.AddHealth(50);
                            player.SetRank("pink", "当前等级:" + lv + " 经验值:" + xp, null);
                        }
                    }
                }
            }
            public void OnUpdate(UpdateEvent ev)
            {
                if ((updatatimerscp1577 < DateTime.Now) && (bhsx == true))
                {
                    updatatimerscp1577 = DateTime.Now.AddSeconds(300.0);
                    njsxtimes++;
                    if(njsxtimes == 2)
                    {
                        njsxtimes = 0;
                        bhsx = false;
                    }
                }
                
                if ((updatatimerscp1577 < DateTime.Now) && (scp1577bj == true))
                {
                    updatatimerscp1577 = DateTime.Now.AddSeconds(20.0);
                    scp1577times++;
                    if (scp1577times == 2)
                    {
                        plugin.Server.Map.SpawnItem(Smod2.API.ItemType.SCP500, scp1577pos, null);
                        plugin.Server.Map.SpawnItem(Smod2.API.ItemType.SCP500, scp1577pos, null);
                        plugin.Server.Map.SpawnItem(Smod2.API.ItemType.MEDKIT, scp1577pos, null);
                        plugin.Server.Map.SpawnItem(Smod2.API.ItemType.MICROHID, scp1577pos, null);
                        plugin.Server.Map.SpawnItem(Smod2.API.ItemType.KEYCARDO5, scp1577pos, null);
                        scp1577times = 0;
                        scp1577bj = false;
                    }
                }
                if (updatatimersteal < DateTime.Now)
                {
                    updatatimersteal = DateTime.Now.AddSeconds(300.0);
                    stealcd = false;
                    plugin.Server.Map.Broadcast(7, "<color=#00FFFF>如果你有什么好点子或者游玩中有什么问题欢迎您加群哦\n278704578</color>", false);
                    plugin.Server.Map.Broadcast(7, "<color=#00FFFF>服务器如果十分卡顿，说明服务器被攻击，联系服主下列表\n上这里278704578找群主</color>", false);
                    
                }
                if ((scp650yes == true) && (updatatimerscp650 < DateTime.Now))
                {
                    updatatimerscp650 = DateTime.Now.AddSeconds(30.0);
                    playerqwq = plugin.Server.GetPlayers();
                    int cardup = new Random().Next(1, playerqwq.Count);

                    if ((playerqwq[cardup].TeamRole.Team != Smod2.API.Team.SCP) && (playerqwq[cardup].TeamRole.Role != Smod2.API.Role.SPECTATOR))
                    {
                        scp650.Teleport(playerqwq[cardup].GetPosition());
                    }
                    foreach (Smod2.API.Player player in plugin.Server.GetPlayers())
                    {
                        if (player.PlayerId == scp650id)
                        {
                            if (player.TeamRole.Role != Smod2.API.Role.SCP_173)
                            {
                                scp650.SetGodmode(false);
                            }
                        }
                    }

                }
                if ((updatatimerscp076 < DateTime.Now) && (scp076yes == true))
                {
                    updatatimerscp076 = DateTime.Now.AddSeconds(240.0);
                    scp076.GiveItem(Smod2.API.ItemType.MICROHID);
                }

                if ((scp457a == true) && (updatatimerscp457 < DateTime.Now))
                {
                    updatatimerscp457 = DateTime.Now.AddSeconds(1.0);
                    scp457b = scp457.GetPosition();
                    float num2 = scp457b.x + 4;
                    float num3 = scp457b.y + 4;
                    float num4 = scp457b.z + 4;
                    float num5 = scp457b.x - 4;
                    float num6 = scp457b.y - 4;
                    float num7 = scp457b.z - 4;
                    player10 = plugin.Server.GetPlayers();
                    foreach (Player player in player10)
                    {
                        if ((player.TeamRole.Team != Smod2.API.Team.SCP) && (player.PlayerId != scp457id) && (player.GetPosition().x <= num2) && (player.GetPosition().x >= num5) && (player.GetPosition().y <= num3) && (player.GetPosition().y >= num6) && ((player.GetPosition().z <= num4) && (player.GetPosition().z >= num7)))
                        {
                            if (player.GetHealth() - 10 < 0)
                            {
                                player.Kill();
                            }
                            else
                            {
                                player.SetHealth(player.GetHealth() - 10);
                                player.PersonalBroadcast(1, "SCP-457在你附近你正在持续扣血", false);
                            }


                        }
                    }
                }
                if ((csm) && (updatatimercsm < DateTime.Now))
                {
                    updatatimercsm = DateTime.Now.AddSeconds(1.0);
                    csmtime++;
                    if (csmtime == 10)
                    {
                        csm = false;
                        csmtime = 0;
                    }

                }
                if ((hrss) && (updatatimerhk < DateTime.Now))
                {
                    updatatimerhk = DateTime.Now.AddSeconds(1.0);
                    hktime++;
                    float num2 = hkzb.x + 2;
                    float num3 = hkzb.y + 2;
                    float num4 = hkzb.z + 2;
                    float num5 = hkzb.x - 2;
                    float num6 = hkzb.y - 2;
                    float num7 = hkzb.z - 2;
                    player10 = plugin.Server.GetPlayers();
                    foreach (Player player in player10)
                    {
                        if ((player.TeamRole.Team != Smod2.API.Team.NINETAILFOX) && (player.TeamRole.Team != Smod2.API.Team.SCIENTIST) && (player.GetPosition().x <= num2) && (player.GetPosition().x >= num5) && (player.GetPosition().y <= num3) && (player.GetPosition().y >= num6) && ((player.GetPosition().z <= num4) && (player.GetPosition().z >= num7)))
                        {
                            jwhhk.ChangeRole(Smod2.API.Role.NTF_SCIENTIST, true, false, false, false);
                            jwhhk.Teleport(hkzb, true);
                            hktime = 0;
                            hrss = false;
                        }
                    }
                    if (hktime == 120)
                    {
                        foreach (Player player in plugin.Server.GetPlayers())
                        {
                            if (player.PlayerId == jwhhkid)
                            {
                                jwhhk.ChangeRole(Smod2.API.Role.NTF_SCIENTIST, true, false, false, false);
                                jwhhk.Teleport(hkzb, true);
                                hktime = 0;
                                hrss = false;
                                
                            }
                        }
                    }
                }
                //181组件头
                if (starttimer && (updatatimer181 < DateTime.Now))
                { 
                    if(scp3108shotyes == true)
                    {
                        scp3108playerid = 0;
                    }
                    updatatimer181 = DateTime.Now.AddSeconds(100.0);
                    scp2006.GiveItem(Smod2.API.ItemType.COIN);
                    foreach (Player player in plugin.Server.GetPlayers())
                    {
                        if (player.TeamRole.Team == Smod2.API.Team.SCP)
                        {
                            player.AddHealth(25);
                        }
                    }
                    if(bpb == true)
                    {
                        foreach(Player player in plugin.Server.GetPlayers())
                        {
                            if(bpb2.Contains(player.PlayerId))
                            {
                                player.GiveItem(Smod2.API.ItemType.GRENADEFRAG);
                            }
                        }
                    }
                    if(ylb1 == true)
                    {
                        ylb.GiveItem(Smod2.API.ItemType.MEDKIT);
                    }

                }
                if ((updatatimer182 < DateTime.Now) && (jntm == true))
                {
                    updatatimer182 = DateTime.Now.AddSeconds(10);
                    times4++;
                    if (times4 == 2)
                    {
                        jntm = false;
                        times4 = 0;
                    }
                }
                if ((updatatimer183 < DateTime.Now) && (cxkyes == true))
                {
                    updatatimer183 = DateTime.Now.AddSeconds(100.0);
                    times2++;
                    if (times2 == 2)
                    {
                        times2 = 1;
                        cxk.GiveItem(Smod2.API.ItemType.FLASHLIGHT);
                        cxk.PersonalBroadcast(4, "鸡你太美充能完毕", false);
                    }
                }
                if (updatatimer184 < DateTime.Now)
                {
                    updatatimer184 = DateTime.Now.AddSeconds(50.0);
                    foreach(Smod2.API.Door door in doord)
                    {
                        door.Locked = false;
                    }
                    if (firstscp == true)
                    {
                        plugin.Server.Map.Broadcast(5, "开始纠正SCP血量", false);
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
                        firstscp = false;
                    }
                    foreach (Player player in plugin.Server.GetPlayers())
                    {
                        if (player.UserId == "76561198401655330@steam")
                        {
                            player.SetRank("blue_green", "醉墨画秋澜", null);
                        }
                        if (player.UserId == "76561198966027787@steam")
                        {
                            player.SetRank("cyan", "你马没了", null);
                        }

                        

                        if (player.UserId == "76561198296186931@steam")
                        {
                            player.SetRank("magenta", "咸鱼金", null);
                        }

                        if (player.UserId == "76561198301803112@steam")
                        {
                            player.SetRank("yellow", "一只萌新", null);
                        }
                        if (player.UserId == "76561198389200613@steam")
                        {
                            player.SetRank("yellow", "非常无聊的大白", null);
                        }
                        if (player.UserId == "76561198105087430@steam")
                        {
                            player.SetRank("yellow", "金之巧Channel", null);
                        }
                        if (player.UserId == "76561198841949627@steam")
                        {
                            player.SetRank("lime", "日常快乐水的杨教授", null);
                        }
                        if (player.UserId == "76561198841744752@steam")
                        {
                            player.SetRank("lime", "VIP1", null);
                        }
                        if (player.UserId == "76561198388299994@steam")
                        {
                            player.SetRank("crimson", "BILIBILI_z_z骚糖", null);
                        }
                        if (player.UserId == "76561197961446054@steam")
                        {
                            player.SetRank("crimson", "BILIBILI_一个根大黄瓜", null);
                        }
                        if (player.UserId == "76561198190686028@steam")
                        {
                            player.SetRank("cyan", "BILIBILI_手残至尊", null);
                        }
                                              
                        if (player.UserId == "76561198380401708@steam")
                        {
                            player.SetRank("liime", "人形自走白给挂(BILIBILI)", null);
                        }
                        if (player.UserId == "76561198825310613@steam")
                        {
                            player.SetRank("crimson", "触手TV_东星.波少", null);
                        }
                        if (player.UserId == "76561198384476113@steam")
                        {
                            player.SetRank("lime", "VIP1", null);
                        }
                        if (player.UserId == "76561198381947239@steam")
                        {
                            player.SetRank("pink", "BILIBILI_我是吴语", null);
                        }
                        if (player.UserId == "76561198816705835@steam")
                        {
                            player.SetRank("silvery", "孤独一生", null);
                        }
                        if (player.UserId == "76561198149835838@steam")
                        {
                            player.SetRank("aqua", "SCP079的正宫夫人丨最大电力：79520丨电力恢复：0AP/s丨专业迫害106", null);
                        }
                        if (player.UserId == "76561198133773112@steam")
                        {
                            player.SetRank("lime", "BILIBILI_优乐美", null);
                        }
                        if (player.UserId == "76561198335932913@steam")
                        {
                            player.SetRank("lime", "招财喵~", null);
                        }
                        if (player.UserId == "76561198376557635@steam")
                        {
                            player.SetRank("lime", "VIP1~", null);
                        }
                        if (player.UserId == "76561198425823494@steam")
                        {
                            player.SetRank("red", "斯大林", null);
                        }
                        if (player.UserId == "76561198979881230@steam")
                        {
                            player.SetRank("aqua", "本群常驻UP主", null);
                        }
                        if (player.UserId == "76561198401019684@steam")
                        {
                            player.SetRank("lime", "不是小学生是少年音小姐姐", null);
                        }
                        if (player.UserId == "76561198416583969@steam")
                        {
                            player.SetRank("blue", "沙雕终结者", null);
                        }
                        if (player.UserId == "76561198961941280@steam")
                        {
                            player.SetRank("aqua", "BILIBILI_元气少年洛鸢", null);
                        }
                        if (player.UserId == "76561198359791579@steam")
                        {
                            player.SetRank("yellow", "D-17396", null);
                        }
                        if (player.UserId == "76561198977855934@steam")
                        {
                            player.SetRank("pink", "49夫人", null);
                        }
                        if (player.UserId == "76561198845175801@steam")
                        {
                            player.SetRank("lime", "七颜喜49", null);
                        }
                        if (player.UserId == "76561198414605683@steam")
                        {
                            player.SetRank("lime", "BILILBILI_殇小拓", null);
                        }
                        if (player.UserId == "76561198360004164@steam")
                        {
                            player.SetRank("lime", "bilibili冷幻cQWQ", null);
                        }
                        if (player.UserId == "76561198865192444@steam")
                        {
                            player.SetRank("red", "老头收容骑士", null);
                        }




                    }
                }
                if (updatatimer185 < DateTime.Now)
                {
                    updatatimer185 = DateTime.Now.AddSeconds(3.0);
                    if (times5 == 6)
                    {
                        foreach (Player player in plugin.Server.GetPlayers())
                        {
                            if (player.UserId == "76561198197721054@steam")
                            {
                                player.SetRank("yellow", "求别乱杀DD", null);
                            }
                            if (player.UserId == "76561198441344563@steam")
                            {
                                player.SetRank("yellow", "服内最帅大佬", null);
                            }
                            if (player.UserId == "76561198816705835@steam")
                            {
                                player.SetRank("lime", "孤独一生", null);
                            }
                            if (player.UserId == "76561198369468432@steam")
                            {
                                player.SetRank("yellow", "白嫖大法好", null);
                            }
                            if (player.UserId == "76561198997348090@steam")
                            {
                                player.SetRank("yellow", "因为是魔王所以很棒呀", null);
                            }
                            if (player.UserId == "76561198893112896@steam")
                            {
                                player.SetRank("cyan", "迪奥·布兰度", null);
                            }
                        }
                        times5 = 1;
                    }
                    if (times5 == 5)
                    {
                        foreach (Player player in plugin.Server.GetPlayers())
                        {
                            if (player.UserId == "76561198197721054@steam")
                            {
                                player.SetRank("green", "求别乱杀DD", null);
                            }
                            if (player.UserId == "76561198441344563@steam")
                            {
                                player.SetRank("green", "服内最帅大佬", null);
                            }
                            if (player.UserId == "76561198816705835@steam")
                            {
                                player.SetRank("crimson", "孤独一生", null);
                            }
                            if (player.UserId == "76561198369468432@steam")
                            {
                                player.SetRank("green", "白嫖大法好", null);
                            }
                            if (player.UserId == "76561198997348090@steam")
                            {
                                player.SetRank("green", "因为是魔王所以很棒呀", null);
                            }
                            if (player.UserId == "76561198893112896@steam")
                            {
                                player.SetRank("green", "迪奥·布兰度", null);
                            }
                        }
                        times5 = 6;
                    }
                    if (times5 == 4)
                    {
                        foreach (Player player in plugin.Server.GetPlayers())
                        {
                            if (player.UserId == "76561198197721054@steam")
                            {
                                player.SetRank("red", "求别乱杀DD", null);
                            }
                            if (player.UserId == "76561198441344563@steam")
                            {
                                player.SetRank("red", "服内最帅大佬", null);
                            }
                            if (player.UserId == "76561198816705835@steam")
                            {
                                player.SetRank("cyan", "孤独一生", null);
                            }
                            if (player.UserId == "76561198369468432@steam")
                            {
                                player.SetRank("red", "白嫖大法好", null);
                            }
                            if (player.UserId == "76561198997348090@steam")
                            {
                                player.SetRank("red", "因为是魔王所以很棒呀", null);
                            }
                            if (player.UserId == "76561198893112896@steam")
                            {
                                player.SetRank("red", "迪奥·布兰度", null);
                            }
                        }
                        times5 = 5;
                    }
                    if (times5 == 3)
                    {
                        foreach (Player player in plugin.Server.GetPlayers())
                        {
                            if (player.UserId == "76561198197721054@steam")
                            {
                                player.SetRank("cyan", "求别乱杀DD", null);
                            }
                            if (player.UserId == "76561198441344563@steam")
                            {
                                player.SetRank("cyan", "服内最帅大佬", null);
                            }
                            if (player.UserId == "76561198816705835@steam")
                            {
                                player.SetRank("red", "孤独一生", null);
                            }
                            if (player.UserId == "76561198369468432@steam")
                            {
                                player.SetRank("cyan", "白嫖大法好", null);
                            }
                            if (player.UserId == "76561198997348090@steam")
                            {
                                player.SetRank("cyan", "因为是魔王所以很棒呀", null);
                            }
                            if (player.UserId == "76561198893112896@steam")
                            {
                                player.SetRank("pink", "迪奥·布兰度", null);
                            }
                        }
                        times5 = 4;
                    }

                    if (times5 == 2)
                    {
                        foreach (Player player in plugin.Server.GetPlayers())
                        {
                            if (player.UserId == "76561198197721054@steam")
                            {
                                player.SetRank("crimson", "求别乱杀DD", null);
                            }
                            if (player.UserId == "76561198441344563@steam")
                            {
                                player.SetRank("crimson", "服内最帅大佬", null);
                            }
                            if (player.UserId == "76561198816705835@steam")
                            {
                                player.SetRank("green", "孤独一生", null);
                            }
                            if (player.UserId == "76561198369468432@steam")
                            {
                                player.SetRank("crimson", "白嫖大法好", null);
                            }
                            if (player.UserId == "76561198997348090@steam")
                            {
                                player.SetRank("crimson", "因为是魔王所以很棒呀", null);
                            }
                            if (player.UserId == "76561198893112896@steam")
                            {
                                player.SetRank("orange", "迪奥·布兰度", null);
                            }
                        }
                        times5 = 3;
                    }

                    if (times5 == 1)
                    {
                        foreach (Player player in plugin.Server.GetPlayers())
                        {
                            if (player.UserId == "76561198197721054@steam")
                            {
                                player.SetRank("lime", "求别乱杀DD", null);
                            }
                            if (player.UserId == "76561198441344563@steam")
                            {
                                player.SetRank("lime", "服内最帅大佬", null);
                            }
                            if (player.UserId == "76561198816705835@steam")
                            {
                                player.SetRank("yellow", "孤独一生", null);
                            }
                            if (player.UserId == "76561198369468432@steam")
                            {
                                player.SetRank("lime", "白嫖大法好", null);
                            }
                            if (player.UserId == "76561198997348090@steam")
                            {
                                player.SetRank("lime", "因为是魔王所以很棒呀", null);
                            }
                            if (player.UserId == "76561198893112896@steam")
                            {
                                player.SetRank("yellow", "迪奥·布兰度", null);
                            }
                        }
                        times5 = 2;
                    }
                }
                if ((updatatimer186 < DateTime.Now) && (scp817yes == true))
                {
                    updatatimer186 = DateTime.Now.AddSeconds(150.0);
                    times3++;
                    if (times3 >= 2)
                    {
                        pos3 = scp817.GetPosition();
                        Items = scp817.GetInventory();
                        int Rolenum = new Random().Next(1, 17);
                        if (Rolenum == 1)
                        {
                            scp817.ChangeRole(Smod2.API.Role.SCIENTIST, true, false, false, false);
                        }
                        if (Rolenum == 2)
                        {
                            scp817.ChangeRole(Smod2.API.Role.CHAOS_INSURGENCY, true, false, false, false);
                        }
                        if (Rolenum == 3)
                        {
                            scp817.ChangeRole(Smod2.API.Role.FACILITY_GUARD, true, false, false, false);
                        }
                        if (Rolenum == 4)
                        {
                            scp817.ChangeRole(Smod2.API.Role.NTF_CADET, true, false, false, false);
                        }
                        if (Rolenum == 5)
                        {
                            scp817.ChangeRole(Smod2.API.Role.NTF_COMMANDER, true, false, false, false);
                        }
                        if (Rolenum == 6)
                        {
                            scp817.ChangeRole(Smod2.API.Role.NTF_LIEUTENANT, true, false, false, false);
                        }
                        if (Rolenum == 7)
                        {
                            scp817.ChangeRole(Smod2.API.Role.NTF_SCIENTIST, true, false, false, false);
                        }
                        if (Rolenum == 8)
                        {
                            scp817.ChangeRole(Smod2.API.Role.SCP_049_2, true, false, false, false);
                        }
                        if (Rolenum == 9)
                        {
                            scp817.ChangeRole(Smod2.API.Role.SCP_079, true, false, false, false);
                        }
                        if (Rolenum == 10)
                        {
                            scp817.ChangeRole(Smod2.API.Role.SCP_106, true, false, false, false);
                        }
                        if (Rolenum == 11)
                        {
                            scp817.ChangeRole(Smod2.API.Role.SCP_173, true, false, false, false);
                        }
                        if (Rolenum == 12)
                        {
                            scp817.ChangeRole(Smod2.API.Role.SCP_939_53, true, false, false, false);
                        }
                        if (Rolenum == 13)
                        {
                            scp817.ChangeRole(Smod2.API.Role.SCP_939_89, true, false, false, false);
                        }
                        if (Rolenum == 14)
                        {
                            scp817.ChangeRole(Smod2.API.Role.TUTORIAL, true, false, false, false);
                        }
                        if (Rolenum == 15)
                        {
                            scp817.ChangeRole(Smod2.API.Role.UNASSIGNED, true, false, false, false);
                        }
                        if (Rolenum == 16)
                        {
                            scp817.ChangeRole(Smod2.API.Role.ZOMBIE, true, false, false, false);
                        }

                        foreach (Smod2.API.Item item2 in Items)
                        {
                            scp817.GiveItem(item2.ItemType);
                        }
                        scp817.PersonalBroadcast(5, "变身完毕qwq", false);
                        times3 = 1;
                        scp817.Teleport(pos3);
                    }
                }
                //181组件尾部
                if (updatatimer7 < DateTime.Now)
                {
                    updatatimer7 = DateTime.Now.AddSeconds(0.1);

                    if (sjtz1 == true)
                    {
                        for (int i = 0; i < player5.Count; i++)
                        {
                            if (Dio2.Contains(player5[i].UserId) == false)
                            {
                                player5[i].Teleport(pos1[i]);
                            }
                        }
                    }
                    else
                    {
                        pos1.Clear();
                    }
                    if (qblcq2 == true)
                    {
                        qblcq.Teleport(scpqbl3.GetPosition());
                    }

                }
                if (updatatimer6 < DateTime.Now)
                {
                    updatatimer6 = DateTime.Now.AddSeconds(30.0);
                    coldwait233 = false;//038cd 30s

                    if (scp1143a == true)
                    {
                        scp1143.GiveItem(Smod2.API.ItemType.GRENADEFRAG);
                    }
                    //1143给手榴弹
                    if (hhzhgzb == false)
                    {
                        HDZHG.PersonalClearBroadcasts();
                        HDZHG.PersonalBroadcast(5, "你是混沌指挥官按~打开控制台输入.help获得指令帮助", false);
                        HDZHG.SetRank("yello", "混沌指挥官", null);
                        HDZHG.SetHealth(150);
                        HDZHG.GiveItem(Smod2.API.ItemType.KEYCARDO5);
                        HDZHG2.Add(HDZHG.UserId);
                        hhzhgzb = true;
                    }
                    //混沌指挥官分配
                    if(scp073zb == false)
                    {
                        scp073.ChangeRole(Smod2.API.Role.NTF_LIEUTENANT, true, false, false, false);
                        scp073zb = true;
                    }
                    if (mrfishzb == false)
                    {
                        pos4 = mrfish.GetPosition();
                        mrfish.ChangeRole(Smod2.API.Role.SCIENTIST, true, true, true, true);
                        
                        foreach (Smod2.API.Item item in mrfish.GetInventory())
                        {
                            item.Remove();
                        }

                   
                        mrfish.SetHealth(120);
                        mrfish.GiveItem(Smod2.API.ItemType.KEYCARDO5);
                        mrfish.GiveItem(Smod2.API.ItemType.MICROHID);
                        mrfish.GiveItem(Smod2.API.ItemType.MICROHID);
                        mrfish.GiveItem(Smod2.API.ItemType.GUNLOGICER);
                        mrfish.GiveItem(Smod2.API.ItemType.GRENADEFRAG);
                        mrfish.GiveItem(Smod2.API.ItemType.RADIO);

                        mrfish.Teleport(pos4, false);
                        mrfish.Teleport(plugin.Server.Map.GetRandomSpawnPoint(Smod2.API.Role.NTF_COMMANDER), true);
                        mrfish.SetAmmo(AmmoType.DROPPED_5, 400);
                        mrfish.SetAmmo(AmmoType.DROPPED_7, 400);
                        mrfish.SetAmmo(AmmoType.DROPPED_9, 400);

                        mrfishzb = true;
                    }
                    if (jljyzb == true)
                    {
                        jljy.ChangeRole(Smod2.API.Role.TUTORIAL, true, true, true, true);
                        foreach (Smod2.API.Item item in jljy.GetInventory())
                        {
                            item.Remove();
                        }
                        jljy.Teleport(plugin.Server.Map.GetRandomSpawnPoint(Smod2.API.Role.FACILITY_GUARD), false);
                        jljy.GiveItem(Smod2.API.ItemType.GUNE11SR);
                        jljy.GiveItem(Smod2.API.ItemType.MICROHID);
                        jljy.GiveItem(Smod2.API.ItemType.MICROHID);
                        jljy.SetAmmo(AmmoType.DROPPED_5, 400);
                        jljy.SetAmmo(AmmoType.DROPPED_7, 400);
                        jljy.SetAmmo(AmmoType.DROPPED_9, 400);
                        jljy.GiveItem(Smod2.API.ItemType.KEYCARDNTFCOMMANDER);
                        jljy.SetHealth(250);
                        jljy2.Add(jljy.UserId);
                        jljy.SetRank("red", "吉良吉影", null);
                        jljyzb = false;
                    }
                }
                if ((updatatimer5 < DateTime.Now) && (starttimer == true))
                {
                    updatatimer5 = DateTime.Now.AddSeconds(200.0);

                    int sjsj2 = new Random().Next(1, 29);
                    if (Dio1 == false)
                    {
                        player2 = plugin.Server.GetPlayers();
                        foreach (Player player3 in player2)
                        {
                            if (player3.TeamRole.Role == Smod2.API.Role.SPECTATOR)
                            {
                                Dio = player3;
                                Dio1 = true;
                                plugin.Server.Map.Broadcast(10, "<color=#BB1444>Dio:</color>\n<color=#BB1444>轮到我上线装逼了</color>", false);
                                Dio.ChangeRole(Smod2.API.Role.TUTORIAL, true, true, true, true);
                                Dio.Teleport(plugin.Server.Map.GetRandomSpawnPoint(Smod2.API.Role.CHAOS_INSURGENCY), false);
                                Dio.SetHealth(500);
                                Dio.GiveItem(Smod2.API.ItemType.FLASHLIGHT);
                                Dio.GiveItem(Smod2.API.ItemType.GUNE11SR);
                                Dio.GiveItem(Smod2.API.ItemType.MICROHID);
                                Dio.GiveItem(Smod2.API.ItemType.MICROHID);
                                Dio.SetAmmo(AmmoType.DROPPED_5, 400);
                                Dio.SetAmmo(AmmoType.DROPPED_7, 400);
                                Dio.SetAmmo(AmmoType.DROPPED_9, 400);
                                Dio.GiveItem(Smod2.API.ItemType.KEYCARDNTFCOMMANDER);
                                Dio.PersonalClearBroadcasts();
                                Dio.PersonalBroadcast(6, "你是Dio丢掉手电使用时间停止", false);
                                Dio.SetRank("red", "Dio", null);
                                Dio2.Add(Dio.UserId);
                                break;

                            }
                        }
                    }


                    if ((scp457die == false) && (scp457a == false))
                    {
                        player2 = plugin.Server.GetPlayers();
                        foreach (Player player3 in player2)
                        {
                            if (player3.TeamRole.Role == Smod2.API.Role.SPECTATOR)
                            {
                                scp457 = player3;
                                scp457a = true;

                                scp457id = scp457.PlayerId;
                                scp457.SetRank("red", "SCP-457", null);
                                scp457.ChangeRole(Smod2.API.Role.TUTORIAL, true, true, true, true);
                                scp457.Teleport(plugin.Server.Map.GetRandomSpawnPoint(Smod2.API.Role.SCP_096), false);
                                scp457.SetHealth(4000);
                                plugin.Server.Map.Broadcast(10, "<color=red>SCP457已经出现请尽快消灭</color>", false);
                                scp457.PersonalBroadcast(10, "<color=#FFC0CB>---[SCP457]---</color>\n<color=#00FFFF>HP:4000  </color>你拥有一种特殊能力\n<color=#FFD700>在你周围的人都会扣血</color>", false);
                                break;
                            }
                        }
                    }

                    if (sjsj2 == 1)
                    {
                        plugin.Server.Map.Broadcast(10, "<color=#BB1444>毒气泄漏！-事件：所有生存人类玩家将在30秒内扣除掉1-12hp</color>", false);
                        player2 = plugin.Server.GetPlayers();
                        foreach (Player player3 in player2)
                        {
                            int kx = new Random().Next(1, 12);
                            if (player3.TeamRole.Team > Smod2.API.Team.SCP)
                            {
                                player3.Damage(kx);
                            }
                        }
                        player2 = null;
                    }
                    if (sjsj2 == 2)
                    {
                        plugin.Server.Map.Broadcast(10, "<color=#BB1444>DD造反！！-事件：所有存活的Class-D获得“造反物品”</color>", false);
                        player2 = plugin.Server.GetPlayers();
                        foreach (Player player3 in player2)
                        {
                            if (player3.TeamRole.Team == Smod2.API.Team.CLASSD)
                            {
                                player3.GiveItem(Smod2.API.ItemType.GUNCOM15);
                                player3.GiveItem(Smod2.API.ItemType.AMMO762);
                                player3.GiveItem(Smod2.API.ItemType.GUNCOM15);
                            }
                        }
                        player2 = null;
                    }

                    if (sjsj2 == 3)
                    {
                        plugin.Server.Map.Broadcast(10, "<color=#BB1444>博士的私货！！-事件：所有存活博士获得电磁炮x2和500hp</color>", false);
                        player2 = plugin.Server.GetPlayers();
                        foreach (Player player3 in player2)
                        {
                            if (player3.TeamRole.Team == Smod2.API.Team.SCIENTIST)
                            {
                                player3.GiveItem(Smod2.API.ItemType.MICROHID);
                                player3.GiveItem(Smod2.API.ItemType.MICROHID);
                                player3.SetHealth(player3.GetHealth() + 500);
                            }
                        }
                        player2 = null;
                    }

                    if (sjsj2 == 4)
                    {
                        plugin.Server.Map.Broadcast(10, "<color=#BB1444>我要下班-事件：随机一名保安获得一张黑卡</color>", false);
                        player2 = plugin.Server.GetPlayers();
                        foreach (Player player3 in player2)
                        {
                            if (player3.TeamRole.Role == Smod2.API.Role.FACILITY_GUARD)
                            {
                                player3.GiveItem(Smod2.API.ItemType.KEYCARDO5);
                                break;
                            }
                        }
                        player2 = null;
                    }

                    if (sjsj2 == 5)
                    {
                        plugin.Server.Map.Broadcast(10, "<color=#BB1444>猪是的念来过倒-事件：在场的所有玩家get到了一个笑点</color>", false);
                    }
                    if (sjsj2 == 6)
                    {
                        plugin.Server.Map.Broadcast(10, "<color=#BB1444>恭喜发财！-事件：所有存活玩家获得一大堆硬币</color>", false);
                        player2 = plugin.Server.GetPlayers();
                        foreach (Player player3 in player2)
                        {
                            player3.GiveItem(Smod2.API.ItemType.COIN);
                            player3.GiveItem(Smod2.API.ItemType.COIN);
                            player3.GiveItem(Smod2.API.ItemType.COIN);
                            player3.GiveItem(Smod2.API.ItemType.COIN);
                            player3.GiveItem(Smod2.API.ItemType.COIN);
                        }

                    }
                    if (sjsj2 == 7)
                    {
                        plugin.Server.Map.Broadcast(10, "<color=#BB1444>巧克力真好吃！-事件：花生吃掉自己手手</color>", false);
                        player2 = plugin.Server.GetPlayers();
                        foreach (Player player3 in player2)
                        {
                            if (player3.TeamRole.Role == Smod2.API.Role.SCP_173)
                            {
                                player3.Damage(50);
                            }
                        }

                    }
                    if (sjsj2 == 8)
                    {
                        plugin.Server.Map.Broadcast(10, "<color=#BB1444>无敌战神！-事件：花生-1HP并且无敌 恢复后满血复活qwq</color>", false);
                        player2 = plugin.Server.GetPlayers();
                        foreach (Player player3 in player2)
                        {
                            if (player3.TeamRole.Role == Smod2.API.Role.SCP_173)
                            {
                                player3.SetHealth(1);
                                player3.SetGodmode(true);
                            }

                        }
                        xhsnb = true;
                    }
                    if (sjsj2 == 9)
                    {
                        plugin.Server.Map.Broadcast(10, "<color=#BB1444>抱抱老爹！-事件：SCP-106随机传送到一名D级人员身边</color>", false);
                        player2 = plugin.Server.GetPlayers();
                        foreach (Player player3 in player2)
                        {
                            if (player3.TeamRole.Role == Smod2.API.Role.SCP_106)
                            {
                                scp106a = player3;
                                break;
                            }
                        }
                        foreach (Player player3 in player2)
                        {
                            if (player3.TeamRole.Team == Smod2.API.Team.CLASSD)
                            {
                                scp106a.Teleport(player3.GetPosition());
                                break;
                            }

                        }
                    }
                    if (sjsj2 == 10)
                    {
                        plugin.Server.Map.Broadcast(10, "<color=#BB1444>毕业学徒！-事件：SCP-49-2变为SCP049</color>", false);
                        foreach (Player player in plugin.Server.GetPlayers())
                        {
                            if (player.TeamRole.Role == Smod2.API.Role.SCP_049_2)
                            {
                                player.ChangeRole(Smod2.API.Role.SCP_049, true, false, false, false);
                                break;
                            }
                        }
                    }
                    if (sjsj2 == 11)
                    {
                        plugin.Server.Map.Broadcast(10, "<color=#BB1444>吊销执照！-事件：SCP-49变为SCP-049-2</color>", false);
                        foreach (Player player in plugin.Server.GetPlayers())
                        {
                            if (player.TeamRole.Role == Smod2.API.Role.SCP_049)
                            {
                                pos3 = player.GetPosition();
                                player.ChangeRole(Smod2.API.Role.SCP_049_2, true, false, false, false);
                                player.SetHealth(5000);
                                player.Teleport(pos3);
                                break;
                            }
                        }
                    }
                    if (sjsj2 == 12)
                    {
                        plugin.Server.Map.Broadcast(10, "<color=#BB1444>敬老院！-事件：多出来一个老头</color>", false);
                        foreach (Player player in plugin.Server.GetPlayers())
                        {
                            if (player.TeamRole.Role == Smod2.API.Role.SPECTATOR)
                            {
                                player.ChangeRole(Smod2.API.Role.SCP_106, true, true, false, false);
                                break;
                            }
                        }
                    }
                    if (sjsj2 == 13)
                    {
                        plugin.Server.Map.Broadcast(10, "<color=#BB1444>343的馈赠！-事件：一名玩家获得 电磁炮 手雷 黑卡</color>", false);
                        foreach (Player player in plugin.Server.GetPlayers())
                        {
                            if ((player.TeamRole.Team > Smod2.API.Team.SCP) && (player.TeamRole.Role != Smod2.API.Role.SPECTATOR))
                            {
                                player.GiveItem(Smod2.API.ItemType.KEYCARDO5);
                                player.GiveItem(Smod2.API.ItemType.MICROHID);
                                player.GiveItem(Smod2.API.ItemType.GRENADEFRAG);
                                break;
                            }
                        }
                    }
                    if (sjsj2 == 14)
                    {
                        plugin.Server.Map.Broadcast(10, "<color=#BB1444>DD们的复仇！-事件：全部D复活 并携带手枪</color>", false);
                        foreach (Player player in plugin.Server.GetPlayers())
                        {
                            if (player.TeamRole.Role == Smod2.API.Role.SPECTATOR)
                            {
                                player.ChangeRole(Smod2.API.Role.CLASSD, true, true, true, true);
                                player.GiveItem(Smod2.API.ItemType.GUNCOM15);
                            }
                        }
                        csm = true;
                    }
                    if (sjsj2 == 15)
                    {
                        plugin.Server.Map.Broadcast(10, "<color=#BB1444>洗澡真舒服！-事件：老头洗白变成96</color>", false);
                        foreach (Player player in plugin.Server.GetPlayers())
                        {
                            if (player.TeamRole.Role == Smod2.API.Role.SCP_106)
                            {
                                player.ChangeRole(Smod2.API.Role.SCP_096, true, false, false, true);
                            }
                        }
                    }
                    if (sjsj2 == 16)
                    {
                        plugin.Server.Map.Broadcast(10, "<color=#BB1444>泥巴真好玩！-事件：96变黑了</color>", false);
                        foreach (Player player in plugin.Server.GetPlayers())
                        {
                            if (player.TeamRole.Role == Smod2.API.Role.SCP_096)
                            {
                                player.ChangeRole(Smod2.API.Role.SCP_106, true, false, false, true);
                            }
                        }
                    }
                    if (sjsj2 == 17)
                    {
                        plugin.Server.Map.Broadcast(10, "<color=#BB1444>我练功发自真心！-事件：一名D级变成SCP079</color>", false);
                        foreach (Player player in plugin.Server.GetPlayers())
                        {
                            if (player.TeamRole.Role == Smod2.API.Role.CLASSD)
                            {
                                player.ChangeRole(Smod2.API.Role.SCP_079, true, false, false, true);
                                scpd79.Add(player);
                                break;
                            }
                        }
                    }
                    if (sjsj2 == 18)
                    {
                        plugin.Server.Map.Broadcast(10, "<color=#BB1444>基金会电闸炸了！-事件：天黑啦</color>", false);

                        Generator079.generators[0].RpcCustomOverchargeForOurBeautifulModCreators(10, false);
                        foreach (FlickerableLight flickerableLight in UnityEngine.Object.FindObjectsOfType<FlickerableLight>())
                        {
                            Scp079Interactable component = flickerableLight.GetComponent<Scp079Interactable>();
                            if (component == null || component.currentZonesAndRooms[0].currentZone == "HeavyRooms")
                            {
                                flickerableLight.EnableFlickering(10f);
                            }
                        }


                        foreach (Room room in PluginManager.Manager.Server.Map.Get079InteractionRooms(Scp079InteractionType.CAMERA))
                        {
                            if (room.ZoneType == ZoneType.LCZ || room.ZoneType == ZoneType.HCZ)
                            {
                                room.FlickerLights();
                            }
                        }
                    }
                    if (sjsj2 == 19)
                    {
                        plugin.Server.Map.Broadcast(10, "<color=#BB1444>杨永信网戒所！-事件：一名事件刷成079变回D级</color>", false);
                        foreach (Player player in scpd79)
                        {
                            if (player.TeamRole.Role == Smod2.API.Role.SCP_079)
                            {
                                player.ChangeRole(Smod2.API.Role.CLASSD, true, false, false, false);
                            }
                        }
                    }
                    if (sjsj2 == 20)
                    {
                        plugin.Server.Map.Broadcast(10, "<color=#BB1444>079帮助SCP！-事件：本回合SCP有5%几率开门</color>", false);
                        bscp79 = true;
                    }
                    if (sjsj2 == 21)
                    {
                        plugin.Server.Map.Broadcast(10, "<color=#BB1444>调皮的传送门！-事件：10秒内100%触发随机门</color>", false);
                        csm = true;
                    }
                    if (sjsj2 == 22)
                    {
                        plugin.Server.Map.Broadcast(10, "<color=#BB1444>乔碧萝的逆袭！-事件：乔碧萝恢复伤害</color>", false);
                        qblcq = null;
                        qblcq2 = false;
                        scpqbl = null;
                        scpqbl3 = null;
                        scpqblid = null;
                        scpqblid2 = 0;

                    }
                    if (sjsj2 == 23)
                    {
                        plugin.Server.Map.Broadcast(10, "<color=#BB1444>空投弹药！-事件：所有人子弹加200发</color>", false);
                        foreach (Player p in plugin.Server.GetPlayers())
                        {
                            p.SetAmmo(AmmoType.DROPPED_5, p.GetAmmo(AmmoType.DROPPED_5) + 200);
                            p.SetAmmo(AmmoType.DROPPED_5, p.GetAmmo(AmmoType.DROPPED_7) + 200);
                            p.SetAmmo(AmmoType.DROPPED_5, p.GetAmmo(AmmoType.DROPPED_9) + 200);
                        }
                    }
                    if (sjsj2 == 24)
                    {
                        plugin.Server.Map.Broadcast(10, "<color=#BB1444>肥宅快乐D！-事件：所有存活D级获得可乐</color>", false);
                        foreach (Player player in plugin.Server.GetPlayers())
                        {
                            if (player.TeamRole.Role == Smod2.API.Role.CLASSD)
                            {
                                player.GiveItem(Smod2.API.ItemType.SCP207);
                            }
                        }
                    }
                    if (sjsj2 == 25)
                    {
                        plugin.Server.Map.Broadcast(10, "<color=#BB1444>花生油！-事件：复活3个小花生但HP：只有30HP</color>", false);
                        foreach (Player player in plugin.Server.GetPlayers())
                        {
                            if (player.TeamRole.Role == Smod2.API.Role.SPECTATOR)
                            {
                                time3++;
                                player.ChangeRole(Smod2.API.Role.SCP_173, false, true, false, false);
                                player.SetHealth(30);
                                if (time3 >= 3)
                                {
                                    break;
                                }

                            }
                        }

                    }
                    if (sjsj2 == 26)
                    {
                        plugin.Server.Map.Broadcast(10, "<color=#BB1444>九尾狐你们的快递到了！-事件：九尾狐出生点刷两个电磁炮</color>", false);
                        plugin.Server.Map.SpawnItem(Smod2.API.ItemType.MICROHID, plugin.Server.Map.GetRandomSpawnPoint(Smod2.API.Role.NTF_COMMANDER), null);
                        plugin.Server.Map.SpawnItem(Smod2.API.ItemType.MICROHID, plugin.Server.Map.GetRandomSpawnPoint(Smod2.API.Role.NTF_COMMANDER), null);
                    }
                    if (sjsj2 == 27)
                    {
                        plugin.Server.Map.Broadcast(10, "<color=#BB1444>随机惊喜！-事件：随意地点刷一个黑卡</color>", false);
                        plugin.Server.Map.SpawnItem(Smod2.API.ItemType.KEYCARDO5, plugin.Server.Map.GetRandomSpawnPoint(Smod2.API.Role.CLASSD), null);

                    }
                    if (sjsj2 == 28)
                    {
                        plugin.Server.Map.Broadcast(10, "<color=#BB1444>年久失修！-事件：设施门有几率无法开启</color>", false);
                        bhsx = true;

                    }

                }
                if (updatatimer9 < DateTime.Now && (xhsnb == true))
                {
                    updatatimer9 = DateTime.Now.AddSeconds(1.0);
                    xhsnb2++;
                    if (xhsnb2 == 15)
                    {
                        xhsnb2 = 0;
                        foreach (Player player in player2)
                        {
                            if (player.TeamRole.Role == Smod2.API.Role.SCP_173)
                            {

                                player.SetHealth(4200);
                                player.SetGodmode(false);
                            }
                        }
                        xhsnb = false;
                    }
                }
                if (updatatimer2 < DateTime.Now)
                {
                    updatatimer2 = DateTime.Now.AddSeconds(5.0);
                    if (ylb1 == true)
                    {
                        Vector pos2 = ylb.GetPosition();
                        float num2 = pos2.x + 3;
                        float num3 = pos2.y + 3;
                        float num4 = pos2.z + 3;
                        float num5 = pos2.x - 3;
                        float num6 = pos2.y - 3;
                        float num7 = pos2.z - 3;
                        player10 = plugin.Server.GetPlayers();
                        foreach (Player player in player10)
                        {
                            if ((player.TeamRole.Team == Smod2.API.Team.NINETAILFOX) && (player.GetPosition().x <= num2) && (player.GetPosition().x >= num5) && (player.GetPosition().y <= num3) && (player.GetPosition().y >= num6) && ((player.GetPosition().z <= num4) && (player.GetPosition().z >= num7)))
                            {
                                player.AddHealth(1);
                                player.PersonalBroadcast(5, "你的伤口正在愈合", false);
                            }
                        }

                    }
                    if (lv == 1)
                    {
                        player6 = plugin.Server.GetPlayers();
                        foreach (Player player in player6)
                        {
                            if (player.TeamRole.Role == Smod2.API.Role.SCP_049)
                            {
                                player.AddHealth(5);
                            }
                        }
                    }
                    if (lv == 2)
                    {
                        player6 = plugin.Server.GetPlayers();
                        foreach (Player player in player6)
                        {
                            if (player.TeamRole.Role == Smod2.API.Role.SCP_049)
                            {
                                player.AddHealth(10);
                            }
                        }
                    }
                    if (lv == 3)
                    {
                        player6 = plugin.Server.GetPlayers();
                        foreach (Player player in player6)
                        {
                            if (player.TeamRole.Role == Smod2.API.Role.SCP_049)
                            {
                                player.AddHealth(15);
                            }
                        }
                    }

                }
                if (starttimer && (updatatimer < DateTime.Now))
                {
                    updatatimer = DateTime.Now.AddSeconds(1.0);
                    deadtimer++;
                    waring1++;
                    if (deadtimer == 120)
                    {
                        xywj = null;
                        xywjid = 0;
                    }
                    if (coldbc)
                    {
                        coldtime++;
                        if (coldtime == 80)
                        {
                            coldbc = false;
                            coldtime = 0;
                        }
                    }
                    if (coldtb)
                    {
                        coldtime2++;
                        if (coldtime2 == 300)
                        {
                            coldtb = false;
                            coldtime = 0;
                        }
                    }
                    if (投票是否发起)
                    {
                        if (DateTime.Now >= maxtime)
                        {
                            TheFlag();
                        }
                        else if ((同意 + 拒绝) == Count)
                        {
                            TheFlag();
                        }
                    }
                    if (waring1 == 0x488)
                    {
                        plugin.PluginManager.Server.Map.ClearBroadcasts();
                        plugin.PluginManager.Server.Map.Broadcast(15, "<color=#FF0000>警告:</color>核弹头将于10分钟后启动", false);
                        plugin.Info("核弹头将于10分钟后启动");
                    }
                    else if (waring1 == 0x636)
                    {
                        plugin.PluginManager.Server.Map.ClearBroadcasts();
                        plugin.PluginManager.Server.Map.Broadcast(15, "<color=#FF0000>警告:</color>核弹头将于3分钟后启动", false);
                        plugin.Info("核弹头将于3分钟后启动");
                    }
                    else if (waring1 == 0x6ae)
                    {
                        plugin.PluginManager.Server.Map.ClearBroadcasts();
                        plugin.PluginManager.Server.Map.Broadcast(15, "<color=#FF0000>警告:</color>Alpha协议已激活,核弹头将于30秒后启动请迅速撤离至避难区", false);
                        plugin.Info("核弹头将于30秒后启动");
                    }
                    if (deadtimer <= 30)
                    {
                        foreach (Player player in plugin.PluginManager.Server.GetPlayers(""))
                        {
                            if (player.TeamRole.Role == Smod2.API.Role.SPECTATOR)
                            {
                                int num = new Random().Next(1, 100);
                                if ((num >= 0) && (num <= 0x19))
                                {
                                    if ((s173 == 0) && (player.TeamRole.Role == Smod2.API.Role.SPECTATOR))
                                    {
                                        player.PersonalClearBroadcasts();
                                        player.ChangeRole(Smod2.API.Role.SCP_173, true, true, true, false);
                                        player.PersonalBroadcast(10, "<color=#FFC0CB>[消息]</color>\n由于你连接晚了\n已为你自动分配阵营", false);
                                        player.PersonalBroadcast(10, "<color=#FFC0CB>---[SCP173]---</color>\n<color=#00FFFF>你拥有一种特殊能力</color>\n受到除手炮以外的<color=#FFD700>枪械伤害只有3点</color>", false);
                                        player.PersonalBroadcast(10, "[<color=#FFA500>" + SCP173 + "</color> <color=#008000>" + SCP049 + "</color> <color=#FF8C00>" + SCP079 + "</color> <color=#808080>" + SCP096 + "</color> <color=#800000>" + SCP939_89 + "</color> <color=#CD5C5C>" + SCP939_53 + "</color> <color=#D2691E>" + SCP106 + "</color>]\n<color=#FF0000>本局您的队友</color>", false);
                                        s173 = 1;
                                        num = 0;
                                        plugin.Info("一名玩家延迟加入变为了: SCP173");
                                    }
                                    else if ((s096 == 0) && (player.TeamRole.Role == Smod2.API.Role.SPECTATOR))
                                    {
                                        player.PersonalClearBroadcasts();
                                        player.ChangeRole(Smod2.API.Role.SCP_096, true, true, true, false);
                                        player.PersonalBroadcast(10, "<color=#FFC0CB>[消息]</color>\n由于你连接晚了\n已为你自动分配阵营接受挨打", false);
                                        player.PersonalBroadcast(10, "[<color=#FFA500>" + SCP173 + "</color> <color=#008000>" + SCP049 + "</color> <color=#FF8C00>" + SCP079 + "</color> <color=#808080>" + SCP096 + "</color> <color=#800000>" + SCP939_89 + "</color> <color=#CD5C5C>" + SCP939_53 + "</color> <color=#D2691E>" + SCP106 + "</color>]\n<color=#FF0000>本局您的队友</color>", false);
                                        s096 = 1;
                                        num = 0;
                                        plugin.Info("一名玩家延迟加入变为了: SCP096");
                                    }
                                    else if ((s106 == 0) && (player.TeamRole.Role == Smod2.API.Role.SPECTATOR))
                                    {
                                        player.PersonalClearBroadcasts();
                                        player.ChangeRole(Smod2.API.Role.SCP_106, true, true, true, false);
                                        player.PersonalBroadcast(10, "<color=#FFC0CB>[消息]</color>\n由于你连接晚了\n已为你自动分配阵营接受挨打", false);
                                        player.PersonalBroadcast(10, "[<color=#FFA500>" + SCP173 + "</color> <color=#008000>" + SCP049 + "</color> <color=#FF8C00>" + SCP079 + "</color> <color=#808080>" + SCP096 + "</color> <color=#800000>" + SCP939_89 + "</color> <color=#CD5C5C>" + SCP939_53 + "</color> <color=#D2691E>" + SCP106 + "</color>]\n<color=#FF0000>本局您的队友</color>", false);
                                        s106 = 1;
                                        num = 0;
                                        plugin.Info("一名玩家延迟加入变为了: SCP106");
                                    }
                                    else if ((s939_53 == 0) && (player.TeamRole.Role == Smod2.API.Role.SPECTATOR))
                                    {
                                        player.PersonalClearBroadcasts();
                                        player.ChangeRole(Smod2.API.Role.SCP_939_53, true, true, true, false);
                                        player.PersonalBroadcast(10, "<color=#FFC0CB>[消息]</color>\n由于你连接晚了\n已为你自动分配阵营接受挨打", false);
                                        player.PersonalBroadcast(10, "[<color=#FFA500>" + SCP173 + "</color> <color=#008000>" + SCP049 + "</color> <color=#FF8C00>" + SCP079 + "</color> <color=#808080>" + SCP096 + "</color> <color=#800000>" + SCP939_89 + "</color> <color=#CD5C5C>" + SCP939_53 + "</color> <color=#D2691E>" + SCP106 + "</color>]\n<color=#FF0000>本局您的队友</color>", false);
                                        s939_53 = 1;
                                        num = 0;
                                        plugin.Info("一名玩家延迟加入变为了: SCP939_53");
                                    }
                                    else if ((s939_89 == 0) && (player.TeamRole.Role == Smod2.API.Role.SPECTATOR))
                                    {
                                        player.PersonalClearBroadcasts();
                                        player.ChangeRole(Smod2.API.Role.SCP_939_89, true, true, true, false);
                                        player.PersonalBroadcast(10, "<color=#FFC0CB>[消息]</color>\n由于你连接晚了\n已为你自动分配阵营接受挨打", false);
                                        player.PersonalBroadcast(10, "[<color=#FFA500>" + SCP173 + "</color> <color=#008000>" + SCP049 + "</color> <color=#FF8C00>" + SCP079 + "</color> <color=#808080>" + SCP096 + "</color> <color=#800000>" + SCP939_89 + "</color> <color=#CD5C5C>" + SCP939_53 + "</color> <color=#D2691E>" + SCP106 + "</color>]\n<color=#FF0000>本局您的队友</color>", false);
                                        s939_89 = 1;
                                        num = 0;
                                        plugin.Info("一名玩家延迟加入变为了: SCP939_89");
                                    }
                                    else if ((s049 == 0) && (player.TeamRole.Role == Smod2.API.Role.SPECTATOR))
                                    {
                                        player.PersonalClearBroadcasts();
                                        player.ChangeRole(Smod2.API.Role.SCP_049, true, true, true, false);
                                        player.PersonalBroadcast(10, "<color=#FFC0CB>[消息]</color>\n由于你连接晚了\n已为你自动分配阵营接受挨打", false);
                                        player.PersonalBroadcast(10, "[<color=#FFA500>" + SCP173 + "</color> <color=#008000>" + SCP049 + "</color> <color=#FF8C00>" + SCP079 + "</color> <color=#808080>" + SCP096 + "</color> <color=#800000>" + SCP939_89 + "</color> <color=#CD5C5C>" + SCP939_53 + "</color> <color=#D2691E>" + SCP106 + "</color>]\n<color=#FF0000>本局您的队友</color>", false);
                                        s049 = 1;
                                        num = 0;
                                        plugin.Info("一名玩家延迟加入变为了: SCP049");
                                    }
                                    else
                                    {
                                        player.ChangeRole(Smod2.API.Role.CLASSD, true, true, true, false);
                                        player.PersonalBroadcast(10, "<color=#FFC0CB>[消息]</color>\n由于你连接晚了\n已为你自动分配阵营接受挨打", false);
                                        player.PersonalBroadcast(10, "[<color=#FFA500>" + SCP173 + "</color> <color=#008000>" + SCP049 + "</color> <color=#FF8C00>" + SCP079 + "</color> <color=#808080>" + SCP096 + "</color> <color=#800000>" + SCP939_89 + "</color> <color=#CD5C5C>" + SCP939_53 + "</color> <color=#D2691E>" + SCP106 + "</color>]\n<color=#FF0000>检测到以上SCP突破收容</color>", false);
                                        num = 0;
                                        plugin.Info("一名玩家延迟加入变为了: CLASSD");
                                    }
                                }
                                else if ((num >= 0x33) && (num <= 100))
                                {
                                    player.ChangeRole(Smod2.API.Role.CLASSD, true, true, true, false);
                                    player.PersonalBroadcast(10, "<color=#FFC0CB>[消息]</color>\n由于你连接晚了\n已为你自动分配阵营接受挨打", false);
                                    player.PersonalBroadcast(10, "[<color=#FFA500>" + SCP173 + "</color> <color=#008000>" + SCP049 + "</color> <color=#FF8C00>" + SCP079 + "</color> <color=#808080>" + SCP096 + "</color> <color=#800000>" + SCP939_89 + "</color> <color=#CD5C5C>" + SCP939_53 + "</color> <color=#D2691E>" + SCP106 + "</color>]\n<color=#FF0000>检测到以上SCP突破收容</color>", false);
                                    num = 0;
                                    plugin.Info("一名玩家延迟加入变为了: CLASSD");
                                }
                                else if ((num >= 0x1a) && (num <= 50))
                                {
                                    player.ChangeRole(Smod2.API.Role.FACILITY_GUARD, true, true, true, false);
                                    player.PersonalBroadcast(10, "<color=#FFC0CB>[消息]</color>\n由于你连接晚了\n已为你自动分配阵营接受挨打", false);
                                    player.PersonalBroadcast(10, "<color=#FFC0CB>[设施保安]</color>\n<color=#00FFFF>你的任务是捆绑救出D级科学家杀光SCP与混沌</color>\n你可以前往<color=#FFD700>逃脱点</color>获得物资", false);
                                    player.PersonalBroadcast(10, "[<color=#FFA500>" + SCP173 + "</color> <color=#008000>" + SCP049 + "</color> <color=#FF8C00>" + SCP079 + "</color> <color=#808080>" + SCP096 + "</color> <color=#800000>" + SCP939_89 + "</color> <color=#CD5C5C>" + SCP939_53 + "</color> <color=#D2691E>" + SCP106 + "</color>]\n<color=#FF0000>检测到以上SCP突破收容</color>", false);
                                    num = 0;
                                    plugin.Info("一名玩家延迟加入变为了: 保安");
                                }
                                else
                                {
                                    player.ChangeRole(Smod2.API.Role.CLASSD, true, true, true, false);
                                    player.PersonalBroadcast(10, "<color=#FFC0CB>[消息]</color>\n由于你连接晚了\n已为你自动分配阵营接受挨打", false);
                                    player.PersonalBroadcast(10, "[<color=#FFA500>" + SCP173 + "</color> <color=#008000>" + SCP049 + "</color> <color=#FF8C00>" + SCP079 + "</color> <color=#808080>" + SCP096 + "</color> <color=#800000>" + SCP939_89 + "</color> <color=#CD5C5C>" + SCP939_53 + "</color> <color=#D2691E>" + SCP106 + "</color>]\n<color=#FF0000>检测到以上SCP突破收容</color>", false);
                                    num = 0;
                                    plugin.Info("一名玩家延迟加入变为了: CLASSD");
                                }
                                break;
                            }
                        }
                    }
                }
                if ((DateTime.Now >= time233) && (gd == true))
                {
                    time233 = DateTime.Now.AddSeconds(8.0);
                    foreach (Room room in PluginManager.Manager.Server.Map.Get079InteractionRooms(Scp079InteractionType.CAMERA))
                    {
                        if (room.ZoneType == ZoneType.LCZ || room.ZoneType == ZoneType.HCZ)
                        {
                            room.FlickerLights();
                        }
                    }
                }
            }

            public void TheFlag()
            {
                if ((plugin.Server.GetPlayers("").Count / 2) <= (同意 + 拒绝))
                {
                    if (同意 > 拒绝)
                    {
                        plugin.Server.Map.ClearBroadcasts();
                        plugin.Server.Map.Broadcast(10, "[<color=red>投票</color>]\n系统已成功踢出玩家:<color=red>" + ban.Name + "</color>", false);
                        ban.Ban(60);
                        TheReset();
                    }
                    else if (同意 < 拒绝)
                    {
                        plugin.Server.Map.ClearBroadcasts();
                        plugin.Server.Map.Broadcast(10, "[<color=red>投票</color>]\n踢出玩家失败,理由:同意票数不足", false);
                        TheReset();
                    }
                    else
                    {
                        plugin.Server.Map.ClearBroadcasts();
                        plugin.Server.Map.Broadcast(10, "[<color=red>投票</color>]\n踢出玩家失败,理由:平票", false);
                        TheReset();
                    }
                }
                else
                {
                    plugin.Server.Map.ClearBroadcasts();
                    plugin.Server.Map.Broadcast(10, "[<color=red>投票</color>]踢出玩家失败,理由<color=red>投票玩家不足</color>\n注:投票玩家需要大于当前一半玩家", false);
                    TheReset();
                }
            }
            public void OnMedkitUse(PlayerMedkitUseEvent ev)
            {
                if (ev.Player.UserId == jklid)
                {
                    ev.RecoverHealth = 0;
                    ev.Player.AddHealth(1000);
                    jklid = null;
                }
            }
            public void TheReset()
            {
                同意 = 0;
                拒绝 = 0;
                投票是否发起 = false;
                理由 = 0;
                理由文本 = null;
                当前是否在投票 = false;
                players = new Dictionary<int, bool>();
                Count = 0;
                issuperTrue = 0;
                issuperFalse = 0;
            }
            
            public void OnPlayerPickupItem(PlayerPickupItemEvent ev)
            {


                if (ev.Item.ItemType == Smod2.API.ItemType.COIN)
                {
                    int num = new Random().Next(1, 12);
                    switch (num)
                    {
                        case 1:
                            ev.ChangeTo = Smod2.API.ItemType.COIN;
                            ev.Player.PersonalBroadcast(5, "<color=#FF1493>你的硬币变成了</color>\n[硬币]", false);
                            plugin.Info("硬币变为了硬币| 玩家:" + ev.Player.Name);
                            goto awsl;

                        case 2:
                            ev.ChangeTo = Smod2.API.ItemType.MICROHID;
                            ev.Player.PersonalBroadcast(5, "<color=#FF1493>你的硬币变成了</color>\n[电磁炮·有电]", false);
                            plugin.Info("硬币变为了电磁炮| 玩家:" + ev.Player.Name);
                            goto awsl;

                        case 3:
                            ev.ChangeTo = Smod2.API.ItemType.GUNE11SR;
                            ev.Player.PersonalBroadcast(5, "<color=#FF1493>你的硬币变成了</color>\n[九尾步枪]", false);
                            plugin.Info("硬币变为了九尾步枪| 玩家:" + ev.Player.Name);
                            goto awsl;

                        case 4:
                            ev.ChangeTo = Smod2.API.ItemType.KEYCARDCHAOSINSURGENCY;
                            ev.Player.PersonalBroadcast(5, "<color=#FF1493>你的硬币变成了</color>\n[收容工程师卡]", false);
                            plugin.Info("硬币变为了收容工程师卡| 玩家:" + ev.Player.Name);
                            goto awsl;
                    }
                    if (num == 5)
                    {
                        ev.ChangeTo = Smod2.API.ItemType.GRENADEFRAG;
                        ev.Player.PersonalBroadcast(5, "<color=#FF1493>你的硬币变成了</color>\n[手雷]", false);
                        plugin.Info("硬币变为了手雷| 玩家:" + ev.Player.Name);
                    }
                    if (num == 6)
                    {
                        ev.ChangeTo = Smod2.API.ItemType.AMMO556;
                        ev.Player.PersonalBroadcast(5, "<color=#FF1493>你的硬币变成了</color>\n[5.56子弹]", false);
                    }
                    if (num == 7)
                    {
                        ev.ChangeTo = Smod2.API.ItemType.GUNLOGICER;
                        ev.Player.PersonalBroadcast(5, "<color=#FF1493>你的硬币变成了</color>\n[大菠萝]", false);
                    }
                    if (num == 8)
                    {
                        ev.ChangeTo = Smod2.API.ItemType.KEYCARDGUARD;
                        ev.Player.PersonalBroadcast(5, "<color=#FF1493>你的硬币变成了</color>\n[保安卡]", false);
                    }
                    if (num == 9)
                    {
                        ev.ChangeTo = Smod2.API.ItemType.RADIO;
                        ev.Player.PersonalBroadcast(5, "<color=#FF1493>你的硬币变成了</color>\n[对讲机有电]", false);
                    }
                    if (num == 10)
                    {
                        ev.ChangeTo = Smod2.API.ItemType.KEYCARDSCIENTIST;
                        ev.Player.PersonalBroadcast(5, "<color=#FF1493>你的硬币变成了</color>\n[科学家卡]", false);
                    }
                    if (num == 11)
                    {
                        ev.ChangeTo = Smod2.API.ItemType.SCP500;
                        ev.Player.PersonalBroadcast(5, "<color=#FF1493>你的硬币变成了</color>\n[科学家卡]", false);
                    }
                    else
                    {
                        ev.ChangeTo = Smod2.API.ItemType.FLASHLIGHT;
                        ev.Player.PersonalBroadcast(5, "<color=#FF1493>你的硬币变成了</color>\n[手电筒]", false);
                        plugin.Info("硬币变为了手电筒| 玩家:" + ev.Player.Name);
                    }
                }
                awsl:
                if (ev.Player.PlayerId == scp457id)
                {
                    ev.Item.Drop();
                    ev.Item.Remove();
                }
                if ((a127c == false) && (ev.Item.ItemType == Smod2.API.ItemType.GUNUSP))
                {
                    a127c = true;
                  
                    a127 = true;
                    ev.Player.PersonalBroadcast(5, "<color=lime>你捡起了</color>[<color=red>SCP-127</color>]\n<color=lime>当你扔掉或者死亡都SCP-127都会消失</color>", false);
                    plugin.Server.Map.Broadcast(10, "SCP127力量已经出现", false);
                }
                Vector pos2 = ev.Player.GetPosition();
                if ((pos2.y > -735) && (pos2.y < -730))
                {

                    if (jkl == false)
                    {
                        jkl = true;
                        jklid = ev.Player.UserId;
                        ev.Player.PersonalBroadcast(5, "你捡起了SCP-金坷垃使用后恢复1000点血", false);
                        plugin.Server.Map.Broadcast(5, "SCP-金坷垃被捡起了", false);

                    }
                }


                if (Dio2.Contains(ev.Player.UserId))
                {
                    ev.Item.Remove();
                }



            public void OnWaitingForPlayers(WaitingForPlayersEvent ev)
            {
                pmd = new Thread(PMD);
                pmd.Start();
            }
            public void CD()
            {
                Dio.AddHealth(120);
                Thread.Sleep(12000);
                sjtz1 = false;
                cd.Abort();
            }
            public void PMD()
            {
                qwq1:
                if (roundstart == false)
                {
                    for (int i = 0; i < player233.Count; i++)
                    {

                        if (roundstart == false)
                        {


                            player233[i].SetRank("red", "称号预留位置", null);
                            if (player233[i].UserId == "76561198366416373@steam")
                            {
                                player233[i].SetRank("lime", "BILIBILI_我在愣神", null);
                            }

                            if (player233[i].UserId == "76561198361793702@steam")
                            {
                                player233[i].SetRank("green", "爱是一道光如此美妙", null);
                            }
                            if (player233[i].UserId == "76561198977855934@steam")
                            {
                                player233[i].SetRank("pink", "49夫人", null);
                            }
                            if (player233[i].UserId == "76561198284755079@steam")
                            {
                                player233[i].SetRank("red", "一只垃圾鱼", null);
                            }
                            if (player233[i].UserId == "76561198841949627@steam")
                            {
                                player233[i].SetRank("lime", "日常快乐水的杨教授", null);
                            }
                            if (player233[i].UserId == "76561198425823494@steam")
                            {
                                player233[i].SetRank("red", "斯大林", null);
                            }
                            if (player233[i].UserId == "76561198388299994@steam")
                            {
                                player233[i].SetRank("crimson", "BILIBILI_z_z骚糖", null);
                            }
                            if (player233[i].UserId == "76561197961446054@steam")
                            {
                                player233[i].SetRank("crimson", "BILIBILI_一个根大黄瓜", null);
                            }
                            if (player233[i].UserId == "76561198190686028@steam")
                            {
                                player233[i].SetRank("cyan", "BILIBILI_手残至尊", null);
                            }
                            if (player233[i].UserId == "76561198825310613@steam")
                            {
                                player233[i].SetRank("crimson", "触手TV_东星.波少", null);
                            }
                            if (player233[i].UserId == "76561198384476113@steam")
                            {
                                player233[i].SetRank("lime", "VIP1", null);
                            }
                            if (player233[i].UserId == "76561198381947239@steam")
                            {
                                player233[i].SetRank("lime", "BILIBILI_我是吴语", null);
                            }
                            if (player233[i].UserId == "76561198816705835@steam")
                            {
                                player233[i].SetRank("silvery", "孤独一生", null);
                            }
                            if (player233[i].UserId == "76561198149835838@steam")
                            {
                                player233[i].SetRank("aqua", "SCP079的正宫夫人丨最大电力：79520丨电力恢复：0AP/s丨专业迫害106", null);
                            }
                            if (player233[i].UserId == "76561198133773112@steam")
                            {
                                player233[i].SetRank("lime", "BILIBILI_优乐美", null);
                            }
                            if (player233[i].UserId == "76561198335932913@steam")
                            {
                                player233[i].SetRank("lime", "招财喵~", null);
                            }
                            if (player233[i].UserId == "76561198371077590@steam")
                            {
                                player233[i].SetRank("lime", "VIP1", null);
                            }
                            if (player233[i].UserId == "76561198979881230@steam")
                            {
                                player233[i].SetRank("aqua", "本群常驻UP主", null);
                            }
                            if (player233[i].UserId == "76561198401019684@steam")
                            {
                                player233[i].SetRank("lime", "不是小学生是少年音小姐姐", null);
                            }
                            if (player233[i].UserId == "76561198145812844@steam")
                            {
                                player233[i].SetRank("green", "老阴比", null);
                            }
                            if (player233[i].UserId == "76561198359791579@steam")
                            {
                                player233[i].SetRank("yellow", "D-17396", null);
                            }
                            if (player233[i].UserId == "76561198389200613@steam")
                            {
                                player233[i].SetRank("aqua", "非常无聊的大白", null);
                            }
                        }

                    }
                    Thread.Sleep(5000);
                    for (int i = 0; i < player233.Count; i++)
                    {
                        if (roundstart == false)
                        {
                            player233[i].SetRank("red", "欢迎加入这个破服务器:278704578 | 请看标题", null);
                            if (player233[i].UserId == "76561198366416373@steam")
                            {
                                player233[i].SetRank("lime", "BILIBILI_我在愣神", null);
                            }
                            if (player233[i].UserId == "76561198977855934")
                            {
                                player233[i].SetRank("pink", "49夫人", null);
                            }
                            if (player233[i].UserId == "76561198361793702@steam")
                            {
                                player233[i].SetRank("green", "爱是一道光如此美妙", null);
                            }
                            if (player233[i].UserId == "76561198284755079@steam")
                            {
                                player233[i].SetRank("red", "一只垃圾鱼", null);
                            }
                            if (player233[i].UserId == "76561198841949627@steam")
                            {
                                player233[i].SetRank("lime", "日常快乐水的杨教授", null);
                            }
                            if (player233[i].UserId == "76561198840690652@steam")
                            {
                                player233[i].SetRank("red", "本服NPC", null);
                            }
                            if (player233[i].UserId == "76561198831124013@steam")
                            {
                                player233[i].SetRank("pink", "援交少女", null);
                            }
                            if (player233[i].UserId == "76561198388299994@steam")
                            {
                                player233[i].SetRank("crimson", "BILIBILI_z_z骚糖", null);
                            }
                            if (player233[i].UserId == "76561197961446054@steam")
                            {
                                player233[i].SetRank("crimson", "BILIBILI_一个根大黄瓜", null);
                            }
                            if (player233[i].UserId == "76561198190686028@steam")
                            {
                                player233[i].SetRank("cyan", "BILIBILI_手残至尊", null);
                            }
                            if (player233[i].UserId == "76561198825310613@steam")
                            {
                                player233[i].SetRank("crimson", "触手TV_东星.波少", null);
                            }
                            if (player233[i].UserId == "76561198384476113@steam")
                            {
                                player233[i].SetRank("lime", "VIP1", null);
                            }
                            if (player233[i].UserId == "76561198381947239@steam")
                            {
                                player233[i].SetRank("pink", "BILIBILI_我是吴语", null);
                            }
                            if (player233[i].UserId == "76561198816705835@steam")
                            {
                                player233[i].SetRank("silvery", "孤独一生", null);
                            }
                            if (player233[i].UserId == "76561198841744752@steam")
                            {
                                player233[i].SetRank("lime", "VIP1", null);
                            }
                            if (player233[i].UserId == "76561198149835838@steam")
                            {
                                player233[i].SetRank("aqua", "SCP079的正宫夫人丨最大电力：79520丨电力恢复：0AP/s丨专业迫害106", null);
                            }
                            if (player233[i].UserId == "76561198133773112@steam")
                            {
                                player233[i].SetRank("lime", "BILIBILI_优乐美", null);
                            }
                            if (player233[i].UserId == "76561198335932913@steam")
                            {
                                player233[i].SetRank("lime", "招财喵~", null);
                            }
                            if (player233[i].UserId == "76561198425823494@steam")
                            {
                                player233[i].SetRank("red", "斯大林", null);
                            }
                            if (player233[i].UserId == "76561198371077590@steam")
                            {
                                player233[i].SetRank("lime", "VIP1", null);
                            }
                            if (player233[i].UserId == "76561198812450849@steam")
                            {
                                player233[i].SetRank("lime", "BILIBILI_gou_mr", null);
                            }
                            if (player233[i].UserId == "76561198979881230@steam")
                            {
                                player233[i].SetRank("aqua", "本群常驻UP主", null);
                            }
                            if (player233[i].UserId == "76561198191585303@steam")
                            {
                                player233[i].SetRank("red", "美少女", null);
                            }
                            if (player233[i].UserId == "76561198401019684@steam")
                            {
                                player233[i].SetRank("lime", "不是小学生是少年音小姐姐", null);
                            }
                            if (player233[i].UserId == "76561198145812844@steam")
                            {
                                player233[i].SetRank("green", "老阴比", null);
                            }
                            if (player233[i].UserId == "76561198359791579@steam")
                            {
                                player233[i].SetRank("yellow", "D-17396", null);
                            }
                            if (player233[i].UserId == "76561198389200613@steam")
                            {
                                player233[i].SetRank("aqua", "非常无聊的大白", null);
                            }
                        }
                    }
                    plugin.Server.PlayerListTitle = "<color=#FFFF00>QQ群:278704578</color>|<color=#FF3300>一定要加群啊QAQ</color>|<color=#00FF00>规则自由</color>";
                    Thread.Sleep(5000);
                    for (int i = 0; i < player233.Count; i++)
                    {
                        if (roundstart == false)
                        {
                            if (player233[i].UserId == "76561198366416373@steam")
                            {
                                player233[i].SetRank("lime", "BILIBILI_我在愣神", null);
                            }
                            if (player233[i].UserId == "76561198361793702@steam")
                            {
                                player233[i].SetRank("green", "爱是一道光如此美妙", null);
                            }
                            player233[i].SetRank("yellow", "欢迎加入这个破服务器:278704578 | 请看标题", null);
                            if (player233[i].UserId == "76561198977855934@steam")
                            {
                                player233[i].SetRank("pink", "49夫人", null);
                            }
                            if (player233[i].UserId == "76561198284755079@steam")
                            {
                                player233[i].SetRank("yellow", "一只垃圾鱼", null);
                            }
                            if (player233[i].UserId == "76561198840690652@steam")
                            {
                                player233[i].SetRank("red", "本服NPC", null);
                            }
                            if (player233[i].UserId == "76561198841949627@steam")
                            {
                                player233[i].SetRank("lime", "日常快乐水的杨教授", null);
                            }
                            if (player233[i].UserId == "76561198831124013@steam")
                            {
                                player233[i].SetRank("pink", "援交少女", null);
                            }
                            if (player233[i].UserId == "76561198388299994@steam")
                            {
                                player233[i].SetRank("crimson", "BILIBILI_z_z骚糖", null);
                            }
                            if (player233[i].UserId == "76561197961446054@steam")
                            {
                                player233[i].SetRank("crimson", "BILIBILI_一个根大黄瓜", null);
                            }
                            if (player233[i].UserId == "76561198190686028@steam")
                            {
                                player233[i].SetRank("cyan", "BILIBILI_手残至尊", null);
                            }
                            if (player233[i].UserId == "76561198825310613@steam")
                            {
                                player233[i].SetRank("crimson", "触手TV_东星.波少", null);
                            }
                            if (player233[i].UserId == "76561198384476113@steam")
                            {
                                player233[i].SetRank("lime", "VIP1", null);
                            }
                            if (player233[i].UserId == "76561198381947239@steam")
                            {
                                player233[i].SetRank("pink", "BILIBILI_我是吴语", null);
                            }
                            if (player233[i].UserId == "76561198816705835@steam")
                            {
                                player233[i].SetRank("silvery", "孤独一生", null);
                            }
                            if (player233[i].UserId == "76561198841744752@steam")
                            {
                                player233[i].SetRank("lime", "VIP1", null);
                            }
                            if (player233[i].UserId == "76561198149835838@steam")
                            {
                                player233[i].SetRank("aqua", "SCP079的正宫夫人丨最大电力：79520丨电力恢复：0AP/s丨专业迫害106", null);
                            }
                            if (player233[i].UserId == "76561198133773112@steam")
                            {
                                player233[i].SetRank("lime", "BILIBILI_优乐美", null);
                            }
                            if (player233[i].UserId == "76561198335932913@steam")
                            {
                                player233[i].SetRank("lime", "招财喵~", null);
                            }
                            if (player233[i].UserId == "76561198425823494@steam")
                            {
                                player233[i].SetRank("red", "斯大林", null);
                            }
                            if (player233[i].UserId == "76561198371077590@steam")
                            {
                                player233[i].SetRank("lime", "VIP1", null);
                            }
                            if (player233[i].UserId == "76561198812450849@steam")
                            {
                                player233[i].SetRank("lime", "BILIBILI_gou_mr", null);
                            }
                            if (player233[i].UserId == "76561198979881230@steam")
                            {
                                player233[i].SetRank("aqua", "本群常驻UP主", null);
                            }
                            if (player233[i].UserId == "76561198191585303@steam")
                            {
                                player233[i].SetRank("red", "美少女", null);
                            }
                            if (player233[i].UserId == "76561198401019684@steam")
                            {
                                player233[i].SetRank("lime", "不是小学生是少年音小姐姐", null);
                            }
                            if (player233[i].UserId == "76561198145812844@steam")
                            {
                                player233[i].SetRank("green", "老阴比", null);
                            }
                            if (player233[i].UserId == "76561198359791579@steam")
                            {
                                player233[i].SetRank("yellow", "D-17396", null);
                            }
                            if (player233[i].UserId == "76561198389200613@steam")
                            {
                                player233[i].SetRank("aqua", "非常无聊的大白", null);
                            }
                        }


                    }
                    plugin.Server.PlayerListTitle = "<color=#FFFF00>QQ群:278704578</color>|<color=#FF3300>不加群我就生气了╭(╯^╰)╮</color>|<color=#00FF00>规则自由</color>";
                    Thread.Sleep(5000);
                    for (int i = 0; i < player233.Count; i++)
                    {
                        if (roundstart == false)
                        {

                            player233[i].SetRank("green", "欢迎加入这个破服务器:278704578 | 请看标题", null);
                            if (player233[i].UserId == "76561198366416373@steam")
                            {
                                player233[i].SetRank("lime", "BILIBILI_我在愣神", null);
                            }
                            if (player233[i].UserId == "76561198361793702@steam")
                            {
                                player233[i].SetRank("green", "爱是一道光如此美妙", null);
                            }
                            if (player233[i].UserId == "76561198977855934@steam")
                            {
                                player233[i].SetRank("pink", "49夫人", null);
                            }
                            if (player233[i].UserId == "76561198284755079@steam")
                            {
                                player233[i].SetRank("green", "一只垃圾鱼", null);
                            }
                            if (player233[i].UserId == "76561198840690652@steam")
                            {
                                player233[i].SetRank("red", "本服NPC", null);
                            }
                            if (player233[i].UserId == "76561198831124013@steam")
                            {
                                player233[i].SetRank("pink", "援交少女", null);
                            }
                            if (player233[i].UserId == "76561198841949627@steam")
                            {
                                player233[i].SetRank("lime", "日常快乐水的杨教授", null);
                            }
                            if (player233[i].UserId == "76561198388299994@steam")
                            {
                                player233[i].SetRank("crimson", "BILIBILI_z_z骚糖", null);
                            }
                            if (player233[i].UserId == "76561197961446054")
                            {
                                player233[i].SetRank("crimson", "BILIBILI_一个根大黄瓜", null);
                            }
                            if (player233[i].UserId == "76561198190686028@steam")
                            {
                                player233[i].SetRank("cyan", "BILIBILI_手残至尊", null);
                            }
                            if (player233[i].UserId == "76561198825310613@steam")
                            {
                                player233[i].SetRank("crimson", "触手TV_东星.波少", null);
                            }
                            if (player233[i].UserId == "76561198384476113@steam")
                            {
                                player233[i].SetRank("lime", "VIP1", null);
                            }
                            if (player233[i].UserId == "76561198381947239@steam")
                            {
                                player233[i].SetRank("pink", "BILIBILI_我是吴语", null);
                            }
                            if (player233[i].UserId == "76561198816705835@steam")
                            {
                                player233[i].SetRank("silvery", "孤独一生", null);
                            }
                            if (player233[i].UserId == "76561198841744752@steam")
                            {
                                player233[i].SetRank("lime", "VIP1", null);
                            }
                            if (player233[i].UserId == "76561198149835838@steam")
                            {
                                player233[i].SetRank("aqua", "SCP079的正宫夫人丨最大电力：79520丨电力恢复：0AP/s丨专业迫害106", null);
                            }
                            if (player233[i].UserId == "76561198133773112@steam")
                            {
                                player233[i].SetRank("lime", "BILIBILI_优乐美", null);
                            }
                            if (player233[i].UserId == "76561198335932913@steam")
                            {
                                player233[i].SetRank("lime", "招财喵~", null);
                            }
                            if (player233[i].UserId == "76561198425823494@steam")
                            {
                                player233[i].SetRank("red", "斯大林", null);
                            }
                            if (player233[i].UserId == "76561198371077590@steam")
                            {
                                player233[i].SetRank("lime", "VIP1", null);
                            }
                            if (player233[i].UserId == "76561198812450849@steam")
                            {
                                player233[i].SetRank("lime", "BILIBILI_gou_mr", null);
                            }
                            if (player233[i].UserId == "76561198979881230@steam")
                            {
                                player233[i].SetRank("aqua", "本群常驻UP主", null);
                            }
                            if (player233[i].UserId == "76561198191585303@steam")
                            {
                                player233[i].SetRank("red", "美少女", null);
                            }
                            if (player233[i].UserId == "76561198401019684@steam")
                            {
                                player233[i].SetRank("lime", "不是小学生是少年音小姐姐", null);
                            }
                            if (player233[i].UserId == "76561198145812844@steam")
                            {
                                player233[i].SetRank("green", "老阴比", null);
                            }
                            if (player233[i].UserId == "76561198359791579@steam")
                            {
                                player233[i].SetRank("yellow", "D-17396", null);
                            }
                            if (player233[i].UserId == "76561198389200613@steam")
                            {
                                player233[i].SetRank("yellow", "非常无聊的大白", null);
                            }
                        }
                    }
                    Thread.Sleep(5000);
                    plugin.Server.PlayerListTitle = "<color=#FFFF00>QQ群:278704578</color>|<color=#FF3300>反正都来了QAQ</color>|<color=#00FF00>规则自由</color>";
                    for (int i = 0; i < player233.Count; i++)
                    {
                        if (roundstart == false)
                        {
                            player233[i].SetRank("pink", "欢迎加入这个破服务器:278704578 | 请看标题", null);
                            if (player233[i].UserId == "76561198366416373@steam")
                            {
                                player233[i].SetRank("lime", "BILIBILI_我在愣神", null);
                            }
                            if (player233[i].UserId == "76561198361793702@steam")
                            {
                                player233[i].SetRank("green", "爱是一道光如此美妙如此美妙", null);
                            }
                            if (player233[i].UserId == "76561198977855934@steam")
                            {
                                player233[i].SetRank("pink", "49夫人", null);
                            }
                            if (player233[i].UserId == "76561198284755079@steam")
                            {
                                player233[i].SetRank("pink", "一只垃圾鱼", null);
                            }
                            if (player233[i].UserId == "76561198840690652@steam")
                            {
                                player233[i].SetRank("red", "本服NPC", null);
                            }
                            if (player233[i].UserId == "76561198841949627@steam")
                            {
                                player233[i].SetRank("lime", "日常快乐水的杨教授", null);
                            }
                            if (player233[i].UserId == "76561198831124013@steam")
                            {
                                player233[i].SetRank("pink", "援交少女", null);
                            }
                            if (player233[i].UserId == "76561198388299994@steam")
                            {
                                player233[i].SetRank("crimson", "BILIBILI_z_z骚糖", null);
                            }
                            if (player233[i].UserId == "76561197961446054@steam")
                            {
                                player233[i].SetRank("crimson", "BILIBILI_一个根大黄瓜", null);
                            }
                            if (player233[i].UserId == "76561198190686028@steam")
                            {
                                player233[i].SetRank("cyan", "BILIBILI_手残至尊", null);
                            }
                            if (player233[i].UserId == "76561198825310613@steam")
                            {
                                player233[i].SetRank("crimson", "触手TV_东星.波少", null);
                            }
                            if (player233[i].UserId == "76561198384476113@steam")
                            {
                                player233[i].SetRank("lime", "VIP1", null);
                            }
                            if (player233[i].UserId == "76561198381947239@steam")
                            {
                                player233[i].SetRank("pink", "BILIBILI_我是吴语", null);
                            }
                            if (player233[i].UserId == "76561198816705835@steam")
                            {
                                player233[i].SetRank("silvery", "孤独一生", null);
                            }
                            if (player233[i].UserId == "76561198841744752@steam")
                            {
                                player233[i].SetRank("lime", "VIP1", null);
                            }
                            if (player233[i].UserId == "76561198149835838@steam")
                            {
                                player233[i].SetRank("aqua", "SCP079的正宫夫人丨最大电力：79520丨电力恢复：0AP/s丨专业迫害106", null);
                            }
                            if (player233[i].UserId == "76561198133773112@steam")
                            {
                                player233[i].SetRank("lime", "BILIBILI_优乐美", null);
                            }
                            if (player233[i].UserId == "76561198335932913@steam")
                            {
                                player233[i].SetRank("lime", "招财喵~", null);
                            }
                            if (player233[i].UserId == "76561198425823494@steam")
                            {
                                player233[i].SetRank("red", "斯大林", null);
                            }
                            if (player233[i].UserId == "76561198371077590@steam")
                            {
                                player233[i].SetRank("lime", "VIP1", null);
                            }
                            if (player233[i].UserId == "76561198812450849@steam")
                            {
                                player233[i].SetRank("lime", "BILIBILI_gou_mr", null);
                            }
                            if (player233[i].UserId == "76561198979881230@steam")
                            {
                                player233[i].SetRank("aqua", "本群常驻UP主", null);
                            }
                            if (player233[i].UserId == "76561198191585303@steam")
                            {
                                player233[i].SetRank("red", "美少女", null);
                            }
                            if (player233[i].UserId == "76561198401019684@steam")
                            {
                                player233[i].SetRank("lime", "不是小学生是少年音小姐姐", null);
                            }
                            if (player233[i].UserId == "76561198145812844@steam")
                            {
                                player233[i].SetRank("green", "老阴比", null);
                            }
                            if (player233[i].UserId == "76561198359791579@steam")
                            {
                                player233[i].SetRank("yellow", "D-17396", null);
                            }
                            if (player233[i].UserId == "76561198389200613@steam")
                            {
                                player233[i].SetRank("yellow", "非常无聊的大白", null);
                            }

                        }

                    }
                    Thread.Sleep(5000);
                    plugin.Server.PlayerListTitle = "<color=#FFFF00>QQ群:278704578</color>|<color=#FF3300>求求你了qwq</color>|<color=#00FF00>规则自由</color>";
                }
                else
                {
                    pmd.Abort();
                }
                goto qwq1;
            }

            public void OnShoot(PlayerShootEvent ev)
            {
                if (ev.Player.PlayerId == scp3108playerid)
                {
                    if(ev.Weapon.WeaponType == WeaponType.USP)
                    {
                        ev.Player.RemoveHandcuffs();
                        scp3108shotyes = true;
                    }
                }
                if(scp1577id.Contains(ev.Player.PlayerId))
                {
                    if (ev.Player.TeamRole.Team == Smod2.API.Team.NINETAILFOX)
                    {
                        if (ev.Weapon.WeaponType == WeaponType.COM15)
                        {
                            scp1577pos = ev.Player.GetPosition();
                            scp1577bj = true;
                            scp1577id = new List<int>();
                            plugin.Server.Map.Broadcast(5, "<color=lime>有人召唤了补给坐标" + scp1577pos.x + "|" + scp1577pos.y + "|" + scp1577pos.z + "按~输入.pos可获取你的坐标</color>", false);
                            ev.Player.PersonalBroadcast(5, "<color=lime>去尽情白给吧qwq</color>", false);
                        }
                    }
                    else
                    {
                        if (ev.Weapon.WeaponType == WeaponType.COM15)
                        {
                            scp1577pos = ev.Player.GetPosition();
                            scp1577bj = true;
                            scp1577id = new List<int>();
                            plugin.Server.Map.Broadcast(5, "<color=lime>有人召唤了补给坐标" + scp1577pos.x + "|" + scp1577pos.y + "|" + scp1577pos.z + "按~输入.pos可获取你的坐标</color>", false);
                            ev.Player.PersonalBroadcast(5, "<color=lime>你已经呼叫了补给</color>", false);
                        }
                    }



                }
            }
        }
    }
}

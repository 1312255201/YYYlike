using YYYIlike;
using Smod2;
using Smod2.API;
using Smod2.Attributes;
using Smod2.Config;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.Lang;
using Smod2.Piping;
using static YYYIlike.EscapeHandler;

namespace YYYIlike
{
	[PluginDetails(
		author = "1312255201",
		name = "YYYIlike",
		description = "新手服务器用的小插件",
		id = "YYYIlike",
		configPrefix = "ep",
		langFile = "YYYILove",
		version = "1.0",
		SmodMajor = 3,
		SmodMinor = 3,
		SmodRevision = 1
		)]
	public class ExamplePlugin : Plugin
	{
		public override void OnDisable()
		{
			this.Info(this.Details.name + "关闭完成QAQ 插件不开心了 ):");
		}

		public override void OnEnable()
		{
			// Sets the pipe field to 0.1 if it exists. Pipes are not accessable in register.
			this.Info(this.Details.name + " 读取成功,咕咕咕是人类的本质qwq 可能不更新的新手服插件 :)");
			this.Info(this.Details.name + " 内置投票t人 人品检测 中立079 硬币变东西还有682大爷 :)");
            this.Info(this.Details.name + " 蔡徐坤 Mr.fish SCP-817 SCP939-3 SCP049等级 随机门:)");
            this.Info(this.Details.name + " SCP-249 SCP-999(咕咕没修bug) SCP-038 :)");
        }

        public override void Register()
        {
            base.AddEventHandlers(new Start(this), Priority.Normal);

            //中立79开始注册
            base.AddEventHandlers(new CheckRun(this), Priority.Normal);
            //SCP999开始注册
            base.AddEventHandlers(new SCP999(this), Priority.Normal);

        }
	}
}

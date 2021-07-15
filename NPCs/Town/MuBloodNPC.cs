using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace Dimension.NPCs.Town
{
    [AutoloadHead]
    class MuBloodNPC:ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("沐血");
            Main.npcFrameCount[base.npc.type] = 1;
        }
        public override void SetDefaults()
        {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 26;
            npc.height = 44;
            npc.aiStyle = 7;
            npc.defense = 20;
            npc.lifeMax = 1000;
            npc.scale = 1f;
            npc.knockBackResist = 0f;
            npc.noGravity = false;
            npc.noTileCollide = false;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
        }
        public override string TownNPCName()
        {
                    return "沐血";
        }
        public override string GetChat()
        {
            WeightedRandom<string> chat = new WeightedRandom<string>();
            if (npc.homeless)
            {
                chat.Add("我...我在哪...？");
                chat.Add("你是人类吗...");
                chat.Add("你有...吃的吗...我好饿...");
            }
            else if(!Main.bloodMoon)
            {
                if (Main.dayTime)
                {
                    chat.Add("说实话，我不习惯...白天...阳光好刺眼。");
                    chat.Add("血腥地？如果你想去的话，沐血可以保护你的哦。");
                    chat.Add("她？谁？");
                    chat.Add("请问，你有看到沫姐姐吗？");
                    chat.Add("有什么沐血可以帮到的吗？");
                }
                if (!Main.dayTime)
                {
                    chat.Add("谁让你和她说话了？想趁我不注意的时候商量什么呢？");
                    chat.Add("我是谁？我可是，沐血呢~");
                    chat.Add("我能变出什么？链枷和血肉，怎么？");
                    chat.Add("和白天性格大变？你的错觉罢了。");
                    chat.Add("她？什么她？如果你指奈月，呵呵呵...");
                }

                if (Main.eclipse)
                {
                    chat.Add("呜啊，好多奇怪的怪物，呜呜呜...");
                    chat.Add("我想回家...这里好可怕...");
                }
                int tavernKeep = NPC.FindFirstNPC(ModContent.NPCType<Yukiko>());
                if (tavernKeep != -1)
                {
                    chat.Add("羽曦？");
                }
            }
            else
            {
                    chat.Add("呵呵呵，我开始兴奋了。");
                    chat.Add("说实话你觉得血腥的怪怎么样？我觉得还行，不知道为什么这么多人喜欢腐化。");
                    chat.Add("当你凝视猩红之月的时候，猩红之神也在凝视着你。");
                    chat.Add("猩红之神？你需要去了解祂吗？");
                int tavernKeep = NPC.FindFirstNPC(ModContent.NPCType<Yukiko>());
                if (tavernKeep != -1)
                {
                    chat.Add("呵呵，那只狐狸真是喜欢多管闲事呢，真想...");
                }
            }
            return chat;
        }
        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
        }
        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;
            }
        }
        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            shop.item[nextSlot].SetDefaults(ItemID.BloodWater);
            shop.item[nextSlot].value = 1000;
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.BloodWaterFountain);
            shop.item[nextSlot].value = 100000;
            nextSlot++;
        }
        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            if (Main.hardMode)
            {
                return true;
            }
            return false;
        }
    }
}

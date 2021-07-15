using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace Dimension.NPCs.Town
{
    [AutoloadHead]
    class Yukiko : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("羽曦");
            Main.npcFrameCount[base.npc.type] = 1;
        }
        public override void SetDefaults()
        {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 34;
            npc.height = 54;
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
            return "稻荷由纪子";
        }
        public override string GetChat()
        {
            WeightedRandom<string> chat = new WeightedRandom<string>();
            if(Main.player[Main.myPlayer].talkNPC == 0)
            {
                chat.Add("你就是新来这个世界的人吧？你好啊。");
            }
            else if (npc.homeless)
            {
                chat.Add("虽然我失去家已经很长时间了，但是我依然想拥有一个。");
            }
            else if (!Main.bloodMoon)
            {
                chat.Add("唔，这个世界没有其它狐狸了，真的。");
                chat.Add("我花了好长时间知道我到底算什么，这令我受益匪浅。");
                chat.Add("神明的本质是无形的规则，当他们拥有看得见摸得着的形体之时，算得上一次小小的退化。");
                chat.Add("我为了一个目标活到现在，至于它是什么，你还不需要知道。");
                chat.Add("世界是神明的沙盒游戏。");
                chat.Add("死亡也许也不是坏事，而是通向真理的大门。");
                if (!Main.hardMode)
                {
                    if (NPC.downedSlimeKing);
                    {
                        chat.Add("凝胶是好东西，但是不够纯粹。");
                    }
                    if (NPC.downedBoss1)
                    {
                        chat.Add("那个眼球完全没有它应有的气势");
                    }
                    if (NPC.downedBoss2 && WorldGen.crimson==true)
                    {
                        chat.Add("遗失了神性，便只有扭曲。");
                    }
                    else if(NPC.downedBoss2 && WorldGen.crimson == false)
                    {
                        chat.Add("不得不说这是一个科学的悲剧。");
                    }
                    if (NPC.downedQueenBee)
                    {
                        chat.Add("要是她知道她的同族经历了怎样的苦难会作何感想呢。");
                    }
                    if (NPC.downedBoss3)
                    {
                        chat.Add("诅咒折磨的并非是身体，而是精神。");
                    }
                }
                else if(Main.hardMode)
                {
                    if (NPC.downedMechBossAny)
                    {
                        chat.Add("机械与灵魂，干涉了神明的领域。");
                    }
                    if (NPC.downedPlantBoss)
                    {
                        chat.Add("灵魂导引之灯熄灭了。");
                    }
                    if (NPC.downedGolemBoss)
                    {
                        chat.Add("他们崇拜错了神明，但是这石像依然具有一些力量。");
                    }
                    if (NPC.downedFishron)
                    {
                        chat.Add("他本不应被屠戮，然而鱼儿总会上钩。");
                    }
                    if (NPC.downedAncientCultist)
                    {
                        chat.Add("人力本不能封印古神，这是一个更加久远的故事。");
                    }
                    if (NPC.downedMoonlord)
                    {
                        chat.Add("一位游离于生死边缘的神明依然具有如此巨大的能量，世界都为之改变。");
                    }
                }
                if (BirthdayParty.PartyIsUp)
                {
                    chat.Add("真热闹啊，这是个大家都开心的日子吧。");
                }
                    int tavernKeep = NPC.FindFirstNPC(ModContent.NPCType<MuBloodNPC>());
                if (tavernKeep != -1)
                {
                    chat.Add("哦，她很特殊，她的体内有着超越这世界的东西。");
                }
            }
            if (Main.bloodMoon)
            {
                chat.Add("我曾直视血色之月，直视这古神之眼，受到他的启示。");
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
            shop.item[nextSlot].SetDefaults(ItemID.CopperOre);
            nextSlot++; shop.item[nextSlot].SetDefaults(ItemID.TinOre);
            nextSlot++; shop.item[nextSlot].SetDefaults(ItemID.LeadOre);
            nextSlot++; shop.item[nextSlot].SetDefaults(ItemID.IronOre);
            nextSlot++; shop.item[nextSlot].SetDefaults(ItemID.SilverOre);
            nextSlot++; shop.item[nextSlot].SetDefaults(ItemID.TungstenOre);
            nextSlot++; shop.item[nextSlot].SetDefaults(ItemID.GoldOre);
            nextSlot++; shop.item[nextSlot].SetDefaults(ItemID.PlatinumOre);
            if (NPC.downedBoss3)
            {
                nextSlot++; shop.item[nextSlot].SetDefaults(ItemID.Hellstone);
            }
            if (Main.hardMode)
            {
            nextSlot++; shop.item[nextSlot].SetDefaults(ItemID.PalladiumOre);
            nextSlot++; shop.item[nextSlot].SetDefaults(ItemID.CobaltOre);
            nextSlot++; shop.item[nextSlot].SetDefaults(ItemID.MythrilOre);
            nextSlot++; shop.item[nextSlot].SetDefaults(ItemID.OrichalcumOre);
            nextSlot++; shop.item[nextSlot].SetDefaults(ItemID.TitaniumOre);
            nextSlot++; shop.item[nextSlot].SetDefaults(ItemID.AdamantiteOre);
            }
            if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
            {
            nextSlot++; shop.item[nextSlot].SetDefaults(ItemID.HallowedBar);
            nextSlot++; shop.item[nextSlot].SetDefaults(ItemID.ChlorophyteOre);
            }
            if (NPC.downedMoonlord)
            {
            nextSlot++; shop.item[nextSlot].SetDefaults(ItemID.LunarOre);
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (!spawnInfo.playerSafe)
            {
                return 0f;
            }
            return SpawnCondition.Cavern.Chance * 0.5f;
        }
    }
}

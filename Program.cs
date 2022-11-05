using Sandbox.ModAPI.Ingame;
using System;
using System.Collections.Generic;
using System.Text;
using VRage.Game.GUI.TextPanel;
using VRage.Game.ModAPI.Ingame.Utilities;
using VRageMath;

namespace IngameScript
{
    partial class Program : MyGridProgram
    {

/*
Exemple to config 

[SGN - Cartello-1]
Title=Prova Titolo
Size=90
Font=Debug
Font Size=2.5
Rotation Angle SX=45
Rotation Angle DX=45
Icon Size=90
Span Icon = 50
Sprite Type SX=Arrow
Sprite Type DX=warning

*/
        const string groupLCDName = "CAR - LCD-Cartelli"; // Name Group
        const string sectionName = "SGN - Cartello-"; // Ini Section initialization


        public Dictionary<string, string> nickToDataNamePairs = new Dictionary<string, string>()
        {
            { "cross", "Cross" },
            { "arrow", "Arrow" },
            { "warning", "Danger" },
            { "stop", "No Entry" },
            { "construction", "Construction" },
            { "rectangle", "SquareSimple" },
            { "circle", "Circle" },
            { "circle hollow", "HollowCircle" },
            { "hollow arrow", "AH_PullUp" },
            { "hollow box", "AH_Textbox" },
            { "trinity", @"Textures\FactionLogo\Builders\BuilderIcon_2.dds" },
            { "left bracket", "DecorativeBracketLeft" },
            { "right bracket", "DecorativeBracketRight" },
            { "hydrogen", "IconHydrogen" },
            { "oxygen", "IconOxygen" },
            { "energy", "IconEnergy" },
            { "radioactive", @"Textures\FactionLogo\Others\OtherIcon_19.dds" },
            { "triangle", "Triangle" },
            { "crosshair", "AH_BoreSight" },
            { "target crosshair", "AH_VelocityVector" },
            { "sc coin", "LCD_Economy_SingleCoin" },
            { "shopping trolley", "StoreBlock2" },
            { "cubes", @"Textures\FactionLogo\Builders\BuilderIcon_1.dds" },
            { "atomic", @"Textures\FactionLogo\Others\OtherIcon_18.dds" },
            { "atomic 2", @"Textures\FactionLogo\Builders\BuilderIcon_13.dds" },
            { "rocket", @"Textures\FactionLogo\Builders\BuilderIcon_14.dds" },
            { "construction tools", @"Textures\FactionLogo\Builders\BuilderIcon_15.dds" },
            { "tool", @"Textures\FactionLogo\Builders\BuilderIcon_16.dds" },
            { "faction icon crown", @"Textures\FactionLogo\Builders\BuilderIcon_10.dds" },
            { "faction icon triangle", @"Textures\FactionLogo\Others\OtherIcon_12.dds" },
            { "power tools", @"Textures\FactionLogo\Builders\BuilderIcon_4.dds" },
            { "shield", @"Textures\FactionLogo\Builders\BuilderIcon_5.dds"},
            { "gears", @"Textures\FactionLogo\Builders\BuilderIcon_7.dds" },
            { "helmet", @"Textures\FactionLogo\Builders\BuilderIcon_8.dds" },
            { "crown", @"Textures\FactionLogo\Builders\BuilderIcon_9.dds" },
            { "drill 1", @"Textures\FactionLogo\Miners\MinerIcon_1.dds" },
            { "drill 2", @"Textures\FactionLogo\Miners\MinerIcon_2.dds" },
            { "drill 3", @"Textures\FactionLogo\Miners\MinerIcon_3.dds" },
            { "drill 4", @"Textures\FactionLogo\Miners\MinerIcon_4.dds" },
            { "weapon emblem", @"Textures\FactionLogo\Others\OtherIcon_1.dds" },
            { "tool emblem", @"Textures\FactionLogo\Others\OtherIcon_10.dds" },
            { "space engineer", @"Textures\FactionLogo\Others\OtherIcon_11.dds" },
            { "crowned space engineer", @"Textures\FactionLogo\Others\OtherIcon_17.dds" },
            { "construction crane", @"Textures\FactionLogo\Others\OtherIcon_2.dds" },
            { "other faction icon 1", @"Textures\FactionLogo\Others\OtherIcon_20.dds" },
            { "other faction icon 2", @"Textures\FactionLogo\Others\OtherIcon_21.dds" },
            { "other faction icon 3", @"Textures\FactionLogo\Others\OtherIcon_28.dds" },
            { "other faction icon 4", @"Textures\FactionLogo\Others\OtherIcon_29.dds" },
            { "other faction icon 5", @"Textures\FactionLogo\Others\OtherIcon_7.dds" },
            { "other faction icon 6", @"Textures\FactionLogo\Builders\BuilderIcon_3.dds" },
            { "other faction icon 7", @"Textures\FactionLogo\Builders\BuilderIcon_6.dds" },
            { "other faction icon 8", @"Textures\FactionLogo\Builders\BuilderIcon_12.dds" },
            { "gear", @"Textures\FactionLogo\Others\OtherIcon_22.dds" },
            { "mushroom cloud", @"Textures\FactionLogo\Others\OtherIcon_23.dds" },
            { "solar system", @"Textures\FactionLogo\Others\OtherIcon_24.dds" },
            { "compass", @"Textures\FactionLogo\Others\OtherIcon_26.dds" },
            { "compass 2", @"Textures\FactionLogo\Others\OtherIcon_30.dds" },
            { "energy 2", @"Textures\FactionLogo\Others\OtherIcon_27.dds" },
            { "skull 1", @"Textures\FactionLogo\Others\OtherIcon_3.dds" },
            { "skull 2", @"Textures\FactionLogo\Others\OtherIcon_31.dds" },
            { "hexagons", @"Textures\FactionLogo\Others\OtherIcon_32.dds" },
            { "rocket 2", @"Textures\FactionLogo\Others\OtherIcon_33.dds"  },
            { "fist", @"Textures\FactionLogo\Others\OtherIcon_4.dds" },
            { "rocket orbit", @"Textures\FactionLogo\Others\OtherIcon_6.dds" },
            { "triangle pattern", @"Textures\FactionLogo\Others\OtherIcon_8.dds" },
            { "helmet glasses", @"Textures\FactionLogo\Others\OtherIcon_9.dds" },
            { "pirate", @"Textures\FactionLogo\PirateIcon.dds" },
            { "spider", @"Textures\FactionLogo\Spiders.dds" },
            { "flags", @"Textures\FactionLogo\Traders\TraderIcon_1.dds" },
            { "business", @"Textures\FactionLogo\Traders\TraderIcon_2.dds" },
            { "money", @"Textures\FactionLogo\Traders\TraderIcon_3.dds" },
            { "money 2", @"Textures\FactionLogo\Traders\TraderIcon_4.dds" },
            { "space engineer tie", @"Textures\FactionLogo\Traders\TraderIcon_5.dds" },
            { "magazine 1", @"MyObjectBuilder_AmmoMagazine/AutocannonClip" },
            { "magazine 2", "MyObjectBuilder_AmmoMagazine/AutomaticRifleGun_Mag_20rd" },
            { "magazine 3", "MyObjectBuilder_AmmoMagazine/ElitePistolMagazine" },
            { "magazine 4", "MyObjectBuilder_AmmoMagazine/FullAutoPistolMagazine" },
            { "magazine 5", "MyObjectBuilder_AmmoMagazine/NATO_5p56x45mm" },
            { "magazine 6", "MyObjectBuilder_AmmoMagazine/PreciseAutomaticRifleGun_Mag_5rd" },
            { "magazine 7", "MyObjectBuilder_AmmoMagazine/RapidFireAutomaticRifleGun_Mag_50rd" },
            { "magazine 8", "MyObjectBuilder_AmmoMagazine/SemiAutoPistolMagazine" },
            { "magazine 9", "MyObjectBuilder_AmmoMagazine/UltimateAutomaticRifleGun_Mag_30rd" },
            { "shell 1", "MyObjectBuilder_AmmoMagazine/LargeCalibreAmmo" },
            { "shell 2", "MyObjectBuilder_AmmoMagazine/MediumCalibreAmmo" },
            { "large sabot", "MyObjectBuilder_AmmoMagazine/LargeRailgunAmmo" },
            { "small sabot", "MyObjectBuilder_AmmoMagazine/SmallRailgunAmmo" },
            { "missile", "MyObjectBuilder_AmmoMagazine/Missile200mm" },
            { "ammo box", "MyObjectBuilder_AmmoMagazine/NATO_25x184mm" },
            { "bulletproof glass", "MyObjectBuilder_Component/BulletproofGlass" },
            { "canvas", "MyObjectBuilder_Component/Canvas" },
            { "computer", "MyObjectBuilder_Component/Computer" },
            { "construction component", "MyObjectBuilder_Component/Construction" },
            { "detector component", "MyObjectBuilder_Component/Detector" },
            { "display", "MyObjectBuilder_Component/Display" },
            { "explosives", "MyObjectBuilder_Component/Explosives" },
            { "girder", "MyObjectBuilder_Component/Girder" },
            { "gravity component", "MyObjectBuilder_Component/GravityGenerator" },
            { "interior plate", "MyObjectBuilder_Component/InteriorPlate" },
            { "large steel tube", "MyObjectBuilder_Component/LargeTube" },
            { "medical componment", "MyObjectBuilder_Component/Medical" },
            { "metal grid", "MyObjectBuilder_Component/MetalGrid" },
            { "motor", "MyObjectBuilder_Component/Motor" },
            { "power cell", "MyObjectBuilder_Component/PowerCell" },
            { "radio-comm comp", "MyObjectBuilder_Component/RadioCommunication" },
            { "reactor component", "MyObjectBuilder_Component/Reactor" },
            { "small steel tube", "MyObjectBuilder_Component/SmallTube" },
            { "solar cell", "MyObjectBuilder_Component/SolarCell" },
            { "steel plate", "MyObjectBuilder_Component/SteelPlate" },
            { "superconductor", "MyObjectBuilder_Component/Superconductor" },
            { "thruster component", "MyObjectBuilder_Component/Thrust" },
            { "zone chip", "MyObjectBuilder_Component/ZoneChip" },
            { "clang cola", "MyObjectBuilder_ConsumableItem/ClangCola" },
            { "cosmic coffee", "MyObjectBuilder_ConsumableItem/CosmicCoffee" },
            { "medkit", "MyObjectBuilder_ConsumableItem/Medkit" },
            { "powerkit", "MyObjectBuilder_ConsumableItem/Powerkit" },
            { "datapad", "MyObjectBuilder_Datapad/Datapad" },
            { "hydrogen bottle", "MyObjectBuilder_GasContainerObject/HydrogenBottle" },
            { "oxygen bottle", "MyObjectBuilder_OxygenContainerObject/OxygenBottle" },
            { "cobalt ingot", "MyObjectBuilder_Ingot/Cobalt" },
            { "gold ingot", "MyObjectBuilder_Ingot/Gold" },
            { "iron ingot", "MyObjectBuilder_Ingot/Iron" },
            { "magnesium ingot", "MyObjectBuilder_Ingot/Magnesiu" },
            { "nickel ingot", "MyObjectBuilder_Ingot/Nickel" },
            { "platinum ingot", "MyObjectBuilder_Ingot/Platinum" },
            { "scrap ingot", "MyObjectBuilder_Ingot/Scrap" },
            { "silicon ingot", "MyObjectBuilder_Ingot/Silicon" },
            { "silver ingot", "MyObjectBuilder_Ingot/Silver" },
            { "stone ingot", "MyObjectBuilder_Ingot/Stone" },
            { "uranium ingot", "MyObjectBuilder_Ingot/Uranium" },
            { "stone", "MyObjectBuilder_Ore/Stone" },
            { "organic", "MyObjectBuilder_Ore/Organic" },
            { "scrap", "MyObjectBuilder_Ore/Scrap" },
            { "cobalt ore", "MyObjectBuilder_Ore/Cobalt" },
            { "gold ore", "MyObjectBuilder_Ore/Gold" },
            { "ice ore", "MyObjectBuilder_Ore/Ice" },
            { "iron ore", "MyObjectBuilder_Ore/Iron" },
            { "magnesium ore", "MyObjectBuilder_Ore/Magnesium" },
            { "nickel ore", "MyObjectBuilder_Ore/Nickel" },
            { "platinum ore", "MyObjectBuilder_Ore/Platinum" },
            { "silicon ore", "MyObjectBuilder_Ore/Silicon" },
            { "silver ore", "MyObjectBuilder_Ore/Silver" },
            { "uranium ore", "MyObjectBuilder_Ore/Uranium" },
            { "package", "MyObjectBuilder_Package/Package" },
            { "rocket launcher 1", "MyObjectBuilder_PhysicalGunObject/BasicHandHeldLauncherItem" },
            { "rocket launcher 2", "MyObjectBuilder_PhysicalGunObject/AdvancedHandHeldLauncherItem" },
            { "welder", "MyObjectBuilder_PhysicalGunObject/WelderItem" },
            { "enhanced welder", "MyObjectBuilder_PhysicalGunObject/Welder2Item" },
            { "proficent welder", "MyObjectBuilder_PhysicalGunObject/Welder3Item" },
            { "elite welder", "MyObjectBuilder_PhysicalGunObject/Welder4Item" },
            { "grinder", "MyObjectBuilder_PhysicalGunObject/AngleGrinderItem" },
            { "enhanced grinder", "MyObjectBuilder_PhysicalGunObject/AngleGrinder2Item" },
            { "proficent grinder", "MyObjectBuilder_PhysicalGunObject/AngleGrinder3Item" },
            { "elite grinder", "MyObjectBuilder_PhysicalGunObject/AngleGrinder4Item" },
            { "drill", "MyObjectBuilder_PhysicalGunObject/HandDrillItem" },
            { "enhanced drill", "MyObjectBuilder_PhysicalGunObject/HandDrill2Item" },
            { "proficent drill", "MyObjectBuilder_PhysicalGunObject/HandDrill3Item" },
            { "elite drill", "MyObjectBuilder_PhysicalGunObject/HandDrill4Item" },
            { "rifle 1", "MyObjectBuilder_PhysicalGunObject/AutomaticRifleItem" },
            { "rifle 2", "MyObjectBuilder_PhysicalGunObject/PreciseAutomaticRifleItem" },
            { "rifle 4", "MyObjectBuilder_PhysicalGunObject/UltimateAutomaticRifleItem" },
            { "rifle 3", "MyObjectBuilder_PhysicalGunObject/RapidFireAutomaticRifleItem" },
            { "pistol 1", "MyObjectBuilder_PhysicalGunObject/ElitePistolItem" },
            { "pistol 2", "MyObjectBuilder_PhysicalGunObject/FullAutoPistolItem" },
            { "pistol 3", "MyObjectBuilder_PhysicalGunObject/SemiAutoPistolItem" },
            { "space credits", "MyObjectBuilder_PhysicalObject/SpaceCredit" },
            { "thumbs up", "MyObjectBuilder_PhysicalGunObject/GoodAIRewardPunishmentTool" },
        };

        RectangleF _viewport;

        public List<SignConfig> signConfig;
        List<IMyTextPanel> lcd_Blocks;

        public Program()
        {
            Runtime.UpdateFrequency = UpdateFrequency.Update100;

            // Get block by group
            lcd_Blocks = new List<IMyTextPanel>();
            IMyBlockGroup grp_LCD = GridTerminalSystem.GetBlockGroupWithName(groupLCDName);
            if (grp_LCD == null)
                throw new Exception("Group " + groupLCDName + " not found");

            // Filter element by type, grid and customdata
            grp_LCD.GetBlocksOfType<IMyTextPanel>(lcd_Blocks, x => x.CubeGrid == Me.CubeGrid && x.CustomData.Contains(sectionName));
            if (lcd_Blocks.Count <= 0)
                throw new Exception("LCD not found");
        }

        public void Main(string argument, UpdateType updateSource)
        {
            foreach (var lcd in lcd_Blocks)
            {
                Echo(lcd.CustomName);
                IMyTextPanel _lcd = lcd;
                if (_lcd != null)
                {
                    CreateConfigSign(_lcd.CustomData);
                    SetupDrawSurface(ref _lcd);

                    var frame = _lcd.DrawFrame();

                    DrawSprites(ref frame, _lcd);
                    frame.Dispose();
                }

            }

        }
        public void SetupDrawSurface(ref IMyTextPanel surface)
        {
            //surface.ScriptBackgroundColor = surface.ScriptBackgroundColor.Alpha(0.46f).Shade(0.09f);
            //surface.ContentType = ContentType.SCRIPT;
            surface.Script = "";
            _viewport = new RectangleF((surface.TextureSize - surface.SurfaceSize) / 2f, surface.SurfaceSize);
        }

        public void DrawSprites(ref MySpriteDrawFrame frame, IMyTextPanel surface)
        {
            int SpanY = 0;
            foreach (var e in signConfig)
            {
                //Square position e size
                Vector2 positionSquare = new Vector2(_viewport.Position.X, _viewport.Position.Y + (e.sizeSquare / 2) + 2 + SpanY);
                Vector2 sizeSquare = new Vector2(_viewport.Size.X, e.sizeSquare);
                float topMargin = _viewport.Position.Y + (e.sizeSquare / 2) - (surface.MeasureStringInPixels(new StringBuilder(e.text), e.font, e.fontSize).Y / 2);
                Vector2 positionText = new Vector2(_viewport.Center.X, topMargin + SpanY);

                frame.Add(new MySprite()
                {
                    Type = SpriteType.TEXTURE,
                    Alignment = TextAlignment.LEFT,
                    Data = "SquareHollow",
                    Position = positionSquare,
                    Size = sizeSquare,
                    Color = e.borderColor.Shade(0.9f),
                    RotationOrScale = 0f,

                });
                frame.Add(new MySprite()
                {
                    Type = SpriteType.TEXTURE,
                    Alignment = TextAlignment.LEFT,
                    Data = "SquareSimple",
                    Position = positionSquare,
                    Size = sizeSquare,
                    Color = e.backgroundColor.Shade(0.2f),
                    RotationOrScale = 0f,
                });
                frame.Add(new MySprite()
                {
                    Type = SpriteType.TEXT,
                    Alignment = TextAlignment.CENTER,
                    Data = e.text,
                    Position = positionText,
                    Color = new Color(255, 255, 255, 255),
                    RotationOrScale = e.fontSize,
                    FontId = e.font,
                });
                //Left
                if (e.spriteSX != null)
                {

                    frame.Add(new MySprite()
                    {
                        Type = SpriteType.TEXTURE,
                        Alignment = TextAlignment.CENTER,
                        Data = GetSpriteName(e.spriteSX),
                        Position = new Vector2(_viewport.Position.X + e.spanSprite, positionSquare.Y),
                        Size = new Vector2(e.sizeSpriteSX, e.sizeSpriteSX),
                        Color = e.SpriteColorSX.Shade(1f),
                        RotationOrScale = ConverToRad(e.rotationSpriteSX),
                    });
                }


                //Right
                if (e.spriteDX != null)
                {
                    frame.Add(new MySprite()
                    {
                        Type = SpriteType.TEXTURE,
                        Alignment = TextAlignment.CENTER,
                        Data = GetSpriteName(e.spriteDX),
                        Position = new Vector2(_viewport.Right - e.spanSprite, positionSquare.Y),
                        Size = new Vector2(e.sizeSpriteDX, e.sizeSpriteDX),
                        Color = e.SpriteColorDX.Shade(1f),
                        RotationOrScale = ConverToRad(e.rotationSpriteDX),
                    });
                }

                SpanY += e.sizeSquare;
            }

        }

        public void CreateConfigSign(string customData)
        {
            signConfig = new List<SignConfig>();

            MyIni ini = new MyIni();


            // Get customdata all section
            if (ini.TryParse(customData))
            {
                for (int i = 1; i < 10; i++)
                {
                    string section = sectionName + i;
                    if (ini.ContainsSection(sectionName + i))
                    {
                        SignConfig element = new SignConfig();
                        element.text = ini.Get(section, "Title").ToString();
                        element.sizeSquare = ini.Get(section, "Size").ToInt16();
                        element.font = ini.Get(section, "Font").ToString();
                        element.fontSize = (float)ini.Get(section, "Font Size").ToDouble();
                        element.borderColor = GetColorFromString(ini.Get(section, "Border Color").ToString());
                        element.backgroundColor = GetColorFromString(ini.Get(section, "Background Color").ToString());

                        element.spriteSX = ini.Get(section, "Sprite Type SX").ToString();
                        element.spriteDX = ini.Get(section, "Sprite Type DX").ToString();
                        element.rotationSpriteSX = ini.Get(section, "Sprite Rotation Angle SX").ToInt16() * -1;
                        element.rotationSpriteDX = ini.Get(section, "Sprite Rotation Angle DX").ToInt16();
                        element.sizeSpriteSX = ini.Get(section, "Sprite Size SX").ToInt16();
                        element.sizeSpriteDX = ini.Get(section, "Sprite Size DX").ToInt16();

                        element.SpriteColorSX = GetColorFromString(ini.Get(section, "Sprite Color SX").ToString());
                        element.SpriteColorDX = GetColorFromString(ini.Get(section, "Sprite Color DX").ToString());

                        element.spanSprite = ini.Get(section, "Sprite Span Border").ToInt16();

                        signConfig.Add(element);
                    }
                    else
                        break;
                }
            }
        }

        public float ConverToRad(double degree) => (float)(degree * Math.PI) / 180;

        public string GetSpriteName(string iconName)
        {
            string key = iconName.ToLower();
            if (nickToDataNamePairs.ContainsKey(key))
            {
                return nickToDataNamePairs[key];
            }
            else
                return iconName;
        }

        public Color GetColorFromString(string colorString) 
        {
            Color color;
            char[] div = { ' ', ';', ','};

            string[] splitStringColor = colorString.Split(div);
            if (splitStringColor.Length == 4)
            {
                color = new Color()
                {
                    R = byte.Parse(splitStringColor[0]),
                    G = byte.Parse(splitStringColor[1]),
                    B = byte.Parse(splitStringColor[2]),
                    A = byte.Parse(splitStringColor[3]),
                };
            }
            else
                color = new Color(255, 255, 255, 255);
            return color;
                
        }


        public class SignConfig
        {
            public string text;
            public int sizeSquare;
            public float fontSize;
            public string font;
            public Color borderColor;
            public Color backgroundColor;

            public int sizeSpriteSX;
            public int sizeSpriteDX;
            public int rotationSpriteSX;
            public int rotationSpriteDX;
            public int spanSprite;
            public string spriteSX;
            public string spriteDX;
            public Color SpriteColorSX;
            public Color SpriteColorDX;
        }

    }
}

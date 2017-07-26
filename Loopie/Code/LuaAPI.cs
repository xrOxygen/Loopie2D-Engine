﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LuaInterface;

namespace Visual
{
    public class FormAPIForLua
    {

    }
    public class LuaAPI
    {
        public string cfg, userdata, scripts, images, snd;

        private INIManager ifs;
        public Lua lua = new Lua();
        public LuaAPI()
        {
            ifs = new INIManager(@"..\\setting.ini");

            cfg      = ifs.GetPrivateString("global", "config");
            userdata = ifs.GetPrivateString("global", "user");
            scripts  = ifs.GetPrivateString("global", "scripts");
            images   = ifs.GetPrivateString("global", "img");
            snd      = ifs.GetPrivateString("global", "snd");

            //lua["Form"] = new FormAPIForLua();
            lua["IFS"]  = new INIManager();
            lua["Text"] = "";
            lua["ActorName"] = "";
            lua["Sound"] = "0";
            lua["ImageNum"] = 1;
            lua.NewTable("Font");
            lua.NewTable("Scene");
            lua.NewTable("Image");

            for (int i = 0; i < 10; i++)
                lua.GetTable("Image")[i] = "";
        }
        public string GetSnd()
        {
            return (string)lua["Sound"];
        }
        public string GetName()
        {
            return (string)lua["ActorName"];
        }
        public string GetText()
        {
            return (string)lua["Text"];
        }
        public string GetTextColor()
        {
            return (string)lua.GetTable("Font")["TextColor"];
        }
        public string GetNameColor()
        {
            return (string)lua.GetTable("Font")["NameColor"];
        }
        public int GetLabelNum()
        {
            return (int)(double)lua.GetTable("Scene")["Options"];
        }
        public string GetImageText(int num)
        {
            return (string)lua.GetTable("Scene")["Image" + Convert.ToString(num)];
        }
        public int GetImageTextPos(int num)
        {
            switch ((string)lua.GetTable("Scene")["Image" + Convert.ToString(num) + "Pos"])
            {
                case "ALeft": return 1;
                case "Left": return 2;
                case "Center": return 3;
                case "Right": return 4;
                case "ARight": return 5;
                default: return 3;
            }
        }
        public int GetImgNum()
        {
            return (int)(double)lua.GetTable("Scene")["Images"];
        }
        public string GetLabelText(int num)
        {
            return (string)lua.GetTable("Scene")["Option" + Convert.ToString(num)];
        }
        public string GetTextFont()
        {
            return (string)lua.GetTable("Font")["Text"];
        }
        public string GetNameFont()
        {
            return (string)lua.GetTable("Font")["Name"];
        }

        public string GetImage(int num)
        {
            return (string)lua.GetTable("Image")[num];
        }
        public void LuaFunc(string file, string func)
        {
            try
            {
                lua.DoFile(scripts + file + ".lua");
                LuaFunction function = lua[func] as LuaFunction;
                function.Call();
            }
            catch (LuaException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
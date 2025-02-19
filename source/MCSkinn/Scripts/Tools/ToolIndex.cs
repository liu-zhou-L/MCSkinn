﻿//
//    MCSkinn, A modern Minecraft 3D skin manager/editor for Windows by NotYoojun.!
//    Copyright © iNKORE! 2023
//
//    The copy of source (only the public part) can be used anywhere with a credit to MCSkinn page at your own risk
//    https://github.com/InkoreStudios/MCSkinn
//

using System.Drawing;
using System.Windows.Forms;
using Inkore.Coreworks;
using MCSkinn.Scripts.Paril.OpenGL;

namespace MCSkinn.Scripts.Tools
{
    public class ToolIndex
    {
        public ToolStripButton Button;
        public Keys DefaultKeys;
        public ToolStripMenuItem MenuItem;
        public string Name;
        public ITool Tool;
        public string Identifer;

        public ToolIndex(ITool tool, string identifier, string name, Image image, Keys defaultKey)
        {
            Name = name;
            DefaultKeys = defaultKey;
            Identifer = identifier;
            Tool = tool;
            MenuItem = new ToolStripMenuItem(Name, image);
            MenuItem.Text = name;
            MenuItem.Tag = this;
            Button = new ToolStripButton(image);
            Button.Text = name;
            Button.DisplayStyle = ToolStripItemDisplayStyle.Image;
            Button.Tag = this;

            Program.Log(LogType.Load, string.Format("Loaded tool '{0}'", name), "at MCSkinn.Scripts.Tools.ToolIndex(ITool, ToolOptionBase, string, Image, Keys)");
        }

        public void SetMeAsTool()
        {
            Program.Editor.SetSelectedTool(this);
        }
    }
}
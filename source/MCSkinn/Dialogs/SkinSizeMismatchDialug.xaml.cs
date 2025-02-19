﻿using Inkore.UI.WPF.Modern.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MCSkinn.Dialogs
{
    /// <summary>
    /// GeneralQuestionDialog.xaml 的交互逻辑
    /// </summary>
    public partial class SkinSizeMismatchDialug : ContentDialog
    {
        public SkinSizeMismatchDialug()
        {
            InitializeComponent();

            this.Title = Program.GetLanguageString("M_SKINSIZEMISMATCH");
            this.Content = Program.GetLanguageString("M_SKINSIZEMISMATCH_MSG");

            this.PrimaryButtonText = Program.GetLanguageString("C_CROP");
            this.SecondaryButtonText = Program.GetLanguageString("C_SCALE");

            this.CloseButtonText = Program.GetLanguageString("C_CANCEL");

            this.DefaultButton = ContentDialogButton.Close;
        }
    }
    public enum ResizeType
    {
        None,
        Crop,
        Scale
    }


}

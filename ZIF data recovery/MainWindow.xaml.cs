﻿using System;
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

namespace ZIF_data_recovery
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void LoadFileClick(object sender, RoutedEventArgs e)
        {
            // load file
            // Add status: file X loaded in Status Textbox
        }

        public void ResetBoardClick(object sender, RoutedEventArgs e)
        {
            // Reset Bitmap Drawingboard
            // Reset Loaded Files
            // Reset Status Textbox
        }
    }
}

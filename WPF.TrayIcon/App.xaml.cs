﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;
using System.Windows;

namespace WPF.TrayIcon
{
    public partial class App : Application
    {
        private bool _isExit;
        private System.Windows.Forms.NotifyIcon _notifyIcon;

        /// <summary>
        /// Set icon and context menu on application startup and show main window of application
        /// </summary>
        /// <param name="e">Startup arguments</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            
            MainWindow = new SomeWindow();
            MainWindow.Closing += MainWindow_Closing;

            _notifyIcon = new System.Windows.Forms.NotifyIcon();
            _notifyIcon.DoubleClick += (s, args) => ShowMainWindow();
           
            // Set application icon
            _notifyIcon.Icon = TrayIcon.Properties.Resources.Icon;
            _notifyIcon.Visible = true;

            CreateContextMenu();
            MainWindow.Show();
        }
        /// <summary>
        /// Context menu initialization
        /// </summary>
        private void CreateContextMenu()
        {
            _notifyIcon.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            _notifyIcon.ContextMenuStrip.Items.Add("MainWindow...").Click += (s, e) => ShowMainWindow();
            _notifyIcon.ContextMenuStrip.Items.Add("Exit").Click += (s, e) => ExitApplication();
        }

        /// <summary>
        /// Close MainWindow and dispose notification icon
        /// </summary>
        private void ExitApplication()
        {
            _isExit = true;
            MainWindow.Close();
            _notifyIcon.Dispose();
            _notifyIcon = null;
        }

        /// <summary>
        /// Show MainWindow or change its state from Minimized to Normal
        /// </summary>
        private void ShowMainWindow()
        {
            if (MainWindow.WindowState == WindowState.Minimized)
            {
                MainWindow.WindowState = WindowState.Normal;
                MainWindow.Activate();
                
            }
            else if (!MainWindow.IsVisible)
            {
                MainWindow.Show();
            }
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            if (!_isExit)
            {
                e.Cancel = true;
                MainWindow.Hide(); // A hidden window can be shown again, a closed one not
            }
        }
    }
}

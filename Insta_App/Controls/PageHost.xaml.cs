﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Channels;
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
using Insta_App.Pages;

namespace Insta_App.Controls
{
    /// <summary>
    /// Interaction logic for PageHost.xaml
    /// </summary>
    public partial class PageHost : UserControl
    {
        public BasePage CurrentPage
        {
            get { return (BasePage) GetValue(CurrentPageProperty);}
            set { SetValue(CurrentPageProperty, value);}
        }

        public static readonly DependencyProperty CurrentPageProperty = 
            DependencyProperty.Register(nameof(CurrentPage), typeof(BasePage), 
                typeof(PageHost), new UIPropertyMetadata(CurrentPagePropertyChanged));

        private static void CurrentPagePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var newPageFrame = (d as PageHost).NewPage;
            var oldPageFrame = (d as PageHost).OldPage;

            var oldPageContent = newPageFrame.Content;

            newPageFrame.Content = null;

            oldPageFrame.Content = oldPageContent;

            if (oldPageContent is BasePage oldPage)
                oldPage.ShouldAnimateOut = true;

            newPageFrame.Content = e.NewValue;
        }

        public PageHost()
        {
            InitializeComponent();
        }
    }
}

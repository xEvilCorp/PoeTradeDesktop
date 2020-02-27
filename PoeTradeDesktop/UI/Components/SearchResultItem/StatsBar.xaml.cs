﻿using PoeTradeDesktop.Schemes.Searching._SearchResultItem._Item;
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

namespace PoeTradeDesktop.UI.Components.SearchResultItem
{

    public partial class StatsBar : UserControl
    {
        public Extended Extended
        {
            get { return (Extended)GetValue(ExtendedProperty); }
            set { SetValue(ExtendedProperty, value); }
        }

        public StatsBar()
        {
            InitializeComponent();
            Loaded += StatsBarLoaded;
        }

        Brush gray = new SolidColorBrush(Color.FromRgb(0x7F, 0x7F, 0x7F));
        Brush darkGray = new SolidColorBrush(Color.FromRgb(0x1D, 0x1C, 0x1C));
        Brush purple = new SolidColorBrush(Color.FromRgb(0x88, 0x88, 0xFF));

        private void StatsBarLoaded(object sender, RoutedEventArgs e)
        {
            if (Extended.Dps != 0) CreateTextBlock("DPS: ", Extended.Dps, Extended.Dps_aug, 0);
            if (Extended.Pdps != 0) CreateTextBlock("P.DPS: ", Extended.Pdps, Extended.Pdps_aug, 1);
            if (Extended.Edps != 0) CreateTextBlock("E.DPS: ", Extended.Edps, Extended.Edps_aug, 2);

            if (Extended.Ar != 0) CreateTextBlock("AR: ", Extended.Ar, Extended.Ar_aug, 0);
            if (Extended.Ev != 0) CreateTextBlock("EV: ", Extended.Ev, Extended.Ev_aug, 1);
            if (Extended.Es != 0) CreateTextBlock("ES: ", Extended.Es, Extended.Es_aug, 2);
        }

        private void CreateTextBlock(string name, float value, bool aug, int pos)
        {
            //Border b = new Border();
            //b.BorderThickness = new Thickness(0, 1, 1, 1);
            //b.BorderBrush = new SolidColorBrush(Color.FromRgb(0x20, 0x20, 0x20));
            //b.BorderBrush = Brushes.Orange;
            //b.CornerRadius = new CornerRadius(0, 5, 5, 0);
            //b.Margin = new Thickness(0, 0, 0, 2);

            TextBlock tb = new TextBlock();
            Run r = new Run();
            r.Text = name;
            r.FontSize = 10;
            r.Foreground = gray;
            tb.Inlines.Add(r);

            Run r2 = new Run();
            r2.Text = value.ToString();
            r2.FontSize = 11;
            r2.Foreground = aug ? purple : Brushes.White;
            r2.FontFamily = new FontFamily("Segoe UI Light");
            tb.Inlines.Add(r2);

            tb.Padding = new Thickness(3, 1, 5, 0);

            tb.MouseEnter += TextBlockMouseEnter;
            tb.MouseLeave += TextBlockMouseLeave;

            //b.Child = tb;

            panel.Children.Add(tb);
        }

        public void TextBlockMouseLeave(object sender, MouseEventArgs e)
        {
            TextBlock tb = ((TextBlock)sender);
            tb.Background = Brushes.Transparent ;
        }

        public void TextBlockMouseEnter(object sender, MouseEventArgs e)
        {
            TextBlock tb = ((TextBlock)sender);
            tb.Background = darkGray;
            tb.Cursor = Cursors.Hand;
        }

        public static readonly DependencyProperty ExtendedProperty = DependencyProperty.Register("Extended", typeof(Extended), typeof(StatsBar));

    }
}

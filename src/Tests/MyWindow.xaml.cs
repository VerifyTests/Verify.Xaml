using System;
using System.Windows;

namespace Tests
{
    public partial class MyWindow : Window
    {
        public MyWindow()
        {
            var uri = new Uri("PresentationFramework.Aero;V3.0.0.0;31bf3856ad364e35;component\\themes/aero.normalcolor.xaml", UriKind.Relative);

            Resources.MergedDictionaries.Add((ResourceDictionary) Application.LoadComponent(uri));
            InitializeComponent();
        }
    }
}
using System;
using System.Windows;
using WPFDanmakuLib;

namespace WPFDanmakuLib_Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WPFDanmakuEngine Engine;
        DanmakuStyle bd;

        Random ra;

        public MainWindow()
        {
            InitializeComponent();
            ra = new Random();
            bd = new DanmakuStyle();
        }

        private void DanmakuRender_Loaded(object sender, RoutedEventArgs e)
        {
            // Bind Canvas to WPFDanmakuLib, and set default danmaku style
            Engine = new WPFDanmakuEngine(
                new EngineBehavior(DrawMode.WPF, CollisionPrevention.Enabled),
                bd, 
                DanmakuRender);
            
            // Draw a R2L danmaku with default style
            Engine.DrawDanmaku("Red Area is Canvas.");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Set a random X position
            bd.PositionX = ra.Next(0, 300);

            // override default danmaku style
            Engine.DrawDanmaku(Utils.GetRandomString(10), bd);
        }
    }
}

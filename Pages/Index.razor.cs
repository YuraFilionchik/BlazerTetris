using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using Microsoft.AspNetCore.Components;
using System.Timers;
using BlazorApp.Components;

namespace BlazorApp.Pages
{
    
    public class IndexModel:ComponentBase
    {
        public Size SizeField;
        public int Level=1;
        public double Interval => 1000 / ((Level * 100) + 900);
       public GameFieldModel Game=GameFieldModel.Game;
        public IndexModel()
        {
            Game=new GameFieldModel();
            SizeField = new Size(300, 600);
            Game.timer = new Timer(Interval);
            Game.timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
           
        }
    }
}

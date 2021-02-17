using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Drawing;

namespace BlazorApp.Components
{
    public class CellComponentmodel : ComponentBase
    {
        [Parameter]
        public int CellSize { get; set; }

        public string content
        {
            get { return PosInField.X + "," + PosInField.Y; }
        }

        [Parameter]
        public bool Empty { get; set; }
        [Parameter]
        public Color CellColor { get; set; }
        [Parameter]
        public Point PosInField { get; set; }
        public string ColorName => CellColor.Name;
       

        public CellComponentmodel()
        {
            CellSize = 0;
            Empty = true;
            CellColor = Color.Transparent;
            PosInField = new Point(0, 0);

        }

       // public void SetContent(int X, int Y)
        //{ content = X.ToString() + "," + Y.ToString();}
        public void SetColor(Color color)
        {   CellColor = color;      }
        public void SetEmpty(bool empty)
        { Empty = empty; }

        public void SetCellSize(int size)
        { CellSize = size; }

        public void SetPosInField(Point point)
        { PosInField = point; }

        public void MoveCell(int X, int Y)
        {
            PosInField = new Point(PosInField.X + X, PosInField.Y + Y);
             
        }
        public static CellComponentmodel CopyCell(CellComponentmodel cell)
        {
            CellComponentmodel result = new CellComponentmodel();
            result.SetCellSize(cell.CellSize);
            result.SetColor(cell.CellColor);
            result.SetEmpty(cell.Empty);
            result.SetPosInField(cell.PosInField);
           // result.SetContent(cell.PosInField.X,cell.PosInField.Y);
            return result;

        }
    }
}
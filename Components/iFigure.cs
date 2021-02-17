using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Components
{
    public interface iFigure
    {
        public CellComponentmodel[] Cells { get; set; }
        public int RotationStatus { get; set; }
        public Color Color { get; set; }

        public CellComponentmodel[] Rotate();
        public CellComponentmodel[] Move(int X,int Y)
        {
            CellComponentmodel[] result = new CellComponentmodel[Cells.Length];

            for (int i = 0; i < Cells.Length; i++)
            {
                result[i] = CellComponentmodel.CopyCell(Cells[i]);
                result[i].MoveCell(X, Y);
            }
            return result;
           
        }
        public static CellComponentmodel[] CopyFigure(CellComponentmodel[] cells)
        {
            CellComponentmodel[] newCells = new CellComponentmodel[cells.Length];
            for (int i = 0; i < cells.Length; i++)
            {
                newCells[i]=CellComponentmodel.CopyCell(cells[i]);
            }
            return newCells;
        }
        
    }
}

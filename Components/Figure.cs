using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Components
{
   
    public class BoxFigure : iFigure
    {
        public CellComponentmodel[] Cells { get; set; }
        public int RotationStatus { get; set; }
        public Color Color { get; set; }
        public BoxFigure(int cellSize)
        {
            RotationStatus = 0;
            Color = Color.LightCoral;
            //start position #4 cell
            Cells = GameField.CreateCells(4, cellSize);            
            Cells[0].SetPosInField(new Point { X = 5, Y = 0 });
            Cells[1].SetPosInField(new Point { X = 6, Y = 0 });
            Cells[2].SetPosInField(new Point { X = 5, Y = 1 });
            Cells[3].SetPosInField(new Point { X = 6, Y = 1 });
            GameField.FillCells(Cells,Color);

        }
        

        public  CellComponentmodel[] Rotate()
        {
            return Cells;
        }
    }
    public class StickFigure : iFigure
    {
        public CellComponentmodel[] Cells { get; set; }
        public int RotationStatus { get; set; }
        public Color Color { get; set; }
        public StickFigure(int cellSize)
        {
            RotationStatus = 0;
            Color = Color.Red;
            //start position #4 cell
            Cells = GameField.CreateCells(4, cellSize);
            Cells[0].SetPosInField(new Point { X = 5, Y = 0 });
            Cells[1].SetPosInField(new Point { X = 5, Y = 1 });
            Cells[2].SetPosInField(new Point { X = 5, Y = 2 });
            Cells[3].SetPosInField(new Point { X = 5, Y = 3 });
            GameField.FillCells(Cells, Color);

        }

        public CellComponentmodel[] Rotate()
        {
            CellComponentmodel[] newCells = iFigure.CopyFigure(Cells);
            
           if(RotationStatus==0 || RotationStatus==180)
            {
                newCells[0].MoveCell(1,1);
                //newCells[1].MoveCell(1, 1);
                newCells[2].MoveCell(-1, -1);
                newCells[3].MoveCell(-2, -2);
            }
            else {//90 or 270
                newCells[0].MoveCell(-1, -1);
                //newCells[1].MoveCell(1, 1);
                newCells[2].MoveCell(1, 1);
                newCells[3].MoveCell(2, 2);
            }
            RotationStatus += 90;
            return newCells;
        }
    }

    public class  CornRFigure : iFigure
    {
        public CellComponentmodel[] Cells { get; set; }
        public int RotationStatus { get; set; }
        public Color Color { get; set; }
        public CornRFigure(int cellSize)
        {
            RotationStatus = 0;
            Color = Color.LightGreen;
            //start position #5 cell
            Cells = GameField.CreateCells(4,cellSize);
            Cells[0].SetPosInField(new Point { X = 5, Y = 0 });
            Cells[1].SetPosInField(new Point { X = 6, Y = 0 });
            Cells[2].SetPosInField(new Point { X = 5, Y = 1 });
            Cells[3].SetPosInField(new Point { X = 5, Y = 2 });
            GameField.FillCells(Cells, Color);

        }


        public CellComponentmodel[] Rotate()
        {
            CellComponentmodel[] newCells = iFigure.CopyFigure(Cells);
            switch(RotationStatus)
            {
                case 0:
                    {
                        newCells[0].MoveCell(1, 1);
                        newCells[1].MoveCell(0, 2);
                       // newCells[2].MoveCell(-1, -1);
                        newCells[3].MoveCell(-1, -1);
                    }
                    break;
                case 90:
                    {
                        newCells[0].MoveCell(-1, 1);
                        newCells[1].MoveCell(-2, 0);
                        // newCells[2].MoveCell(-1, -1);
                        newCells[3].MoveCell(1, -1);

                    }
                    
                    break;
                case 180:
                    {
                        newCells[0].MoveCell(-1, -1);
                        newCells[1].MoveCell(0, -2);
                        // newCells[2].MoveCell(-1, -1);
                        newCells[3].MoveCell(1, 1);
                    }
                    break;
                case 270:
                    {
                        newCells[0].MoveCell(1, -1);
                        newCells[1].MoveCell(2, 0);
                        // newCells[2].MoveCell(-1, -1);
                        newCells[3].MoveCell(-1, 1);
                    }
                    break;
            }

            RotationStatus += 90;
            return newCells;
        }
    }

    public class CornLFigure : iFigure
    {
        public CellComponentmodel[] Cells { get; set; }
        public int RotationStatus { get; set; }
        public Color Color { get; set; }
        public CornLFigure(int cellSize)
        {
            RotationStatus = 0;
            Color = Color.LightYellow;
            //start position #5 cell
            Cells = GameField.CreateCells(4,cellSize);
            Cells[0].SetPosInField(new Point { X = 5, Y = 0 });
            Cells[1].SetPosInField(new Point { X = 6, Y = 0 });
            Cells[2].SetPosInField(new Point { X = 6, Y = 1 });
            Cells[3].SetPosInField(new Point { X = 6, Y = 2 });
            GameField.FillCells(Cells, Color);

        }


        public CellComponentmodel[] Rotate()
        {
            CellComponentmodel[] newCells = iFigure.CopyFigure(Cells);
            switch (RotationStatus)
            {
                case 0:
                    {
                        newCells[0].MoveCell(2, 0);
                        newCells[1].MoveCell(1, 1);
                        // newCells[2].MoveCell(-1, -1);
                        newCells[3].MoveCell(-1, -1);
                    }
                    break;
                case 90:
                    {
                        newCells[0].MoveCell(0, 2);
                        newCells[1].MoveCell(-1, 1);
                        // newCells[2].MoveCell(-1, -1);
                        newCells[3].MoveCell(1, -1);

                    }

                    break;
                case 180:
                    {
                        newCells[0].MoveCell(-2, 0);
                        newCells[1].MoveCell(1, -1);
                        // newCells[2].MoveCell(-1, -1);
                        newCells[3].MoveCell(1, 1);
                    }
                    break;
                case 270:
                    {
                        newCells[0].MoveCell(1, -2);
                        newCells[1].MoveCell(1, -1);
                        // newCells[2].MoveCell(-1, -1);
                        newCells[3].MoveCell(-1, 1);
                    }
                    break;
            }

            RotationStatus += 90;
            return newCells;
        }
    }

    public class CapFigure : iFigure
    {
        public CellComponentmodel[] Cells { get; set; }
        public int RotationStatus { get; set; }
        public Color Color { get; set; }
        public CapFigure(int cellSize)
        {
            RotationStatus = 0;
            Color = Color.LightBlue;
            //start position #5 cell
            Cells = GameField.CreateCells(4,cellSize);
            Cells[0].SetPosInField(new Point { X = 4, Y = 0 });
            Cells[1].SetPosInField(new Point { X = 5, Y = 0 });
            Cells[2].SetPosInField(new Point { X = 6, Y = 0 });
            Cells[3].SetPosInField(new Point { X = 5, Y = 1 });
            GameField.FillCells(Cells, Color);

        }


        public CellComponentmodel[] Rotate()
        {
            CellComponentmodel[] newCells = iFigure.CopyFigure(Cells);
            switch (RotationStatus)
            {
                case 0:
                    {
                        newCells[0].MoveCell(1, -1);
                       // newCells[1].MoveCell(0, 2);
                        newCells[2].MoveCell(-1, 1);
                        newCells[3].MoveCell(-1, -1);
                    }
                    break;
                case 90:
                    {
                        newCells[0].MoveCell(1, 1);
                        //newCells[1].MoveCell(-2, 0);
                        newCells[2].MoveCell(-1, -1);
                        newCells[3].MoveCell(1, -1);

                    }

                    break;
                case 180:
                    {
                        newCells[0].MoveCell(-1, 1);
                        //newCells[1].MoveCell(0, -2);
                        newCells[2].MoveCell(1, -1);
                        newCells[3].MoveCell(1, 1);
                    }
                    break;
                case 270:
                    {
                        newCells[0].MoveCell(-1, -1);
                        //newCells[1].MoveCell(2, 0);
                        newCells[2].MoveCell(1, 1);
                        newCells[3].MoveCell(-1, 1);
                    }
                    break;
            }

            RotationStatus += 90;
            return newCells;
        }
    }

    public class FigureBuilder
    {
        iFigure Figure;
        private int cellSize;
        public FigureBuilder(int cellsize)
        {
            cellSize = cellsize;
        }
        public iFigure BuildRandom()
        {
            int rnd = new Random().Next(0, 4);
            switch (rnd)
            {
                case 0: Figure = new BoxFigure(cellSize);   break;
                case 1: Figure = new StickFigure(cellSize); break;
                case 2: Figure = new CornLFigure(cellSize); break;
                case 3: Figure = new CornRFigure(cellSize); break;
                case 4: Figure = new CapFigure(cellSize);   break;
                default: break;
            }
            return Figure;
        }

    }

}

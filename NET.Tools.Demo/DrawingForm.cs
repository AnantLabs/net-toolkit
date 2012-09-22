using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NET.Tools.Engines.Graphics2D;
using NET.Tools.Engines.Mathematica;
using NET.Tools.OS;



namespace NET.Tools
{
    public partial class DrawingForm : Form
    {
        private const int X = 50;
        private const int Y = 100;

        public DrawingForm()
        {
            InitializeComponent();
        }

        private void DrawingForm_Paint(object sender, PaintEventArgs e)
        {
            ObliqueCube cube = e.Graphics.CreateObliqueCube();
            cube.DarkFaceBrush = Brushes.DarkRed;
            cube.LightFaceBrush = Brushes.Red;
            cube.LineStyle = Pens.Black;
            cube.ObliqueFaceStyle = ObliqueFaceStyle.ShowInvisibleFaces;
            cube.ObliqueLineStyle = ObliqueLineStyle.ShowInvisibleLinesDotted;
            cube.Rectangle = new ObliqueRectangle(30, 30, 100, 100, 50);
            e.Graphics.Draw(DrawStyle.Both, cube);

            DrawableCoordinateSystem coordSys = e.Graphics.CreateCoordinateSystem();
            coordSys.CoordinateSystemArea = new Rectangle(200, 10, 100, 100);
            coordSys.ValueDimension = new Dimension(-5, -5, 5, 5);
            e.Graphics.Draw(DrawStyle.Both, coordSys);

            DrawableGraph graph = e.Graphics.CreateDrawableGraph();
            graph.GraphArea = new Rectangle(200, 10, 100, 100);
            graph.ValueDimension = new Dimension(-5, -5, 5, 5);
            graph.Function = (x) => { return Math.Pow(x * 0.75d, 2) - 4.5d; };
            e.Graphics.Draw(DrawStyle.Lines, graph);

            int y = 150;
            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            {
                int x = 10;
                foreach (CardType type in Enum.GetValues(typeof(CardType)))
                {
                    e.Graphics.DrawCardFace(x, y, suit, type);
                    x += X;
                }

                y += Y;
            }

            int xx = 10;
            foreach (CardDeck deck in Enum.GetValues(typeof(CardDeck)))
            {
                e.Graphics.DrawCardDeck(xx, y, deck);
                xx += X;
            }
        }
    }
}

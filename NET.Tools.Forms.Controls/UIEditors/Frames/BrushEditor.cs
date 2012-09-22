using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace NET.Tools.Forms
{
    internal partial class BrushEditor : Form
    {
        private BrushType Brush_Type
        {
            get { return (BrushType)cmbBrushes.SelectedItem; }
            set { cmbBrushes.SelectedItem = value; }
        }

        private SolidBrush Brush_Solid
        {
            get { return new SolidBrush((Color)btnSolidBrushColor.Tag); }
            set { btnSolidBrushColor.Tag = value; }
        }

        private LinearGradientBrush Brush_LinearGradient
        {
            get
            {
                return new LinearGradientBrush(
                    ParseRectangle(txtLinearGradientRectangle.Text),
                    (Color)btnLinearGradientBrushColor1.Tag,
                    (Color)btnLinearGradientBrushColor2.Tag,
                    txtAngle.Text.ToFloatValue());
            }
            set
            {
                btnLinearGradientBrushColor1.Tag = value.LinearColors[0];
                btnLinearGradientBrushColor2.Tag = value.LinearColors[1];
                txtLinearGradientRectangle.Text = 
                    value.Rectangle.X.ToString() + "|" + 
                    value.Rectangle.Y.ToString() + "|" +
                    value.Rectangle.Width.ToString() + "|" +
                    value.Rectangle.Height.ToString();
            }
        }

        private HatchBrush Brush_Hatch
        {
            get
            {
                return new HatchBrush((HatchStyle)cmbHatches.SelectedItem,
                    (Color)btnHatchBrushColor1.Tag, (Color)btnHatchBrushColor2.Tag);
            }
            set
            {
                cmbHatches.SelectedItem = value.HatchStyle;
                btnHatchBrushColor1.Tag = value.ForegroundColor;
                btnHatchBrushColor2.Tag = value.BackgroundColor;
            }
        }

        public Brush SelectedBrush
        {
            get
            {
                switch (Brush_Type)
                {
                    case BrushType.Solid:
                        return Brush_Solid;
                    case BrushType.LinearGradient:
                        return Brush_LinearGradient;
                    case BrushType.Hatch:
                        return Brush_Hatch;
                    default:
                        throw new NotImplementedException();
                }
            }
            set
            {
                if (value is SolidBrush)
                {
                    Brush_Type = BrushType.Solid;
                    Brush_Solid = value as SolidBrush;
                }
                else if (value is LinearGradientBrush)
                {
                    Brush_Type = BrushType.LinearGradient;
                    Brush_LinearGradient = value as LinearGradientBrush;
                }
                else if (value is HatchBrush)
                {
                    Brush_Type = BrushType.Hatch;
                    Brush_Hatch = value as HatchBrush;
                }
                else
                    throw new NotImplementedException();
            }
        }

        public BrushEditor()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;

            foreach (BrushType type in Enum.GetValues(typeof(BrushType)))
            {
                cmbBrushes.Items.Add(type);
            }
            cmbBrushes.SelectedIndex = 0;

            foreach (HatchStyle hatch in Enum.GetValues(typeof(HatchStyle)))
            {
                cmbHatches.Items.Add(hatch);
            }
            cmbHatches.SelectedIndex = 0;

            btnSolidBrushColor.Tag = Color.Black;
            btnLinearGradientBrushColor1.Tag = Color.White;
            btnLinearGradientBrushColor2.Tag = Color.Black;
            btnHatchBrushColor1.Tag = Color.White;
            btnHatchBrushColor2.Tag = Color.Black;

            txtLinearGradientRectangle.Text = "0|0|100|100";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private RectangleF ParseRectangle(String str)
        {
            try
            {
                String[] parts = str.Trim().Split('|');
                if (parts.Length != 4)
                    return RectangleF.Empty;

                return new RectangleF(
                    parts[0].ToFloatValue(), parts[1].ToFloatValue(),
                    parts[2].ToFloatValue(), parts[3].ToFloatValue());
            }
            catch (Exception)
            {
                return RectangleF.Empty;
            }
        }

        private float ParseFloat(String str)
        {
            try
            {
                return str.ToFloatValue();
            }
            catch (Exception)
            {
                return Single.NaN;
            }
        }

        private void pnlSolidBrushExample_Paint(object sender, PaintEventArgs e)
        {
            if (btnSolidBrushColor.Tag == null)
                return;

            e.Graphics.FillRectangle(Brush_Solid, e.ClipRectangle);
        }

        private void pnlLinearGradientBrushExample_Paint(object sender, PaintEventArgs e)
        {
            if ((btnLinearGradientBrushColor1.Tag == null) ||
                (btnLinearGradientBrushColor2.Tag == null) ||
                (ParseRectangle(txtLinearGradientRectangle.Text) == RectangleF.Empty) ||
                (ParseFloat(txtAngle.Text) == Single.NaN))
                return;

            e.Graphics.FillRectangle(Brush_LinearGradient, e.ClipRectangle);
        }

        private void pnlHatchBrushExample_Paint(object sender, PaintEventArgs e)
        {
            if ((btnHatchBrushColor1.Tag == null) ||
                (btnHatchBrushColor2.Tag == null))
                return;

            e.Graphics.FillRectangle(Brush_Hatch, e.ClipRectangle);
        }

        private void cmbBrushes_SelectedIndexChanged(object sender, EventArgs e)
        {
            grbSolidBrush.Enabled = false;
            grbHatchBrush.Enabled = false;
            grbLinearGradientBrush.Enabled = false;

            switch ((BrushType)cmbBrushes.SelectedItem)
            {
                case BrushType.Solid:
                    grbSolidBrush.Enabled = true;
                    break;
                case BrushType.LinearGradient:
                    grbLinearGradientBrush.Enabled = true;
                    break;
                case BrushType.Hatch:
                    grbHatchBrush.Enabled = true;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void btnSolidBrushColor_Click(object sender, EventArgs e)
        {
            colorDlg.Color = (Color)btnSolidBrushColor.Tag;
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                btnSolidBrushColor.Tag = colorDlg.Color;
                pnlSolidBrushExample.Refresh();
            }
        }

        private void btnLinearGradientBrushColor1_Click(object sender, EventArgs e)
        {
            colorDlg.Color = (Color)btnLinearGradientBrushColor1.Tag;
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                btnLinearGradientBrushColor1.Tag = colorDlg.Color;
                pnlLinearGradientBrushExample.Refresh();
            }
        }

        private void btnLinearGradientBrushColor2_Click(object sender, EventArgs e)
        {
            colorDlg.Color = (Color)btnLinearGradientBrushColor2.Tag;
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                btnLinearGradientBrushColor2.Tag = colorDlg.Color;
                pnlLinearGradientBrushExample.Refresh();
            }
        }

        private void txtPoint1_TextChanged(object sender, EventArgs e)
        {
            pnlLinearGradientBrushExample.Refresh();
        }

        private void txtAngle_TextChanged(object sender, EventArgs e)
        {
            pnlLinearGradientBrushExample.Refresh();
        }

        private void btnHatchBrushColor1_Click(object sender, EventArgs e)
        {
            colorDlg.Color = (Color)btnHatchBrushColor1.Tag;
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                btnHatchBrushColor1.Tag = colorDlg.Color;
                pnlHatchBrushExample.Refresh();
            }
        }

        private void btnHatchBrushColor2_Click(object sender, EventArgs e)
        {
            colorDlg.Color = (Color)btnHatchBrushColor2.Tag;
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                btnHatchBrushColor2.Tag = colorDlg.Color;
                pnlHatchBrushExample.Refresh();
            }
        }

        private void cmbHatches_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlHatchBrushExample.Refresh();
        }
    }

    internal enum BrushType
    {
        Solid = 0,
        LinearGradient = 1,
        Hatch = 2
    }
}

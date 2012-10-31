using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace NET.Tools
{
    public sealed class EditableImage
    {
        #region Static 
        public static Bitmap EditImage(Bitmap bmp, ImageEditEventHandler evt)
        {
            EditableImage img = new EditableImage(bmp);
            img.EditImage(evt);
            return img.Image;
        }
        #endregion

        private int[,] colors;
        public PixelFormat PixelFormat { get; private set; }
        public int Stride { get; private set; }
        public ColorPalette Palette { get; private set; }

        public EditableImage(Bitmap image)
        {
            Image = image;
        }

        public EditableImage(EditableImage image)
        {
            this.colors = image.colors.Clone() as int[,];
            this.PixelFormat = image.PixelFormat;
            this.Stride = image.Stride;
            this.Palette = image.Palette;
        }

        public EditableImage(int width, int height, PixelFormat format)
        {
            colors = new int[width, height];
            PixelFormat = format;

            using (Bitmap bmp = new Bitmap(width, height, format))
            {
                Palette = bmp.Palette;

                BitmapData data = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, format);
                Stride = data.Stride;
                bmp.UnlockBits(data);
            }
        }

        public Color this[int x, int y]
        {
            get { return GetPixel(x, y); }
            set { SetPixel(x, y, value); }
        }

        public Color GetPixel(int x, int y)
        {
            return Color.FromArgb((int)colors[x, y]);
        }

        public void SetPixel(int x, int y, Color color)
        {
            colors[x, y] = color.ToArgb();
        }

        public int Width { get { return colors.GetLength(0); } }
        public int Height { get { return colors.GetLength(1); } }
        public Bitmap Image
        {
            set
            {
                LoadImage(value);
            }
            get
            {
                switch (PixelFormat)
                {
                    case PixelFormat.Alpha:
                        throw new NotSupportedException();
                    case PixelFormat.Canonical:
                        throw new NotSupportedException();
                    case PixelFormat.DontCare:
                        throw new NotSupportedException();
                    case PixelFormat.Extended:
                        throw new NotSupportedException();
                    case PixelFormat.Format16bppArgb1555:
                        throw new NotSupportedException();
                    case PixelFormat.Format16bppGrayScale:
                        throw new NotSupportedException();
                    case PixelFormat.Format16bppRgb555:
                        throw new NotSupportedException();
                    case PixelFormat.Format16bppRgb565:
                        throw new NotSupportedException();
                    case PixelFormat.Format1bppIndexed:
                        break;
                    case PixelFormat.Format24bppRgb:
                        return To24RGB();
                    case PixelFormat.Format32bppArgb:
                        return To32ARGB();
                    case PixelFormat.Format32bppPArgb:
                        throw new NotSupportedException();
                    case PixelFormat.Format32bppRgb:
                        throw new NotSupportedException();
                    case PixelFormat.Format48bppRgb:
                        throw new NotSupportedException();
                    case PixelFormat.Format4bppIndexed:
                        break;
                    case PixelFormat.Format64bppArgb:
                        throw new NotSupportedException();
                    case PixelFormat.Format64bppPArgb:
                        throw new NotSupportedException();
                    case PixelFormat.Format8bppIndexed:
                        break;
                    case PixelFormat.Gdi:
                        throw new NotSupportedException();
                    case PixelFormat.Indexed:
                        throw new NotSupportedException();
                    case PixelFormat.Max:
                        throw new NotSupportedException();
                    case PixelFormat.PAlpha:
                        throw new NotSupportedException();
                    default:
                        throw new NotImplementedException();
                }

                return null;
            }
        }

        public static implicit operator EditableImage(Bitmap bmp)
        {
            return new EditableImage(bmp);
        }

        public static implicit operator Bitmap(EditableImage bmp)
        {
            return bmp.Image;
        }

        public void EditImage(ImageEditEventHandler evt)
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (evt != null)
                    {
                        ImageEditEventArgs args = new ImageEditEventArgs(x, y, this[x,y]);
                        evt(this, args);
                        this[x, y] = args.DestColor;
                    }
                }
            }
        }

        public int[,] ColorArray
        {
            get { return colors; }
            set { colors = value; }
        }

        //*********************************************************
        //*********************************************************
        //*********************************************************

        private void ReadFrom32ARGB(byte[] data)
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    colors[x, y] = Color.FromArgb(
                        data[y * Stride + x * 4 + 3],
                        data[y * Stride + x * 4 + 2],
                        data[y * Stride + x * 4 + 1],
                        data[y * Stride + x * 4 + 0]).ToArgb();
                }
            }
        }

        private void ReadFrom24RGB(byte[] data)
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    colors[x, y] = Color.FromArgb(
                        data[y * Stride + x * 3 + 2],
                        data[y * Stride + x * 3 + 1],
                        data[y * Stride + x * 3 + 0]).ToArgb();
                }
            }
        }

        private void ReadFrom8Indexed(byte[] data)
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    colors[x, y] = Palette.Entries[
                        data[y * Stride + x]].ToArgb();
                }
            }
        }

        private void ReadFrom4Indexed(byte[] data)
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (x % 2 == 0)
                        colors[x, y] = Palette.Entries[
                            LowByte(data[y * Stride + x / 2])].ToArgb();
                    else
                        colors[x, y] = Palette.Entries[
                            HighByte(data[y * Stride + x / 2])].ToArgb();
                }
            }
        }

        private void ReadFrom1Indexed(byte[] data)
        {
            int x, y;
            byte bit;

            for (y = 0; y < Height; y++)
            {
                for (x = 0; x < Width - 8; x += 8)
                {
                    bit = data[y * Stride + x / 8];
                    colors[x + 0, y] = Palette.Entries[(bit & 128) / 128].ToArgb();
                    colors[x + 1, y] = Palette.Entries[(bit & 64) / 64].ToArgb();
                    colors[x + 2, y] = Palette.Entries[(bit & 32) / 32].ToArgb();
                    colors[x + 3, y] = Palette.Entries[(bit & 16) / 16].ToArgb();
                    colors[x + 4, y] = Palette.Entries[(bit & 8) / 8].ToArgb();
                    colors[x + 5, y] = Palette.Entries[(bit & 4) / 4].ToArgb();
                    colors[x + 6, y] = Palette.Entries[(bit & 2) / 2].ToArgb();
                    colors[x + 7, y] = Palette.Entries[(bit & 1) / 1].ToArgb();
                }

                bit = data[y * Stride + x / 8];
                int div = 128;
                for (int i = 0; i < Width % 8; i++)
                {
                    colors[x + i, y] = Palette.Entries[(bit & div) / div].ToArgb();
                    div /= 2;
                }
            }
        }

        private int LowByte(byte b)
        {
            return b & 15;
        }

        private int HighByte(byte b)
        {
            return b >> 4;
        }

        private void LoadImage(Bitmap image)
        {
            PixelFormat = image.PixelFormat;
            Palette = image.Palette;

            BitmapData data = image.LockBits(
                new Rectangle(0, 0, image.Width, image.Height),
                System.Drawing.Imaging.ImageLockMode.ReadOnly,
                image.PixelFormat);
            Stride = data.Stride;
            byte[] imageData = new byte[data.Stride * image.Height];
            System.Runtime.InteropServices.Marshal.Copy(data.Scan0, imageData, 0, imageData.Length);
            image.UnlockBits(data);

            colors = new int[image.Width, image.Height];
            switch (PixelFormat)
            {
                case PixelFormat.Alpha:
                    throw new NotSupportedException();
                case PixelFormat.Canonical:
                    throw new NotSupportedException();
                case PixelFormat.DontCare:
                    throw new NotSupportedException();
                case PixelFormat.Extended:
                    throw new NotSupportedException();
                case PixelFormat.Format16bppArgb1555:
                    throw new NotSupportedException();
                case PixelFormat.Format16bppGrayScale:
                    throw new NotSupportedException();
                case PixelFormat.Format16bppRgb555:
                    throw new NotSupportedException(); 
                case PixelFormat.Format16bppRgb565:
                    throw new NotSupportedException();
                case PixelFormat.Format1bppIndexed:
                    ReadFrom1Indexed(imageData);
                    break;
                case PixelFormat.Format24bppRgb:
                    ReadFrom24RGB(imageData);
                    break;
                case PixelFormat.Format32bppArgb:
                    ReadFrom32ARGB(imageData);
                    break;
                case PixelFormat.Format32bppPArgb:
                    throw new NotSupportedException();
                case PixelFormat.Format32bppRgb:
                    throw new NotSupportedException();
                case PixelFormat.Format48bppRgb:
                    throw new NotSupportedException();
                case PixelFormat.Format4bppIndexed:
                    ReadFrom4Indexed(imageData);
                    break;
                case PixelFormat.Format64bppArgb:
                    throw new NotSupportedException();
                case PixelFormat.Format64bppPArgb:
                    throw new NotSupportedException();
                case PixelFormat.Format8bppIndexed:
                    ReadFrom8Indexed(imageData);
                    break;
                case PixelFormat.Gdi:
                    throw new NotSupportedException();
                case PixelFormat.Indexed:
                    throw new NotSupportedException();
                case PixelFormat.Max:
                    throw new NotSupportedException();
                case PixelFormat.PAlpha:
                    throw new NotSupportedException();
                default:
                    throw new NotImplementedException();
            }
        }

        private Bitmap To24RGB()
        {
            byte[] data = new byte[Stride * Height];

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Color color = Color.FromArgb((int)colors[x, y]);
                    data[y * Stride + x * 3 + 2] = color.R;
                    data[y * Stride + x * 3 + 1] = color.G;
                    data[y * Stride + x * 3 + 0] = color.B;
                }
            }

            Bitmap image = new Bitmap(Width, Height, PixelFormat);
            BitmapData bmpData = image.LockBits(new Rectangle(0, 0, Width, Height),
                ImageLockMode.WriteOnly, PixelFormat);
            System.Runtime.InteropServices.Marshal.Copy(data, 0, bmpData.Scan0, data.Length);
            image.UnlockBits(bmpData);

            return image;
        }

        private Bitmap To32ARGB()
        {
            byte[] data = new byte[Stride * Height];

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Color color = Color.FromArgb((int)colors[x, y]);
                    data[y * Stride + x * 4 + 3] = color.A;
                    data[y * Stride + x * 4 + 2] = color.R;
                    data[y * Stride + x * 4 + 1] = color.G;
                    data[y * Stride + x * 4 + 0] = color.B;
                }
            }

            Bitmap image = new Bitmap(Width, Height, PixelFormat);
            BitmapData bmpData = image.LockBits(new Rectangle(0, 0, Width, Height),
                ImageLockMode.WriteOnly, PixelFormat);
            System.Runtime.InteropServices.Marshal.Copy(data, 0, bmpData.Scan0, data.Length);
            image.UnlockBits(bmpData);

            return image;
        }
    }

    public delegate void ImageEditEventHandler(object sender, ImageEditEventArgs e);

    public class ImageEditEventArgs : EventArgs
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Color SourceColor { get; private set; }
        public Color DestColor { get; set; }

        public ImageEditEventArgs(int x, int y, Color source)
        {
            X = x;
            Y = y;
            SourceColor = source;
            DestColor = source;
        }
    }
}

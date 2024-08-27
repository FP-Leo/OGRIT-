using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace OGRIT_Database_Custom_App.Views.Generics
{
    /// <summary>
    /// Represents a customizable button with rounded corners and configurable border size, radius, and color.
    /// </summary>
    public class RoundButton : Button
    {
        //Fields
        private int borderSize = 0;
        private int borderRadius = 7;
        private Color borderColor = Color.PaleVioletRed;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoundButton"/> class.
        /// </summary>
        public RoundButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Size = new Size(150, 40);
            BackColor = Color.MediumSlateBlue;
            ForeColor = Color.White;
            Resize += new EventHandler(Button_Resize);
        }

        /// <summary>
        /// Handles the Resize event of the button to ensure the border radius does not exceed the button height.
        /// </summary>
        private void Button_Resize(object sender, EventArgs e)
        {
            if (borderRadius > Height)
                borderRadius = Height;
        }

        /// <summary>
        /// Gets or sets the size of the border.
        /// </summary>
        [Category("Custom Settings")]
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                borderSize = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the radius of the button's corners.
        /// </summary>
        [Category("Custom Settings")]
        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                borderRadius = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the button's border.
        /// </summary>
        [Category("Custom Settings")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the background color of the button.
        /// </summary>
        [Category("Custom Settings")]
        public Color BackgroundColor
        {
            get { return BackColor; }
            set { BackColor = value; }
        }

        /// <summary>
        /// Gets or sets the text color of the button.
        /// </summary>
        [Category("Custom Settings")]
        public Color TextColor
        {
            get { return ForeColor; }
            set { ForeColor = value; }
        }

        /// <summary>
        /// Creates a rounded rectangle path based on the specified rectangle and radius.
        /// </summary>
        /// <param name="rect">The rectangle that defines the button's surface.</param>
        /// <param name="radius">The radius of the rounded corners.</param>
        /// <returns>A <see cref="GraphicsPath"/> representing the rounded rectangle.</returns>
        private GraphicsPath GetFigurePath(Rectangle rect, float radius)
        {
            GraphicsPath path = new();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        /// <summary>
        /// Overrides the OnPaint method to customize the appearance of the button.
        /// </summary>
        /// <param name="pevent">A <see cref="PaintEventArgs"/> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            Rectangle rectSurface = ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);
            int smoothSize = 2;
            if (borderSize > 0)
                smoothSize = borderSize;

            if (borderRadius > 2) //Rounded button
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize))
                using (Pen penSurface = new(Parent.BackColor, smoothSize))
                using (Pen penBorder = new(borderColor, borderSize))
                {
                    pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    //Button surface
                    Region = new Region(pathSurface);
                    //Draw surface border for HD result
                    pevent.Graphics.DrawPath(penSurface, pathSurface);

                    //Button border                    
                    if (borderSize >= 1)
                        //Draw control border
                        pevent.Graphics.DrawPath(penBorder, pathBorder);
                }
            }
            else //Normal button
            {
                pevent.Graphics.SmoothingMode = SmoothingMode.None;
                //Button surface
                Region = new Region(rectSurface);
                //Button border
                if (borderSize >= 1)
                {
                    using (Pen penBorder = new(borderColor, borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, Width - 1, Height - 1);
                    }
                }
            }
        }

        /// <summary>
        /// Overrides the OnHandleCreated method to register an event handler for the parent container's BackColorChanged event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
        }

        /// <summary>
        /// Handles the BackColorChanged event of the parent container to refresh the button's appearance.
        /// </summary>
        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}

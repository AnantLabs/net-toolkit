using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX.Direct3D;

namespace NET.Tools.Engines.Graphics3D
{
    /// \addtogroup graphics3d
    /// @{

    /// <summary>
    /// Represent the main graphics object
    /// </summary>
    /// <example>
    /// In this code you can see the using of the engine:
    /// <code>
    /// XmlConfigurator config = new XmlConfigurator();
    /// config.Load("config.xml");
    /// Graphics3D graphics = new Graphics3D(mainForm.Handle, config);
    /// ...
    /// graphics.Dispose();
    /// </code>
    /// </example>
    public sealed class Graphics3D : IDisposable
    {
        private Device d3dx9;
        private GraphicsNode root;
        private IList<Viewport> viewports;

        /// <summary>
        /// Gets the active configuration
        /// </summary>
        public IConfigurator Configuration { get; private set; }

        internal Device D3DX9 { get { return d3dx9; } }

        public Graphics3D(IntPtr targetPtr, IConfigurator config)
        {
            Configuration = config;

            PresentParameters pp = new PresentParameters();
            pp.AutoDepthStencilFormat = DepthFormat.D16;
            pp.BackBufferCount = 1;
            switch (config.ColorDepth)
            {
                case ColorDepth.Bit16:
                    pp.BackBufferFormat = Format.A4R4G4B4;
                    break;
                case ColorDepth.Bit32:
                    pp.BackBufferFormat = Format.A8R8G8B8;
                    break;
                default:
                    throw new NotImplementedException();
            }
            pp.BackBufferHeight = (int)config.ScreenHeight;
            pp.BackBufferWidth = (int)config.ScreenWidth;
            pp.EnableAutoDepthStencil = config.StencilEnabled;
            if (!config.AntiAlaisingEnabled)
                pp.MultiSample = MultiSampleType.None;
            else
                pp.MultiSample = (MultiSampleType)config.AntiAlaisingQuality;
            pp.PresentationInterval = (PresentInterval)config.RefreshInterval;
            pp.SwapEffect = SwapEffect.Discard;
            pp.Windowed = config.FullScreen;

            d3dx9 = new Device(0, DeviceType.Hardware, targetPtr, 
                CreateFlags.SoftwareVertexProcessing, pp);

            root = new GraphicsNode("ROOT");
            viewports = new List<Viewport>();
        }

        private void Clean()
        {
            d3dx9.Clear(ClearFlags.Target | ClearFlags.ZBuffer, 0, 1.0f, 0);
            d3dx9.BeginScene();
        }

        private void Present()
        {
            d3dx9.EndScene();
            d3dx9.Present();
        }

        private void Draw()
        {
            foreach (Viewport vp in viewports)
            {
                vp.SetViewport(this);
                root.Render(this);
            }
        }

        /// <summary>
        /// Render one image
        /// </summary>
        public void Render()
        {
            if (viewports.Count <= 0)
                throw new InvalidOperationException("Cannot render to target: No viewport is defined!");

            Clean();
            Draw();
            Present();
        }

        #region Nodes

        /// <summary>
        /// Add a graphical node
        /// </summary>
        /// <param name="node">Node to add</param>
        public void AddNode(GraphicsNode node)
        {
            root.Children.Add(node);
        }

        /// <summary>
        /// Remove a graphical node
        /// </summary>
        /// <param name="node">node to remove</param>
        private void RemoveNode(GraphicsNode node)
        {
            root.Children.Remove(node);
        }

        /// <summary>
        /// Remove a graphical node
        /// </summary>
        /// <param name="name">name of node to remove</param>
        public void RemoveNode(String name)
        {
            RemoveNode(FindFirstNode(name));
        }

        private bool ContainsNode(String name)
        {
            return FindFirstNode(name) != null;
        }

        /// <summary>
        /// Find the first graphical node with the given name
        /// </summary>
        /// <param name="name">Name to search</param>
        /// <returns>The first graphical node or NULL if it does not exist</returns>
        public GraphicsNode FindFirstNode(String name)
        {
            return root.Children.FindFirst(name);
        }

        #endregion

        #region Viewports

        /// <summary>
        /// Add a viewport
        /// </summary>
        /// <param name="viewport">Viewport to add</param>
        public void AddViewport(Viewport viewport)
        {
            viewports.Add(viewport);
        }

        private void RemoveViewport(Viewport viewport)
        {
            viewports.Remove(viewport);
        }

        /// <summary>
        /// Remove a viewport by name
        /// </summary>
        /// <param name="name">Name of viewport to remove</param>
        public void RemoveViewport(String name)
        {
            RemoveViewport(FindFirstViewport(name));
        }

        public bool ContainsViewport(String name)
        {
            return FindFirstViewport(name) != null;
        }

        /// <summary>
        /// Find the first viewport with the given name
        /// </summary>
        /// <param name="name">Name of viewport to search</param>
        /// <returns>First viewport with the given name or NULL if no viewport was found</returns>
        public Viewport FindFirstViewport(String name)
        {
            foreach (Viewport vp in viewports)
                if (vp.Name.Equals(name))
                    return vp;

            return null;
        }

        #endregion

        #region IDisposable Member

        public void Dispose()
        {
            d3dx9.Dispose();
        }

        #endregion
    }

    /// @}
}

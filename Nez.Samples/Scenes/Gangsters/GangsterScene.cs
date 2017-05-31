using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez.Tiled;
using Nez.Tweens;
using Nez.UI;


namespace Nez.Samples
{
    public class GangsterScene : Scene, IFinalRenderDelegate
    {
        public const int SCREEN_SPACE_RENDER_LAYER = 999;
        public UICanvas canvas;

        Table _table;
        List<Button> _sceneButtons = new List<Button>();
        ScreenSpaceRenderer _screenSpaceRenderer;


        public GangsterScene()
        {
            // setup one renderer in screen space for the UI and then (optionally) another renderer to render everything else

            _screenSpaceRenderer = new ScreenSpaceRenderer(100, SCREEN_SPACE_RENDER_LAYER);
            _screenSpaceRenderer.shouldDebugRender = false;
            finalRenderDelegate = this;

            addRenderer(new RenderLayerExcludeRenderer(0, SCREEN_SPACE_RENDER_LAYER));

            // create our canvas and put it on the screen space render layer
            canvas = createEntity("ui").addComponent(new UICanvas());
            canvas.isFullScreen = true;
            canvas.renderLayer = SCREEN_SPACE_RENDER_LAYER;
            setupSceneSelector();
        }


        void setupSceneSelector()
        {
            _table = canvas.stage.addElement(new Table());
            _table.setFillParent(true).right().top();

            var topButtonStyle = new TextButtonStyle(new PrimitiveDrawable(Color.Black, 10f), new PrimitiveDrawable(Color.Yellow), new PrimitiveDrawable(Color.DarkSlateBlue))
            {
                downFontColor = Color.Black
            };
            _table.add(new TextButton("Toggle Scene List", topButtonStyle)).setFillX().setMinHeight(30).getElement<Button>().onClicked += onToggleSceneListClicked;

            _table.row().setPadTop(10);
            var checkbox = _table.add(new CheckBox("Debug Render", new CheckBoxStyle
            {
                checkboxOn = new PrimitiveDrawable(30, Color.Green),
                checkboxOff = new PrimitiveDrawable(30, new Color(0x00, 0x3c, 0xe7, 0xff))
            })).getElement<CheckBox>();
            checkbox.onChanged += enabled => Core.debugRenderEnabled = enabled;
            checkbox.isChecked = Core.debugRenderEnabled;
            _table.row().setPadTop(30);

            var buttonStyle = new TextButtonStyle(new PrimitiveDrawable(new Color(78, 91, 98), 10f), new PrimitiveDrawable(new Color(244, 23, 135)), new PrimitiveDrawable(new Color(168, 207, 115)))
            {
                downFontColor = Color.Black
            };

            var button = _table.add(new TextButton("name", buttonStyle)).setFillX().setMinHeight(30).getElement<TextButton>();
            _sceneButtons.Add(button);
            button.onClicked += butt =>
            {
                // stop all tweens in case any demo scene started some up
                TweenManager.stopAllTweens();
            };

            _table.row().setPadTop(10);
        }


        void onToggleSceneListClicked(Button butt)
        {
            foreach (var button in _sceneButtons)
                button.setIsVisible(!button.isVisible());
        }

        public Scene scene { get; set; }

        public void onAddedToScene()
        { }


        public void onSceneBackBufferSizeChanged(int newWidth, int newHeight)
        {
            _screenSpaceRenderer.onSceneBackBufferSizeChanged(newWidth, newHeight);
        }


        public void handleFinalRender(Color letterboxColor, Microsoft.Xna.Framework.Graphics.RenderTarget2D source, Rectangle finalRenderDestinationRect, Microsoft.Xna.Framework.Graphics.SamplerState samplerState)
        {
            Core.graphicsDevice.SetRenderTarget(null);
            Core.graphicsDevice.Clear(letterboxColor);
            Graphics.instance.batcher.begin(BlendState.Opaque, samplerState, DepthStencilState.None, RasterizerState.CullNone, null);
            Graphics.instance.batcher.draw(source, finalRenderDestinationRect, Color.White);
            Graphics.instance.batcher.end();

            _screenSpaceRenderer.render(scene);
        }


        public override void initialize()
        {
            var width = 768;
            var height = 468;


            setDesignResolution(width, height, Scene.SceneResolutionPolicy.ShowAllPixelPerfect);
            Screen.setSize(width * 2, height * 2);


            var tiledEntity = createEntity("tiled-map-entity");
            var mapTex = content.Load<Texture2D>(Content.Gangsters.map);
            var tiledMapComponent = tiledEntity.addComponent(new CustomMapComponent(mapTex));

            camera.position = new Vector2(width / 2, height / 2 - 36);
            clearColor = Color.Black;

            //            var playerEntity = createEntity("player", new Vector2(100, 100));
            //            playerEntity.addComponent(new UtilityMiner());
        }
    }
}


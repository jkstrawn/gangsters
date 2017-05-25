using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez.Sprites;


namespace Nez.Samples
{
	[SampleScene( "AI", 120, "" )]
	public class AIScene : SampleScene
	{
		public override void initialize()
		{
			addRenderer( new DefaultRenderer() );


            //createEntity( "miner" )
            //	.addComponent<BehaviorTreeMiner>();

            //createEntity( "utility-miner" )
            //	.addComponent<UtilityMiner>();

            //createEntity( "goap-miner" )
            //	.addComponent<GOAPMiner>();

		    var width = 768;
		    var height = 468;

            setDesignResolution(width, height, Scene.SceneResolutionPolicy.ShowAllPixelPerfect);
            Screen.setSize(width * 2, height * 2);


            var tiledEntity = createEntity("tiled-map-entity");
            var mapTex = content.Load<Texture2D>(Content.Gangsters.map);
            var tiledMapComponent = tiledEntity.addComponent(new CustomMapComponent(mapTex));

            var playerEntity = createEntity("player", new Vector2(100, 100));
            playerEntity.addComponent(new UtilityMiner());

            createEntity("ai-ui")
                .addComponent<AIUI>();

            camera.position = new Vector2(width / 2, height / 2 - 36);
            clearColor = Color.Black;
        }
	}
}


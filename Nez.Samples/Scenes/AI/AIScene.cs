using System;
using Microsoft.Xna.Framework.Graphics;


namespace Nez.Samples
{
	[SampleScene( "AI", 120, "" )]
	public class AIScene : SampleScene
	{
		public override void initialize()
		{
			addRenderer( new DefaultRenderer() );

			//createEntity( "ai-ui" )
			//	.addComponent<AIUI>();

			//createEntity( "miner" )
			//	.addComponent<BehaviorTreeMiner>();

			//createEntity( "utility-miner" )
			//	.addComponent<UtilityMiner>();

			//createEntity( "goap-miner" )
			//	.addComponent<GOAPMiner>();



            setDesignResolution(768, 432, Scene.SceneResolutionPolicy.ShowAllPixelPerfect);
            Screen.setSize(768 * 2, 448 * 2);


            var tiledEntity = createEntity("tiled-map-entity");
            var mapTex = content.Load<Texture2D>(Content.NinjaAdventure.Map.map);
            var tiledMapComponent = tiledEntity.addComponent(new CustomMapComponent(mapTex));
        }
	}
}


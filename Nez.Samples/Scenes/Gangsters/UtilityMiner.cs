using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez.AI.UtilityAI;
using Nez.Sprites;


namespace Nez.Samples
{
    /// <summary>
    /// Utility AI example of miner bob. Utility AI is the most complex of all the AI types to setup. The complexity comes with a lot of power
    /// though.
    /// </summary>
    public class UtilityMiner : Component, IUpdatable
    {
        UtilityAI<UtilityMiner> _ai;


        public override void onAddedToEntity()
        {

            var texture = entity.scene.content.Load<Texture2D>(Content.Gangsters.person);
            entity.addComponent(new Sprite(texture));

            enabled = true;
            

        }


        public void update()
        {
            //_ai.tick();
        }
     

        public void goToLocation()
        {
        }

    }
}

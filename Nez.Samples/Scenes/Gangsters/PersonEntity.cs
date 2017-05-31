using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez.Sprites;

namespace Nez.Samples
{
    public class PersonEntity : Component, IUpdatable
    {
        public PersonEntity()
        {

        }

        public override void onAddedToEntity()
        {
            var texture = entity.scene.content.Load<Texture2D>(Content.Gangsters.person);
            entity.addComponent(new Sprite(texture));
        }

        void IUpdatable.update()
        {
            var x = entity.position.X;
            var y = entity.position.Y;

            entity.position = new Vector2(x += 1f, y += 1f);
        }
    }
}
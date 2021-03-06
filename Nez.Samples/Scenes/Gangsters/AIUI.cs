﻿using Nez.UI;


namespace Nez.Samples
{
	/// <summary>
	/// component that displays a simple UI to enable/disable the different AI types
	/// </summary>
	public class AIUI : UICanvas
	{
		public override RectangleF bounds { get { return new RectangleF( 0, 0, 200, 200 ); } }
        public int ScreenWidth { get; set; }
        public int ScreenHeight { get; set; }
        
		UtilityMiner _utilityMiner;

	    public AIUI(int width, int height)
	    {
	        ScreenWidth = width;
	        ScreenHeight = height;
	    }

		public override void onAddedToEntity()
		{
			base.onAddedToEntity();

			// setup a Skin and a Table for our UI
			var skin = Skin.createDefaultSkin();
			var table = stage.addElement( new Table() );
			table.defaults().setMinWidth( 170 ).setMinHeight( 30 );
			table.setFillParent( true ).center();

			// add a button for each of the actions/AI types we need
			table.add( new TextButton( "BT: LowerPriority Abort Tree", skin ) )
				 .getElement<TextButton>()
				 .onClicked += onClickBtLowerPriority;
			table.row();
		    table.setPosition(0, ScreenHeight / 2 * -1 - 17);
			//table.row().setPadTop( 40 );

            var dialogue = stage.addElement(new Dialog("Testing", skin));
		    dialogue.addText("This is some text being shown");
            dialogue.setVisible(false);

		    var text = stage.addElement(new TextField("Money: $400", skin));
		    //text.setAlignment(Align.topLeft);
            

			// fetch our different AI Components
			_utilityMiner = entity.scene.findComponentOfType<UtilityMiner>();
		}


		#region button click handlers

		void onClickBtLowerPriority( Button button )
		{
			Debug.log( "------ Enabled Behavior Tree LowerPriority Abort ------" );
			disableAllAI();
		}


		void onClickBtSelfAbort( Button button )
		{
			Debug.log( "------ Enabled Behavior Tree Self Abort ------" );
			disableAllAI();
		}


		void onClickUtilityAI( Button button )
		{
			Debug.log( "------ Enabled Utility AI ------" );
			disableAllAI();
			_utilityMiner.setEnabled( true );
		}


		void onClickGoap( Button button )
		{
			Debug.log( "------ Enabled GOAP ------" );
			disableAllAI();
		}


		void onClickStopAllAi( Button button )
		{
			disableAllAI();
		}


		void disableAllAI()
		{
			_utilityMiner.setEnabled( false );		
		}

		#endregion

	}
}


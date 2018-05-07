using System.Diagnostics;
using System.Runtime.Remoting.Messaging;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Monogame_Engine.Engine;
using Monogame_Engine.Engine.Mesh;
using Monogame_Engine.Engine.Renderer;

namespace LevelEditor
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Main : Game
    {
        private readonly GraphicsDeviceManager mGraphics;

        private readonly Camera mCamera;
        private readonly Scene mScene;
        private readonly Light mLight;
        private readonly RenderTarget mRenderTarget;

        private MasterRenderer mMasterRenderer;


        private Mesh mMesh;
        private Actor mActor;



        public Main()
        {
            mGraphics = new GraphicsDeviceManager(this);

            // You have to set the graphics profile to HiDef in every project
            // to use custom shader
            mGraphics.GraphicsProfile = GraphicsProfile.HiDef;

            mCamera = new Camera(fieldOfView: 55.0f, aspectRatio: 2.0f, nearPlane: 1.0f, farPlane: 200.0f);
            mCamera.UpdatePerspective();

            mScene = new Scene();
            mLight = new Light();

            mRenderTarget = new RenderTarget(mGraphics.GraphicsDevice, 1920, 1080, 4096);

            mScene.Add(mLight);

            Content.RootDirectory = "Content";
          
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            

            // TODO: use this.Content to load your game content here
            Model model = Content.Load<Model>("blabla");
            mMesh = new Mesh(model);

            mActor = new Actor(mMesh);
            mActor.mModelMatrix = Matrix.CreateTranslation(1.0f, 2.0f, 2.0f);

            mMasterRenderer = new MasterRenderer(mGraphics.GraphicsDevice, Content);

            /*
            for (uint i = 0; i < 1000; i++)
            {
                Actor actor = new Actor(mMesh);
                actor.mMesh = Matrix.CreateTranslation(2.0f, 2.0f, 2.0f);
                mScene.Add(actor);
            }
            */

            mScene.Add(mActor);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            mCamera.UpdateView();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            
            mCamera.mLocation = new Vector3(0.0f, 0.0f, -10.0f);

            mMasterRenderer.Render(mRenderTarget, mCamera, mScene);

            base.Draw(gameTime);
        }
    }
}

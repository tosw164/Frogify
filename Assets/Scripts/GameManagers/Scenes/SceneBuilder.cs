using System;

namespace POCC.Scenes {
    public class SceneBuilder {

        private Scene _scene;

        public SceneBuilder(SceneType sceneType) : this(new Scene(sceneType, null)) {

        }

        public SceneBuilder(SceneType sceneType, string sceneLocation) : this(new Scene(sceneType, sceneLocation)) {

        }

        public SceneBuilder(Scene scene) {
            _scene = scene;
        }

        public Scene build() {
            return _scene;
        }

        public SceneBuilder setLocation(string sceneLocation) {
            Action startupHooks = _scene.getStartupHooks();
            Action teardownHooks = _scene.getTeardownHooks();

            _scene = new Scene(_scene.getSceneType(), sceneLocation);

            _scene.appendStartupHook(startupHooks);
            _scene.appendTeardownHook(teardownHooks);

            return this;
        }

        // Custom builder methods here, make sure they return this (SceneBuilder)

        public SceneBuilder appendStartupHook(Action hook) {
            _scene.appendStartupHook(hook);

            return this;
        }

        public SceneBuilder appendTeardownHook(Action hook) {
            _scene.appendTeardownHook(hook);

            return this;
        }
    }
}

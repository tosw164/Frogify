using System;

namespace POCC {
	public class Scene {
		protected Action _startupHooks;
		protected Action _teardownHooks;

		protected string _sceneLocation;

		protected SceneType _sceneType;

		public Scene() {
			_startupHooks = startupHookBase;
			_teardownHooks = teardownHookBase;
		}

		protected void startupHookBase() {
		}

		protected void teardownHookBase() {
		}

		public string getLocation() {
			return _sceneLocation;
		}

		public Action getStartupHooks() {
			return _startupHooks;
		}

		public Action getTeardownHooks() {
			return _teardownHooks;
		}

		public void prependStartupHook(Action hook) {
			_startupHooks = hook + _startupHooks;
		}

		public void appendStartupHook(Action hook) {
			_startupHooks = _startupHooks + hook;
		}

		public void prependTeardownHook(Action hook) {
			_teardownHooks = hook + _teardownHooks;
		}

		public void appendTeardownHook(Action hook) {
			_teardownHooks = _teardownHooks + hook;
		}
	}
}

// http://pastebin.com/UPzuCUM4
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FungusTrigger : MonoBehaviour {

	[System.Serializable]
	public class Broadcast {
		public string messageToSend = "";
		public void Trigger() { Fungus.Flowchart.BroadcastFungusMessage (messageToSend); }
	}

	[Tooltip("broadcast a message to Fungus, which can start Fungus scripts")]
	public Broadcast[] broadcast;

	public static Fungus.Variable FindVariable(Fungus.Flowchart flowchart, string variableName) {
		List<Fungus.Variable> vars = flowchart.Variables;
		for (int i = 0; i < vars.Count; ++i) {
			if (vars [i].Key == variableName) { return vars [i]; }
		}
		return null;
	}

	public static Fungus.Flowchart FindFlowchartWithVariable(string variableName, out Fungus.Variable foundVariable) {
		Fungus.Flowchart flowchart = null;
		Fungus.Flowchart[] flows = GameObject.FindObjectsOfType<Fungus.Flowchart> ();
		foundVariable = null;
		for (var f=0;f<flows.Length && foundVariable == null;++f) {
			flowchart = flows [f]; // check to see if the variable in question is in this flowchart
			foundVariable = FindVariable(flowchart, variableName);
		}
		if (!flowchart) { Debug.LogError ("Could not find flowchart with variable \""+variableName+"\""); }
		return flowchart;
	}

	[System.Serializable]
	public class SetStringVariable {
		public string variableName, variableValue;
		[Tooltip("will automagically find a Fungus flowchart if none is given")]
		public Fungus.Flowchart flowchart;
		public void Trigger() {
			Fungus.Variable v = null;
			if (!flowchart) { flowchart = FindFlowchartWithVariable (variableName, out v); } else { v = FindVariable (flowchart, variableName); }
			if (v.GetType() == typeof(Fungus.StringVariable)) { flowchart.SetStringVariable (variableName, variableValue); }
			if (v.GetType() == typeof(Fungus.FloatVariable)) { flowchart.SetFloatVariable (variableName, System.Single.Parse(variableValue)); }
			if (v.GetType() == typeof(Fungus.IntegerVariable)) { flowchart.SetIntegerVariable (variableName, System.Int32.Parse(variableValue)); }
			if (v.GetType() == typeof(Fungus.BooleanVariable)) { flowchart.SetBooleanVariable (variableName, (variableValue != "" && variableValue != "0" && variableValue.ToLower() != "false")); }
		}
	}
	public SetStringVariable[] setVariable;

	[System.Serializable]
	public class AddToVariable {
		public string variableName, variableValue;
		[Tooltip("will automagically find a Fungus flowchart if none is given")]
		public Fungus.Flowchart flowchart = null;
		public void Trigger() {
			Fungus.Variable v = null;
			if (!flowchart) { flowchart = FindFlowchartWithVariable (variableName, out v); } else { v = FindVariable (flowchart, variableName); }
			if (v.GetType() == typeof(Fungus.StringVariable)) { flowchart.SetStringVariable (variableName, flowchart.GetStringVariable(variableName)+variableValue); }
			if (v.GetType() == typeof(Fungus.FloatVariable)) { flowchart.SetFloatVariable (variableName, flowchart.GetFloatVariable(variableName)+System.Single.Parse(variableValue)); }
			if (v.GetType() == typeof(Fungus.IntegerVariable)) { flowchart.SetIntegerVariable (variableName, flowchart.GetIntegerVariable(variableName)+System.Int32.Parse(variableValue)); }
			if (v.GetType() == typeof(Fungus.BooleanVariable)) { flowchart.SetBooleanVariable (variableName, !flowchart.GetBooleanVariable(variableName)); }
		}
	}
	public AddToVariable[] addToVariable;

	[Tooltip("Only triggered by an object with one of these tags, or any object if left blank")]
	public string[] tagsThatCanTrigger;

	[Tooltip("Disables after triggering once")]
	public bool onlyTriggerOnce = false;

	/// <summary>Trigger this instance</summary>
	public void Trigger() {
		if (this.enabled) {
			if (setVariable!=null)  { System.Array.ForEach (setVariable,   (i) => { i.Trigger(); }); }
			if (addToVariable!=null){ System.Array.ForEach (addToVariable, (i) => { i.Trigger(); }); }
			if (broadcast!=null)    { System.Array.ForEach (broadcast,     (i) => { i.Trigger(); }); }
			if (onlyTriggerOnce) { this.enabled = false; }
		}
	}

	private bool IsTaggedCorrectly(GameObject go) { 
		return tagsThatCanTrigger.Length == 0 || System.Array.IndexOf(tagsThatCanTrigger, go.tag) >= 0;
	}

	void OnTriggerEnter (Collider other) { 
		if(IsTaggedCorrectly(other.gameObject)) { Trigger(); }
	}

	void OnCollisionEnter(Collision collision) {
		if(IsTaggedCorrectly(collision.gameObject)) { Trigger(); }
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {
		if(IsTaggedCorrectly(hit.collider.gameObject)) { Trigger(); }
	}

	/// <summary>list of rigid bodies stopped in time</summary>
	private static Rigidbody[] bodies_s = null;
	private static List<MonoBehaviour> temporarilyDisabled_s = null;

	/// <summary>keep track of an object's physics info</summary>
	private struct Freeze {
		public Vector3 v;
		public Freeze(Rigidbody rb){
			v=rb.velocity;
			if(!rb.GetComponent<CharacterController>())
				rb.isKinematic=true;
		}
		public void Unfreeze(Rigidbody rb) {
			rb.velocity=v;
			if(!rb.GetComponent<CharacterController>())
				rb.isKinematic=false;
		}
	}

	/// <summary>list of velocities, saved before the objects are halted.</summary>
	private static Freeze[] snapshot_s = null;

	/// <returns><c>true</c> if the physics is frozen; otherwise, <c>false</c>.</returns>
	public static bool IsStopped() { return snapshot_s != null; }

	public void TogglePause() { TogglePause_s (); }
	public void PauseEverything() { PauseEverything_s (); }
	public void UnpauseEverything() { UnpauseEverything_s (); }

	public static void PauseEverything_s() {
		if (IsStopped ()) return;
		bodies_s = GameObject.FindObjectsOfType<Rigidbody> ();
		snapshot_s = new Freeze[bodies_s.Length];
		for (int i = 0; i < bodies_s.Length; ++i) {
			snapshot_s [i] = new Freeze(bodies_s [i]);
		}
		// disable all active components on CharacterControllers
		CharacterController[] charControllers_s = GameObject.FindObjectsOfType<CharacterController> ();
		temporarilyDisabled_s = new List<MonoBehaviour> ();
		for (int i = 0; i < charControllers_s.Length; ++i) {
			if (charControllers_s [i].enabled) {
				MonoBehaviour[] list = charControllers_s [i].GetComponents<MonoBehaviour> ();
				for(int c=0;c<list.Length;++c) {
					if (list [c].enabled) {
						list [c].enabled = false;
						temporarilyDisabled_s.Add (list [c]);
					}
				}
			}
		}
	}

	public static void UnpauseEverything_s() {
		if (!IsStopped ()) return;
		for (int i = 0; i < bodies_s.Length; ++i) {
			if (bodies_s [i] != null) {
				snapshot_s [i].Unfreeze(bodies_s [i]);
			}
		}
		// re-enable components on CharacterControllers
		for (int i = 0; i < temporarilyDisabled_s.Count; ++i) {
			temporarilyDisabled_s [i].enabled = true;
		}
		snapshot_s = null;
		bodies_s = null;
		temporarilyDisabled_s = null;
	}

	/// <summary>Toggles the rigibdody physics and character controllers.</summary>
	public static void TogglePause_s() {
		if(IsStopped()) {
			UnpauseEverything_s ();
		} else {
			PauseEverything_s ();
		}
	}
}
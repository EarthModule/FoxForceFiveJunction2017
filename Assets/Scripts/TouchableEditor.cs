// Touchable_Editor component, to prevent treating the component as a Text object.

using UnityEditor;


public class TouchableEditor : Editor
{
	public override void OnInspectorGUI ()
	{
		// Do nothing
	}
}
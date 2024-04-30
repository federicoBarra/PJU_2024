using UnityEngine;

//[CreateAssetMenu(fileName = "ConfigSingleton", menuName = "My SOs/ConfigSingleton")]
public class ConfigSingleton<T> : ScriptableObject where T : ScriptableObject
{
	private static T _instance;

	public static T Get()
	{
		if (_instance == null)
		{
			_instance = Resources.Load<T>(typeof(T).Name);
			(_instance as ConfigSingleton<T>)?.OnFirstLoad();
		}
		return _instance;
	}

	public virtual void OnFirstLoad() { }
}

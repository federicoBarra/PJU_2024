using UnityEngine;

namespace nullbloq
{
	/// <summary>
	/// Base class for MonoBehaviourSingleton
	/// </summary>
	public class BehaviourSingleton : MonoBehaviour
	{
		/// <summary>
		/// Indicates if the singleton should persist between scenes.
		/// </summary>
		public bool persistent = false;

		public void TrySetDontDestroyOnLoad()
		{
			if (persistent)
			{
				if (transform.parent != null)
					transform.SetParent(null);
				DontDestroyOnLoad(this);
			}
		}

		public virtual void TryInitialize() { }
		public virtual void TryFinalize() { }
	}

	/// <summary>
	/// Be aware this will not prevent a non singleton constructor
	///   such as `T myT = new T();`
	/// To prevent that, add `protected T () {}` to your singleton class.
	/// 
	/// As a note, this is made as MonoBehaviour because we need Coroutines.
	/// </summary>
	public class MonoBehaviourSingleton<T> : BehaviourSingleton where T : BehaviourSingleton
	{
		/// <summary>
		/// The static reference to the instance
		/// </summary>
		public static T Instance { get; private set; } = null;

		public static T Get() { return Instance; }

#if UNITY_EDITOR
		public static T Find()
		{
			if (!Application.isPlaying)
				Instance = (T)FindObjectOfType(typeof(T));
			return Instance;
		}
#endif

		/// <summary>
		/// Indicates if the singleton exists or was properly initialized.
		/// </summary>
		public static bool Exists { get { return Instance != null; } }
		public static DerivedType Get<DerivedType>() where DerivedType : T { return Get() as DerivedType; }

		protected virtual void Awake()
		{
			TryInitialize();
		}

		protected virtual void OnDestroy()
		{
			TryFinalize();
		}

		/// <summary>
		/// Allows to initialize this singleton externally (probably to ensure a initialization order).
		/// </summary>
		public override void TryInitialize()
		{
			if (Instance == null)
			{
				Instance = this as T;
				TrySetDontDestroyOnLoad();
				OnInitialized();
			}
			else if (Instance != this)
				Destroy(gameObject);
		}

		/// <summary>
		/// Allows to finalize this singleton externally (probably to ensuer a finalization order).
		/// </summary>
		public override void TryFinalize()
		{
			if (this == Instance)
			{
				OnFinalized();
				Instance = null;
			}
		}

		public virtual void OnInitialized() { }
		public virtual void OnFinalized() { }
	}
}
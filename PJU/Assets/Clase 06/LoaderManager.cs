using System;
using System.Collections;
using nullbloq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoaderManager : MonoBehaviour
{
	private static LoaderManager instance;

	public float loadingProgress;
    public float timeLoading;
    public float fakeLoadTime = 2;

    public static event Action<LoaderManager> OnLoadingStart;
    public static event Action<LoaderManager> OnLoadingEnd;

    public static LoaderManager Get()
    {
	    return instance;
    }

    void Awake()
    {
	    if (instance != null)
	    {
		    Destroy(gameObject);
	    }
	    else
	    {
		    instance = this;
		}
    }

    public void LoadScene(string sceneName, float fakeTime = -1)
    {
		//Debug.Log("Load Scene: " + sceneName + " => " + loadType);

        fakeTime = fakeTime < 0.01f ? fakeLoadTime : fakeTime;

        StartCoroutine(AsynchronousLoadWithFake(sceneName, fakeTime));
		
    }

    IEnumerator AsynchronousLoad(string scene)
    {
        OnLoadingStart?.Invoke(this);

        loadingProgress = 0;

        yield return null;

        AsyncOperation ao = SceneManager.LoadSceneAsync(scene);
        ao.allowSceneActivation = false;

        while (!ao.isDone)
        {
            loadingProgress = ao.progress + 0.1f;

            // Loading completed
            if (ao.progress >= 0.9f)
            {
                ao.allowSceneActivation = true;
            }

            yield return null;
        }
        OnLoadingEnd?.Invoke(this);
    }

    IEnumerator AsynchronousLoadWithFake(string scene, float fakeTime)
    {
        OnLoadingStart?.Invoke(this);

        //Debug.Log("AsynchronousLoadWithFake");

		loadingProgress = 0;
        timeLoading = 0;
        yield return null;

        AsyncOperation ao = SceneManager.LoadSceneAsync(scene);
        ao.allowSceneActivation = false;

        while (!ao.isDone)
        {
            timeLoading += Time.unscaledDeltaTime;
            //Debug.Log("Time.deltaTime: " + Time.unscaledDeltaTime);
			loadingProgress = ao.progress + 0.1f;
            loadingProgress = loadingProgress * timeLoading / fakeTime;
            //Debug.Log("loadingProgress: " + loadingProgress + " => " + timeLoading + " => " + fakeTime);

			// Loading completed
			if (loadingProgress >= 1)
            {
                ao.allowSceneActivation = true;
            }

            yield return null;
        }
        OnLoadingEnd?.Invoke(this);
    }
}

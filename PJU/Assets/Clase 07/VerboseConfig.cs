using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VerboseConfig", menuName = "My SOs/VerboseConfig")]
public class VerboseConfig : ConfigSingleton<VerboseConfig>
{
	public bool playerVerbose;
}

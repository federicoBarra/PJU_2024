using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UIConfig", menuName = "My SOs/UIConfig")]
public class UIConfig : ConfigSingleton<UIConfig>
{
	public Color buttonColor;
	public float buttonFontSize = 12;
}

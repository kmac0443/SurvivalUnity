using UnityEngine;
using System.Collections;

namespace ViewController
{
	public class TestListeners : MonoBehaviour 
	{
		static void Main(string[] args)
		{
			GUIMeterUpd MeterUpd = new GUIMeterUpd ();
			MeterUpd.onEnable ();
		}
	}
}
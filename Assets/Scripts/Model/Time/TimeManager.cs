using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour {

	public int Time = 1;
	private const int DAYEND = 24;

	private ArrayList TimeAffectedList = new ArrayList();

	public void AddTimeAffected(ITimeAffected Affected) {
		TimeAffectedList.Add(Affected);
	}

	public void AddHour() {
		AddHours(1);
	}

	public void AddHours(int hours) {
		Time += hours;
		Time = Time > DAYEND ? (Time - DAYEND) : Time;

		foreach (ITimeAffected Affected in TimeAffectedList) 
			Affected.OnHour();
	}

}

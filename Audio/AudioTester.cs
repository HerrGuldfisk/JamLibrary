using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		StartCoroutine(TestDampening());
    }

	IEnumerator TestDampening()
	{
		yield return new WaitForSecondsRealtime(1f);
		Debug.Log("Start playing ambient music");
		AudioManager.Instance.PlayAudio("TestTrack", true);

		yield return new WaitForSecondsRealtime(4f);
		Debug.Log("Ramping down to 50% music volume over 1.5 seconds");
		AudioManager.Instance.SetSubMixerVolume("MusicSubVolume", .5f, 1.5f);

		yield return new WaitForSecondsRealtime(4f);
		Debug.Log("Ramping up to 100% volume over 2 seconds");
		AudioManager.Instance.SetSubMixerVolume("MusicSubVolume", 1f, 2f);

		yield return new WaitForSecondsRealtime(4f);
		Debug.Log("Ramping music from 0% up to 100% over 4 seconds");
		AudioManager.Instance.PlayAudio("TestTrack", true, 4f);

		yield return new WaitForSecondsRealtime(6f);
		Debug.Log("Ramping down clip speed to 85% during 0.75 seconds");
		AudioManager.Instance.ChangeClipSpeed("TestTrack", 0.85f, 0.75f);

		yield return new WaitForSecondsRealtime(5f);
		Debug.Log("Ramping up clip speed to 115% during 0.75 seconds");
		AudioManager.Instance.ChangeClipSpeed("TestTrack", 1.15f, 0.75f);

		yield return new WaitForSecondsRealtime(5f);
		Debug.Log("Back To Normal");
		AudioManager.Instance.ChangeClipSpeed("TestTrack", 1f, 0.75f);
	}

}

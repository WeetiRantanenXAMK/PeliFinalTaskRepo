using System.Collections;
using TMPro;
using UnityEngine;

#if UNITY_ANDROID // Apparently necessary so iOS works.
using UnityEngine.Android;
#endif

public class GPS_Coordinates : MonoBehaviour
{
    private TMP_Text gps;

    public float latitude;
    public float longitude;

    void Start()
    {
        foreach (Transform t in GameObject.Find("Canvas").transform) // TEMPORARY.
        {
            if (t.name == "GPS" && t.GetComponent<TMP_Text>())
            {
                gps = t.GetComponent<TMP_Text>();
            }
        }
        StartCoroutine(InitGPS());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.location.isEnabledByUser && Input.location.status == LocationServiceStatus.Running)
        {
            latitude = Input.location.lastData.latitude;
            longitude = Input.location.lastData.longitude;

            Debug.Log($"Lat: {latitude} Lon: {longitude}");
            gps.text = $"Lat: {latitude} Lon: {longitude}";
        }
        else
        {
            Debug.Log("GPS not enabled or running yet.");
        }
    }

    private IEnumerator InitGPS()
    {
#if UNITY_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
            yield return new WaitForSeconds(2f);
        }
#endif

        Input.location.Start(10, 5);

        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1.0f);
            maxWait--;
        }

        if (maxWait < 1)
        {
            Debug.Log("Timed out waiting for GPS initialization.");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determine device location.");
            yield break;
        }
    }
}

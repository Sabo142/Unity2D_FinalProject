/*using System;
using Unity.Services.Analytics;
using Unity.Services.Core;
using UnityEngine;

public class Analytics : MonoBehaviour
{
    async void Awake()
    {
        try
        {
            await UnityServices.InitializeAsync();
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
        ConsentGiven();
    }
    void ConsentGiven()
    {
        AnalyticsService.Instance.StartDataCollection();
    }
}
*/
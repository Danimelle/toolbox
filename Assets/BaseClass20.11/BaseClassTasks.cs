using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;


public class BaseClassTasks : MonoBehaviour
{
    // Start is called before the first frame update
    async void Start()
    {
        Debug.Log("first method started");
        FirstAssignment();
        Debug.Log("first method ended");

        Debug.Log("second method started");
        await SecondAssignment();
        Debug.Log("second method ended");

        Debug.Log("running all task methods");
        await Task.WhenAll(SecondAssignment(), ThirdAssignment());
        Debug.Log("all task methods finished");
    }

    public async void FirstAssignment() //async method called without await in start
    {
        await Task.Delay(1000);
        Debug.Log("first method running");
    }

    public async Task SecondAssignment() //async task method called with await in start
    {
        await Task.Delay(1000);
        Debug.Log("second method running");

        Debug.Log("third method started");
        await ThirdAssignment(); // third method called from second method
        Debug.Log("third method ended");

    }

    public async Task ThirdAssignment()
    {
        Debug.Log("third method running");

        Debug.Log("first method started");
        FirstAssignment(); //first method called from third method, without await
        Debug.Log("first method ended");

        await Task.Delay(1000);
    }
}

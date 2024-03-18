using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using UXF;

public class SimpleHTTPPost : DataHandler
{
    [Tooltip("URL of the form to POST to.")]

    public string url = "http://127.0.0.1:5000/";

    [Tooltip("Enable to use username and password to add Basic HTTP Authentication to the request.")]
    public bool httpBasicAuthentication = true;
    [BasteRainGames.HideIf("httpBasicAuthentication", false)]
    public string username = "susan";
    [BasteRainGames.HideIf("httpBasicAuthentication", false)]
    public string password = "password";
    public ConditionHandler Experiment;

    // private Session session;

    private Dictionary<string, object> participantDetails;

    string condition;
    string trial;
    string time;
    string trialResult;
    string participantID;
    string sessionID;
    float trialTime;

    void Awake()
    {
        // Get the Session component from the parent
        Session parentSession = GetComponentInParent<Session>();

        // Initialize the session
        Initialise(parentSession);

        // Get the participant details
        participantDetails = parentSession.participantDetails;
    }

    void DataGatherer()
    {
        //// NOTE: This can be moved to the Data Handler if we want to make this better, by using UXF to specify conditipon settings and behavioral results. I don't want to do this - Georg///////
        condition = Experiment.conditionNumber.ToString();
        trial = "1"; // currently, there is only one trial
        time = DateTime.Now.ToString();
        trialResult = session.settings.GetString("session_ended"); // Use double quotes for string literals
        participantID = session.ppid;
    }

    public void SendToSheets(Session session)
    {
        WWWForm form = new WWWForm();
        DataGatherer();
        // Create a dictionary
        Dictionary<string, string> data = new Dictionary<string, string>
        {
            {"Condition", condition},
            {"Trial", trial},
            {"Time", time},
            {"TrialResult", trialResult},
            {"ParticipantID", participantID},
            {"TrialTime", trialTime.ToString()}
        };

        // Add participant details to the data dictionary
        foreach (KeyValuePair<string, object> entry in participantDetails)
        {
            data.Add(entry.Key, entry.Value.ToString());
        }

        // Add each item in the dictionary to the form
        foreach (var item in data)
        {
            form.AddField(item.Key, item.Value);
        }

        UnityWebRequest www = UnityWebRequest.Post(url, form);

        if (httpBasicAuthentication)
        {
            string auth = username + ":" + password;
            auth = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(auth));
            auth = "Basic " + auth;
            www.SetRequestHeader("AUTHORIZATION", auth);
        }

        StartCoroutine(SendRequest(www));
    }

    IEnumerator SendRequest(UnityWebRequest www)
    {
        yield return www.SendWebRequest();

        bool error;
#if UNITY_2020_OR_NEWER
        error = www.result != UnityWebRequest.Result.Success;
#else
#pragma warning disable
        error = www.isHttpError || www.isNetworkError;
#pragma warning restore
#endif
        if (error)
        {
            Debug.LogError(www.error);
        }
    }

    //////// BUNCH OF STUFF FROM CUSTOM DATA HANDLER IN UXF WIKI - I DO NOT UNDERSTAND IT //////////

    public override bool CheckIfRiskOfOverwrite(string experiment, string ppid, int sessionNum, string rootPath = "")
    {
        return false; // You could write a condition to return true when a ppid already exists.
    }

    public override void SetUp()
    {
        // No setup is needed in this case. But you can add any code here that will be run when the session begins.
    }

    public override string HandleDataTable(UXFDataTable table, string experiment, string ppid, int sessionNum, string dataName, UXFDataType dataType, int optionalTrialNum = 0)
    {
        // get data as text
        string[] lines = table.GetCSVLines();
        string text = string.Join("\n", lines);

        // here we "write" our data, you could upload to database, or do whatever.
        Debug.Log(text);
        if (dataName == "trial_results")
        {
            var rows = table.GetAsListOfDict();
            if (rows.Count == 0)
            {
                Debug.Log("AAAHHHHH no rows");
            }
            else
            {
                float trialStart = (float)table.GetAsListOfDict()[0]["start_time"];
                float trialEnd = (float)table.GetAsListOfDict()[0]["end_time"];
                trialTime = trialEnd - trialStart;
            }

        }

        // return a string representing the location of the data. Will be stored in the trial_results output.
        return "Data printed to console.";
    }

    public override string HandleJSONSerializableObject(List<object> serializableObject, string experiment, string ppid, int sessionNum, string dataName, UXFDataType dataType, int optionalTrialNum = 0)
    {
        // get data as text
        string text = MiniJSON.Json.Serialize(serializableObject);

        // here we "write" our data, you could upload to database, or do whatever.
        Debug.Log(text);

        // return a string representing the location of the data. Will be stored in the trial_results output.
        return "Data printed to console.";
    }

    public override string HandleJSONSerializableObject(Dictionary<string, object> serializableObject, string experiment, string ppid, int sessionNum, string dataName, UXFDataType dataType, int optionalTrialNum = 0)
    {
        // get data as text
        string text = MiniJSON.Json.Serialize(serializableObject);

        // here we "write" our data, you could upload to database, or do whatever.
        Debug.Log(text);

        // return a string representing the location of the data. Will be stored in the trial_results output.
        return "Data printed to console.";
    }

    public override string HandleText(string text, string experiment, string ppid, int sessionNum, string dataName, UXFDataType dataType, int optionalTrialNum = 0)
    {
        // here we "write" our data, you could upload to database, or do whatever.
        Debug.Log(text);

        // return a string representing the location of the data. Will be stored in the trial_results output.
        return "Data printed to console.";
    }

    public override string HandleBytes(byte[] bytes, string experiment, string ppid, int sessionNum, string dataName, UXFDataType dataType, int optionalTrialNum = 0)
    {
        // here we "write" our data, you could upload to database, or do whatever.
        string text = System.Text.Encoding.UTF8.GetString(bytes);
        Debug.Log(text);

        // return a string representing the location of the data. Will be stored in the trial_results output.
        return "Data printed to console.";
    }

    public override void CleanUp()
    {
        // No cleanup is needed in this case. But you can add any code here that will be run when the session finishes.
    }
}



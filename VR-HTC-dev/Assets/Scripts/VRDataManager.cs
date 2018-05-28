// By Starsky Lara
// starsk@noumena.io
// Future Realities Seminar - IAAC - Institute for Advanced Architecture of Catalonia
// under a Creative Commons Attribution-ShareAlike 3.0 Unported License.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using FutureRealities;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;

public class VRDataManager : MonoBehaviour
{

    private float _Timer;
    private int _SceneBuildIndex;
    private int _SceneBuildIndexStart_;
    private int _UserNumber;
    private GameObject VRHeatSet;
    private GameObject VRGaze;
    private MongoClient _client;
    private MongoServer _server;
    private MongoDatabase _database;
    private MongoCollection<BsonDocument> _colection;

    List<BsonDocument> batch = new List<BsonDocument>();
    public bool created = false;
    public string connectionString = "mongodb://localhost:27017";
    public float DataCollectionDelay = 2.0f;

    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
            _SceneBuildIndexStart_ = 2;
        }
    }

    // Use this for initialization
    void Start()
    {
        _SceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        VRHeatSet = GameObject.FindGameObjectWithTag("MainCamera");
        VRHeatSet = GameObject.FindGameObjectWithTag("Gaze");
        _client = new MongoClient(connectionString);
        _server = _client.GetServer();
        _database = _server.GetDatabase("VR_rutas");
        _colection = _database.GetCollection<BsonDocument>("VRviews");
        Debug.Log("established connection");
    }

    // Update is called once per frame
    void Update()
    {
        VRDataCollection();
    }

    void VRDataCollection()
    {
        if (_SceneBuildIndex != SceneManager.GetActiveScene().buildIndex)
        {
            //_VRroom = GameObject.FindGameObjectWithTag("VRroom");
            VRHeatSet = GameObject.FindGameObjectWithTag("MainCamera");
            VRGaze = GameObject.FindGameObjectWithTag("Gaze");


            _SceneBuildIndex = SceneManager.GetActiveScene().buildIndex;

            if ((_SceneBuildIndexStart_ == _SceneBuildIndex))
            {
                _UserNumber++;
            }
        }



        _Timer += Time.deltaTime;
        if (_Timer > DataCollectionDelay)
        {
            _Timer = 0.0f;
            if(!(_SceneBuildIndex == _SceneBuildIndexStart_))
            {
                _colection.Insert(new BsonDocument {
                {"current_date", new DateTime()},
                {"UserNumber", _UserNumber},
                {"SceneBuildIndex", SceneManager.GetActiveScene().buildIndex},
                {"HeatSet_x", VRHeatSet.transform.localPosition.x},
                {"HeatSet_x_y", VRHeatSet.transform.position.y},
                {"HeatSet_x_z", VRHeatSet.transform.position.z},
                {"Gaze_x", VRGaze.transform.position.x},
                {"Gaze_y", VRGaze.transform.position.y},
                {"Gaze_z", VRGaze.transform.position.z}
            });
            }

            Debug.Log(string.Format("UserNumber, {0}", _UserNumber));
        }
    }
}

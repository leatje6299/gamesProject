using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JournalEvent : MonoBehaviour
{
    UnityEvent m_JournalEvent;
    // Start is called before the first frame update
    void Start()
    {
        if (m_JournalEvent == null)
        {
            m_JournalEvent = new UnityEvent();
            m_JournalEvent.AddListener(Ping);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && m_JournalEvent != null)
        {
            m_JournalEvent.Invoke();
        }
    }

    void Ping()
    {
        Debug.Log("Ping");
    }
}

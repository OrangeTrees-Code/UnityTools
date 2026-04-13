using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPrefsDataManager
{
    private static PlayerPrefsDataManager instance = new PlayerPrefsDataManager();

    public static PlayerPrefsDataManager Instance
    {
        get
        {
            return instance;
        }
    }

    private PlayerPrefsDataManager()
    {

    }

    public void SaveData(object data, string keyName)
    {
        Type typeInfo = data.GetType();
        FieldInfo[] infos = typeInfo.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        string fullKeyName;

        for (int i = 0; i < infos.Length; i++)
        {
            FieldInfo info = infos[i];
            fullKeyName = keyName + "_" + typeInfo.Name + "_" + info.FieldType.Name + "_" + info.Name;
            SaveValue(info.GetValue(data), fullKeyName);
        }
    }

    private void SaveValue(object value, string keyName)
    {
        if(value == null)
        {
            return;
        }
        Type fieldType = value.GetType();
        if (fieldType == typeof(int))
        {
            PlayerPrefs.SetInt(keyName, (int)value);
        }
        else if (fieldType == typeof(float))
        {
            PlayerPrefs.SetFloat(keyName, (float)value);
        }
        else if (fieldType == typeof(string))
        {
            PlayerPrefs.SetString(keyName, value.ToString());
        }
        else if (fieldType == typeof(bool))
        {
            PlayerPrefs.SetInt(keyName, (bool)value == true ? 1 : 0);
        }
        else if (typeof(IList).IsAssignableFrom(fieldType))
        {
            IList list = value as IList;
            PlayerPrefs.SetInt(keyName, list.Count);
            int index = 0;
            foreach (object obj in list)
            {
                SaveValue(obj, keyName + index);
                ++index;
            }
        }
        else if (typeof(IDictionary).IsAssignableFrom(fieldType))
        {
            IDictionary dict = value as IDictionary;
            PlayerPrefs.SetInt(keyName, dict.Count);
            int index = 0;
            foreach (object key in dict.Keys)
            {
                SaveValue(key, keyName + "_key_" + index);
                SaveValue(dict[key], keyName + "_value_" + index);
                ++index;
            }
        }
        else
        {
            SaveData(value, keyName);
        }
    }

    public object LoadData(Type type, string keyName)
    {
        object data = Activator.CreateInstance(type);

        FieldInfo[] infos = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        string fullKeyName;
        FieldInfo info;
        for (int i = 0; i < infos.Length; i++)
        {
            info = infos[i];
            fullKeyName = keyName + "_" + type.Name + "_" + info.FieldType.Name + "_" + info.Name;
            info.SetValue(data,LoadValue(info.FieldType, fullKeyName));
        }
        return data;
    }

    private object LoadValue(Type fieldType,string keyName)
    {
        if (fieldType == typeof(int))
        {
            return PlayerPrefs.GetInt(keyName);
        }
        else if (fieldType == typeof(float))
        {
            return PlayerPrefs.GetFloat(keyName);
        }
        else if (fieldType == typeof(string))
        {
            return PlayerPrefs.GetString(keyName);
        }
        else if (fieldType == typeof(bool))
        {
            return PlayerPrefs.GetInt(keyName) == 1 ? true : false;
        }
        else if (typeof(IList).IsAssignableFrom(fieldType))
        {
            int length = PlayerPrefs.GetInt(keyName);
            IList list = Activator.CreateInstance(fieldType) as IList;
            for (int i = 0; i < length; i++)
            {
                list.Add(LoadValue(fieldType.GetGenericArguments()[0], keyName + i));
            }
            return list;
        }
        else if (typeof(IDictionary).IsAssignableFrom(fieldType))
        {
            int length = PlayerPrefs.GetInt(keyName);
            IDictionary dict = Activator.CreateInstance(fieldType) as IDictionary;
            var KV_Type = fieldType.GetGenericArguments();
            for (int i = 0; i < length; i++)
            {
                dict.Add(LoadValue(KV_Type[0], keyName + "_key_" + i), LoadValue(KV_Type[1], keyName + "_value_" + i));
            }
            return dict;
        }
        else
        {
            return LoadData(fieldType, keyName);
        }
    }
}



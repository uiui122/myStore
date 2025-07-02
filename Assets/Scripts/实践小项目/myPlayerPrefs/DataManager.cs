using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

/// <summary>
/// PlayerPrefs数据管理类，统一管理数据的存储和读取
/// </summary>
public class DataManager
{
    private static DataManager instance = new DataManager();

    public static DataManager Instance
    {
        get
        {
            return instance;
        }
        set
        {

        }
    }
    private DataManager()
    {

    }

    /// <summary>
    /// 存储数据
    /// </summary>
    /// <param name="data">数据对象</param>
    /// <param name="keyName">数据对象的唯一Key</param>
    public void SaveData(object data,string keyName)
    {
        //要通过 Type 得到传入数据对象所有的字段
        Type dataType = data.GetType();
        FieldInfo[] infos = dataType.GetFields();//这里学
        FieldInfo info;
        string saveKeyName = "";
        for (int i = 0; i < infos.Length; i++)
        {
            info = infos[i];

            //info.FieldType.Name;
            //info.Name;
            saveKeyName = keyName + "_" + 
                          dataType.Name + "_" +
                          info.FieldType.Name + "_" +
                          info.Name;
            SaveValue(info.GetValue(data), saveKeyName);
        }
        PlayerPrefs.Save();
        //命名规则
        //keyName_数据类型_字段类型_字段名      
    }

    /// <summary>
    /// 存储信息的函数
    /// </summary>
    /// <param name="value">要存储的信息</param>
    /// <param name="keyName">数据对象的唯一key</param>
    private void SaveValue(object value,string keyName)
    {
        if(value == null)
        {
            return;
        }

        Type fieldType = value.GetType();
        #region 常用字段

        //判断类型，存储数据
        if (fieldType == typeof(int))
        {
            PlayerPrefs.SetInt(keyName, (int)value);
        }
        else if (fieldType == typeof(float))
        {
            PlayerPrefs.SetFloat(keyName, (float)value);
        }
        else if (fieldType == typeof (string))
        {
            PlayerPrefs.SetString(keyName, value.ToString());
        }
        else if (fieldType == typeof(bool))
        {
            PlayerPrefs.SetInt(keyName, (bool)value ? 1 : 0);
        }
        //有其他的类型也要先加上
        else if(typeof(IList).IsAssignableFrom(fieldType))
        {
            IList list = value as IList;
            PlayerPrefs.SetInt(keyName, list.Count);
            int index = 0;
            foreach (object item in list)
            {
                
                SaveValue(item, keyName + index);
                ++index;
            }
        }
        else if (typeof(IDictionary).IsAssignableFrom(fieldType))
        {
            IDictionary dic = value as IDictionary;
            PlayerPrefs.SetInt(keyName, dic.Count);
            int index = 0;

            foreach (object item in dic.Keys)
            {

                SaveValue(item, keyName +"_key_"+ index);
                SaveValue(dic[item], keyName + "_value_" + index);
                ++index;
            }
        }
        //不是基础类型，是自定义类型
        //原本传的也是类，相同处理
        else
        {
            SaveData(value, keyName);
        }
        #endregion
    }

    /// <summary>
    /// 读取数据
    /// </summary>
    /// <param name="type">想要读取数据的数据类型</param>
    /// <param name="keyName">数据对象的唯一key</param>
    /// <returns></returns>
    public object LoadData(Type type, string keyName)
    {
        object data = Activator.CreateInstance(type);

        FieldInfo[] infos = type.GetFields();

        string loadKeyName = "";

        FieldInfo info;
        for (int i = 0; i < infos.Length; i++)
        {
            info = infos[i];
            loadKeyName  = keyName + "_" +
                           type.Name + "_" +
                           info.FieldType.Name + "_" +
                           info.Name;

            info.SetValue(data, LoadValue(info.FieldType, loadKeyName));
        }

        return data;
    }
    /// <summary>
    /// 获取单个数据的方法
    /// </summary>
    /// <param name="type">字段类型 用于判断由哪个API获取</param>
    /// <param name="keyName">数据对象的唯一key</param>
    private object LoadValue(Type type, string keyName)
    {
        if(type == typeof(int))
        {
            return PlayerPrefs.GetInt(keyName, 0);
        }
        else if (type == typeof(float))
        {
            return PlayerPrefs.GetFloat(keyName, 0);
        }
        else if (type == typeof(string))
        {
            return PlayerPrefs.GetString(keyName, "");
        }
        else if (type == typeof(bool))
        {
            return PlayerPrefs.GetInt(keyName, 0) ==1?true:false;
        }
        else if (typeof(IList).IsAssignableFrom(type))
        {
            int count = PlayerPrefs.GetInt(keyName, 0);

            IList list = Activator.CreateInstance(type) as IList;
            for (int i = 0; i < count; i++)
            {
                list.Add(LoadValue(type.GetGenericArguments()[0], keyName + i));
            }
            return list;
        }
        else if (typeof(IDictionary).IsAssignableFrom(type))
        {
            int count = PlayerPrefs.GetInt(keyName, 0);
            IDictionary dic = Activator.CreateInstance(type) as IDictionary;
            Type[] kvType = type.GetGenericArguments();
            for (int i = 0; i < count; i++)
            {
                dic.Add(LoadValue(kvType[0], keyName + "_key_" + i),
                        LoadValue(kvType[1], keyName + "_value_" + i));
            }
            return dic;
        }
        else
        {
            return LoadData(type, keyName);
        }
    }
}
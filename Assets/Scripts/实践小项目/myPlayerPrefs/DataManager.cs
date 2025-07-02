using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

/// <summary>
/// PlayerPrefs���ݹ����࣬ͳһ�������ݵĴ洢�Ͷ�ȡ
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
    /// �洢����
    /// </summary>
    /// <param name="data">���ݶ���</param>
    /// <param name="keyName">���ݶ����ΨһKey</param>
    public void SaveData(object data,string keyName)
    {
        //Ҫͨ�� Type �õ��������ݶ������е��ֶ�
        Type dataType = data.GetType();
        FieldInfo[] infos = dataType.GetFields();//����ѧ
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
        //��������
        //keyName_��������_�ֶ�����_�ֶ���      
    }

    /// <summary>
    /// �洢��Ϣ�ĺ���
    /// </summary>
    /// <param name="value">Ҫ�洢����Ϣ</param>
    /// <param name="keyName">���ݶ����Ψһkey</param>
    private void SaveValue(object value,string keyName)
    {
        if(value == null)
        {
            return;
        }

        Type fieldType = value.GetType();
        #region �����ֶ�

        //�ж����ͣ��洢����
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
        //������������ҲҪ�ȼ���
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
        //���ǻ������ͣ����Զ�������
        //ԭ������Ҳ���࣬��ͬ����
        else
        {
            SaveData(value, keyName);
        }
        #endregion
    }

    /// <summary>
    /// ��ȡ����
    /// </summary>
    /// <param name="type">��Ҫ��ȡ���ݵ���������</param>
    /// <param name="keyName">���ݶ����Ψһkey</param>
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
    /// ��ȡ�������ݵķ���
    /// </summary>
    /// <param name="type">�ֶ����� �����ж����ĸ�API��ȡ</param>
    /// <param name="keyName">���ݶ����Ψһkey</param>
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
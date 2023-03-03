using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadUtil
{
    // 这两个命名空间需添加

    // 二进制方法：存档和读档
    public static void SaveByBin(Demo1SaveData save)
    {
        // 序列化过程 （将Save 对象转换为字节流）
        // 创建一个二进制格式化程序
        BinaryFormatter bf = new BinaryFormatter();
        // 创建一个文件流
        FileStream fileStream = File.Create(Application.dataPath + "/StreamingAssets" + "/byBin.txt");
        // 用二进制格式化程序的序列化方法 来 序列化Save对象
        //      参数：创建的文件流和需要序列化的对象
        bf.Serialize(fileStream, save);
        // 关闭流
        fileStream.Close();

        // 如果文件存在,则显示保存成功
        if (File.Exists(Application.dataPath + "/StreamingAssets" + "/byBin.txt"))
        {
            Debug.Log("Save success!");
        }
    }

    public static Demo1SaveData LoadByBin()
    {
        if (File.Exists(Application.dataPath + "/StreamingAssets" + "/byBin.txt"))
        {
            // 反序列化过程
            // 创建一个二进制格式化程序
            BinaryFormatter bf = new BinaryFormatter();
            // 打开一个文件流
            FileStream fileStream = File.Open(Application.dataPath + "/StreamingAssets"
    + "/byBin.txt", FileMode.Open);
            // 调用格式化程序的反序列化方法,将文件流转换为Save 对象
            Demo1SaveData save = (Demo1SaveData)bf.Deserialize(fileStream);
            // 关闭文件流
            fileStream.Close();
            return save;
        }
        else
        {
            Debug.Log("存档文件不存在!");
            return null;
        }

    }
}

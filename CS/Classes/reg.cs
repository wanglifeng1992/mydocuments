using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace Solution
{
    public class reg
    {
        //.读取指定名称的注册表的值
        public string getSetting(string name)
        {
            try
            {

                string registData;
                RegistryKey hkml = Registry.LocalMachine;
                RegistryKey software = hkml.OpenSubKey("SOFTWARE", true);
                RegistryKey aimdir = software.OpenSubKey("BOOKBOY", true);
                registData = aimdir.GetValue(name).ToString();
                return registData;
            }
            catch
            {
                return "";
            }
        }
        //以上是读取的注册表中HKEY_LOCAL_MACHINE\SOFTWARE目录下的XXX目录中名称为name的注册表值；

        //2.向注册表中写数据
        public void saveSetting(string name, string tovalue)
        {
            try
            {
                RegistryKey hklm = Registry.LocalMachine;
                RegistryKey software = hklm.OpenSubKey("SOFTWARE", true);
                RegistryKey aimdir = software.CreateSubKey("BOOKBOY");
                aimdir.SetValue(name, tovalue);
                return;
            }
            catch
            {
                return;
            }
        }
        //以上是在注册表中HKEY_LOCAL_MACHINE\SOFTWARE目录下新建XXX目录并在此目录下创建名称为name值为tovalue的注册表项；

        //3.删除注册表中指定的注册表项
        public void deleteSetting(string name)
        {

            string[] aimnames;
            try
            {
                RegistryKey hkml = Registry.LocalMachine;
                RegistryKey software = hkml.OpenSubKey("SOFTWARE", true);
                RegistryKey aimdir = software.OpenSubKey("BOOKBOY", true);
                aimnames = aimdir.GetSubKeyNames();
                foreach (string aimKey in aimnames)
                {
                    if (aimKey == name)
                        aimdir.DeleteSubKeyTree(name);
                }
                return;
            }
            catch
            {
                return;
            }
        }
        //以上是在注册表中HKEY_LOCAL_MACHINE\SOFTWARE目录下XXX目录中删除名称为name注册表项；



        //4.判断指定注册表项是否存在
        public bool existSetting(string name)
        {
            bool _exit = false;
            try
            {
                string[] subkeyNames;
                RegistryKey hkml = Registry.LocalMachine;
                RegistryKey software = hkml.OpenSubKey("SOFTWARE", true);
                RegistryKey aimdir = software.OpenSubKey("BOOKBOY", true);
                subkeyNames = aimdir.GetValueNames();
                foreach (string keyName in subkeyNames)
                {
                    if (keyName == name)
                    {
                        _exit = true;
                        return _exit;
                    }
                }
            }
            catch
            { }
            return _exit;
        }
    }
}

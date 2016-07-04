using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace WpfApplication2.Helper
{
    /// <summary>
    /// [3]:[0]投影仪 [1]电脑 [2]激光笔
    /// </summary>
    public class AttEquipment
    {
        private int[] arrEquipment = new int[] { 1, 0, 1 };


        public AttEquipment(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                List<string> strs = str.Split(',').ToList();
                for (int i = 0; i < strs.Count && i < arrEquipment.Length; i++)
                {
                    if (strs[i] == "1")
                    {
                        arrEquipment[i] = 1;
                    }
                    else
                    {
                        arrEquipment[i] = 0;
                    }
                }
            }
        }
        //属性
        public bool IsProjectorNeeded
        {
            get { return arrEquipment[0] == 1; }
            set
            {
                arrEquipment[0] = value == true ? 1 : 0;
            }
        }
        public bool IsComputerNeeded
        {
            get { return arrEquipment[1] == 1; }
            set
            {
                arrEquipment[1] = value == true ? 1 : 0;
            }
        }
        public bool IsLaserPointerNeeded
        {
            get { return arrEquipment[2] == 1; }
            set
            {
                arrEquipment[2] = value == true ? 1 : 0;
            }
        }
        //实现INPC
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string GetValue()
        {
            string[] arrStr = new string[arrEquipment.Length];
            for (int i = 0; i < arrEquipment.Length; i++)
            {
                arrStr[i] = arrEquipment[i].ToString();
            }
            return string.Join(",", arrStr);
        }
    }
}

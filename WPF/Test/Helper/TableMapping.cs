using System;
using System.Collections.Generic;

namespace WpfApplication2.Helper
{
    public class TableMapping
    {
        static List<string> types;
        static TableMapping()
        {
            types = new List<string>();
            types.Add("RBC信息");
            types.Add("车站信息");//无行向
            types.Add("道岔信息");//无行向
            types.Add("制动距离");//无行向
            types.Add("分相信息");
            types.Add("桥梁隧道信息");
            types.Add("断链明细");//无行向
            types.Add("线路坡度");
            types.Add("线路速度");
            types.Add("信号数据");
            types.Add("侵限监控");
            types.Add("应答器位置");
            types.Add("轨道区段与道岔映射");
            types.Add("制动距离");
            types.Add("坐标系信息");
            types.Add("进路信息");
        }
        public string header;
        public string GUIDField;
        public string GUIDValue;
        public List<string> fields;
        public bool IsCategoryNeeded;
        public string SheetName
        {
            set
            {
                if (CategoryField=="Category")
                {
                    WpfApplication2.Converter.ExcelConverter.ConvertCategory(value, ref _categoryValue);
                }
                else
                {
                    _categoryValue = value;
                }
            }
        }
        public string CategoryField;
        string _categoryValue;
        public string CategoryValue
        {
            get
            {
                return _categoryValue.ToString();
            }
        }

        public TableMapping(string A1Content)
        {
            fields = new List<string>();
            //设定组ID
            GUIDValue = Guid.NewGuid().ToString();
            GUIDField = "GroupID";
            //获取表类型
            for (int i = 0; i < types.Count; i++)
            {
                if (A1Content.Contains(types[i]))
                {
                    header = types[i];
                    break;
                }
            }
            //获取字段集
            if (!string.IsNullOrEmpty(header))
            {
                switch (header)
                {
                    case "RBC信息":
                        fields.Add("ID");
                        fields.Add("AreaID");
                        fields.Add("RBCID");
                        fields.Add("PhoneNum");
                        fields.Add("StartPoint");
                        fields.Add("Cutoff");
                        fields.Add("EndPoint");
                        IsCategoryNeeded = true;
                        CategoryField = "Category";
                        break;
                    case "车站信息":
                        fields.Add("ID");
                        fields.Add("StationName");
                        fields.Add("RegionID");
                        fields.Add("AreaID");
                        fields.Add("StationID");
                        IsCategoryNeeded = false;
                        break;
                    case "道岔信息":
                        fields.Add("ID");
                        fields.Add("StationName");
                        fields.Add("TurnoutName");
                        fields.Add("Mileage");
                        fields.Add("Siding");
                        fields.Add("CategoryStr");
                        fields.Add("Speed");
                        fields.Add("TFLine");
                        fields.Add("default1");
                        fields.Add("default2");
                        fields.Add("default3");
                        fields.Add("default4");
                        IsCategoryNeeded = false;
                        break;
                    case "分相信息":
                        fields.Add("ID");
                        fields.Add("StartMileage");
                        fields.Add("EndMileage");
                        fields.Add("Length");
                        fields.Add("Remark1");
                        fields.Add("Remark2");
                        IsCategoryNeeded = true;
                        CategoryField = "Category";
                        break;
                    case "桥梁隧道信息":
                        fields.Add("ID");
                        fields.Add("StartMileage");
                        fields.Add("EndMileage");
                        fields.Add("Type");
                        fields.Add("Remark1");
                        fields.Add("Remark2");
                        IsCategoryNeeded = true;
                        CategoryField = "Category";
                        break;
                    case "断链明细":
                        fields.Add("LineName");
                        fields.Add("CategoryStr");
                        fields.Add("Type");
                        fields.Add("StartMileage");
                        fields.Add("EndMileage");
                        fields.Add("LongChainStr");
                        fields.Add("ShortChainStr");
                        IsCategoryNeeded = false;
                        break;
                    case "线路坡度":
                        fields.Add("ID");
                        fields.Add("Gradient");
                        fields.Add("Length");
                        fields.Add("EndMileage");
                        fields.Add("Remark");
                        IsCategoryNeeded = true;
                        break;
                    case "线路速度":
                        fields.Add("ID");
                        fields.Add("Speed");
                        fields.Add("Length");
                        fields.Add("EndMileage");
                        fields.Add("Remark");
                        IsCategoryNeeded = true;
                        CategoryField = "Category";
                        break;
                    case "信号数据":
                        fields.Add("ID");
                        fields.Add("StationName");
                        fields.Add("SignalName");
                        fields.Add("SignalMileage");
                        fields.Add("SignalTypeStr");
                        fields.Add("IsolationTypeStr");
                        fields.Add("SectionName");
                        fields.Add("SectionCarrirer");
                        fields.Add("SectionLength");
                        fields.Add("SectionAttribute");
                        fields.Add("Remark");
                        IsCategoryNeeded = true;
                        CategoryField = "Category";
                        break;
                    case "侵限监控":
                        fields.Add("ID");
                        fields.Add("StationName");
                        fields.Add("CategoryStr");
                        fields.Add("StartMileage");
                        fields.Add("EndMileage");
                        fields.Add("WarningRelay");
                        fields.Add("AffectedSectionName");
                        fields.Add("Remark");
                        IsCategoryNeeded = false;
                        break;
                    case "应答器位置":
                        fields.Add("ID");
                        fields.Add("TransponderName");
                        fields.Add("TransponderID");
                        fields.Add("Mileage");
                        fields.Add("Type");
                        fields.Add("Usage");
                        fields.Add("Remark1");
                        fields.Add("Remark2");
                        IsCategoryNeeded = true;
                        CategoryField = "Category";
                        break;
                    case "轨道区段与道岔映射":
                        fields.Add("ID");
                        fields.Add("SectionName");
                        fields.Add("TurnoutIDs");
                        IsCategoryNeeded = true;
                        CategoryField = "StationName";
                        break;
                    case "制动距离":
                        fields.Add("ID");
                        fields.Add("Speed");
                        fields.Add("Gradient");
                        fields.Add("LengthFor300T");
                        fields.Add("LengthForPulling");
                        fields.Add("LengthForMessage");
                        IsCategoryNeeded = false;
                        break;
                    case "坐标系信息":
                        fields.Add("ID");
                        fields.Add("CoordinateID");
                        fields.Add("CategoryStr");
                        fields.Add("CoordinateName");
                        fields.Add("Length");
                        fields.Add("Remark");
                        fields.Add("IsReversed");
                        fields.Add("CurrentMileage");
                        fields.Add("EdgeMileage");
                        IsCategoryNeeded = false;
                        break;
                    case "进路信息":
                        fields.Add("ID");
                        fields.Add("ResponderID");
                        fields.Add("ApprochID");
                        fields.Add("ApprochInfo");
                        fields.Add("ApproachType");
                        fields.Add("StartAnnunciatorName");
                        fields.Add("StartAnnunciatorDisplay");
                        fields.Add("EndAnnunciator");
                        fields.Add("ExperiencedResponders");
                        fields.Add("ExperiencedTurnouts");
                        fields.Add("ExperiencedSpeeds");
                        fields.Add("ExperiencedStationSections");
                        fields.Add("AffectedDisasters");
                        IsCategoryNeeded = false;
                        break;
                    default: break;
                }
            }
        }
    }
}

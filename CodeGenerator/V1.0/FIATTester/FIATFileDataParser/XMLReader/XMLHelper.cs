using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AccountPayable.NewCode.ImportExport.FIATFileDataParser.XMLReader
{

    public enum operationEnum
    {
        equal,
        like
    }

    public class XMLHelper
    {
        XDocument Document { get; set; }
        List<XElement> Elements { get; set; }

        #region Constructors
        public XMLHelper()
        {
        }
        public XMLHelper(string path)
        {
            LoadDocument(path);
        } 
        #endregion

        /// <summary>
        /// 加载文档
        /// </summary>
        /// <param name="path"></param>
        public void LoadDocument(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    Document = XDocument.Load(path);
                }
                catch
                {
                    throw new Exception("xml文件加载失败");
                }
            }
            else
            {
                throw new Exception("xml文件未找到");
            }
        }
        /// <summary>
        /// 加载节点
        /// </summary>
        /// <param name="elementName"></param>
        public void LoadElements(string elementName)
        {
            Elements = Document.Descendants(elementName).ToList();
        }

        public IEnumerable<XElement> FindElementsByAttributeValue(string name, string value, operationEnum operation)
        {
            switch (operation)
            {
                case operationEnum.equal:
                    return Elements.Where(c => c.Attribute(name).Value == value);
                case operationEnum.like:
                    return Elements.Where(c => c.Attribute(name).Value.Contains(value));
                default:
                    return null;
            }
        }
    }
}

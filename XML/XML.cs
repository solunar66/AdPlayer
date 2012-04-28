using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Drawing;
using System.Collections;
using System.IO;

namespace XML
{
    public class XMLInfo
    {
        private string path;

        private LOG.LogInfo log;

        public XMLInfo(string p)
        {
            this.path = p;
            log = LOG.LogInfo.GetInstance;
        }

        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="attribute">属性名，非空时返回该属性值，否则返回串联值</param>
        /// <returns>string</returns>
        /**************************************************
         * 使用示列:
         * XmlHelper.Read("/Node", "")
         * XmlHelper.Read("/Node/Element[@Attribute='Name']", "Attribute")
         ************************************************/
        public string Read(string node, string attribute)
        {
            string value = "";
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode xn = doc.SelectSingleNode(node);
                value = (attribute.Equals("") ? xn.InnerText : xn.Attributes[attribute].Value);
            }
            catch { }
            return value;
        }
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="element">元素名，非空时插入新元素，否则在该元素中插入属性</param>
        /// <param name="attribute">属性名，非空时插入该元素属性值，否则插入元素值</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        /**************************************************
         * 使用示列:
         * XmlHelper.Insert("/Node", "Element", "", "Value")
         * XmlHelper.Insert("/Node", "Element", "Attribute", "Value")
         * XmlHelper.Insert("/Node", "", "Attribute", "Value")
         ************************************************/
        public void Insert(string node, string element, string attribute, string value)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode xn = doc.SelectSingleNode(node);
                if (element.Equals(""))
                {
                    if (!attribute.Equals(""))
                    {
                        XmlElement xe = (XmlElement)xn;
                        xe.SetAttribute(attribute, value);
                    }
                }
                else
                {
                    XmlElement xe = doc.CreateElement(element);
                    if (attribute.Equals(""))
                        xe.InnerText = value;
                    else
                        xe.SetAttribute(attribute, value);
                    xn.AppendChild(xe);
                }
                doc.Save(path);
            }
            catch { }
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="attribute">属性名，非空时修改该节点属性值，否则修改节点值</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        /**************************************************
         * 使用示列:
         * XmlHelper.Insert("/Node", "", "Value")
         * XmlHelper.Insert("/Node", "Attribute", "Value")
         ************************************************/
        public void Update(string node, string attribute, string value)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode system = doc.SelectSingleNode("system");
                XmlNode xn = system.SelectSingleNode(node);
                XmlElement xe = (XmlElement)xn;
                if (attribute.Equals(""))
                    xe.InnerText = value;
                else
                    xe.SetAttribute(attribute, value);
                doc.Save(path);
            }
            catch { }
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="attribute">属性名，非空时删除该节点属性值，否则删除节点值</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        /**************************************************
         * 使用示列:
         * XmlHelper.Delete("/Node", "")
         * XmlHelper.Delete("/Node", "Attribute")
         ************************************************/
        public void Delete(string node, string attribute)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode xn = doc.SelectSingleNode(node);
                XmlElement xe = (XmlElement)xn;
                if (attribute.Equals(""))
                    xn.ParentNode.RemoveChild(xn);
                else
                    xe.RemoveAttribute(attribute);
                doc.Save(path);
            }
            catch { }
        }

        /// <summary>
        /// 读取播放配置
        /// </summary>
        /// <returns></returns>
        public bool ReadPlayConfig(out Config config)
        {
            config = new Config();

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);

                XmlNode system = doc.SelectSingleNode("system");

                XmlNode screen = system.SelectSingleNode("screen");
                config.scr = int.Parse(screen.Attributes["index"].Value);

                XmlNode notice = system.SelectSingleNode("notice");
                config.notice.bold = notice.Attributes["bold"].Value == "0" ? false : true;
                config.notice.color = Color.FromName(notice.Attributes["color"].Value);
                config.notice.bgcolor = Color.FromName(notice.Attributes["bgcolor"].Value);
                config.notice.font = notice.Attributes["fontname"].Value;
                config.notice.size = int.Parse(notice.Attributes["size"].Value);
                config.notice.interval = int.Parse(notice.Attributes["speed"].Value);


                XmlNodeList root = system.SelectNodes("period");
                config.datesheets = new List<DateSheet>();
                foreach (XmlNode period in root)
                {
                    DateSheet datesheets = new DateSheet();

                    datesheets.startDate = DateTime.Parse(period.Attributes["start"].Value);
                    datesheets.endDate = DateTime.Parse(period.Attributes["end"].Value + " 23:59:59");

                    datesheets.Mon = period.Attributes["mon"].Value.Equals("1") ? true : false;
                    datesheets.Tus = period.Attributes["tus"].Value.Equals("1") ? true : false;
                    datesheets.Wed = period.Attributes["wed"].Value.Equals("1") ? true : false;
                    datesheets.Thu = period.Attributes["thu"].Value.Equals("1") ? true : false;
                    datesheets.Fri = period.Attributes["fri"].Value.Equals("1") ? true : false;
                    datesheets.Sat = period.Attributes["sat"].Value.Equals("1") ? true : false;
                    datesheets.Sun = period.Attributes["sun"].Value.Equals("1") ? true : false;
                    datesheets.timesheets = new List<TimeSheet>();

                    XmlNodeList timelist = period.ChildNodes;
                    foreach (XmlNode timewindow in timelist)
                    {
                        TimeSheet timesheets = new TimeSheet();
                        timesheets.startTime = DateTime.Parse(timewindow.Attributes["start"].Value);
                        timesheets.endTime = DateTime.Parse(timewindow.Attributes["end"].Value);
                        string mode = timewindow.Attributes["mode"].Value;
                        if (mode.Equals("sequencial")) { timesheets.mode = PlayMode.sequencial; }
                        if (mode.Equals("random")) { timesheets.mode = PlayMode.random; }
                        timesheets.contents = new List<Content>();

                        XmlNodeList itemlist = timewindow.ChildNodes;
                        foreach (XmlNode item in timewindow)
                        {
                            string type = item.Attributes["type"].Value;
                            if (type.Equals("dir"))
                            {
                                DirectoryInfo dir = new DirectoryInfo(item.Attributes["src"].Value);
                                foreach (FileInfo file in dir.GetFiles())
                                {
                                    Content content = new Content();
                                    if (file.Extension.Contains("ppt"))
                                    { content.type = ContentType.powerpoint; }
                                    else
                                    { content.type = ContentType.video; }
                                    content.duration = int.Parse(item.Attributes["duration"].Value);
                                    content.file = file.FullName;
                                    timesheets.contents.Add(content);
                                }
                            }
                            else
                            {
                                Content content = new Content();
                                content.duration = int.Parse(item.Attributes["duration"].Value);
                                content.file = item.Attributes["src"].Value;                                
                                if (type.Equals("video")) { content.type = ContentType.video; }
                                if (type.Equals("ppt")) { content.type = ContentType.powerpoint; }
                                timesheets.contents.Add(content);
                            }
                        }
                        datesheets.timesheets.Add(timesheets);
                    }
                    config.datesheets.Add(datesheets);
                }

                LogXML("log file read successfully: \"" + path + "\"");

                return true;
            }
            catch (Exception e) 
            {
                LogXML(e.Message);
                return false; 
            }
        }

        private void LogXML(string s)
        {
            log.WriteConsoleAndLog("[XML]=====>>>>> " + s);
        }
    }
}

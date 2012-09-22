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

        #region left funcs
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
        #endregion

        public bool ReadPlayConfig(ref Config config, ref string error)
        {
            return ReadPlayConfig(ref config, true, ref error);
        }

        /// <summary>
        /// 读取播放配置
        /// </summary>
        /// <returns></returns>
        public bool ReadPlayConfig(ref Config config, bool expendDir, ref string error)
        {
            error = string.Empty;

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);

                XmlNode system = doc.SelectSingleNode("system");

                XmlNode screen = system.SelectSingleNode("screen");
                config.scr = int.Parse(screen.Attributes["index"].Value);

                XmlNode idle = system.SelectSingleNode("idle");
                config.idle = new Content();
                string idletype = idle.Attributes["type"].Value;
                if (idletype.Equals("video")) { config.idle.type = ContentType.video; }
                if (idletype.Equals("powerpoint")) { config.idle.type = ContentType.powerpoint; }
                config.idle.file = idle.Attributes["src"].Value;
                config.idle.duration = int.Parse(idle.Attributes["duration"].Value);

                XmlNode sleep = system.SelectSingleNode("sleep");
                config.sleep = new Sleep();
                config.sleep.timespan.startTime = DateTime.Parse(sleep.Attributes["starttime"].Value);
                config.sleep.timespan.endTime = DateTime.Parse(sleep.Attributes["endtime"].Value);
                config.sleep.enable = sleep.Attributes["enable"].Value == "0" ? false : true;

                XmlNode notice = system.SelectSingleNode("notice");
                config.notice.bold = notice.Attributes["bold"].Value == "0" ? false : true;
                config.notice.color = Color.FromName(notice.Attributes["color"].Value);
                config.notice.bgcolor = Color.FromName(notice.Attributes["bgcolor"].Value);
                config.notice.font = notice.Attributes["fontname"].Value;
                config.notice.size = int.Parse(notice.Attributes["size"].Value);
                config.notice.interval = int.Parse(notice.Attributes["speed"].Value);

                XmlNode intermedia = system.SelectSingleNode("intermedia");
                config.intermedia.enable = intermedia.Attributes["enable"].Value == "0" ? false : true;
                config.intermedia.limit = int.Parse(intermedia.Attributes["limit"].Value);
                config.intermedia.duration = int.Parse(intermedia.Attributes["duration"].Value);
                if(config.intermedia.contents == null) config.intermedia.contents = new List<Content>();
                /*DirectoryInfo d = new DirectoryInfo(intermedia.Attributes["root"].Value);
                if (d.Exists)
                {
                    foreach (FileInfo file in d.GetFiles())
                    {
                        Content content = new Content();
                        if (file.Extension.Contains("ppt")) { content.type = ContentType.powerpoint; }
                        else { content.type = ContentType.video; }
                        content.duration = config.intermedia.duration;
                        content.file = file.FullName;
                        config.intermedia.contents.Add(content);
                    }
                }*/

                XmlNode syscfg = system.SelectSingleNode("syscfg");
                config.syscfg.sysDuration = syscfg.Attributes["sysduration"].Value == "0" ? false : true;
                config.syscfg.duration = int.Parse(syscfg.Attributes["duration"].Value);

                XmlNodeList root = system.SelectNodes("period");
                config.datesheets = new List<DateSheet>();
                foreach (XmlNode period in root)
                {
                    DateSheet datesheets = new DateSheet();

                    datesheets.startDate = DateTime.Parse(period.Attributes["startdate"].Value);
                    datesheets.endDate = DateTime.Parse(period.Attributes["enddate"].Value + " 23:59:59");

                    datesheets.Mon = period.Attributes["mon"].Value.Equals("1") ? true : false;
                    datesheets.Tue = period.Attributes["tue"].Value.Equals("1") ? true : false;
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
                        timesheets.startTime = DateTime.Parse(timewindow.Attributes["starttime"].Value);
                        timesheets.endTime = DateTime.Parse(timewindow.Attributes["endtime"].Value);
                        string mode = timewindow.Attributes["mode"].Value;
                        if (mode.Equals("sequencial")) { timesheets.mode = PlayMode.sequencial; }
                        if (mode.Equals("random")) { timesheets.mode = PlayMode.random; }
                        timesheets.contents = new List<Content>();

                        XmlNodeList itemlist = timewindow.ChildNodes;
                        foreach (XmlNode item in timewindow)
                        {
                            string type = item.Attributes["type"].Value;
                            if (type.Equals("dir") && expendDir)
                            {
                                DirectoryInfo dir = new DirectoryInfo(item.Attributes["src"].Value);
                                foreach (FileInfo file in dir.GetFiles())
                                {
                                    Content content = new Content();
                                    if (file.Extension.Contains("ppt")) { content.type = ContentType.powerpoint; }
                                    else { content.type = ContentType.video; }
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
                                if (type.Equals("dir")) { content.type = ContentType.dir; }
                                if (type.Equals("video")) { content.type = ContentType.video; }
                                if (type.Equals("powerpoint")) { content.type = ContentType.powerpoint; }
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
                error = e.Message;
                return false;
            }
        }

        /// <summary>
        /// 保存播放配置
        /// </summary>
        /// <param name="config"></param>
        /// <returns>error message</returns>
        public string SavePlayConfig(Config config)
        {
            string err = string.Empty;

            for (int i = 1; i < config.datesheets.Count; i++)
            {
                DateSheet ds = config.datesheets[i];
                DateSheet prevds = config.datesheets[i - 1];
                if (ds.startDate.Date < prevds.endDate.Date)
                {
                    return "时间段起始日期：" + ds.startDate.ToShortDateString() + "早于上一时间段终止日期：" + prevds.endDate.ToShortDateString();
                }
                for (int j = 1; j < ds.timesheets.Count; j++)
                {
                    TimeSheet ts = ds.timesheets[j];
                    TimeSheet prevts = ds.timesheets[j - 1];
                    if (ts.startTime.TimeOfDay < prevts.endTime.TimeOfDay)
                    {
                        return "时间段起始时间：" + ts.startTime.ToLongTimeString() + "早于上一时间段终止时间：" + prevts.endTime.ToLongTimeString();
                    }
                }
            }

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);

                XmlNode system = doc.SelectSingleNode("system");

                XmlNodeList periods = system.SelectNodes("period");
                foreach (XmlNode period in periods)
                    system.RemoveChild(period);

                foreach (DateSheet datesheet in config.datesheets)
                {
                    XmlElement date = doc.CreateElement("period");
                    date.SetAttribute("startdate", datesheet.startDate.ToShortDateString());
                    date.SetAttribute("enddate", datesheet.endDate.ToShortDateString());
                    date.SetAttribute("mon", datesheet.Mon ? "1" : "0");
                    date.SetAttribute("tue", datesheet.Tue ? "1" : "0");
                    date.SetAttribute("wed", datesheet.Wed ? "1" : "0");
                    date.SetAttribute("thu", datesheet.Thu ? "1" : "0");
                    date.SetAttribute("fri", datesheet.Fri ? "1" : "0");
                    date.SetAttribute("sat", datesheet.Sat ? "1" : "0");
                    date.SetAttribute("sun", datesheet.Sun ? "1" : "0");
                    foreach (TimeSheet timesheet in datesheet.timesheets)
                    {
                        XmlElement time = doc.CreateElement("time");
                        time.SetAttribute("starttime", timesheet.startTime.ToLongTimeString());
                        time.SetAttribute("endtime", timesheet.endTime.ToLongTimeString());
                        time.SetAttribute("mode", timesheet.mode.ToString());
                        foreach (Content content in timesheet.contents)
                        {
                            XmlElement item = doc.CreateElement("item");
                            item.SetAttribute("type", content.type.ToString());
                            item.SetAttribute("src", content.file.ToString());
                            item.SetAttribute("duration", content.duration.ToString());
                            time.AppendChild(item);
                        }
                        date.AppendChild(time);
                    }
                    system.AppendChild(date);
                }

                doc.Save(path);

                return err;
            }
            catch (Exception e)
            {
                LogXML(e.Message);
                return e.Message;
            }
        }

        private void LogXML(string s)
        {
            log.WriteConsoleAndLog("[XML]=====>>>>> " + s);
        }
    }
}
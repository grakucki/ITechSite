using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace ITechSite.Areas.Testy.Models
{
    public partial class TestKompetencji
    {
        public int getFirstQuestionId()
        {
            var xml = this.xml;
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlNodeList nodeList = doc.SelectNodes("/Test/questions/question");

            if (nodeList.Count > 0)
                return Int32.Parse(nodeList[0]["id"].InnerText);
            else
                return 0;
        }

        public int getNextQuestionId(int qId)
        {
            var xml = this.xml;
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            XmlNodeList nodeList = doc.SelectNodes("/Test/questions/question");

            int nextId = 0;

            for(int i=0;i<nodeList.Count;i++)
            {
                if (Int32.Parse(nodeList[i]["id"].InnerText) == qId && (i+1) < nodeList.Count)
                {
                    nextId = Int32.Parse(nodeList[i + 1]["id"].InnerText);
                    break;
                }
            }

            return nextId;
        }

        public int getPreviousQuestionId(int qId)
        {
            var xml = this.xml;
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            XmlNodeList nodeList = doc.SelectNodes("/Test/questions/question");

            int prevId = 0;

            for (int i = 0; i < nodeList.Count; i++)
            {
                if (Int32.Parse(nodeList[i]["id"].InnerText) == qId && (i - 1) > -1)
                {
                    prevId = Int32.Parse(nodeList[i - 1]["id"].InnerText);
                    break;
                }
            }

            return prevId;
        }
    }
}
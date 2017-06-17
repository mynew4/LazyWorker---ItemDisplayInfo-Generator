using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace d_itemDisplayGenerator.Sources.XMLParser
{
    public class XMLLoader
    {
        private static ConcurrentDictionary<string, ConcurrentDictionary<string, string>> d_itemDisplay = new ConcurrentDictionary<string, ConcurrentDictionary<string, string>>();
        private static ConcurrentDictionary<string, ConcurrentDictionary<string, string>> d_itemTemplate = new ConcurrentDictionary<string, ConcurrentDictionary<string, string>>();

        public XMLLoader()
        {
            if (d_itemDisplay.IsEmpty)
                initAllItemDisplay();
            if (d_itemTemplate.IsEmpty)
                initAllItemTemplate();
            // debug
            //foreach (KeyValuePair<string, ConcurrentDictionary<string, string>> kvp in allItems)
            //{
            //    //textBox3.Text += ("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            //    foreach (KeyValuePair<string, string> kvp2 in kvp.Value)
            //    {
            //        Console.WriteLine("Key = {0}, Value = {1}", kvp2.Key, kvp2.Value);
            //    }

            //}
        }
        
        // ================================ Item Display Info Model ================================ \\
        public void initAllItemDisplay()
        {
            string XMLd_itemDisplayPath = "./Ressources/ItemDisplayInfo.xml";
            XElement doc = XElement.Load(XMLd_itemDisplayPath);
            IEnumerable<XElement> nodes = doc.Elements();
            ConcurrentDictionary<string, string> current = new ConcurrentDictionary<string, string>();

            Task.Factory.StartNew(() =>
            {
                foreach (var node in nodes)
                {
                    foreach (XElement xe in node.Elements())
                        current.TryAdd(xe.Name.ToString(), xe.Value.ToString());
                    d_itemDisplay.TryAdd(node.Element("m_ID").Value, current);
                    current = new ConcurrentDictionary<string, string>();
                }
            });
        }

        public ConcurrentDictionary<string, string> loadItemDisplay(string id)
        {
            return d_itemDisplay.ContainsKey(id) ? d_itemDisplay[id] : null;
        }


        // ================================ Item Template ================================ \\
        public void initAllItemTemplate()
        {
            string XMLItemTemplate = "./Ressources/Item_Template.xml";
            XElement doc = XElement.Load(XMLItemTemplate);
            IEnumerable<XElement> nodes = doc.Elements();
            ConcurrentDictionary<string, string> current = new ConcurrentDictionary<string, string>();

            Task.Factory.StartNew(() =>
            {
                foreach (var node in nodes)
                {
                    foreach (XElement xe in node.Elements())
                        current.TryAdd(xe.Name.ToString(), xe.Value.ToString());
                    d_itemTemplate.TryAdd(node.Element("entry").Value, current);
                    current = new ConcurrentDictionary<string, string>();
                }
            });
        }

        public ConcurrentDictionary<string, string> loadItemTemplateById(string id)
        {
            return d_itemTemplate.ContainsKey(id) ? d_itemTemplate[id] : null;
        }

        // ================================ Item Appearence ================================ \\
    }
}

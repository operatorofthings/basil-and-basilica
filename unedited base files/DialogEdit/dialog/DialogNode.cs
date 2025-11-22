using System.Collections.Generic;
using System.IO;

namespace DialogEdit.dialog
{
    public class DialogNode
    {
        public DialogNode()
        {
        }

        public DialogNode(DialogNode dialogNode)
        {
            this.name = dialogNode.name;
            this.text = new TextSeries[dialogNode.text.Length];
            for (int i = 0; i < this.text.Length; i++)
            {
                this.text[i].text = dialogNode.text[i].text;
            }
            this.option = new NodeOption[5];
            for (int j = 0; j < 5; j++)
            {
                this.option[j] = new NodeOption(dialogNode.option[j]);
            }
            this.precheckFlagStr = new string[dialogNode.precheckFlagStr.Length];
            this.precheckFlagGoto = new string[dialogNode.precheckFlagGoto.Length];
            for (int k = 0; k < 4; k++)
            {
                this.precheckFlagStr[k] = dialogNode.precheckFlagStr[k];
                this.precheckFlagGoto[k] = dialogNode.precheckFlagGoto[k];
            }
            this.postSetFlagStr = dialogNode.postSetFlagStr;
            this.postGoto = dialogNode.postGoto;
            this.giveScript = dialogNode.giveScript;
            this.storeScript = dialogNode.storeScript;
        }

        internal void Read(BinaryReader reader)
        {
            this.name = reader.ReadString();
            this.text = new TextSeries[13];
            for (int i = 0; i < 13; i++)
            {
                this.text[i] = new TextSeries();
                string text = reader.ReadString();
                if (text == "")
                {
                    this.text[i].text = null;
                }
                else if (i == 6)
                {
                    if (text.StartsWith(">") && text.Length > 1)
                    {
                        text = text.Substring(1);
                    }
                    this.text[i].text = text.Split(new char[]
                    {
                        '>'
                    });
                }
                else
                {
                    this.text[i].text = text.Split(new char[]
                    {
                        '\n'
                    });
                }
            }
            this.precheckFlagStr = new string[4];
            this.precheckFlagGoto = new string[4];
            List<NodeOption> list = new List<NodeOption>();
            for (int j = 0; j < 5; j++)
            {
                NodeOption nodeOption = new NodeOption();
                nodeOption.Read(reader);
                if (nodeOption.text[0] != "")
                {
                    list.Add(nodeOption);
                }
            }
            if (list.Count > 0)
            {
                this.option = list.ToArray();
            }
            else
            {
                this.option = null;
            }
            for (int k = 0; k < 4; k++)
            {
                this.precheckFlagStr[k] = reader.ReadString();
                this.precheckFlagGoto[k] = reader.ReadString();
            }
            this.postSetFlagStr = reader.ReadString();
            this.postGoto = reader.ReadString();
            string text2 = reader.ReadString();
            if (text2 != "")
            {
                this.giveScript = text2.Split(new char[]
                {
                    '\r'
                });
                text2 = "";
                foreach (string str in this.giveScript)
                {
                    text2 += str;
                }
                this.giveScript = text2.Split(new char[]
                {
                    '\n'
                });
            }
            else
            {
                this.giveScript = null;
            }
            text2 = reader.ReadString();
            if (text2 != "")
            {
                this.storeScript = text2.Split(new char[]
                {
                    '\r'
                });
                text2 = "";
                foreach (string str2 in this.storeScript)
                {
                    text2 += str2;
                }
                this.storeScript = text2.Split(new char[]
                {
                    '\n'
                });
                return;
            }
            this.storeScript = null;
        }

        private const int TOTAL_PRECHECKS = 4;

        public const int TOTAL_NODE_OPTIONS = 5;

        public string name;

        public TextSeries[] text;

        public NodeOption[] option;

        public string[] precheckFlagStr;

        public string[] precheckFlagGoto;

        public string postSetFlagStr;

        public string postGoto;

        public string[] giveScript;

        public string[] storeScript;
    }
}
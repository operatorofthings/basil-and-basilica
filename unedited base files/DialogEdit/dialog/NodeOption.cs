using LootEdit;
using System.IO;

namespace DialogEdit.dialog
{
    public class NodeOption
    {
        public NodeOption()
        {
            this.text = new string[13];
            for (int i = 0; i < this.text.Length; i++)
            {
                this.text[i] = "";
            }
            this.action = "";
            this.coopAction = "";
        }

        public NodeOption(NodeOption nodeOption)
        {
            this.text = new string[nodeOption.text.Length];
            for (int i = 0; i < this.text.Length; i++)
            {
                this.text[i] = nodeOption.text[i];
            }
            this.action = nodeOption.action;
            this.coopAction = nodeOption.coopAction;
        }

        internal void Write(BinaryWriter writer)
        {
            for (int i = 0; i < 13; i++)
            {
                if (i < this.text.Length)
                {
                    writer.Write(this.text[i]);
                }
                else
                {
                    writer.Write(this.text[0] + " - " + TranslationMgr.GetLangStrFromIdx(i));
                }
            }
            writer.Write(this.action);
            writer.Write(this.coopAction);
        }

        internal void Read(BinaryReader reader)
        {
            for (int i = 0; i < this.text.Length; i++)
            {
                this.text[i] = reader.ReadString();
            }
            this.action = reader.ReadString();
            this.coopAction = reader.ReadString();
        }

        public string[] text;

        public string action;

        public string coopAction;
    }
}
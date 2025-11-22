namespace DialogEdit.dialog
{
    public class LocPair
    {
        public LocPair(int ID)
        {
            this.orig = "NEW_" + ID.ToString();
            this.locStr = new string[13];
            for (int i = 0; i < this.locStr.Length; i++)
            {
                this.locStr[i] = "";
            }
        }

        public LocPair(string p)
        {
            this.orig = p;
            this.locStr = new string[13];
            for (int i = 0; i < this.locStr.Length; i++)
            {
                this.locStr[i] = "";
            }
        }

        public string orig;

        public string[] locStr;
    }
}
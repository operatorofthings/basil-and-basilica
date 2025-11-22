using System.Collections.Generic;

namespace LootEdit
{
    public class TranslationMgr
    {
        internal static string GetLangStrFromIdx(int i)
        {
            return "Error";
        }

        public const int LANGUAGE_ENGLISH = 0;

        public const int LANGUAGE_FRENCH = 1;

        public const int LANGUAGE_ITALIAN = 2;

        public const int LANGUAGE_GERMAN = 3;

        public const int LANGUAGE_SPANISH = 4;

        public const int LANGUAGE_PORTUGUESE = 5;

        public const int LANGUAGE_JAPANESE = 6;

        public const int LANGUAGE_CHINESE_SIMPLIFIED = 7;

        public const int LANGUAGE_KOREAN = 8;

        public const int LANGUAGE_RUSSIAN = 9;

        public const int LANGUAGE_POLISH = 10;

        public const int LANGUAGE_CHINESE_TRADITIONAL = 11;

        public const int LANGUAGE_UNUSED_2 = 12;

        public const int MAX_LANGUAGES = 7;

        public const int NEW_MAX_LANGUAGES = 13;

        public const int FILETYPE_LOOTNAME = 0;

        public const int FILETYPE_LOOTDEF = 1;

        public const int FILETYPE_MONSTERNAME = 2;

        public const int FILETYPE_MONSTERDEF = 3;

        public const int FILETYPE_DIALOG = 4;

        public const int FILETYPE_SKILLDESC = 6;

        public const int FILETYPE_STRING = 7;

        public const int FILETYPE_DIALOG_OPTION = 8;

        public static Dictionary<string, string> rawPairs;

        public static Dictionary<string, string[]> rawTuples;
    }
}
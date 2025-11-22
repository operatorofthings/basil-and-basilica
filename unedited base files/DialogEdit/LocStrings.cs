using DialogEdit.dialog;
using System.Text;

namespace DialogEdit
{
    public class LocStrings
    {
        public static string GetLocStr(int i)
        {
            return DialogMgr.GetLocStr(i);
        }

        public static StringBuilder GetLocString(int i)
        {
            return DialogMgr.GetLocString(i);
        }

        public const int STR_SHIELD_REDUC = 0;

        public const int STR_SHIELD_DEFLECT = 1;

        public const int STR_SHIELD_PHYS = 2;

        public const int STR_SHIELD_FIRE = 3;

        public const int STR_SHIELD_LIT = 4;

        public const int STR_SHIELD_POISON = 5;

        public const int STR_SHIELD_BLADED = 6;

        public const int STR_SHIELD_HOLY = 7;

        public const int STR_SHIELD_DARK = 8;

        public const int STR_ARMOR_PHYS = 9;

        public const int STR_ARMOR_FIRE = 10;

        public const int STR_ARMOR_LIT = 11;

        public const int STR_ARMOR_BLADED = 12;

        public const int STR_ARMOR_POISON = 13;

        public const int STR_ARMOR_HOLY = 14;

        public const int STR_ARMOR_DARK = 15;

        public const int STR_ARMOR_POISE = 16;

        public const int STR_WEAP_ATTACK = 17;

        public const int STR_WEAP_SCL_STR = 18;

        public const int STR_WEAP_SCL_DEX = 19;

        public const int STR_WEAP_SCL_MAG = 20;

        public const int STR_WEAP_SCL_WIS = 21;

        public const int STR_WEAP_FIRE = 22;

        public const int STR_WEAP_LIT = 23;

        public const int STR_WEAP_POISON = 24;

        public const int STR_WEAP_FROST = 25;

        public const int STR_WEAP_HOLY = 26;

        public const int STR_WEAP_DARK = 27;

        public const int STR_WEIGHT = 28;

        public const int STR_DURABILITY = 29;

        public const int STR_SCL_S = 30;

        public const int STR_SCL_A = 31;

        public const int STR_SCL_B = 32;

        public const int STR_SCL_C = 33;

        public const int STR_SCL_D = 34;

        public const int STR_SCL_E = 35;

        public const int STR_SCL_N = 36;

        public const int STR_REQ_STR = 37;

        public const int STR_REQ_DEX = 38;

        public const int STR_REQ_MAG = 39;

        public const int STR_REQ_WIS = 40;

        public const int STR_S_REQ_STR = 41;

        public const int STR_S_REQ_DEX = 42;

        public const int STR_S_REQ_MAG = 43;

        public const int STR_S_REQ_WIS = 44;

        public const int STR_WEAP_SPARK = 45;

        public const int STR_WEAP_NATURAL = 46;

        public const int STR_WEAP_MAGIC = 47;

        public const int STR_TENDENCY_PHYSICAL = 48;

        public const int STR_TENDENCY_NATURAL = 49;

        public const int STR_TENDENCY_SPARK = 50;

        public const int STR_TENDENCY_MAGIC = 51;

        public const int STR_SALT = 52;

        public const int STR_TENDENCY = 53;

        public const int STR_SLASH = 54;

        public const int STR_ELEMENTAL_NONE = 55;

        public const int STR_ELEMENTAL_FIRE = 56;

        public const int STR_ELEMENTAL_LIGHTNING = 57;

        public const int STR_ELEMENTAL_FROST = 58;

        public const int STR_ELEMENTAL_POISON = 59;

        public const int STR_ELEMENTAL_HOLY = 60;

        public const int STR_ELEMENTAL_DARK = 61;

        public const int STR_ELEMENTAL = 62;

        public const int STR_O_PAREN = 63;

        public const int STR_C_PAREN = 64;

        public const int STR_POWER = 65;

        public const int STR_POWER_NAT_BUFF = 66;

        public const int STR_POWER_NAT_RAIN = 67;

        public const int STR_POWER_NAT_NOVA = 68;

        public const int STR_POWER_SPARK_BUFF = 69;

        public const int STR_POWER_SPARK_WAVE = 70;

        public const int STR_POWER_SPARK_BOLT = 71;

        public const int STR_POWER_MAGIC_BUFF = 72;

        public const int STR_POWER_MAGIC_HEAL = 73;

        public const int STR_POWER_MAGIC_PILLAR = 74;

        public const int STR_POWER_MAGIC_COIL = 75;

        public const int STR_REQ_FORT = 76;

        public const int STR_NO_MATERIAL = 77;

        public const int STR_NO_KEYS = 78;

        public const int STR_SELECT = 79;

        public const int STR_UNEQUIP = 80;

        public const int STR_INFO = 81;

        public const int STR_CLOSE = 82;

        public const int STR_DESCRIPTION = 83;

        public const int STR_EQUIP = 84;

        public const int STR_NO_WEAPONS = 85;

        public const int STR_NO_SHIELDS = 86;

        public const int STR_NO_HELMS = 87;

        public const int STR_NO_ARMOR = 88;

        public const int STR_NO_GLOVES = 89;

        public const int STR_NO_BOOTS = 90;

        public const int STR_NO_ARROWS = 91;

        public const int STR_NO_RINGS = 92;

        public const int STR_NO_CONSUMABLES = 93;

        public const int STR_NO_SPELLS = 94;

        public const int STR_BUY = 95;

        public const int STR_MAGIC_COST = 96;

        public const int STR_NO_OFFERINGS = 97;

        public const int STR_CONFIRM = 98;

        public const int STR_CANCEL = 99;

        public const int STR_TRANSMUTE = 100;

        public const int STR_TRAVEL = 101;

        public const int STR_VISITS = 102;

        public const int STR_NO_TRANSMUTE = 103;

        public const int STR_UPGRADE = 104;

        public const int STR_REQ_WEAP_TYPE_DAGGER = 105;

        public const int STR_REQ_WEAP_TYPE_SWORD = 106;

        public const int STR_REQ_WEAP_TYPE_HAMMER = 107;

        public const int STR_REQ_WEAP_TYPE_AXE = 108;

        public const int STR_REQ_WEAP_TYPE_SPEAR = 109;

        public const int STR_REQ_WEAP_TYPE_HALBERD = 110;

        public const int STR_REQ_WEAP_TYPE_GREATSWORD = 111;

        public const int STR_REQ_WEAP_TYPE_GREATHAMMER = 112;

        public const int STR_REQ_WEAP_TYPE_BOW = 113;

        public const int STR_REQ_WEAP_TYPE_CROSSBOW = 114;

        public const int STR_REQ_WEAP_TYPE_STAFF = 115;

        public const int STR_REQ_WEAP_TYPE_WHIP = 116;

        public const int STR_REQ_WEAP_TYPE_GREATAXE = 117;

        public const int STR_REQ_WEAP_TYPE_POLEAXE = 118;

        public const int STR_REQ_WEAP_TYPE_FLINTLOCK = 119;

        public const int STR_REQ_WEAP_TYPE_TORCH = 120;

        public const int STR_REQ_WEAP_TYPE_WAND = 121;

        public const int STR_REQ_WEAP_TYPE_UNUSED_1 = 122;

        public const int STR_REQ_WEAP_TYPE_UNUSED_2 = 123;

        public const int STR_REQ_WEAP_TYPE_UNUSED_3 = 124;

        public const int STR_REQ_WEAP_TYPE_UNUSED_4 = 125;

        public const int STR_REQ_WEAP_TYPE_UNUSED_5 = 126;

        public const int STR_REQ_WEAP_TYPE_UNUSED_6 = 127;

        public const int STR_REQ_WEAP_TYPE_UNUSED_7 = 128;

        public const int STR_REQ_WEAP_TYPE_UNUSED_8 = 129;

        public const int STR_CLASS = 130;

        public const int STR_MAGIC_CLASS = 131;

        public const int STR_PRAYER_CLASS = 132;

        public const int STR_SHIELD_BUCKLER = 133;

        public const int STR_SHIELD_HEATER = 134;

        public const int STR_SHIELD_KITE = 135;

        public const int STR_SHIELD_TOWER = 136;

        public const int STR_ARMOR = 137;

        public const int STR_NO_CHARMS = 138;

        public const int STR_NO_BOLTS = 139;

        public const int STR_NO_STOCK = 140;

        public const int STR_TURN_IN = 141;

        public const int STR_NO_RUNES = 142;

        public const int STR_L3_PERCENT = 143;

        public const int STR_LIGHT_ARMOR = 144;

        public const int STR_R1_INFO = 145;

        public const int STR_R1_STATS = 146;

        public const int STR_DELETE = 147;

        public const int STR_SELL = 148;

        public const int STR_INVENTORY = 149;

        public const int STR_BESTIARY = 150;

        public const int STR_MENU = 151;

        public const int STR_NO_BULLETS = 152;

        public const int STR_1H = 153;

        public const int STR_2H = 154;

        public const int STR_TOGGLE_1H_2H = 155;

        public const int STR_PEARL_UPGRADE = 156;

        public const int STR_REMOVE = 157;

        public const int STR_DELETE_CHARACTER = 158;

        public const int STR_LEVEL = 159;

        public const int STR_EQUIP_STATS = 160;

        public const int STR_VITALITY = 161;

        public const int STR_STRENGTH = 162;

        public const int STR_STAMINA = 163;

        public const int STR_DEXTERITY = 164;

        public const int STR_MAGIC = 165;

        public const int STR_WISDOM = 166;

        public const int STR_EQUIP_L = 167;

        public const int STR_EQUIP_M = 168;

        public const int STR_EQUIP_H = 169;

        public const int STR_EQUIP_O = 170;

        public const int STR_PHYS_DEF = 171;

        public const int STR_FIRE_DEF = 172;

        public const int STR_LIT_DEF = 173;

        public const int STR_BLADED_DEF = 174;

        public const int STR_POISON_DEF = 175;

        public const int STR_HOLY_DEF = 176;

        public const int STR_DARK_DEF = 177;

        public const int STR_POISE = 178;

        public const int STR_ATTACK = 179;

        public const int STR_SALT_COST = 180;

        public const int STR_SALT_AVAIL = 181;

        public const int STR_MAX_HP = 182;

        public const int STR_MAX_MP = 183;

        public const int STR_MAX_SP = 184;

        public const int STR_SPIRIT = 185;

        public const int STR_ENDURANCE = 186;

        public const int STR_WILL = 187;

        public const int STR_MAIN = 188;

        public const int STR_STATS = 189;

        public const int STR_DEFENSE = 190;

        public const int STR_CREED = 191;

        public const int STR_CREED_NONE = 192;

        public const int STR_CREED_IRON = 193;

        public const int STR_CREED_CLERIC = 194;

        public const int STR_CREED_THREE = 195;

        public const int STR_CREED_WOODS = 196;

        public const int STR_CREED_DARK = 197;

        public const int STR_CREED_SPLENDOR = 198;

        public const int STR_CREED_FOOL = 199;

        public const int STR_CREED_FIRE = 200;

        public const int STR_CREED_BONES = 201;

        public const int STR_DROP_RATE = 202;

        public const int STR_ARDOR_LEVEL = 203;

        public const int STR_LV = 204;

        public const int STR_PR = 205;

        public const int STR_EMPTY_SLOT = 206;

        public const int STR_CHARACTER_ROSTER = 207;

        public const int STR_YES = 208;

        public const int STR_NO = 209;

        public const int STR_CANCEL_CREATION = 210;

        public const int STR_NAME = 211;

        public const int STR_SEX = 212;

        public const int STR_HAIR = 213;

        public const int STR_HAIR_COLOR = 214;

        public const int STR_WHISKERS = 215;

        public const int STR_WHISKERS_COLOR = 216;

        public const int STR_EYE_COLOR = 217;

        public const int STR_ORIGIN = 218;

        public const int STR_EFFECTS = 219;

        public const int STR_VENTURE_FORTH = 220;

        public const int STR_WHAT_IS_YOUR_NAME = 221;

        public const int STR_ACCEPT = 222;

        public const int STR_BACK = 223;

        public const int STR_ACCEPT_CHANGES = 224;

        public const int STR_AUDIO = 225;

        public const int STR_SFX = 226;

        public const int STR_BGM = 227;

        public const int STR_NOTES = 228;

        public const int STR_OPTIONS = 229;

        public const int STR_VIDEO = 230;

        public const int STR_VIDEO_SETTINGS = 231;

        public const int STR_FULLSCREEN = 232;

        public const int STR_OFF = 233;

        public const int STR_ON = 234;

        public const int STR_WHAT_IS_LOST = 235;

        public const int STR_QUIT = 236;

        public const int STR_STATS_WILL_BE_SAVED = 237;

        public const int STR_NEW_GAME = 238;

        public const int STR_CONTINUE = 239;

        public const int STR_EXIT = 240;

        public const int STR_AUDIO_SETTINGS = 241;

        public const int STR_END_GAME = 242;

        public const int STR_GAME = 243;

        public const int STR_APPLY = 244;

        public const int STR_REALLY_DELETE = 245;

        public const int STR_FOREVER_VANQUISH = 246;

        public const int STR_LEVEL_2 = 247;

        public const int STR_WRITE_MESSAGE = 248;

        public const int STR_AN_IMPROPERLY_PUNCTUATED = 249;

        public const int STR_EDIT = 250;

        public const int STR_PURCHASE_SKILL = 251;

        public const int STR_ACCEPT_TRANSMUTATION = 252;

        public const int STR_YOU_HAVE_INSUFFICIENT = 253;

        public const int STR_ACCEPT_UPGRADE = 254;

        public const int STR_RING_BELL = 255;

        public const int STR_BELL_RETURNED = 256;

        public const int STR_BELL_COOP_RETURNED = 257;

        public const int STR_PURCHASE = 258;

        public const int STR_PURCHASE_ITEM = 259;

        public const int STR_SELL_ITEM = 260;

        public const int STR_CANCEL_MESSAGE = 261;

        public const int STR_CLEANSE_CORRUPTION = 262;

        public const int STR_DESECRATE_ALTAR = 263;

        public const int STR_FORGIVE_SIN = 264;

        public const int STR_SELLSWORD_PRESS = 265;

        public const int STR_AWAITING_SELLSWORD = 266;

        public const int STR_NEED_MORE_SALT = 267;

        public const int STR_LEVEL_UP = 268;

        public const int STR_ASCEND_TO_LEVEL = 269;

        public const int STR_WITH_SALT_EVEN = 270;

        public const int STR_YOU_ARE_NOT_CORRUPT = 271;

        public const int STR_OK = 272;

        public const int STR_COST = 273;

        public const int STR_WITH_SALT_YOUR = 274;

        public const int STR_YOU_HAVE_NO_SIN = 275;

        public const int STR_DESECRATE_THE_ALTAR = 276;

        public const int STR_THE_SANCTUARY_WILL = 277;

        public const int STR_DEFEAT_THE_GUARDIANS = 278;

        public const int STR_SUCCEED_OR_FAIL = 279;

        public const int STR_JOIN_CREED = 280;

        public const int STR_TAKE_THE_OATH = 281;

        public const int STR_JOINING_A_CREED = 282;

        public const int STR_YOU_WILL_DENOUNCE = 283;

        public const int STR_YOU_WILL_ABANDON = 284;

        public const int STR_COMPOSE_MESSAGE = 285;

        public const int STR_OPEN_CHEST = 286;

        public const int STR_PULL_LEVER = 287;

        public const int STR_READ_MESSAGE = 288;

        public const int STR_TOUCH_OBELISK = 289;

        public const int STR_OPEN_DOOR = 290;

        public const int STR_KICK_LADDER = 291;

        public const int STR_SECRET_DOOR = 292;

        public const int STR_SECRET_SLASH = 293;

        public const int STR_AREA = 294;

        public const int STR_LIGHT_CANDLE = 295;

        public const int STR_PICK_UP = 296;

        public const int STR_CLAIM_SANCTUARY = 297;

        public const int STR_EQUIP_ICON = 298;

        public const int STR_SELECT_ICON = 299;

        public const int STR_SELECT_CONSUMABLES = 300;

        public const int STR_DESECRATE_SANCTUARY = 301;

        public const int STR_TALK_TO_PRIEST = 302;

        public const int STR_TALK_TO_MERCHANT = 303;

        public const int STR_TALK_TO_BLACKSMITH = 304;

        public const int STR_TALK_TO_MAGE = 305;

        public const int STR_PRAY_AT_ALTAR = 306;

        public const int STR_TALK = 307;

        public const int STR_LEVEL_UP_2 = 308;

        public const int STR_DONE = 309;

        public const int STR_TREE_OF_SKILL = 310;

        public const int STR_TAKE_OATH = 311;

        public const int STR_MAKE_OFFERING = 312;

        public const int STR_EQUIP_2 = 313;

        public const int STR_USE = 314;

        public const int STR_DROP = 315;

        public const int STR_OWNED = 316;

        public const int STR_PRESS_A = 317;

        public const int STR_THIS_WORLD_1 = 318;

        public const int STR_THIS_WORLD_2 = 319;

        public const int STR_THIS_WORLD_3 = 320;

        public const int STR_THIS_WORLD_4 = 321;

        public const int STR_FAILING_THIS_1 = 322;

        public const int STR_FAILING_THIS_2 = 323;

        public const int STR_FAILING_THIS_3 = 324;

        public const int STR_LANGUAGE = 325;

        public const int STR_ENGLISH = 326;

        public const int STR_FRENCH = 327;

        public const int STR_ITALIAN = 328;

        public const int STR_GERMAN = 329;

        public const int STR_SPANISH = 330;

        public const int STR_PORTUGUESE = 331;

        public const int STR_JAPANESE = 332;

        public const int STR_NO_INCANTATIONS = 333;

        public const int STR_FINISH = 334;

        public const int STR_SAVE_WARN_1 = 335;

        public const int STR_SAVE_WARN_2 = 336;

        public const int STR_BEARD_CLEAN = 337;

        public const int STR_BEARD_BEARD = 338;

        public const int STR_BEARD_VAN_DIJK = 339;

        public const int STR_BEARD_MOUSTACHE = 340;

        public const int STR_BEARD_MOUNTAINSMITH = 341;

        public const int STR_BEARD_PANS_BEARD = 342;

        public const int STR_BEARD_FULL = 343;

        public const int STR_BEARD_MOUCHE = 344;

        public const int STR_BEARD_SHAG = 345;

        public const int STR_BEARD_NOBLETRIM = 346;

        public const int STR_BEARD_SAGE = 347;

        public const int STR_CLASS_PALADIN = 348;

        public const int STR_CLASS_CLERIC = 349;

        public const int STR_CLASS_THIEF = 350;

        public const int STR_CLASS_MAGE = 351;

        public const int STR_CLASS_KNIGHT = 352;

        public const int STR_CLASS_PAUPER = 353;

        public const int STR_CLASS_CHEF = 354;

        public const int STR_CLASS_HUNTER = 355;

        public const int STR_HAIR_BALD = 356;

        public const int STR_HAIR_CREW = 357;

        public const int STR_HAIR_MESSY = 358;

        public const int STR_HAIR_DREADED = 359;

        public const int STR_HAIR_BANGS = 360;

        public const int STR_HAIR_BOB = 361;

        public const int STR_HAIR_SHORT = 362;

        public const int STR_HAIR_TOPKNOT = 363;

        public const int STR_HAIR_UPDO = 364;

        public const int STR_HAIR_SHAVED = 365;

        public const int STR_HAIR_BANDIT = 366;

        public const int STR_HAIR_BUNS = 367;

        public const int STR_HAIR_SPIKY = 368;

        public const int STR_HAIR_SHAG = 369;

        public const int STR_HAIR_WAVY = 370;

        public const int STR_HAIR_SAGECAP = 371;

        public const int STR_HAIR_RABBIT = 372;

        public const int STR_HAIR_FIRESTARTER = 373;

        public const int STR_HAIR_CROPPED = 374;

        public const int STR_HAIR_SHORT_FRO = 375;

        public const int STR_HAIR_SHORT_ROUND = 376;

        public const int STR_HAIR_DAMBAUB = 377;

        public const int STR_HAIR_ANTIMIAN = 378;

        public const int STR_HAIRCOLOR_RAVEN = 379;

        public const int STR_HAIRCOLOR_BRUNETTE = 380;

        public const int STR_HAIRCOLOR_HAZELNUT = 381;

        public const int STR_HAIRCOLOR_BLONDE = 382;

        public const int STR_HAIRCOLOR_BRONZE = 383;

        public const int STR_HAIRCOLOR_DARKSTEEL = 384;

        public const int STR_HAIRCOLOR_SILVER = 385;

        public const int STR_HAIRCOLOR_CLOUD = 386;

        public const int STR_HAIRCOLOR_BLUEBERRY = 387;

        public const int STR_HAIRCOLOR_MAGENTA = 388;

        public const int STR_HAIRCOLOR_CHARLIE_GREEN = 389;

        public const int STR_HAIRCOLOR_CHERRY = 390;

        public const int STR_HAIRCOLOR_AUBURN = 391;

        public const int STR_HAIRCOLOR_STRAWBERRY_BLOND = 392;

        public const int STR_HAIRCOLOR_ORCHID = 393;

        public const int STR_HAIRCOLOR_AQUA = 394;

        public const int STR_HAIRCOLOR_LIINX = 395;

        public const int STR_HAIRCOLOR_STARDUST = 396;

        public const int STR_EYECOLOR_BROWN = 397;

        public const int STR_EYECOLOR_GRAY = 398;

        public const int STR_EYECOLOR_BLUE = 399;

        public const int STR_EYECOLOR_GREEN = 400;

        public const int STR_EYECOLOR_SILVER = 401;

        public const int STR_EYECOLOR_BLACK = 402;

        public const int STR_EYECOLOR_RED = 403;

        public const int STR_EYECOLOR_CLEAR = 404;

        public const int STR_EYECOLOR_SKY = 405;

        public const int STR_EYECOLOR_YELLOW = 406;

        public const int STR_SKIN_MALE = 407;

        public const int STR_SKIN_FEMALE = 408;

        public const int STR_ORIGIN_KADANIA = 409;

        public const int STR_ORIGIN_MARKDOR = 410;

        public const int STR_ORIGIN_TRISTIN = 411;

        public const int STR_ORIGIN_KARHI = 412;

        public const int STR_ORIGIN_TAENIBIR = 413;

        public const int STR_ORIGIN_ASKARIA = 414;

        public const int STR_ORIGIN_LIVEN = 415;

        public const int STR_ORIGIN_KULKAAS = 416;

        public const int STR_ORIGIN_COASTROCK = 417;

        public const int STR_ORIGIN_DOR_ISLE = 418;

        public const int STR_ORIGIN_CITADEL = 419;

        public const int STR_ORIGIN_JONAS_LANDING = 420;

        public const int STR_CHANGE_NEXT_TIME = 421;

        public const int STR_CHG_NONE = 422;

        public const int STR_CHG_CHALLENGE = 423;

        public const int STR_CHG_NO_ARMOR = 424;

        public const int STR_CHG_HARDCORE_MODE = 425;

        public const int STR_CHG_NO_HEALING = 426;

        public const int STR_CHG_MAGIC_ONLY = 427;

        public const int STR_CHG_IRON_POT_ONLY = 428;

        public const int STR_CHG_OAR_ONLY = 429;

        public const int STR_CHG_NO_BLOCKING = 430;

        public const int STR_INTRO_1_1 = 431;

        public const int STR_INTRO_1_2 = 432;

        public const int STR_INTRO_1_3 = 433;

        public const int STR_INTRO_1_4 = 434;

        public const int STR_INTRO_2_1 = 435;

        public const int STR_INTRO_2_2 = 436;

        public const int STR_INTRO_2_3 = 437;

        public const int STR_SUPPLIES_RED_SHARDS = 438;

        public const int STR_SUPPLIES_STONE_SELLSWORD = 439;

        public const int STR_SUPPLIES_AMBER_IDOL = 440;

        public const int STR_SUPPLIES_GRASPING_RING = 441;

        public const int STR_SUPPLIES_CRYSTAL_SPHERE = 442;

        public const int STR_SUPPLIES_NONE = 443;

        public const int STR_MSG_ROSTERFULL = 444;

        public const int STR_MSG_ROSTERFULL_MSG = 445;

        public const int STR_MSG_MAX_LEVEL = 446;

        public const int STR_MSG_MAX_LEVEL_MSG = 447;

        public const int STR_TUT_PARRY = 448;

        public const int STR_TUT_ROLL = 449;

        public const int STR_TUT_LOADOUT = 450;

        public const int STR_TUT_USE_ITEM = 451;

        public const int STR_TUT_SWITCH_ITEM = 452;

        public const int STR_TUT_VIEW_INV = 453;

        public const int STR_NEED = 454;

        public const int STR_GIVE = 455;

        public const int STR_TUT_BLOCK = 456;

        public const int STR_TUT_DROP_DOWN = 457;

        public const int STR_CONTROLS = 458;

        public const int STR_HAIR_NATURAL = 459;

        public const int STR_CANT_OFFER = 460;

        public const int STR_VILLAGER_ALREADY_EXISTS = 461;

        public const int STR_MAX_VILLAGERS = 462;

        public const int STR_SKILL_SWORDFIGHTER_CLASS = 463;

        public const int STR_SKILL_SWORDFIGHTER_DESC_1 = 464;

        public const int STR_SKILL_SWORDFIGHTER_DESC_2 = 465;

        public const int STR_SKILL_SWORDFIGHTER_DESC_3 = 466;

        public const int STR_SKILL_BERZERKER_CLASS = 467;

        public const int STR_SKILL_BERZERKER_DESC_1 = 468;

        public const int STR_SKILL_ASSASSIN_CLASS = 469;

        public const int STR_SKILL_ASSASSIN_DESC_1 = 470;

        public const int STR_SKILL_DEFENDER_CLASS = 471;

        public const int STR_SKILL_DEFENDER_DESC_1 = 472;

        public const int STR_SKILL_HEAVYMACE_CLASS = 473;

        public const int STR_SKILL_HEAVYMACE_DESC_1 = 474;

        public const int STR_SKILL_HEAVYMACE_DESC_2 = 475;

        public const int STR_SKILL_HEAVYMACE_DESC_3 = 476;

        public const int STR_SKILL_HUNTER_CLASS = 477;

        public const int STR_SKILL_HUNTER_DESC_1 = 478;

        public const int STR_SKILL_CHANNELER_CLASS = 479;

        public const int STR_SKILL_CHANNELER_DESC_1 = 480;

        public const int STR_SKILL_MAGUS_CLASS = 481;

        public const int STR_SKILL_MAGUS_DESC_1 = 482;

        public const int STR_SKILL_ARCHER_CLASS = 483;

        public const int STR_SKILL_ARCHER_DESC_1 = 484;

        public const int STR_SKILL_MARKSMAN_CLASS = 485;

        public const int STR_SKILL_MARKSMAN_DESC_1 = 486;

        public const int STR_SKILL_PIKEMAN_CLASS = 487;

        public const int STR_SKILL_PIKEMAN_DESC_1 = 488;

        public const int STR_SKILL_PIKEMAN_DESC_2 = 489;

        public const int STR_SKILL_PIKEMAN_DESC_3 = 490;

        public const int STR_SKILL_HEAVYARMOR_CLASS = 491;

        public const int STR_SKILL_HEAVYARMOR_DESC_1 = 492;

        public const int STR_SKILL_LIGHTARMOR_CLASS = 493;

        public const int STR_SKILL_LIGHTARMOR_DESC_1 = 494;

        public const int STR_SKILL_HEALPOT_CLASS = 495;

        public const int STR_SKILL_HEALPOT_DESC_1 = 496;

        public const int STR_SKILL_ENERGYPOT_CLASS = 497;

        public const int STR_SKILL_ENERGYPOT_DESC_1 = 498;

        public const int STR_SKILL_CLERIC_CLASS = 499;

        public const int STR_SKILL_CLERIC_DESC_1 = 500;

        public const int STR_SKILL_MAGIC_CLASS = 501;

        public const int STR_SKILL_MAGIC_DESC_1 = 502;

        public const int STR_SKILL_STAT_STR_CLASS = 503;

        public const int STR_SKILL_STAT_STR_DESC_1 = 504;

        public const int STR_SKILL_STAT_STR_DESC_2 = 505;

        public const int STR_SKILL_STAT_STR_DESC_3 = 506;

        public const int STR_SKILL_STAT_END_CLASS = 507;

        public const int STR_SKILL_STAT_END_DESC_1 = 508;

        public const int STR_SKILL_STAT_END_DESC_2 = 509;

        public const int STR_SKILL_STAT_END_DESC_3 = 510;

        public const int STR_SKILL_STAT_DEX_CLASS = 511;

        public const int STR_SKILL_STAT_DEX_DESC_1 = 512;

        public const int STR_SKILL_STAT_DEX_DESC_2 = 513;

        public const int STR_SKILL_STAT_DEX_DESC_3 = 514;

        public const int STR_SKILL_STAT_WILL_CLASS = 515;

        public const int STR_SKILL_STAT_WILL_DESC_1 = 516;

        public const int STR_SKILL_STAT_WILL_DESC_2 = 517;

        public const int STR_SKILL_STAT_WILL_DESC_3 = 518;

        public const int STR_SKILL_STAT_MAG_CLASS = 519;

        public const int STR_SKILL_STAT_MAG_DESC_1 = 520;

        public const int STR_SKILL_STAT_MAG_DESC_2 = 521;

        public const int STR_SKILL_STAT_MAG_DESC_3 = 522;

        public const int STR_SKILL_STAT_WIS_CLASS = 523;

        public const int STR_SKILL_STAT_WIS_DESC_1 = 524;

        public const int STR_SKILL_STAT_WIS_DESC_2 = 525;

        public const int STR_SKILL_STAT_WIS_DESC_3 = 526;

        public const int STR_RUNE_WORD_A = 527;

        public const int STR_RUNE_WORD_ABANDON = 528;

        public const int STR_RUNE_WORD_ACROSS = 529;

        public const int STR_RUNE_WORD_ADVANCE = 530;

        public const int STR_RUNE_WORD_AFRAID = 531;

        public const int STR_RUNE_WORD_AHEAD = 532;

        public const int STR_RUNE_WORD_ALLY = 533;

        public const int STR_RUNE_WORD_ALSO = 534;

        public const int STR_RUNE_WORD_AM = 535;

        public const int STR_RUNE_WORD_AMAZING = 536;

        public const int STR_RUNE_WORD_AN = 537;

        public const int STR_RUNE_WORD_ALL = 538;

        public const int STR_RUNE_WORD_ALONE = 539;

        public const int STR_RUNE_WORD_AMBUSH = 540;

        public const int STR_RUNE_WORD_AND = 541;

        public const int STR_RUNE_WORD_APPROACH = 542;

        public const int STR_RUNE_WORD_ARCANE = 543;

        public const int STR_RUNE_WORD_ARCHER = 544;

        public const int STR_RUNE_WORD_ARCHERY = 545;

        public const int STR_RUNE_WORD_ARE = 546;

        public const int STR_RUNE_WORD_ARMOR = 547;

        public const int STR_RUNE_WORD_ARROWS = 548;

        public const int STR_RUNE_WORD_ART = 549;

        public const int STR_RUNE_WORD_ATTACK = 550;

        public const int STR_RUNE_WORD_ATTACKS = 551;

        public const int STR_RUNE_WORD_AWAITS = 552;

        public const int STR_RUNE_WORD_AWAY = 553;

        public const int STR_RUNE_WORD_BACK = 554;

        public const int STR_RUNE_WORD_BAG = 555;

        public const int STR_RUNE_WORD_BE = 556;

        public const int STR_RUNE_WORD_BEACH = 557;

        public const int STR_RUNE_WORD_BEING = 558;

        public const int STR_RUNE_WORD_BELOW = 559;

        public const int STR_RUNE_WORD_BEWARE = 560;

        public const int STR_RUNE_WORD_BIRDS = 561;

        public const int STR_RUNE_WORD_BLACKSMITH = 562;

        public const int STR_RUNE_WORD_BLEED = 563;

        public const int STR_RUNE_WORD_BLEEDING = 564;

        public const int STR_RUNE_WORD_BLESSINGS = 565;

        public const int STR_RUNE_WORD_BLOOD = 566;

        public const int STR_RUNE_WORD_BODY = 567;

        public const int STR_RUNE_WORD_BOOTS = 568;

        public const int STR_RUNE_WORD_BOTHER = 569;

        public const int STR_RUNE_WORD_BOW = 570;

        public const int STR_RUNE_WORD_BOUND = 571;

        public const int STR_RUNE_WORD_BRAND = 572;

        public const int STR_RUNE_WORD_BRING = 573;

        public const int STR_RUNE_WORD_BUCKLER = 574;

        public const int STR_RUNE_WORD_BUNDLE = 575;

        public const int STR_RUNE_WORD_CAN = 576;

        public const int STR_RUNE_WORD_CARELESS = 577;

        public const int STR_RUNE_WORD_CARELESSNESS = 578;

        public const int STR_RUNE_WORD_CASTLE = 579;

        public const int STR_RUNE_WORD_CAUTION = 580;

        public const int STR_RUNE_WORD_CELESTIAL = 581;

        public const int STR_RUNE_WORD_CHECK = 582;

        public const int STR_RUNE_WORD_CHEST = 583;

        public const int STR_RUNE_WORD_CLERIC = 584;

        public const int STR_RUNE_WORD_CRAZY = 585;

        public const int STR_RUNE_WORD_CREATURES = 586;

        public const int STR_RUNE_WORD_CRUSHING = 587;

        public const int STR_RUNE_WORD_DAMAGE = 588;

        public const int STR_RUNE_WORD_DARK = 589;

        public const int STR_RUNE_WORD_DARKNESS = 590;

        public const int STR_RUNE_WORD_DEAD = 591;

        public const int STR_RUNE_WORD_DEADLY = 592;

        public const int STR_RUNE_WORD_DEATH = 593;

        public const int STR_RUNE_WORD_DESPAIR = 594;

        public const int STR_RUNE_WORD_DESIRE = 595;

        public const int STR_RUNE_WORD_DEVARA = 596;

        public const int STR_RUNE_WORD_DO = 597;

        public const int STR_RUNE_WORD_DODGE = 598;

        public const int STR_RUNE_WORD_DODGING = 599;

        public const int STR_RUNE_WORD_DONT = 600;

        public const int STR_RUNE_WORD_DOOR = 601;

        public const int STR_RUNE_WORD_DOOM = 602;

        public const int STR_RUNE_WORD_DOUBT = 603;

        public const int STR_RUNE_WORD_DOWN = 604;

        public const int STR_RUNE_WORD_DREAD = 605;

        public const int STR_RUNE_WORD_DROP = 606;

        public const int STR_RUNE_WORD_DROWNED = 607;

        public const int STR_RUNE_WORD_EGG = 608;

        public const int STR_RUNE_WORD_ELEMENT = 609;

        public const int STR_RUNE_WORD_ELEMENTAL = 610;

        public const int STR_RUNE_WORD_EPIC = 611;

        public const int STR_RUNE_WORD_END = 612;

        public const int STR_RUNE_WORD_ENTER = 613;

        public const int STR_RUNE_WORD_EQUIP = 614;

        public const int STR_RUNE_WORD_EQUIPMENT = 615;

        public const int STR_RUNE_WORD_EVERYTHING = 616;

        public const int STR_RUNE_WORD_EVADE = 617;

        public const int STR_RUNE_WORD_EVADING = 618;

        public const int STR_RUNE_WORD_EVERYBODY = 619;

        public const int STR_RUNE_WORD_EXAMINE = 620;

        public const int STR_RUNE_WORD_EXIT = 621;

        public const int STR_RUNE_WORD_EXPECT = 622;

        public const int STR_RUNE_WORD_FALL = 623;

        public const int STR_RUNE_WORD_FAMILY = 624;

        public const int STR_RUNE_WORD_FAR = 625;

        public const int STR_RUNE_WORD_FEAR = 626;

        public const int STR_RUNE_WORD_FIND = 627;

        public const int STR_RUNE_WORD_FLAME = 628;

        public const int STR_RUNE_WORD_FLYING = 629;

        public const int STR_RUNE_WORD_FOOL = 630;

        public const int STR_RUNE_WORD_FOR = 631;

        public const int STR_RUNE_WORD_FOREST = 632;

        public const int STR_RUNE_WORD_FOUR = 633;

        public const int STR_RUNE_WORD_FRIEND = 634;

        public const int STR_RUNE_WORD_FRIENDLY = 635;

        public const int STR_RUNE_WORD_FUN = 636;

        public const int STR_RUNE_WORD_GAUNTLETS = 637;

        public const int STR_RUNE_WORD_GET = 638;

        public const int STR_RUNE_WORD_GIANT = 639;

        public const int STR_RUNE_WORD_GLOVES = 640;

        public const int STR_RUNE_WORD_GO = 641;

        public const int STR_RUNE_WORD_GOD = 642;

        public const int STR_RUNE_WORD_GODDESS = 643;

        public const int STR_RUNE_WORD_GODS = 644;

        public const int STR_RUNE_WORD_GODSPEED = 645;

        public const int STR_RUNE_WORD_GOOD = 646;

        public const int STR_RUNE_WORD_GORE = 647;

        public const int STR_RUNE_WORD_GREAT = 648;

        public const int STR_RUNE_WORD_GREATAXE = 649;

        public const int STR_RUNE_WORD_GREATHAMMER = 650;

        public const int STR_RUNE_WORD_GREATSWORD = 651;

        public const int STR_RUNE_WORD_GREAVES = 652;

        public const int STR_RUNE_WORD_GUARDIAN = 653;

        public const int STR_RUNE_WORD_HALBERD = 654;

        public const int STR_RUNE_WORD_HAMMER = 655;

        public const int STR_RUNE_WORD_HAUNT = 656;

        public const int STR_RUNE_WORD_HAUNTED = 657;

        public const int STR_RUNE_WORD_HAUNTING = 658;

        public const int STR_RUNE_WORD_HAVE = 659;

        public const int STR_RUNE_WORD_HEAD = 660;

        public const int STR_RUNE_WORD_HEART = 661;

        public const int STR_RUNE_WORD_HEATER = 662;

        public const int STR_RUNE_WORD_HELM = 663;

        public const int STR_RUNE_WORD_HELP = 664;

        public const int STR_RUNE_WORD_HERE = 665;

        public const int STR_RUNE_WORD_HOLE = 666;

        public const int STR_RUNE_WORD_HOLY = 667;

        public const int STR_RUNE_WORD_HONOR = 668;

        public const int STR_RUNE_WORD_HOOK = 669;

        public const int STR_RUNE_WORD_HOPE = 670;

        public const int STR_RUNE_WORD_HOPED = 671;

        public const int STR_RUNE_WORD_HOPEFUL = 672;

        public const int STR_RUNE_WORD_HOPING = 673;

        public const int STR_RUNE_WORD_HOW = 674;

        public const int STR_RUNE_WORD_HORDE = 675;

        public const int STR_RUNE_WORD_HUGE = 676;

        public const int STR_RUNE_WORD_HUMILITY = 677;

        public const int STR_RUNE_WORD_HUNT = 678;

        public const int STR_RUNE_WORD_HUNTED = 679;

        public const int STR_RUNE_WORD_HUNTER = 680;

        public const int STR_RUNE_WORD_HURT = 681;

        public const int STR_RUNE_WORD_HURTING = 682;

        public const int STR_RUNE_WORD_I = 683;

        public const int STR_RUNE_WORD_ICON = 684;

        public const int STR_RUNE_WORD_IDOL = 685;

        public const int STR_RUNE_WORD_IF = 686;

        public const int STR_RUNE_WORD_IGNORE = 687;

        public const int STR_RUNE_WORD_IMPOSSIBLE = 688;

        public const int STR_RUNE_WORD_IN = 689;

        public const int STR_RUNE_WORD_INSIDE = 690;

        public const int STR_RUNE_WORD_INTO = 691;

        public const int STR_RUNE_WORD_INCANTATION = 692;

        public const int STR_RUNE_WORD_INSANE = 693;

        public const int STR_RUNE_WORD_INSANITY = 694;

        public const int STR_RUNE_WORD_IS = 695;

        public const int STR_RUNE_WORD_IT = 696;

        public const int STR_RUNE_WORD_ITEM = 697;

        public const int STR_RUNE_WORD_ITS = 698;

        public const int STR_RUNE_WORD_JESTER = 699;

        public const int STR_RUNE_WORD_JUMP = 700;

        public const int STR_RUNE_WORD_JUST = 701;

        public const int STR_RUNE_WORD_KEEP = 702;

        public const int STR_RUNE_WORD_KEY = 703;

        public const int STR_RUNE_WORD_KILL = 704;

        public const int STR_RUNE_WORD_KILLING = 705;

        public const int STR_RUNE_WORD_KNIGHT = 706;

        public const int STR_RUNE_WORD_KNOW = 707;

        public const int STR_RUNE_WORD_KRAEKAN = 708;

        public const int STR_RUNE_WORD_LADDER = 709;

        public const int STR_RUNE_WORD_LEFT = 710;

        public const int STR_RUNE_WORD_LET = 711;

        public const int STR_RUNE_WORD_LIGHT = 712;

        public const int STR_RUNE_WORD_LIGHTNING = 713;

        public const int STR_RUNE_WORD_LIKE = 714;

        public const int STR_RUNE_WORD_LISTEN = 715;

        public const int STR_RUNE_WORD_LOOK = 716;

        public const int STR_RUNE_WORD_LOOKS = 717;

        public const int STR_RUNE_WORD_LOOT = 718;

        public const int STR_RUNE_WORD_LOST = 719;

        public const int STR_RUNE_WORD_LOVE = 720;

        public const int STR_RUNE_WORD_LUCK = 721;

        public const int STR_RUNE_WORD_MACE = 722;

        public const int STR_RUNE_WORD_MAGE = 723;

        public const int STR_RUNE_WORD_MAGIC = 724;

        public const int STR_RUNE_WORD_MAGICAL = 725;

        public const int STR_RUNE_WORD_MAIM = 726;

        public const int STR_RUNE_WORD_MAIN = 727;

        public const int STR_RUNE_WORD_MAN = 728;

        public const int STR_RUNE_WORD_MANY = 729;

        public const int STR_RUNE_WORD_MATERIALS = 730;

        public const int STR_RUNE_WORD_ME = 731;

        public const int STR_RUNE_WORD_MEET = 732;

        public const int STR_RUNE_WORD_MELEE = 733;

        public const int STR_RUNE_WORD_MERCHANT = 734;

        public const int STR_RUNE_WORD_MESSAGE = 735;

        public const int STR_RUNE_WORD_MIRE = 736;

        public const int STR_RUNE_WORD_MONSTER = 737;

        public const int STR_RUNE_WORD_MOON = 738;

        public const int STR_RUNE_WORD_MUST = 739;

        public const int STR_RUNE_WORD_MY = 740;

        public const int STR_RUNE_WORD_NATURAL = 741;

        public const int STR_RUNE_WORD_NEAR = 742;

        public const int STR_RUNE_WORD_NEED = 743;

        public const int STR_RUNE_WORD_NEVER = 744;

        public const int STR_RUNE_WORD_NIGH = 745;

        public const int STR_RUNE_WORD_NIGHT = 746;

        public const int STR_RUNE_WORD_NO = 747;

        public const int STR_RUNE_WORD_NOT = 748;

        public const int STR_RUNE_WORD_NOW = 749;

        public const int STR_RUNE_WORD_OF = 750;

        public const int STR_RUNE_WORD_OFF = 751;

        public const int STR_RUNE_WORD_OH = 752;

        public const int STR_RUNE_WORD_OLD = 753;

        public const int STR_RUNE_WORD_ONE = 754;

        public const int STR_RUNE_WORD_ONWARD = 755;

        public const int STR_RUNE_WORD_OR = 756;

        public const int STR_RUNE_WORD_ORB = 757;

        public const int STR_RUNE_WORD_ORDER = 758;

        public const int STR_RUNE_WORD_OTHER = 759;

        public const int STR_RUNE_WORD_OUR = 760;

        public const int STR_RUNE_WORD_OUT = 761;

        public const int STR_RUNE_WORD_OUTSIDE = 762;

        public const int STR_RUNE_WORD_OVER = 763;

        public const int STR_RUNE_WORD_PAIN = 764;

        public const int STR_RUNE_WORD_PALADIN = 765;

        public const int STR_RUNE_WORD_PHYSICAL = 766;

        public const int STR_RUNE_WORD_PIT = 767;

        public const int STR_RUNE_WORD_PLACE = 768;

        public const int STR_RUNE_WORD_POISON = 769;

        public const int STR_RUNE_WORD_POTION = 770;

        public const int STR_RUNE_WORD_PRAISE = 771;

        public const int STR_RUNE_WORD_PRAISED = 772;

        public const int STR_RUNE_WORD_PRAY = 773;

        public const int STR_RUNE_WORD_PRAYER = 774;

        public const int STR_RUNE_WORD_PRIDE = 775;

        public const int STR_RUNE_WORD_PRIEST = 776;

        public const int STR_RUNE_WORD_PROCEED = 777;

        public const int STR_RUNE_WORD_PROTECT = 778;

        public const int STR_RUNE_WORD_QUEST = 779;

        public const int STR_RUNE_WORD_QUIT = 780;

        public const int STR_RUNE_WORD_QUITTING = 781;

        public const int STR_RUNE_WORD_RANGED = 782;

        public const int STR_RUNE_WORD_RARE = 783;

        public const int STR_RUNE_WORD_REMEMBER = 784;

        public const int STR_RUNE_WORD_REQUIRED = 785;

        public const int STR_RUNE_WORD_RETREAT = 786;

        public const int STR_RUNE_WORD_RIGHT = 787;

        public const int STR_RUNE_WORD_RING = 788;

        public const int STR_RUNE_WORD_ROLL = 789;

        public const int STR_RUNE_WORD_ROLLING = 790;

        public const int STR_RUNE_WORD_RUN = 791;

        public const int STR_RUNE_WORD_RUNE = 792;

        public const int STR_RUNE_WORD_RUNNING = 793;

        public const int STR_RUNE_WORD_SACRIFICE = 794;

        public const int STR_RUNE_WORD_SAD = 795;

        public const int STR_RUNE_WORD_SADNESS = 796;

        public const int STR_RUNE_WORD_SAFE = 797;

        public const int STR_RUNE_WORD_SALT = 798;

        public const int STR_RUNE_WORD_SANCTUARY = 799;

        public const int STR_RUNE_WORD_SCARS = 800;

        public const int STR_RUNE_WORD_SCARED = 801;

        public const int STR_RUNE_WORD_SCARY = 802;

        public const int STR_RUNE_WORD_SEARCH = 803;

        public const int STR_RUNE_WORD_SECRET = 804;

        public const int STR_RUNE_WORD_SERIOUS = 805;

        public const int STR_RUNE_WORD_SHIELD = 806;

        public const int STR_RUNE_WORD_SHIP = 807;

        public const int STR_RUNE_WORD_SHORTCUT = 808;

        public const int STR_RUNE_WORD_SHRINE = 809;

        public const int STR_RUNE_WORD_SIN = 810;

        public const int STR_RUNE_WORD_SKY = 811;

        public const int STR_RUNE_WORD_SLASH = 812;

        public const int STR_RUNE_WORD_SNEAK = 813;

        public const int STR_RUNE_WORD_SOLDIER = 814;

        public const int STR_RUNE_WORD_SOUL = 815;

        public const int STR_RUNE_WORD_SPARK = 816;

        public const int STR_RUNE_WORD_SPEAK = 817;

        public const int STR_RUNE_WORD_SPELL = 818;

        public const int STR_RUNE_WORD_SPIRIT = 819;

        public const int STR_RUNE_WORD_STAFF = 820;

        public const int STR_RUNE_WORD_STAIRS = 821;

        public const int STR_RUNE_WORD_STAR = 822;

        public const int STR_RUNE_WORD_STONE = 823;

        public const int STR_RUNE_WORD_SURPRISE = 824;

        public const int STR_RUNE_WORD_SURROUNDINGS = 825;

        public const int STR_RUNE_WORD_SWORD = 826;

        public const int STR_RUNE_WORD_TENDENCY = 827;

        public const int STR_RUNE_WORD_TERRAIN = 828;

        public const int STR_RUNE_WORD_TERRIFYING = 829;

        public const int STR_RUNE_WORD_THAT = 830;

        public const int STR_RUNE_WORD_THAN = 831;

        public const int STR_RUNE_WORD_THE = 832;

        public const int STR_RUNE_WORD_THEN = 833;

        public const int STR_RUNE_WORD_THERE = 834;

        public const int STR_RUNE_WORD_THESE = 835;

        public const int STR_RUNE_WORD_THEY = 836;

        public const int STR_RUNE_WORD_THIEF = 837;

        public const int STR_RUNE_WORD_THING = 838;

        public const int STR_RUNE_WORD_THIS = 839;

        public const int STR_RUNE_WORD_THREE = 840;

        public const int STR_RUNE_WORD_THROUGH = 841;

        public const int STR_RUNE_WORD_THY = 842;

        public const int STR_RUNE_WORD_TO = 843;

        public const int STR_RUNE_WORD_TOO = 844;

        public const int STR_RUNE_WORD_TOXIC = 845;

        public const int STR_RUNE_WORD_TORTURE = 846;

        public const int STR_RUNE_WORD_TOWER = 847;

        public const int STR_RUNE_WORD_TRAP = 848;

        public const int STR_RUNE_WORD_TRAPPED = 849;

        public const int STR_RUNE_WORD_TREASURE = 850;

        public const int STR_RUNE_WORD_TROLL = 851;

        public const int STR_RUNE_WORD_TRUST = 852;

        public const int STR_RUNE_WORD_TRY = 853;

        public const int STR_RUNE_WORD_TRYING = 854;

        public const int STR_RUNE_WORD_TUNNEL = 855;

        public const int STR_RUNE_WORD_TWO = 856;

        public const int STR_RUNE_WORD_UNDEAD = 857;

        public const int STR_RUNE_WORD_UNDER = 858;

        public const int STR_RUNE_WORD_UNDERSIGHT = 859;

        public const int STR_RUNE_WORD_UP = 860;

        public const int STR_RUNE_WORD_US = 861;

        public const int STR_RUNE_WORD_USE = 862;

        public const int STR_RUNE_WORD_USING = 863;

        public const int STR_RUNE_WORD_VERY = 864;

        public const int STR_RUNE_WORD_VILLAGE = 865;

        public const int STR_RUNE_WORD_VILLAIN = 866;

        public const int STR_RUNE_WORD_VOID = 867;

        public const int STR_RUNE_WORD_WARNING = 868;

        public const int STR_RUNE_WORD_WAY = 869;

        public const int STR_RUNE_WORD_WE = 870;

        public const int STR_RUNE_WORD_WEAK = 871;

        public const int STR_RUNE_WORD_WELCOME = 872;

        public const int STR_RUNE_WORD_WERE = 873;

        public const int STR_RUNE_WORD_WHEN = 874;

        public const int STR_RUNE_WORD_WHERE = 875;

        public const int STR_RUNE_WORD_WHIP = 876;

        public const int STR_RUNE_WORD_WILL = 877;

        public const int STR_RUNE_WORD_WILLING = 878;

        public const int STR_RUNE_WORD_WISH = 879;

        public const int STR_RUNE_WORD_WISHING = 880;

        public const int STR_RUNE_WORD_WISTFUL = 881;

        public const int STR_RUNE_WORD_WITH = 882;

        public const int STR_RUNE_WORD_WOMAN = 883;

        public const int STR_RUNE_WORD_WONDER = 884;

        public const int STR_RUNE_WORD_WONDERFUL = 885;

        public const int STR_RUNE_WORD_WORTHLESS = 886;

        public const int STR_RUNE_WORD_WOUND = 887;

        public const int STR_RUNE_WORD_WOUNDING = 888;

        public const int STR_RUNE_WORD_WRAITH = 889;

        public const int STR_RUNE_WORD_WRECKED = 890;

        public const int STR_RUNE_WORD_X = 891;

        public const int STR_RUNE_WORD_YEARN = 892;

        public const int STR_RUNE_WORD_YES = 893;

        public const int STR_RUNE_WORD_YIELD = 894;

        public const int STR_RUNE_WORD_YOU = 895;

        public const int STR_RUNE_WORD_YOUR = 896;

        public const int STR_RUNE_WORD_ZOO = 897;

        public const int STR_RUNE_WORD_ZEN = 898;

        public const int STR_RUNE_WORD_ZIGGURAT = 899;

        public const int STR_CTRL_MOVE = 900;

        public const int STR_CTRL_SELECT_ITEM = 901;

        public const int STR_CTRL_USE_TORCH = 902;

        public const int STR_CTRL_ATTACK = 903;

        public const int STR_CTRL_STRONG_ATTACK = 904;

        public const int STR_CTRL_USE = 905;

        public const int STR_CTRL_JUMP = 906;

        public const int STR_CTRL_LOOK = 907;

        public const int STR_CTRL_BLOCKOFFHAND = 908;

        public const int STR_CTRL_SWITCHLOADOUT = 909;

        public const int STR_CTRL_ROLL = 910;

        public const int STR_CTRL_USE_ITEM = 911;

        public const int STR_CTRL_INVENTORY = 912;

        public const int STR_GAMEPAD_ICONS = 913;

        public const int STR_TRP_SALTBORN = 914;

        public const int STR_TRP_THE_BANQUET = 915;

        public const int STR_TRP_THE_VILLAGE = 916;

        public const int STR_TRP_THE_KEEP = 917;

        public const int STR_TRP_THE_FOREST = 918;

        public const int STR_TRP_THE_IMPOSTER = 919;

        public const int STR_TRP_THE_CASTLE = 920;

        public const int STR_TRP_THE_RED_HALL = 921;

        public const int STR_TRP_THE_CAVE = 922;

        public const int STR_TRP_THE_MIRE = 923;

        public const int STR_TRP_THE_DOME = 924;

        public const int STR_TRP_THE_SACRIFICE = 925;

        public const int STR_TRP_THE_ZIGGURAT = 926;

        public const int STR_TRP_THE_CONSTRUCT = 927;

        public const int STR_TRP_THE_RUINS = 928;

        public const int STR_TRP_THE_PITCHWOODS = 929;

        public const int STR_TRP_THE_LAKE = 930;

        public const int STR_TRP_THE_ALKYMANCERY = 931;

        public const int STR_TRP_THE_CRYPT = 932;

        public const int STR_TRP_THE_PALACE = 933;

        public const int STR_TRP_FIND_SANCTUARY = 934;

        public const int STR_TRP_FIND_SALVATION = 935;

        public const int STR_TRP_THE_UNSPEAKABLE_DEEP = 936;

        public const int STR_TRP_COASTROCK = 937;

        public const int STR_TRP_WISE_WORDS = 938;

        public const int STR_TRP_FADING_FAST = 939;

        public const int STR_TRP_BRANDED = 940;

        public const int STR_TRP_STORIED = 941;

        public const int STR_TRP_THE_THREE = 942;

        public const int STR_TRP_DEVARAS_LIGHT = 943;

        public const int STR_TRP_THE_IRON_ONES = 944;

        public const int STR_TRP_THE_STONE_ROOTS = 945;

        public const int STR_TRP_KEEPERS_OF_FIRE = 946;

        public const int STR_TRP_HOUSE_OF_SPLENDOR = 947;

        public const int STR_TRP_ORDER_OF_BETRAYER = 948;

        public const int STR_TRP_DEVOTED = 949;

        public const int STR_TRP_HONED = 950;

        public const int STR_TRP_SALTBORN_DESC = 951;

        public const int STR_TRP_THE_BANQUET_DESC = 952;

        public const int STR_TRP_THE_VILLAGE_DESC = 953;

        public const int STR_TRP_THE_KEEP_DESC = 954;

        public const int STR_TRP_THE_FOREST_DESC = 955;

        public const int STR_TRP_THE_IMPOSTER_DESC = 956;

        public const int STR_TRP_THE_CASTLE_DESC = 957;

        public const int STR_TRP_THE_RED_HALL_DESC = 958;

        public const int STR_TRP_THE_CAVE_DESC = 959;

        public const int STR_TRP_THE_MIRE_DESC = 960;

        public const int STR_TRP_THE_DOME_DESC = 961;

        public const int STR_TRP_THE_SACRIFICE_DESC = 962;

        public const int STR_TRP_THE_ZIGGURAT_DESC = 963;

        public const int STR_TRP_THE_CONSTRUCT_DESC = 964;

        public const int STR_TRP_THE_RUINS_DESC = 965;

        public const int STR_TRP_THE_PITCHWOODS_DESC = 966;

        public const int STR_TRP_THE_LAKE_DESC = 967;

        public const int STR_TRP_THE_ALKYMANCERY_DESC = 968;

        public const int STR_TRP_THE_CRYPT_DESC = 969;

        public const int STR_TRP_THE_PALACE_DESC = 970;

        public const int STR_TRP_FIND_SANCTUARY_DESC = 971;

        public const int STR_TRP_FIND_SALVATION_DESC = 972;

        public const int STR_TRP_THE_UNSPEAKABLE_DEEP_DESC = 973;

        public const int STR_TRP_COASTROCK_DESC = 974;

        public const int STR_TRP_WISE_WORDS_DESC = 975;

        public const int STR_TRP_FADING_FAST_DESC = 976;

        public const int STR_TRP_BRANDED_DESC = 977;

        public const int STR_TRP_STORIED_DESC = 978;

        public const int STR_TRP_THE_THREE_DESC = 979;

        public const int STR_TRP_DEVARAS_LIGHT_DESC = 980;

        public const int STR_TRP_THE_IRON_ONES_DESC = 981;

        public const int STR_TRP_THE_STONE_ROOTS_DESC = 982;

        public const int STR_TRP_KEEPERS_OF_FIRE_DESC = 983;

        public const int STR_TRP_HOUSE_OF_SPLENDOR_DESC = 984;

        public const int STR_TRP_ORDER_OF_BETRAYER_DESC = 985;

        public const int STR_TRP_DEVOTED_DESC = 986;

        public const int STR_TRP_HONED_DESC = 987;

        public const int STR_ERR_STORE_MAYBE_CORRUPT = 988;

        public const int STR_ERR_STORE_BAD_MOUNT = 989;

        public const int STR_ERR_STORE_CORRUPT = 990;

        public const int STR_ERR_STORE_NO_SPACE = 991;

        public const int STR_ERR_STORE_OUT_OF_MEMORY = 992;

        public const int STR_ERR_STORE_USER_NOT_INITED = 993;

        public const int STR_ERR_STORAGE = 994;

        public const int STR_ORIGIN_GULCHMIRE = 995;

        public const int STR_ORIGIN_JINDEREN = 996;

        public const int STR_MSG_ILLEGAL_NAME = 997;

        public const int STR_MSG_ILLEGAL_NAME_MSG = 998;

        public const int STR_MSG_ILLEGAL_NAME_MSG_C = 999;

        public const int STR_MSG_ILLEGAL_NAME_SHORT = 1000;

        public const int STR_AREA_ASHEN_SHORE = 1001;

        public const int STR_AREA_FORSAKEN_VILLAGE = 1002;

        public const int STR_AREA_BANDITS_PASS = 1003;

        public const int STR_AREA_CASTLE_OF_STORMS = 1004;

        public const int STR_AREA_SUNKEN_KEEP = 1005;

        public const int STR_AREA_RED_DUNGEON = 1006;

        public const int STR_AREA_LOST_WOODS = 1007;

        public const int STR_AREA_CAVES = 1008;

        public const int STR_AREA_SWAMP = 1009;

        public const int STR_AREA_DOME = 1010;

        public const int STR_AREA_SKY_CASTLE = 1011;

        public const int STR_AREA_DUNGEON_CAVE = 1012;

        public const int STR_AREA_FAR_BEACH = 1013;

        public const int STR_AREA_COASTAL_FORT = 1014;

        public const int STR_AREA_SIAM_LAKE = 1015;

        public const int STR_AREA_DARKWOOD = 1016;

        public const int STR_AREA_ZIGGURAT = 1017;

        public const int STR_AREA_PARTY_FORT = 1018;

        public const int STR_AREA_RUINS = 1019;

        public const int STR_AREA_LAB = 1020;

        public const int STR_AREA_TOMB = 1021;

        public const int STR_AREA_PALACE = 1022;

        public const int STR_AREA_DARK_CREED = 1023;

        public const int STR_NO_AVAIL_CHARS = 1024;

        public const int STR_CANT_HIRE = 1025;

        public const int STR_COOP_PLAY_DISABLED = 1026;

        public const int STR_SELECTED_PROFILE_IN_USE = 1027;

        public const int STR_SELLSWORD_CANNOT_ALTER = 1028;

        public const int STR_PARTY_HAS_FALLEN = 1029;

        public const int STR_RISE_AGAIN_RECLAIM = 1030;

        public const int STR_YOUR_JOURNEY_ENDS_HERE = 1031;

        public const int STR_ALAS_YOU_SHALL_LOSE = 1032;

        public const int STR_HAS_STOLEN_SALT = 1033;

        public const int STR_RETURN_TO_THIS_LOCATION = 1034;

        public const int STR_YOU_HAVE_LOST_SALT = 1035;

        public const int STR_A_MYSTERIOUS_CLERIC = 1036;

        public const int STR_HAIR_SMOOTH_DREADS = 1037;

        public const int STR_SAVE_WARN_PC = 1038;

        public const int STR_BELL_COOP_END_RETURNED = 1039;

        public const int STR_THREE_POEM_GOOD = 1040;

        public const int STR_THREE_POEM_BAD = 1041;

        public const int STR_DEVARA_POEM_GOOD = 1042;

        public const int STR_DEVARA_POEM_BAD = 1043;

        public const int STR_IRON_ONES_POEM_GOOD = 1044;

        public const int STR_IRON_ONES_POEM_BAD = 1045;

        public const int STR_STONE_ROOTS_POEM_GOOD = 1046;

        public const int STR_STONE_ROOTS_POEM_BAD = 1047;

        public const int STR_FIRE_SKY_POEM_GOOD = 1048;

        public const int STR_FIRE_SKY_POEM_BAD = 1049;

        public const int STR_BETRAYER_POEM_GOOD = 1050;

        public const int STR_BETRAYER_POEM_BAD = 1051;

        public const int STR_SPLENDOR_POEM_GOOD = 1052;

        public const int STR_SPLENDOR_POEM_BAD = 1053;

        public const int STR_VIBRATION_ON = 1054;

        public const int STR_VIBRATION_OFF = 1055;

        public const int STR_ERR_UPDATE_REQD = 1056;

        public const int STR_ERR_UPDATE_REQD_MSG = 1057;

        public const int STR_ERR_NETWORK = 1058;

        public const int STR_ERR_NETWORK_MSG = 1059;

        public const int STR_TRP_DOMINION = 1060;

        public const int STR_TRP_DOMINION_DESC = 1061;

        public const int STR_LOCKED = 1062;

        public const int STR_USED_KEY = 1063;

        public const int STR_ERR_AGE_RESTRICTIONS = 1064;

        public const int STR_ERR_NETWORK_GENERIC = 1065;

        public const int STR_ERR_STORE_CORRUPT_NO_MAKE = 1066;

        public const int STR_HUD_SIZE = 1067;

        public const int STR_HUD_VIS = 1068;

        public const int STR_HUD_VIS_FULL = 1069;

        public const int STR_HUD_VIS_NO_TRIM = 1070;

        public const int STR_HUD_VIS_MINIMAL = 1071;

        public const int STR_HUD_VIS_OFF = 1072;

        public const int STR_DROP_ITEM = 1073;

        public const int STR_BORDERLESS = 1074;

        public const int STR_SANCTUARIES_WILL_ADD = 1075;

        public const int STR_MOUSE_DISABLED = 1076;

        public const int STR_MOUSE_ENABLED = 1077;

        public const int STR_KEY_LEFT = 1078;

        public const int STR_KEY_RIGHT = 1079;

        public const int STR_KEY_UP = 1080;

        public const int STR_KEY_DOWN = 1081;

        public const int STR_KEY_PREV_ITEM = 1082;

        public const int STR_KEY_NEXT_ITEM = 1083;

        public const int STR_KEY_LOOK_LEFT = 1084;

        public const int STR_KEY_LOOK_RIGHT = 1085;

        public const int STR_KEY_LOOK_UP = 1086;

        public const int STR_KEY_LOOK_DOWN = 1087;

        public const int STR_KEY_RESET_TO_DEFAULTS = 1088;

        public const int STR_INPUT_KEY_FOR = 1089;

        public const int STR_ESC_CANCEL = 1090;

        public const int STR_INVALID_KEY = 1091;

        public const int STR_INVALID_KEY_DESC = 1092;

        public const int STR_RESET_KEYS = 1093;

        public const int STR_KEY_ALREADY_MAPPED = 1094;

        public const int STR_TEXTURE_PACKS = 1095;

        public const int STR_REMAP_KEYS = 1096;

        public const int STR_READING_CONTENT = 1097;

        public const int STR_NO_AVAILABLE_CONTENT = 1098;

        public const int STR_UGC_ERROR = 1099;

        public const int STR_END_GAME_Q = 1100;

        public const int STR_VENTURE_FORTH_Q = 1101;

        public const int STR_REMOVE_SKILL_Q = 1102;

        public const int STR_PURCHASE_SKILL_Q = 1103;

        public const int STR_TURN_IN_Q = 1104;

        public const int STR_CONFIRM_GAMEPAD = 1105;

        public const int STR_CONFIRM_GAMEPAD_DESC = 1106;

        public const int STR_ASCEND_TO_LEVEL_2 = 1107;

        public const int STR_SAVE_WARN_VITA = 1108;

        public const int STR_CHINESE = 1109;

        public const int STR_KOREAN = 1110;

        public const int STR_RUSSIAN = 1111;

        public const int STR_POLISH = 1112;

        public const int STR_CHINESE_SIMPLIFIED = 1113;

        public const int STR_CHINESE_TRADITIONAL = 1114;

        public const int STR_BLOOD_ON = 1115;

        public const int STR_BLOOD_OFF = 1116;

        public const int STR_MENU_FRAMERATE = 1117;

        public const int STR_MENU_SCREENSHAKE = 1118;

        public const int STR_MENU_VSYNC = 1119;

        public const int STR_INVENTORY_SORT_ITEMS = 1120;

        public const int STR_INVENTORY_STRIKE_DAMAGE = 1121;

        public const int STR_INVENTORY_SLASH_DAMAGE = 1122;
    }
}
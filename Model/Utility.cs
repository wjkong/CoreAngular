namespace Konger.CoreAngular.Model
{
    public abstract class Utility
    {
        // Fields
        public static readonly string DEFAULT_SELECTION = "Select...";
        public static readonly int FIRST_TIME = 0;
        public static readonly int ONE_ROW_AFFECTED = 1;
        public static readonly string ABSENT_LINK = "#";
        public static readonly string NOTICE_INTERNAL_ERROR = "Sorry, the server encounters internal error. Please, come back laster.";
        public static readonly string NOTICE_INVALID_INPUT = "Please, correct your input according to the instruction.";
        public static readonly string SECURE_KEY_CONTROL = "hidSecureKey";
        public static readonly string JS_NEW_LINE = "\\r\\n";
    }

    public enum NRegexType
    {
        Email,
        Phone
    }

    public enum NCustomValidator
    {
        DMSSource
    }


    public enum NReasonError
    {
        [StringValue("Must be a valid date format. i.e. 01/15/2007")]
        Date_Field = 8,
        [StringValue("Must be a positive number, inclusive zero")]
        Decimal_Field = 7,
        [StringValue("Must be a valid email address. i.e. DMS@Curomax.com")]
        Email_Field = 9,
        [StringValue("You are not allowed to retrieve data from this application folder.")]
        Folder_Unautorhrized_Access = 15,
        [StringValue("Must be a positive whole number, inclusive zero")]
        Integer_Field = 6,
        [StringValue("Required attribute with data")]
        Mandatory_Attribute = 4,
        [StringValue("Required element with data")]
        Mandatory_Field = 3,
        [StringValue("Non-registered DMS provider. Please, register this DMS code with Curomax.")]
        Non_Registered_DMSCode = 14,
        [StringValue("Invalid password and username in XML file")]
        Password_UserID_NotMatched = 2,
        [StringValue("Invalid password, username or DMSCode.")]
        Password_UserName_NotMatched = 0x10,
        [StringValue("Must be a valid 10 digits phone number without any spaces or hypens. i.e. 7801234567")]
        Phone_Field = 10,
        [StringValue("Server error occured")]
        Server_Error = 11,
        [StringValue("Invalid pre-defined value")]
        Undefined_Element_Data = 5,
        [StringValue("Unknown attribute")]
        Unknown_Attribute_Name = 1,
        [StringValue("Unknown element")]
        Unknown_Element_Name = 0,
        [StringValue("Value cannot be greater than ")]
        Value_GreaterThan_Maximum = 13,
        [StringValue("Value cannot be less than ")]
        Value_LessThan_Minimum = 12
    }

    public enum NAction
    {
        VIEW,
        DELETE,
        EDIT,
        CANCLE
    }


    public enum NBranch
    {
        US,
        CN,
        FR
    }

    public enum NCountry
    {
        CANADA = 2,
        CHINA = 3,
        USA = 1
    }


    public enum NHostNames
    {
        InternalServerName,
        ExternalServerName
    }


    public enum NHttpMethod
    {
        POST,
        GET
    }

    public enum NLanguage
    {
        [StringValue("English")]
        en = 0,
        [StringValue("French")]
        fr = 2,
        [StringValue("Chinese")]
        zh = 1
    }


    public enum NLinkCategory
    {
        Admin,
        Blog,
        Sales,
        Job_Search
    }


    public enum NProvince
    {
        Ontario = 1
    }


    public enum NServerType
    {
        PRODUCTION,
        UAT,
        DEVELOPMENT,
        LOCALHOST
    }

    public enum NSortDirection
    {
        ASC,
        DESC
    }

    public enum NTypeError
    {
        NoError,
        Unknown_ElementOrAttribute,
        Invalid_Data,
        Invalid_PasswordAndUserID,
        Unknown_Error,
        Unauthorized_Access
    }

    public enum NRole
    {
        DEFAULT = 100,
        GUEST = 40,
        MEMBER = 30,
        PREMIUM_MEMBER = 20,
        SUPER_USER = 10,
        WEB_MASTER = 0
    }

    public enum NTaskCustomer
    {
        LoadByUsername,
        LoadByCustID,
        LoadBySessionID,
        LoadByEmail,
        LoadMenu
    }

    public enum NTaskLink
    {
        LoadAllTop,
        LoadAllByParent,
        LoadAllByRole,
        LoadAllBySessionID,
        LoadAllExternal,
        UpdateOneSequence
    }

    public enum NPriority
    {
        High = 3,
        Low = 1,
        Medium = 2
    }

    public enum NSearchEngineURL
    {
        [StringValue("http://submissions.ask.com/ping?sitemap=")]
        ASK = 3,
        [StringValue("http://www.google.com/webmasters/tools/ping?sitemap=")]
        GOOGLE = 0,
        [StringValue("http://api.moreover.com/ping?u=")]
        MSN = 2,
        [StringValue("http://search.yahooapis.com/SiteExplorerService/V1/ping?sitemap=")]
        YAHOO = 1
    }

    public enum NHtmlMetaType
    {
        Title,
        Keywords,
        Description
    }

    public enum NWeatherCondition
    {
        CLOUDY,
        SUNNY,
        SHOWERS,
        RAIN,
        FLOG,
        HAZE,
        MAINLY_SUNNY,
        MOSTLY_CLOUDY,
        PARTLY_CLOUDY,
        A_FEW_SHOWERS,
        A_FEW_CLOUDY,
        PERIODS_OF_RAIN,
        A_MIX_OF_SUN_AND_CLOUD,
        CHANCE_OF_SHOWERS,
        CLOUD_WITH_SUNNY_PERIODS,
        SHOWERS_THUNDERSTORM,
        SUNNY_WITH_CLOUDY_PERIODS,
        SHOWERS_OR_THUNDERSTORMS,
        LIGHT_RAINSHOWER
    }

    public enum NTabIndex
    {
        MCAD = 0,
        MCPD = 4,
        MCSD = 2
    }


}

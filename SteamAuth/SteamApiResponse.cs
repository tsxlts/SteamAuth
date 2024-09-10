
using Newtonsoft.Json;

namespace SteamAuth
{
    public class SteamApiResponse<T>
    {
        public ErrorCodes EResult { get; set; }

        [JsonProperty("response")]
        public T Response { get; set; }
    }
    public enum ErrorCodes
    {
        /// <summary>
        /// 
        /// </summary>
        Invalid = 0,

        /// <summary>
        /// 成功
        /// </summary>
        OK = 1,

        /// <summary>
        /// 失败
        /// </summary>
        Fail = 2,

        /// <summary>
        /// 参数错误
        /// </summary>
        InvalidParam = 8,

        /// <summary>
        /// 该交易报价处于无效状态
        /// </summary>
        InvalidState = 11,

        /// <summary>
        /// 访问被拒绝
        /// 您无法发送或接受此交易报价，因为您无法与其他用户进行交易，或者此交易中的一方无法发送或接收交易中的其中一项商品。可能的原因：
        /// 1、您不是其他用户的朋友，并且您没有提供交易令牌
        /// 2、提供的交易代币有误
        /// 3、您正尝试发送或接收您或其他用户无法交易的游戏物品（例如由于 VAC 禁令）
        /// 4、您正在尝试发送物品，而其他用户的该游戏库存已满
        /// </summary>
        AccessDenied = 15,

        /// <summary>
        /// Steam 社区网络服务器在发送/接受此交易报价时未收到交易报价服务器的及时回复
        /// 该操作有可能（并非不可能）确实成功
        /// </summary>
        Timeout = 16,

        /// <summary>
        /// 服务目前不可用
        /// </summary>
        ServiceUnavailable = 20,

        /// <summary>
        /// 未登录
        /// </summary>
        NotLoggedOn = 21,

        /// <summary>
        /// 发送此交易报价将使您超出您的限制。
        /// 您最多只能向单个收件人提供 5 个有效报价（包括需要确认的报价，但不包括托管的报价），
        /// 或者总共 30 个有效报价。
        /// 如果您接受交易报价，那么您的特定游戏库存可能已满。
        /// </summary>
        LimitExceeded = 25,

        /// <summary>
        /// 此响应代码表明此贸易报价中的一项或多项商品不存在于所请求的库存中
        /// </summary>
        Revoked = 26,

        /// <summary>
        /// 当接受交易报价时，此响应代码表明它已被接受
        /// </summary>
        AlreadyRedeemed = 28,

        /// <summary>
        /// 重复请求
        /// </summary>
        DuplicateRequest = 29,

        NoConnection = 3,
        InvalidPassword = 5,
        LoggedInElsewhere = 6,
        InvalidProtocolVer = 7,
        FileNotFound = 9,
        Busy = 10,
        InvalidName = 12,
        InvalidEmail = 13,
        DuplicateName = 14,
        Banned = 17,
        AccountNotFound = 18,
        InvalidSteamID = 19,
        Pending = 22,
        EncryptionFailure = 23,
        InsufficientPrivilege = 24,
        Expired = 27,
        AlreadyOwned = 30,
        IPNotFound = 31,
        PersistFailed = 32,
        LockingFailed = 33,
        LogonSessionReplaced = 34,
        ConnectFailed = 35,
        HandshakeFailed = 36,
        IOFailure = 37,
        RemoteDisconnect = 38,
        ShoppingCartNotFound = 39,
        Blocked = 40,
        Ignored = 41,
        NoMatch = 42,
        AccountDisabled = 43,
        ServiceReadOnly = 44,
        AccountNotFeatured = 45,
        AdministratorOK = 46,
        ContentVersion = 47,
        TryAnotherCM = 48,
        PasswordRequiredToKickSession = 49,
        AlreadyLoggedInElsewhere = 50,
        Suspended = 51,
        Cancelled = 52,
        DataCorruption = 53,
        DiskFull = 54,
        RemoteCallFailed = 55,
        PasswordUnset = 56,
        ExternalAccountUnlinked = 57,
        PSNTicketInvalid = 58,
        ExternalAccountAlreadyLinked = 59,
        RemoteFileConflict = 60,
        IllegalPassword = 61,
        SameAsPreviousValue = 62,
        AccountLogonDenied = 63,
        CannotUseOldPassword = 64,
        InvalidLoginAuthCode = 65,
        AccountLogonDeniedNoMail = 66,
        HardwareNotCapableOfIPT = 67,
        IPTInitError = 68,
        ParentalControlRestricted = 69,
        FacebookQueryError = 70,
        ExpiredLoginAuthCode = 71,
        IPLoginRestrictionFailed = 72,
        AccountLockedDown = 73,
        AccountLogonDeniedVerifiedEmailRequired = 74,
        NoMatchingURL = 75,
        BadResponse = 76,
        RequirePasswordReEntry = 77,
        ValueOutOfRange = 78,
        UnexpectedError = 79,
        Disabled = 80,
        InvalidCEGSubmission = 81,
        RestrictedDevice = 82,
        RegionLocked = 83,
        RateLimitExceeded = 84,
        AccountLoginDeniedNeedTwoFactor = 85,
        ItemDeleted = 86,
        AccountLoginDeniedThrottle = 87,
        TwoFactorCodeMismatch = 88,
        TwoFactorActivationCodeMismatch = 89,
        AccountAssociatedToMultiplePartners = 90,
        NotModified = 91,
        NoMobileDevice = 92,
        TimeNotSynced = 93,
        SMSCodeFailed = 94,
        AccountLimitExceeded = 95,
        AccountActivityLimitExceeded = 96,
        PhoneActivityLimitExceeded = 97,
        RefundToWallet = 98,
        EmailSendFailure = 99,
        NotSettled = 100,
        NeedCaptcha = 101,
        GSLTDenied = 102,
        GSOwnerDenied = 103,
        InvalidItemType = 104,
        IPBanned = 105,
        GSLTExpired = 106,
        InsufficientFunds = 107,
        TooManyPending = 108,
        NoSiteLicensesFound = 109,
        WGNetworkSendExceeded = 110,
        AccountNotFriends = 111,
        LimitedUserAccount = 112,
        CantRemoveItem = 113,
        AccountDeleted = 114,
        ExistingUserCancelledLicense = 115,
        CommunityCooldown = 116,
        NoLauncherSpecified = 117,
        MustAgreeToSSA = 118,
        LauncherMigrated = 119,
        SteamRealmMismatch = 120,
        InvalidSignature = 121,
        ParseFailure = 122,
        NoVerifiedPhone = 123,
        InsufficientBattery = 124,
        ChargerRequired = 125,
        CachedCredentialInvalid = 126,
        PhoneNumberIsVOIP = 127,
    }
}

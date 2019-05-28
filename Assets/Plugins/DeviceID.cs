using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
public class DeviceID{

    public static string Get() {
#if UNITY_ANDROID
        string aID = SystemInfo.deviceUniqueIdentifier;
        return Regex.Replace("ANDROID" + aID, "[ \\[ \\] \\^ \\-_*×――(^)$%~!/@#$…&%￥—+=<>《》!！??？:：•`·、。，；,.;\"‘’“”-]", "");

#elif UNITY_IPHONE
        string iID = SystemInfo.deviceUniqueIdentifier;
        return Regex.Replace("IOS" + iID, "[ \\[ \\] \\^ \\-_*×――(^)$%~!/@#$…&%￥—+=<>《》!！??？:：•`·、。，；,.;\"‘’“”-]", "");
#endif
        string oID = SystemInfo.deviceUniqueIdentifier;
        return Regex.Replace("OHTHER" + oID, "[ \\[ \\] \\^ \\-_*×――(^)$%~!/@#$…&%￥—+=<>《》!！??？:：•`·、。，；,.;\"‘’“”-]", "");
    }
}

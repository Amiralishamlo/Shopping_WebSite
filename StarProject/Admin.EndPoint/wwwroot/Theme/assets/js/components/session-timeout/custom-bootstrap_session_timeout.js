var SessionTimeout=function() {
    var e=function() {
        $.sessionTimeout( {
            title:"Session Timeout Notification",
            message:"جلسه شما در حال پایان است.",
            keepAliveUrl:"", 
            redirUrl:"auth_lockscreen.html", 
            logoutUrl:"auth_login.html", 
            warnAfter:6e3, 
            redirAfter:21e3, 
            ignoreUserActivity:!0, 
            countdownMessage:"تغییر مسیر در {timer}.",
            countdownBar: !0
        }
        )
    };
    return {
        init:function() {
            e()
        }
    }
}

();
jQuery(document).ready(function() {
    SessionTimeout.init()
}
);
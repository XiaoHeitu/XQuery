window.xquery = {
    dommaps: {},
    resetdommaps: function () {
        window.xquery.dommaps = {};
    },
    find: function (s, nguid, cguid) {
        var map = {};
        if (cguid == undefined) {
            map["E" + nguid] = $(s);
        }
        else {
            var context = window.xquery.dommaps["E" + cguid]
            map["E" + nguid] = $(s, context);
        }
        $.extend(window.xquery.dommaps, map);
        return nguid;
    },
    invoke: function (guid, f, ps) {
        var e = window.xquery.dommaps["E" + guid];

        var psstring = "";
        for (var i = 0; i < ps.length; i++) {
            if (typeof (ps[i]) === "string") {
                psstring = psstring + "\"" + ps[i] + "\",";
            }
            else {
                psstring = psstring + ps[i] + ",";
            }
        }
        if (psstring != "") {
            psstring = psstring.substr(0, psstring.length - 1);
        }
        var code = "e." + f + "(" + psstring + ")";
        return eval(code);
    }
}
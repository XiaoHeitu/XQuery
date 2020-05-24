window.xquery = {
    dommaps: {},
    get: function (s, guid) {
        var map = {};
        map["E" + guid] = $(s);
        $.extend(window.xquery.dommaps, map);
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
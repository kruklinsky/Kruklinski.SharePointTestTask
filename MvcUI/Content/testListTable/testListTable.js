var testListTable = (function () {
    function parse(json) {
        var result = new Array("");
        for (item in json.d.results) {
            result.push("<li>" + json.d.results[item].Title + ": " + json.d.results[item].Experience + "</li>");
        }
        return result.join("");
    };
    return {
        build: function (json) {
            var result = "<ol>" + parse(json) + "</ol>";
            return result;
        }
    }
})();

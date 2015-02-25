var index = index || {};
index.testListTable = (function () {
    function success(json) {
        var table = $("#testListTable");
        var error = $("#testListTableLoadError").empty();
        try {
            var jsonTree = JSON.parse(json);
            table.empty();
            table.append(testListTable.build(jsonTree));
        } catch (e) {
            console.log(e);
            error.append("<a>Cannot parse requested json.</a>");
        }
    };
    function error(jqXHR) {
        var _error = $("#testListTableLoadError").empty();
        _error.append("<a>" + jqXHR.statusText + ": " + jqXHR.status + "</a>");
    };
    return {
        load: function () {
            $("#testListTableLoadError").empty().append("<img src='../Content/testListTable/images/loading.GIF' />")
            $.ajax({
                url: "../Home/GetTestList",
                type: "POST",
                success: success,
                error: error
            })
        }
    }
})();

$(document).ready(function () {
    index.testListTable.load();
    $("#testListTableLoadButton").bind("click", index.testListTable.load);
});
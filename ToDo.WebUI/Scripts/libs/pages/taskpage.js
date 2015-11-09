//  A
(function () {
    console.log("[tasks-page] - test")

    var onIsDoneClick = function (e) {
        console.log("[taskpage]-checkboxClick", arguments);

        var ch = e.target;
        var isDone = ch.checked;
        var taskId = ch.getAttribute("data-task-id");
        console.log("[taskpage]-click : isDone = " + isDone);
        console.log("[taskpage]-click : taskId = " + taskId);

        $.ajax({
            url: "/ToDo/ChangeStatus",
            type: "POST",
            dataType: "text",
            data: {
                taskId: taskId,
                isDone: isDone
            }
        }).done(function () {
            console.log("[taskpage]-click : DONE ");

            //put a mark on implementation for one task
            if (isDone) {
                $("tr").eq(taskId).attr("class", "trYes");
            }
            else {
                $("tr").eq(taskId).attr("class", "trNo");
            }
            // -----------------------------------------
        }).fail(function () {
            console.log("[taskpage]-click : FAILED ");
        });

    };

    //  RK version
    var onIsSelect = function () {

        var select = $("#task-status-filter option:selected").val();

        //  not finished !!! here
        var $completed = $("tr.data-row").has('input[type="checkbox"]:checked');
        var inprogress = $("tr.data-row").;

        switch (select) {

            case 'all':
                $('tr').has('input[type="checkbox"]').show();
                break;

            case 'completed':
                var array = $('tr').not($('tr').has('input[type="checkbox"]:checked'));
                array.hide();
                break;

            case 'inprogress':
                $('tr').has('input[type="checkbox"]:checked').hide();
                break;

            default:
                break;
        }
    };

    var onIsSelect2 = function () {
        var status = $("#task-status-filter").val();

        $.ajax({
            type: "POST",
            dataType: "html",
            url: "/ToDo/TasksPartial/",
            data: {
                taskStatus: status
            }

        }).done(function (data) {
            $("tasks-table").html(data);
            console.log("[taskpage]-filter : DONE ");
            //  TODO: event handler for checkbox
            
        }).fail(function () {
            console.log("[taskpage]-filter : FAILED ");
        });

    };

    //  DONE
    var sel = function () {
        console.log("[tasks-page] - sel");

        //$("select").on("change", onIsSelect);
        //$("#task-status-filter").on("change", onIsSelect);
        $("#task-status-filter").on("change", onIsSelect2);

        console.log("[tasks-page] - click", arguments);
    };

    //  DONE
    var init = function () {
        console.log("[taskpage]-init");

        //select all checkbox in page
        $("input[type='checkbox']").on("click", onIsDoneClick);

        sel();

        //put a mark on implementation for all tasks
        $('tr').has('input[type="checkbox"]:checked').addClass("trYes");
    };

    //  DONE
    $(function () {
        //  main
        console.log("[taskpage]-main");
        init();
    });

    var onTaskStatusFilterChanged = function (e) {
        console.log("[tasks-page] onTaskStatusFilterChanged");
    };

})();


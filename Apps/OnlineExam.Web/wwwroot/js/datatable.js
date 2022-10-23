/* datetime- moment plugin for sorting date */
(function (factory) {
    if (typeof define === "function" && define.amd) {
        define(["jquery", "moment", "datatables.net"], factory);
    } else {
        factory(jQuery, moment);
    }
}(function ($, moment) {

    function strip(d) {
        if (typeof d === 'string') {
            // Strip HTML tags and newline characters if possible
            d = d.replace(/(<.*?>)|(\r?\n|\r)/g, '');

            // Strip out surrounding white space
            d = d.trim();
        }

        return d;
    }

    $.fn.dataTable.moment = function (format, locale, reverseEmpties) {
        var types = $.fn.dataTable.ext.type;

        // Add type detection
        types.detect.unshift(function (d) {
            d = strip(d);

            // Null and empty values are acceptable
            if (d === '' || d === null) {
                return 'moment-' + format;
            }

            return moment(d, format, locale, true).isValid() ?
                'moment-' + format :
                null;
        });

        // Add sorting method - use an integer for the sorting
        types.order['moment-' + format + '-pre'] = function (d) {
            d = strip(d);

            return !moment(d, format, locale, true).isValid() ?
                (reverseEmpties ? -Infinity : Infinity) :
                parseInt(moment(d, format, locale, true).format('x'), 10);
        };
    };

}));

/* Datatables.js implementation */
var Table = function (_id, _modelDesc, _customSettings) {
    if (_id == null || _modelDesc == null)
        return;

    var id = _id;
    var modelDesc = _modelDesc;
    var customSettings = _customSettings;

    var table = null;
    var headerTexts = [];
    var selectedRowNode = null;
    var selectedItem = null;
    var selectCallback = null;
    var columnClickCallback = null;

    var createHTML = function () {
        var tableNode = $("#" + id);

        /* create header HTML */
        tableNode.append($("<thead>"));
        var headerNode = tableNode.find('thead');
        headerNode.append($("<tr>"));
        headerNode = headerNode.find("tr");

        /* create body HTML*/
        tableNode.append($("<tbody>"));

        return headerNode;
    }

    var render = function (headerNode) {
        var settings = {
            columnDefs: [
                { visible: false, targets: [] }
            ],
            order: [],
            pageLength: 10,
            lengthMenu: [[10, 25, 50, -1], [10, 25, 50, "All"]],
            paging: true,
            ordering: true,
            info: true,
            filter: true,
            createdRow: null,
            rowCallback: null,
            scrollY: false,
            scrollX: true,
            dom: 'lBfrtip',
            deferRender: true,
            buttons: [ ]
        };

        /* create table headers */
        var editableColumnIndexList = [];
        var isThereEditableColumn = false;
        var i = 0;
        Object.keys(modelDesc).forEach(function (prop) {
            prop = modelDesc[prop]
            if (typeof prop != 'object')
                prop = { value: "" + prop, hidden: false, editable: false };

            headerNode.append($('<th>')
                .attr('id', id + '_header_' + i)
                .text(prop.value)
            );
            headerTexts.push(prop.value);

            if (prop.hidden) {
                $("#" + id + '_header_' + i).hide()
                settings.columnDefs[0].targets.push(i);
            }
            else if (prop.sort != undefined) {
                if (prop.sort == "desc") {
                    settings.order.push([i, "desc"]);
                }
            }

            if (prop.width != null) {
                settings.columnDefs.push({ "width": "" + prop.width, targets: i + 1 });
            }

            if (prop.editable) {
                isThereEditableColumn = true;
                editableColumnIndexList.push(i);
            }
            i++;
        });

        /* arrange table settings */
        if (customSettings != null) {
            Object.keys(settings).forEach(function (prop) {
                if (customSettings[prop] != null)
                    settings[prop] = customSettings[prop];
            });
        }

        /* datatables lib object  */
        table = $("#" + id).DataTable(settings);

        /* check editable columns */
        if (isThereEditableColumn) {
            $("#" + id + " tbody").on('dblclick', 'td', function () {
                var isEditable = false;
                for (var j = 0; j < editableColumnIndexList.length; j++) {
                    if (editableColumnIndexList[j] == this._DT_CellIndex.column) {
                        isEditable = true;
                        break;
                    }
                }

                if (isEditable) {
                    var obj = createObjFromData(table.row(this).data());
                    columnClickCallback(this._DT_CellIndex, headerTexts[this._DT_CellIndex.column], obj);
                }
            });
        }
    }

    var prepareItem = function (item) {
        var recordItemList = [];
        Object.keys(modelDesc).forEach(function (prop) {
            recordItemList.push(item[prop]);
        });

        return recordItemList;
    }

    var insertIter = function (list) {
        var arrayAll = [];
        for (var i = 0; i < list.length; i++) {
            var item = list[i];
            var recordItemList = prepareItem(item);
            arrayAll.push(recordItemList);
        }
        if (arrayAll.length > 0)
            table.rows.add(arrayAll).draw();
    }

    var createClickEvent = function () {
        $("#" + id + " tbody").on('click', 'tr', function () {
            selectedRowNode = this;
            selectedItem = table.row(this).data();

            if ($(this).hasClass('selected')) {
                $(this).removeClass('selected');
                selectedItem = null;
            }
            else {
                table.$('tr.selected').removeClass('selected');
                $(this).addClass('selected');

                if (selectCallback != null)
                    selectCallback();
            }
        });
    }

    var createObjFromData = function (data) {
        var result = {};
        var i = 0;

        Object.keys(modelDesc).forEach(function (prop) {
            result[prop] = data[i];
            i++
        });

        return result;
    }

    this.setColumnClickFunction = function (func) {
        columnClickCallback = func;
    }

    this.init = function () {
        var headerNode = createHTML();
        render(headerNode);

        createClickEvent();
    }

    this.selectByIndex = function (index) {
        $('#' + id + ' tbody tr:eq(' + index + ')').click();
    }

    this.loadList = function (list) {
        table.clear().draw(false);
        if (Array.isArray(list)) insertIter(list);
        else {
            var tmp = [];
            tmp.push(list);
            insertIter(tmp);
        }
    }
    this.clearTable = function () {
        table.clear().draw(false);
    }
    this.append = function (list) {
        if (!Array.isArray(list)) list = [list];
        insertIter(list);
    }

    this.getSelectedItem = function () {
        if (selectedItem == null) return null;
        return createObjFromData(selectedItem);
    }

    this.deleteSelection = function () {
        if (selectedItem == null) return;
        table.row(selectedRowNode).remove().draw(false);
    }

    this.updateSelection = function (model) {
        if (selectedItem == null) return;
        table.row(selectedRowNode).data(prepareItem(model)).draw(false);
    }

    this.updateByIndex = function (index, model) {
        table.row(index).data(prepareItem(model)).draw(false);
    }

    this.selectCallback = function (func) {
        selectCallback = func;
    }
};
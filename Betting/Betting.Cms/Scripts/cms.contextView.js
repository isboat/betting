(function() {
    'use strict';

    function renderNewTeam(data) {
        var html = window.cms.handlebars.getHtml("#team-tpl", data);

        $(".teamtable").append(html);
    }

    function createSelectOptions(dir) {
        
        var selectoptions = [
            { text: "Wins", val: 0, selected: dir === 0 },
            { text: "Lose", val: 1, selected: dir === 1 },
            { text: "Draws", val: 2,selected: dir === 2 }
        ];

        return selectoptions;
    }

    function renderNewSelection(data) {
        
        var html = window.cms.handlebars.getHtml("#sel-tpl", data);

        $(".seltable").append(html);
    }

    function renderTeams() {
        var list = [];

        $(".teams li").each(function () {
            list.push({
                name: $(this).data("name"),
                description: $(this).data("description"),
                id: $(this).data("id")
            });
        });
        
        window.cms.handlebars.render("#teams-tpl", { teams: list }, ".teamlist");

        window.cms.contextview.teamlist = list;
    }

    function renderSelections() {
        var list = [];

        $(".sels li").each(function () {
            var item = {
                label: $(this).data("label"),
                id: $(this).data("id"),
                firstnumm: $(this).data("firstnumm"),
                secondnum: $(this).data("secondnum")
            };
            list.push(item);
        });

        window.cms.handlebars.render("#sels-tpl", { selections: list }, ".selslist");

        window.cms.contextview.selslist = list;
    }

    function addNewTeam() {
        var newTeam = $("#newTeam").val();
        var newTeamDesc = $("#newTeamDesc").val();

        if (!newTeam || !newTeamDesc) {
            return;
        }

        window.cms.web.post({
            url: "/trading/AddTeam",
            data: { Name: newTeam, Description: newTeamDesc, Cid: window.cms.contextview.cid },
            success: function(data) {
                renderNewTeam(data);
            }
        });
    }

    function updateTeam(item, callbk) {
        window.cms.web.post({
            url: "/trading/UpdateTeam",
            data: {
                Id: item.id,
                Name: item.name,
                Description: item.description,
                Cid: window.cms.contextview.cid
            },
            success: function (data) {
                callbk(data);
            }
        });
    }

    function saveSelection(item, callbk) {
        window.cms.web.post({
            url: "/trading/UpdateSelection",
            data: {
                Id: item.id,
                Label: item.label,
                FirstNum: item.firstnum,
                SecondNum: item.secondnum,
                Cid: window.cms.contextview.cid
            },
            success: function (data) {
                callbk();
            }
        });
    }

    function deleteSelection(id, callbk) {
        window.cms.web.get({
            url: "/trading/DeleteSelection",
            data: { id: id },
            success: function (data) {
                callbk(data);
            }
        });
    }

    function addNewSel() {
        var newSel = $("#newSel").val();
        var newoddfirstnum = $("#newoddfirstnum").val();
        var newoddsecondnum = $("#newoddsecondnum").val();

        if (!newSel || !Number(newoddfirstnum) || !Number(newoddsecondnum)) {
            return;
        }

        var self = this;

        window.cms.web.post({
            url: "/trading/AddSelection",
            data: {
                Label: newSel,
                FirstNum: newoddfirstnum,
                SecondNum: newoddsecondnum,
                Cid: window.cms.contextview.cid
            },
            success: function (data) {
                data.firstnumm = newoddfirstnum;
                data.secondnum = newoddsecondnum;
                renderNewSelection(data);
            }
        });
    }

    window.cms.contextview = {
        addNewTeam: addNewTeam,
        renderTeams: renderTeams,
        addNewSel: addNewSel,
        saveSelection: saveSelection,
        renderSelections: renderSelections,
        deleteSelection: deleteSelection,
        updateTeam: updateTeam
    };
})();
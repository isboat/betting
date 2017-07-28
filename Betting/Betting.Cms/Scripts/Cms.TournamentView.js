(function() {
    'use strict';

    function renderNewCategory(data) {
        var html = window.cms.handlebars.getHtml("#cat-item-tpl", data);

        $(".cctable").append(html);
    }

    function renderCategories() {
        var list = [];

        $(".cclist li").each(function () {
            list.push({
                name: $(this).data("name"),
                id: $(this).data("id")
            });
        });

        window.cms.handlebars.render("#cats-tpl", { cats: list }, ".catlist");

        window.cms.tournamentview.catlist = list;
    }

    function addNewCategory() {
        var newName = $("#newName").val();
        if (!newName) {
            return;
        }

        var self = this;

        window.cms.web.post({
            url: "/trading/AddContextCategory",
            data: { Name: newName, TournamentId: window.cms.tournamentview.tid },
            success: function(id) {
                renderNewCategory(id);
            }
        });
    }

    function savecategory(item, callbk) {
        window.cms.web.post({
            url: "/trading/UpdateCategory",
            data: {
                Id: item.id,
                Name: item.name,
                TournamentId: window.cms.tournamentview.tid
            },
            success: function (data) {
                callbk();
            }
        });
    }

    window.cms.tournamentview = {
        addNewCategory: addNewCategory,
        renderCategories: renderCategories,
        savecategory: savecategory
    };
})();